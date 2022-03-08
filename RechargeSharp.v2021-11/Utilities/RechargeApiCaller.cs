using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Entities;
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
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public RechargeApiCaller(IHttpClientFactory httpClientFactory, ILogger<RechargeApiCaller> logger)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();

        _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new SnakeCaseNamingPolicy()
        };
    }

    public async Task<T> Get<T>(string uri)
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        var response = await SendRequest(request);
        var responseContentsStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<T>(responseContentsStream);
        return responseJson;
    }

    public async Task<TResponse> Put<TRequest, TResponse>(TRequest instance, string uri)
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri(uri, UriKind.Relative),
            Content = CreateJsonRequestBody(instance)
        };
        
        var response = await SendRequest(request);
        var responseContentsStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);
        
        return responseJson;
    }

    public async Task<TResponse> Post<TRequest, TResponse>(TRequest instance, string uri)
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri, UriKind.Relative),
            Content = CreateJsonRequestBody(instance)
        };
        
        var response = await SendRequest(request);
        var responseContentsStream = await response.Content.ReadAsStreamAsync();
        var responseJson = await DeserializeResponseJson<TResponse>(responseContentsStream);
        
        return responseJson;
    }

    public async Task Delete(string uri)
    {
        var request = new HttpRequestMessage()
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uri, UriKind.Relative)
        };

        await SendRequest(request);
    }

    private async Task<HttpResponseMessage> SendRequest(HttpRequestMessage httpRequest)
    {
        try
        {
            var response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return response;
            
            var exceptionToThrow = await CreateAppropriateException(response);
            throw exceptionToThrow;
        }
        catch (Exception e) when (e is not RechargeApiException)
        {
            throw new NotImplementedException("exception handling is not implemented yet", e);
        }
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
            400 => new BadRequestException(responseBodyAsStructuredJson),
            401 => new UnauthorizedException(responseBodyAsStructuredJson),
            402 => new UnknownApiFailureException(responseBodyAsStructuredJson),
            403 => new ForbiddenException(responseBodyAsStructuredJson),
            404 => new NotFoundException(responseBodyAsStructuredJson),
            405 => new MethodNotAllowedException(responseBodyAsStructuredJson),
            406 => new UnknownApiFailureException(responseBodyAsStructuredJson),
            409 => new ConflictException(responseBodyAsStructuredJson),
            415 => new UnsupportedMediaTypeException(responseBodyAsStructuredJson),
            422 => new UnprocessableEntityException(responseBodyAsStructuredJson),
            426 => new InvalidApiVersionException(responseBodyAsStructuredJson),
            429 => new RateLimitingException(responseBodyAsStructuredJson),
            500 => new RechargeApiServerException(responseBodyAsStructuredJson),
            501 => new RechargeApiServerException(responseBodyAsStructuredJson),
            503 => new RechargeApiServerException(responseBodyAsStructuredJson),
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
        var requestJson = JsonSerializer.Serialize<T>(request, _jsonSerializerOptions);
        var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
        return content;
    }
}