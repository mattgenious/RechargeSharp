using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;

namespace RechargeSharp.Services
{
    public class RechargeSharpService
    {
        protected readonly AsyncRetryPolicy<HttpResponseMessage> AsyncRetryPolicy;

        private readonly ILogger<RechargeSharpService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly RechargeServiceOptions _rechargeServiceOptions;
        private readonly HttpClient _client;
        protected RechargeSharpService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _rechargeServiceOptions = rechargeServiceOptions.Value;

            var apiKey = _rechargeServiceOptions.GetApiKey();

            _client = _httpClientFactory.CreateClient("RechargeSharpClient");
            _client.DefaultRequestHeaders.Remove("X-Recharge-Access-Token");
            _client.DefaultRequestHeaders.Add("X-Recharge-Access-Token", apiKey);

            AsyncRetryPolicy = Policy.HandleResult<HttpResponseMessage>(x =>
            {
                if (!x.IsSuccessStatusCode)
                {
                    _logger.LogError(x.RequestMessage.ToString());
                    _logger.LogError("X-Request-Id:" + string.Join(",", x.Headers.GetValues("X-Request-Id")));
                    _logger.LogError(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    if ((int)x.StatusCode == 401)
                    {
                        throw new UnauthorizedAccessException($"Api key starts with: {(apiKey.Length > 4 ? apiKey.Substring(0, 4) : "")} was unauthorized");
                    }
                    if (x.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        apiKey = _rechargeServiceOptions.GetApiKey();
                        _client.DefaultRequestHeaders.Remove("X-Recharge-Access-Token");
                        _client.DefaultRequestHeaders.Add("X-Recharge-Access-Token", apiKey);
                        _logger.LogInformation($"changed apikey to: {apiKey}");
                        return true;
                    }
                    if ((int)x.StatusCode > 399 && x.StatusCode != HttpStatusCode.TooManyRequests && (x.StatusCode != HttpStatusCode.NotFound && x.RequestMessage.Method != HttpMethod.Get))
                    {
                        throw new Exception(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    }

                    if (x.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Returned 404");
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }).WaitAndRetryForeverAsync(
                retryAttempt =>
                    TimeSpan.FromSeconds(3));
        }

        protected Task<HttpResponseMessage> GetAsync(string path)
        {
            _logger.LogInformation($"RechargeSharp GET: {path}");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.GetAsync(path));
        }
        protected Task<HttpResponseMessage> PutAsJsonAsync(string path, string jsonData)
        {
            _logger.LogInformation($"RechargeSharp PUT: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.PutAsync(path, content));
        }
        protected Task<HttpResponseMessage> PostAsJsonAsync(string path, string jsonData)
        {
            _logger.LogInformation($"RechargeSharp POST: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.PostAsync(path, content));
        }
        protected Task<HttpResponseMessage> DeleteAsync(string path)
        {
            _logger.LogInformation($"RechargeSharp DELETE: {path}");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.DeleteAsync(path));
        }

        protected void ValidateModel(object objectToValidate)
        {
            var context = new ValidationContext(objectToValidate);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(objectToValidate, context, results, true))
            {
                throw new ArgumentException(string.Join(", ", results), nameof(objectToValidate));
            }
        }
    }
}
