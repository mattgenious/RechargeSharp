using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Webhooks;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Webhooks
{
    public class WebhookService
    {
        protected readonly AsyncRetryPolicy<HttpResponseMessage> AsyncRetryPolicy;

        private readonly ILogger<RechargeSharpService> _logger;
        private readonly HttpClient _client;
        
        public WebhookService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions)
        {
            _logger = logger;
            var rechargeServiceOptions1 = rechargeServiceOptions.Value;

            _client = httpClientFactory.CreateClient("RechargeSharpWebhookClient");
            _client.DefaultRequestHeaders.Remove("X-Recharge-Access-Token");
            _client.DefaultRequestHeaders.Add("X-Recharge-Access-Token", rechargeServiceOptions1.GetWebhookApiKey());

            AsyncRetryPolicy = Policy.HandleResult<HttpResponseMessage>(x =>
            {
                if (!x.IsSuccessStatusCode)
                {
                    _logger.LogError(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    if ((int)x.StatusCode > 399 && x.StatusCode != HttpStatusCode.TooManyRequests && (x.StatusCode != HttpStatusCode.NotFound && x.RequestMessage.Method != HttpMethod.Get))
                    {
                        throw new Exception(x.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    }

                    if (x.StatusCode == HttpStatusCode.NotFound && x.RequestMessage.Method == HttpMethod.Get)
                    {
                        return false;
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

        public async Task<bool?> WebhookExistsAsync(long id)
        {
            var response = await GetAsync($"/webhooks/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Webhook?> GetWebhookAsync(long id)
        {
            var response = await GetAsync($"/webhooks/{id}");
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync(), new DateTimeOffsetJsonConverter())?.Webhook;
        }

        public async Task<IEnumerable<Webhook>?> GetWebhooksAsync()
        {
            var response = await GetAsync($"/webhooks");
            return JsonConvert.DeserializeObject<WebhookListResponse>(
                await response.Content.ReadAsStringAsync(), new DateTimeOffsetJsonConverter())?.Webhooks;
        }

        public async Task<Webhook?> CreateWebhookAsync(CreateWebhookRequest createWebhookRequest)
        {
            ValidateModel(createWebhookRequest);

            var response = await PostAsJsonAsync("/webhooks", JsonConvert.SerializeObject(createWebhookRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync(), new DateTimeOffsetJsonConverter())?.Webhook;
        }

        public async Task<Webhook?> UpdateWebhookAsync(long id, UpdateWebhookRequest updateWebhookRequest)
        {
            ValidateModel(updateWebhookRequest);

            var response = await PutAsJsonAsync($"/webhooks/{id}", JsonConvert.SerializeObject(updateWebhookRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync(), new DateTimeOffsetJsonConverter())?.Webhook;
        }
        public async Task<Webhook?> OverrideShippingLines(long id, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            ValidateModel(overrideShippingLinesRequest);

            var response = await PutAsJsonAsync($"/webhooks/{id}", JsonConvert.SerializeObject(overrideShippingLinesRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync(), new DateTimeOffsetJsonConverter())?.Webhook;
        }

        public async Task DeleteWebhookAsync(long id)
        {
            _ = await DeleteAsync($"/webhooks/{id}");
        }

        private Task<HttpResponseMessage> GetAsync(string path)
        {
            _logger.LogInformation($"RechargeSharp GET: {path}");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.GetAsync(path));
        }
        private Task<HttpResponseMessage> PutAsJsonAsync(string path, string jsonData)
        {
            _logger.LogInformation($"RechargeSharp PUT: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.PutAsync(path, content));
        }
        private Task<HttpResponseMessage> PostAsJsonAsync(string path, string jsonData)
        {
            _logger.LogInformation($"RechargeSharp POST: {path}\r\nJSONDATA: {jsonData}");
            var content = new StringContent(jsonData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.PostAsync(path, content));
        }
        private Task<HttpResponseMessage> DeleteAsync(string path)
        {
            _logger.LogInformation($"RechargeSharp DELETE: {path}");
            return AsyncRetryPolicy.ExecuteAsync(async () => await _client.DeleteAsync(path));
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
    }
}
