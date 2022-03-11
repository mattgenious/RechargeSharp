using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Polly;
using RechargeSharp.v2021_11.Entities.Errors;
using RechargeSharp.v2021_11.Exceptions;
using RechargeSharp.v2021_11.Utilities.Json;

namespace RechargeSharp.v2021_11.Utilities;

public interface IRechargeApiCaller
{
    Task<T> Get<T>(string uri);
    Task<TResponse> Put<TRequest, TResponse>(TRequest instance, string uri);
    Task<TResponse> Post<TRequest, TResponse>(TRequest instance, string uri);
    Task Delete(string uri);
}

public class RechargeApiCaller : IRechargeApiCaller
{
    private readonly ILogger<RechargeApiCaller> _logger;
    private readonly RechargeApiCallerOptions _rechargeApiCallerOptions;
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    public IAsyncPolicy AsyncRetryPolicy { get; set; }

    public RechargeApiCaller(IHttpClientFactory httpClientFactory, ILogger<RechargeApiCaller> logger, RechargeApiCallerOptions rechargeApiCallerOptions)
    {
        _logger = logger;
        _rechargeApiCallerOptions = rechargeApiCallerOptions;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.DefaultRequestHeaders.Add("X-Recharge-Version", "2021-11");
        _httpClient.DefaultRequestHeaders.Add ("X-Recharge-Access-Token", rechargeApiCallerOptions.ApiKey);

        _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
        };
        _jsonSerializerOptions.Converters.Add(new ApiErrorJsonConverter());
        _jsonSerializerOptions.Converters.Add(new DateOnlyNullableConverter());
        _jsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        _jsonSerializerOptions.Converters.Add(new DecimalConverter());
        _jsonSerializerOptions.Converters.Add(new DecimalNullableConverter());

        AsyncRetryPolicy = _rechargeApiCallerOptions.ApiCallPolicy;
    }

    public async Task<T> Get<T>(string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        var response = await SendRequest(requestFactory);
        var responseContentsStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<T>(responseContentsStream);
        return responseJson;
    }

    public async Task<TResponse> Put<TRequest, TResponse>(TRequest instance, string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(uri, UriKind.Relative),
            Content = CreateJsonRequestBody(instance)
        };
        
        var response = await SendRequest(requestFactory);
        var responseContentsStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);
        
        return responseJson;
    }

    public async Task<TResponse> Post<TRequest, TResponse>(TRequest instance, string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri, UriKind.Relative),
            Content = CreateJsonRequestBody(instance)
        };
        
        var response = await SendRequest(requestFactory);
        var responseContentsStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);
        
        return responseJson;
    }
    
    public async Task<TResponse> Post<TResponse>(string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri, UriKind.Relative)
        };
        
        var response = await SendRequest(requestFactory);
        var responseContentsStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);
        
        return responseJson;
    }

    public async Task Delete(string uri)
    {
        var requestFactory = () => new HttpRequestMessage()
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        await SendRequest(requestFactory);
    }
    
    private async Task<HttpResponseMessage> SendRequest(Func<HttpRequestMessage> httpRequestFactory)
    {
        // HttpRequestMessages can only be used once, so we have to create new ones between retries
        var result = await AsyncRetryPolicy.ExecuteAsync(() => SendRequestInner(httpRequestFactory));
        return result;
    }

    private async Task<HttpResponseMessage> SendRequestInner(Func<HttpRequestMessage> httpRequestFactory)
    {
        var httpRequest = httpRequestFactory();
        var response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
            return response;
        
        var exceptionToThrow = await CreateAppropriateException(response);
        throw exceptionToThrow;
    }

    private async Task<Exception> CreateAppropriateException(HttpResponseMessage response)
    {
        ApiError? responseBodyAsStructuredJson;
        try
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            responseBodyAsStructuredJson = await DeserializeResponseJson<ApiError>(responseStream);
        }
        catch (Exception e)
        {
            responseBodyAsStructuredJson = null;
        }

        // Recharge sometimes uses HTTP status codes to communicate something different than what the 
        // name of the HTTP status code indicates (for instance "402 Payment Required" for requests that fails for unspecified reasons)
        // Therefore, we match on ints instead of names
        return (int) response.StatusCode switch
        {
            // Bad Request: The request was unacceptable, often due to a missing required parameter.
            400 => new BadRequestException(responseBodyAsStructuredJson),
            
            // Unauthorized: No valid API key was provided.
            401 => new UnauthorizedException(responseBodyAsStructuredJson),
            
            // Request Failed: The parameters were valid but the request failed.
            402 => new UnknownApiFailureException(responseBodyAsStructuredJson),
            
            // The request was authenticated but not authorized for the requested resource (permission scope error).
            403 => new ForbiddenException(responseBodyAsStructuredJson),
            
            // Not Found: The requested resource doesn’t exist.
            404 => new NotFoundException(responseBodyAsStructuredJson),
            
            // Method Not Allowed: The method is not allowed for this URI.
            405 => new MethodNotAllowedException(responseBodyAsStructuredJson),
            
            // The request was unacceptable, or requesting a data source which is not allowed although permissions permit the request.
            406 => new UnknownApiFailureException(responseBodyAsStructuredJson),
            
            // Conflict: You will get this error when you try to send two requests to edit an address or any of its child objects at the same time, in order to avoid out of date information being returned.
            409 => new ConflictException(responseBodyAsStructuredJson),
            
            // The request body was not a JSON object.
            415 => new UnsupportedMediaTypeException(responseBodyAsStructuredJson),
            
            // The request was understood but cannot be processed due to invalid or missing supplemental information.
            422 => new UnprocessableEntityException(responseBodyAsStructuredJson),
            
            // The request was made using an invalid API version.
            426 => new InvalidApiVersionException(responseBodyAsStructuredJson),
            
            // The request has been rate limited.
            429 => new RateLimitingException(responseBodyAsStructuredJson),
            
            // Internal server error.
            500 => new RechargeApiServerException(responseBodyAsStructuredJson),
            
            // The resource requested has not been implemented in the current version but may be implemented in the future.
            501 => new RechargeApiServerException(responseBodyAsStructuredJson),
            
            // A 3rd party service on which the request depends has timed out.
            503 => new RechargeApiServerException(responseBodyAsStructuredJson),
            
            // Unknown error
            _ => new RechargeApiException($"An unknown error occurred with unhandled status code {(int) response.StatusCode}")
        };
    }

    private async Task<T> DeserializeResponseJson<T>(Stream response)
    {
        var responseJson = await JsonSerializer.DeserializeAsync<T>(response, _jsonSerializerOptions);
        if (responseJson == null)
            throw new UnexpectedResponseContentException("The response could not be deserialized to JSON");
        return responseJson;
    }

    private StringContent CreateJsonRequestBody<T>(T request)
    {
        var requestJson = JsonSerializer.Serialize(request, _jsonSerializerOptions);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        return content;
    }
}