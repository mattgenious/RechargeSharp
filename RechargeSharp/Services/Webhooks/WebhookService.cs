using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Webhooks;

namespace RechargeSharp.Services.Webhooks
{
    public class WebhookService : RechargeSharpService
    {
        public WebhookService(string apiKey) : base(apiKey)
        {
        }

        public async Task<Webhook> GetWebhookAsync(long id)
        {
            var response = await GetAsync($"/webhooks/{id}");
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync()).Webhook;
        }

        public async Task<IEnumerable<Webhook>> GetWebhooksAsync()
        {
            var response = await GetAsync($"/webhooks");
            return JsonConvert.DeserializeObject<WebhookListResponse>(
                await response.Content.ReadAsStringAsync()).Webhooks;
        }

        public async Task<Webhook> CreateWebhookAsync(CreateWebhookRequest createWebhookRequest)
        {
            ValidateModel(createWebhookRequest);

            var response = await PostAsJsonAsync("/webhooks", JsonConvert.SerializeObject(createWebhookRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync()).Webhook;
        }

        public async Task<Webhook> UpdateWebhookAsync(long id, UpdateWebhookRequest updateWebhookRequest)
        {
            ValidateModel(updateWebhookRequest);

            var response = await PutAsync($"/webhooks/{id}", JsonConvert.SerializeObject(updateWebhookRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync()).Webhook;
        }
        public async Task<Webhook> OverrideShippingLines(long id, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            ValidateModel(overrideShippingLinesRequest);

            var response = await PutAsync($"/webhooks/{id}", JsonConvert.SerializeObject(overrideShippingLinesRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync()).Webhook;
        }

        public async Task DeleteWebhookAsync(long id)
        {
            var response = await DeleteAsync($"/webhooks/{id}");
        }
    }
}
