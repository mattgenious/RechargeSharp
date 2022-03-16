using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Security.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services
{
    public class RechargeSharpService
    {
        protected readonly AsyncRetryPolicy<HttpResponseMessage> AsyncRetryPolicy;

        private readonly ILogger<RechargeSharpService> _logger;
        private readonly List<HttpClient> _clients;
        private readonly Random _random;
        
        protected RechargeSharpService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions)
        {
            _logger = logger;
            var rechargeServiceOptions1 = rechargeServiceOptions.Value;
            _random = new Random();
            _clients = new List<HttpClient>();

            if (rechargeServiceOptions1?.ApiKeyArray is null)
            {
                throw new ArgumentException("RechargeServiceOptions were null or RechargeServiceOptions.ApiKeyArray was null");
            }
            foreach (var apiKey in rechargeServiceOptions1.ApiKeyArray)
            {
                var client = httpClientFactory.CreateClient("RechargeSharpClient");
                client.DefaultRequestHeaders.Add("X-Recharge-Access-Token", apiKey);
                _clients.Add(client);
            }

            AsyncRetryPolicy = Policy
                .Handle<HttpRequestException>(HandleHttpRequestException)
                .OrResult<HttpResponseMessage>(HandleHttpResponseMessage)
                .WaitAndRetryAsync(10, x => TimeSpan.FromSeconds(x));
        }

        protected Task<HttpResponseMessage> GetAsync(string path, bool noRetry = false)
        {
            _logger.LogInformation($"RechargeSharp GET: {path}");
            return noRetry ? ExecuteSingleRequest(() => GetRandomHttpClient().GetAsync(path)) : AsyncRetryPolicy.ExecuteAsync(() => GetRandomHttpClient().GetAsync(path));
        }
        protected Task<HttpResponseMessage> PutAsJsonAsync(string path, string jsonData, bool noRetry = false)
        {
            _logger.LogInformation($"RechargeSharp PUT: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return noRetry ? ExecuteSingleRequest(() => GetRandomHttpClient().PutAsync(path, content)) : AsyncRetryPolicy.ExecuteAsync(() => GetRandomHttpClient().PutAsync(path, content));
        }
        protected Task<HttpResponseMessage> PostAsJsonAsync(string path, string jsonData, bool noRetry = false)
        {
            _logger.LogInformation($"RechargeSharp POST: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return noRetry ? ExecuteSingleRequest(() => GetRandomHttpClient().PostAsync(path, content)) : AsyncRetryPolicy.ExecuteAsync(() => GetRandomHttpClient().PostAsync(path, content));
        }
        protected Task<HttpResponseMessage> DeleteAsync(string path, bool noRetry = false)
        {
            _logger.LogInformation($"RechargeSharp DELETE: {path}");
            return noRetry ? ExecuteSingleRequest(() => GetRandomHttpClient().DeleteAsync(path)) : AsyncRetryPolicy.ExecuteAsync(() => GetRandomHttpClient().DeleteAsync(path));
        }

        protected static void ValidateModel(object? objectToValidate)
        {
            if (objectToValidate == null)
                return;
            var context = new ValidationContext(objectToValidate);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(objectToValidate, context, results, true))
            {
                throw new ArgumentException(string.Join(", ", results), nameof(objectToValidate));
            }
        }

        private HttpClient GetRandomHttpClient()
        {
            return _clients[_random.Next(_clients.Count)];
        }

        private bool HandleHttpRequestException(HttpRequestException httpRequestException)
        {
            _logger.LogError(httpRequestException, "HttpRequestException");
            return httpRequestException.InnerException is IOException or AuthenticationException;
        }

        private async Task<HttpResponseMessage> ExecuteSingleRequest(Func<Task<HttpResponseMessage>> funky)
        {
            var response = await funky.Invoke();

            HandleHttpResponseMessage(response);

            return response;
        }

        private bool HandleHttpResponseMessage(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.IsSuccessStatusCode) return false;

            LogErrors(httpResponseMessage);

            ExceptionUtility.ThrowIfSuitableExceptionFound(httpResponseMessage);

            return true;
        }

        private void LogErrors(HttpResponseMessage httpResponseMessage)
        {
            _logger.LogError(httpResponseMessage.RequestMessage.ToString());
            _logger.LogError(httpResponseMessage.ToString());
            _logger.LogError("X-Request-Id:" + string.Join(",", httpResponseMessage.Headers.GetValues("X-Request-Id")));
            _logger.LogError(httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
    }
}
