using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using RechargeSharp.v2021_11.Configuration;
using RechargeSharp.v2021_11.Configuration.DependencyInjection;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.SharedModels.Errors;
using RechargeSharp.v2021_11.Utilities.Json;

namespace RechargeSharp.v2021_11.Utilities;

public interface IRechargeApiCaller
{
    Task<T> GetAsync<T>(string uri);

    /// <summary>
    ///     Sends a GET request to the API, but will just return null if the API responds with 404 Not Found
    /// </summary>
    Task<T?> GetNullableAsync<T>(string uri);
    Task<TResponse> PutAsync<TRequest, TResponse>(TRequest instance, string uri);
    Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, string uri);
    Task<TResponse> PostAsync<TResponse>(string uri);
    Task DeleteAsync(string uri);
}

public class RechargeApiCaller : IRechargeApiCaller
{
    private readonly ILogger<RechargeApiCaller> _logger;
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly IAsyncPolicy _asyncRetryPolicy;

    public RechargeApiCaller(IHttpClientFactory httpClientFactory, ILogger<RechargeApiCaller> logger,        IOptions<RechargeApiCallerOptions> rechargeApiCallerOptions)
    {
        _logger = logger;
        var resolvedRechargeApiCallerOptions = rechargeApiCallerOptions.Value;
        _httpClient = httpClientFactory.CreateClient(RechargeSharpDependencyInjection.RechargeSharpHttpClientKey);
        _httpClient.DefaultRequestHeaders.Add(RechargeConstants.Headers.Keys.ApiVersion, RechargeConstants.Headers.Values.Version2021_11);
        _httpClient.DefaultRequestHeaders.Add(RechargeConstants.Headers.Keys.ApiKey, resolvedRechargeApiCallerOptions.ApiKey);

        _jsonSerializerOptions = CreateJsonOptions();
        _asyncRetryPolicy = CreateRetryPolicy(resolvedRechargeApiCallerOptions.RetryCount);
    }

    private AsyncRetryPolicy CreateRetryPolicy(int retryCount)
    {
        var jitterer = new Random();
        return Policy
            .Handle<HttpRequestException>()
            .Or<RechargeApiException>(e => e.IsTransient is true or null)
            .WaitAndRetryAsync(
                retryCount,
                currentRetryNumber => TimeSpan.FromSeconds(currentRetryNumber) +
                                      TimeSpan.FromMilliseconds(jitterer.NextInt64(1000)),
                (exception, timeSpan, currentRetryNumber, context) =>
                {
                    _logger.LogError(exception,
                        "An error occurred while calling the Recharge API, retry number {RetryNumber} will be attempted in {TimeUntilRetry} - Polly correlation ID: {PollyCorrelationId}",
                        currentRetryNumber, timeSpan, context.CorrelationId);
                }
            );
    }

    private static JsonSerializerOptions CreateJsonOptions()
    {
        var jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
        };
        jsonSerializerOptions.Converters.Add(new ApiErrorJsonConverter());
        jsonSerializerOptions.Converters.Add(new DateOnlyNullableConverter());
        jsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        jsonSerializerOptions.Converters.Add(new DecimalConverter());
        jsonSerializerOptions.Converters.Add(new DecimalNullableConverter());
        return jsonSerializerOptions;
    }

    public async Task<T> GetAsync<T>(string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        var responseContent = await SendRequest(requestFactory);
        var responseContentsStream = await responseContent.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<T>(responseContentsStream);
        return responseJson;
    }

    public async Task<T?> GetNullableAsync<T>(string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        var (httpContent, apiError) = await SendRequestWithManualErrorHandling(requestFactory);

        if (apiError?.IsEntityNotFoundError() == true)
            return default;

        var responseContentsStream = await (httpContent?.ReadAsStreamAsync() ?? Task.FromResult(Stream.Null));
        var responseJson = await DeserializeNullableResponseJson<T?>(responseContentsStream);
        return responseJson;
    }

    public async Task<TResponse> PutAsync<TRequest, TResponse>(TRequest instance, string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(uri, UriKind.Relative),
            Content = CreateJsonRequestBody(instance)
        };

        var responseContent = await SendRequest(requestFactory);
        var responseContentsStream = await responseContent.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);

        return responseJson;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest instance, string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri, UriKind.Relative),
            Content = CreateJsonRequestBody(instance)
        };

        var responseContent = await SendRequest(requestFactory);
        var responseContentsStream = await responseContent.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);

        return responseJson;
    }

    public async Task<TResponse> PostAsync<TResponse>(string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        var responseContent = await SendRequest(requestFactory);
        var responseContentsStream = await responseContent.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);

        return responseJson;
    }

    public async Task DeleteAsync(string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        await SendRequest(requestFactory);
    }

    private async Task<HttpContent> SendRequest(Func<HttpRequestMessage> httpRequestFactory)
    {
        // HttpRequestMessages can only be used once, so we have to create new ones between retries
        var result = await _asyncRetryPolicy.ExecuteAsync(() => SendRequestInner(httpRequestFactory, true));
        return result.Result ?? throw new Exception("A result should be guaranteed at this point, but none were returned");
    }
    
    private async Task<RechargeApiResponse> SendRequestWithManualErrorHandling(Func<HttpRequestMessage> httpRequestFactory)
    {
        // HttpRequestMessages can only be used once, so we have to create new ones between retries
        var result = await _asyncRetryPolicy.ExecuteAsync(() => SendRequestInner(httpRequestFactory, false));
        return result;
    }
    
    private async Task<RechargeApiResponse> SendRequestInner(Func<HttpRequestMessage> httpRequestFactory, bool throwWhenNotFound)
    {
        var httpRequest = httpRequestFactory();
        var response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
            return RechargeApiResponse.Success(response.Content);
        
        var (apiError, exceptionToThrow) = await CreateAppropriateError(response, throwWhenNotFound);
        if (exceptionToThrow != null)
            throw exceptionToThrow;

        return RechargeApiResponse.Failure(apiError);
    }

    private async Task<RechargeApiError> CreateAppropriateError(HttpResponseMessage response, bool throwWhenNotFound)
    {
        var responseBodyAsStructuredJson = await CreateApiErrorFromHttpContent(response.Content);

        var statusCodeAsInt = (int) response.StatusCode;

        // Recharge sometimes uses HTTP status codes to communicate something different than what the 
        // name of the HTTP status code indicates (for instance "402 Payment Required" for requests that fails for unspecified reasons)
        // Therefore, we match on ints instead of names
        return statusCodeAsInt switch
        {
            // Bad Request: The request was unacceptable, often due to a missing required parameter.
            400 => RechargeApiError.WithExceptionToBeThrown(new BadRequestException(responseBodyAsStructuredJson)),

            // Unauthorized: No valid API key was provided.
            401 => RechargeApiError.WithExceptionToBeThrown(new UnauthorizedException(responseBodyAsStructuredJson)),

            // Request Failed: The parameters were valid but the request failed.
            402 => RechargeApiError.WithExceptionToBeThrown(new UnknownApiFailureException(responseBodyAsStructuredJson)),

            // The request was authenticated but not authorized for the requested resource (permission scope error).
            403 => RechargeApiError.WithExceptionToBeThrown(new ForbiddenException(responseBodyAsStructuredJson)),
            
            // The entity was not found
            404 when throwWhenNotFound == false && responseBodyAsStructuredJson?.IsEntityNotFoundError() == true => RechargeApiError.WhereNoExceptionShouldBeThrown(responseBodyAsStructuredJson),

            // Not Found: The requested resource does not exist.
            404 => RechargeApiError.WithExceptionToBeThrown(new NotFoundException(responseBodyAsStructuredJson)),

            // Method Not Allowed: The method is not allowed for this URI.
            405 => RechargeApiError.WithExceptionToBeThrown(new MethodNotAllowedException(responseBodyAsStructuredJson)),

            // The request was unacceptable, or requesting a data source which is not allowed although permissions permit the request.
            406 => RechargeApiError.WithExceptionToBeThrown(new UnknownApiFailureException(responseBodyAsStructuredJson)),

            // Conflict: You will get this error when you try to send two requests to edit an address or any of its child objects at the same time, in order to avoid out of date information being returned.
            409 => RechargeApiError.WithExceptionToBeThrown(new ConflictException(responseBodyAsStructuredJson)),

            // The request body was not a JSON object.
            415 => RechargeApiError.WithExceptionToBeThrown(new UnsupportedMediaTypeException(responseBodyAsStructuredJson)),

            // The request was understood but cannot be processed due to invalid or missing supplemental information.
            422 => RechargeApiError.WithExceptionToBeThrown(new UnprocessableEntityException(responseBodyAsStructuredJson)),

            // The request was made using an invalid API version.
            426 => RechargeApiError.WithExceptionToBeThrown(new InvalidApiVersionException(responseBodyAsStructuredJson)),

            // The request has been rate limited.
            429 => RechargeApiError.WithExceptionToBeThrown(new RateLimitingException(responseBodyAsStructuredJson)),

            // Internal server error.
            500 => RechargeApiError.WithExceptionToBeThrown(new RechargeApiServerException(responseBodyAsStructuredJson)),

            // The resource requested has not been implemented in the current version but may be implemented in the future.
            501 => RechargeApiError.WithExceptionToBeThrown(new RechargeApiServerException(responseBodyAsStructuredJson)),

            // A 3rd party service on which the request depends has timed out.
            503 => RechargeApiError.WithExceptionToBeThrown(new RechargeApiServerException(responseBodyAsStructuredJson)),

            // Unknown error
            _ => RechargeApiError.WithExceptionToBeThrown(new RechargeApiException(
                $"An unknown error occurred with unhandled status code {(int) response.StatusCode}"))
        };
    }

    private async Task<ApiError?> CreateApiErrorFromHttpContent(HttpContent stringContent)
    {
        var responseBodyAsString = await stringContent.ReadAsStringAsync();

        if (string.IsNullOrEmpty(responseBodyAsString))
            return new ApiError();
        
        try
        {
            var responseBodyAsStructuredJson = DeserializeResponseJson<ApiError>(responseBodyAsString);
            return responseBodyAsStructuredJson;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Could not read the response body as JSON");
        }
        
        return new ApiError()
        {
            RawErrorBody = responseBodyAsString
        };
    }

    private async Task<T> DeserializeResponseJson<T>(Stream responseBody)
    {
        var responseJson = await JsonSerializer.DeserializeAsync<T>(responseBody, _jsonSerializerOptions);
        if (responseJson == null)
            throw new UnexpectedResponseContentException("The response could not be deserialized to JSON");
        return responseJson;
    }
    
    private T DeserializeResponseJson<T>(string responseBody)
    {
        var responseJson = JsonSerializer.Deserialize<T>(responseBody, _jsonSerializerOptions);
        if (responseJson == null)
            throw new UnexpectedResponseContentException("The response could not be deserialized to JSON");
        return responseJson;
    }

    private async Task<T?> DeserializeNullableResponseJson<T>(Stream? response)
    {
        if (response == null)
            return default;

        await using var ms = new MemoryStream();
        await response.CopyToAsync(ms);
        var responseAsString = Encoding.UTF8.GetString(ms.ToArray());
        if (string.IsNullOrWhiteSpace(responseAsString))
            return default;
        var responseJson = JsonSerializer.Deserialize<T>(responseAsString, _jsonSerializerOptions);
        return responseJson;
    }

    private StringContent CreateJsonRequestBody<T>(T request)
    {
        var requestJson = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        return content;
    }

    private record RechargeApiResponse(HttpContent? Result, ApiError? Error)
    {
        public static RechargeApiResponse Success(HttpContent content) => new RechargeApiResponse(content, null);
        public static RechargeApiResponse Failure(ApiError? error) => new RechargeApiResponse(null, error);
    };

    private record RechargeApiError(ApiError? ApiError, Exception? ExceptionToThrow)
    {
        public static RechargeApiError WithExceptionToBeThrown(Exception exception) => new RechargeApiError(null, exception);
        public static RechargeApiError WhereNoExceptionShouldBeThrown(ApiError error) => new RechargeApiError(error, null);
    }
}