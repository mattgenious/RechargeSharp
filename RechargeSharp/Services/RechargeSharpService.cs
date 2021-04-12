using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private readonly List<HttpClient> _clients;
        private readonly Random _random;
        protected RechargeSharpService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _rechargeServiceOptions = rechargeServiceOptions.Value;
            _random = new Random();
            _clients = new List<HttpClient>();

            foreach (var apiKey in _rechargeServiceOptions.ApiKeyArray)
            {
                var client = _httpClientFactory.CreateClient("RechargeSharpClient");
                client.DefaultRequestHeaders.Add("X-Recharge-Access-Token", apiKey);
                _clients.Add(client);
            }

            AsyncRetryPolicy = Policy.HandleResult<HttpResponseMessage>(x =>
            {
                if (!x.IsSuccessStatusCode)
                {
                    _logger.LogError(x.RequestMessage.ToString());
                    _logger.LogError(x.ToString());
                    _logger.LogError("X-Request-Id:" + string.Join(",", x.Headers.GetValues("X-Request-Id")));
                    _logger.LogError(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                    if ((int)x.StatusCode == 401)
                    {
                        throw new UnauthorizedAccessException(x.RequestMessage.ToString());
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
            return AsyncRetryPolicy.ExecuteAsync(async () => await _clients[_random.Next(_clients.Count)].GetAsync(path));
        }
        protected Task<HttpResponseMessage> PutAsJsonAsync(string path, string jsonData)
        {
            _logger.LogInformation($"RechargeSharp PUT: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _clients[_random.Next(_clients.Count)].PutAsync(path, content));
        }
        protected Task<HttpResponseMessage> PostAsJsonAsync(string path, string jsonData)
        {
            _logger.LogInformation($"RechargeSharp POST: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _clients[_random.Next(_clients.Count)].PostAsync(path, content));
        }
        protected Task<HttpResponseMessage> DeleteAsync(string path)
        {
            _logger.LogInformation($"RechargeSharp DELETE: {path}");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _clients[_random.Next(_clients.Count)].DeleteAsync(path));
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
