﻿using System;
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

        public async Task<Webhook> GetWebhookAsync(string id)
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
            var response = await PostAsJsonAsync("/webhooks", createWebhookRequest);
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync()).Webhook;
        }

        public async Task<Webhook> UpdateWebhookAsync(string id, UpdateWebhookRequest updateWebhookRequest)
        {
            var response = await PutAsync($"/webhooks/{id}", JsonConvert.SerializeObject(updateWebhookRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync()).Webhook;
        }
        public async Task<Webhook> OverrideShippingLines(string id, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            var response = await PutAsync($"/webhooks/{id}", JsonConvert.SerializeObject(overrideShippingLinesRequest));
            return JsonConvert.DeserializeObject<WebhookResponse>(
                await response.Content.ReadAsStringAsync()).Webhook;
        }

        public async Task DeleteWebhookAsync(string id)
        {
            var response = await DeleteAsync($"/webhooks/{id}");
        }
    }
}
