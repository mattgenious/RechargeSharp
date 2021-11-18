using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Entities.Subscriptions;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Subscriptions
{
    public class SubscriptionService : RechargeSharpService
    {
        public SubscriptionService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> SubscriptionExistsAsync(long id)
        {
            var response = await GetAsync($"/subscriptions/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Subscription> GetSubscriptionAsync(long id)
        {
            var response = await GetAsync($"/subscriptions/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
        }

        private async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(string queryParams)
        {
            var response = await GetAsync($"/subscriptions?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscriptions;
        }

        public Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int page = 1, int limit = 50, long? customerId = null, long? addressId = null, string status = null, long? shopifyCustomerId = null, long? shopifyVariantId = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += shopifyVariantId != null ? $"&shopify_variant_id={shopifyVariantId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";


            return GetSubscriptionsAsync(queryParams);
        }

        public Task<IEnumerable<Subscription>> GetAllSubscriptionsWithParamsAsync(long? customerId = null, long? addressId = null, string status = null, long? shopifyCustomerId = null, long? shopifyVariantId = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += shopifyVariantId != null ? $"&shopify_variant_id={shopifyVariantId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";
            return GetAllSubscriptionsAsync(queryParams);
        }

        private async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync(string queryParams)
        {
            var count = await CountSubscriptionsAsync(queryParams);

            var taskList = new List<Task<IEnumerable<Subscription>>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetSubscriptionsAsync($"page={i}&limit=250" + queryParams));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Subscription>();

            foreach (var subscriptions in computed)
            {
                result.AddRange(subscriptions);
            }

            return result;
        }

        public async Task<long> CountSubscriptionsAsync(long? customerId = null, long? addressId = null, string status = null, long? shopifyCustomerId = null, long? shopifyVariantId = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += shopifyVariantId != null ? $"&shopify_variant_id={shopifyVariantId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            var response = await GetAsync($"/subscriptions/count?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Count;
        }

        private async Task<long> CountSubscriptionsAsync(string query = null)
        {
            var response = await GetAsync($"/subscriptions/count?{query}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Count;
        }

        public async Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionRequest createSubscriptionRequest)
        {
            ValidateModel(createSubscriptionRequest);

            var response = await PostAsJsonAsync("/subscriptions", JsonConvert.SerializeObject(createSubscriptionRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
        }
        public async Task<Subscription> ChangeNextChargeDateAsync(long id, DateTimeOffset date)
        {
            var response = await PostAsJsonAsync($"/subscriptions/{id}/set_next_charge_date", JsonConvert.SerializeObject(new ChangeNextChargeDateRequest { Date = date.ToString("yyyy-MM-dd") })).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
        }
        /// <summary>
        /// Changes the address of a subscription to an address with a given id, optionally the next charge date can be changed too
        /// </summary>
        /// <param name="id">Subscription id</param>
        /// <param name="changeAddressRequest">Object containing address id and optionally next charge date</param>
        /// <returns></returns>
        public async Task<Subscription> ChangeAddressAsync(long id, ChangeAddressRequest changeAddressRequest)
        {
            ValidateModel(changeAddressRequest);

            var response = await PostAsJsonAsync($"/subscriptions/{id}/change_address", JsonConvert.SerializeObject(changeAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
        }
        public async Task<Subscription> CancelSubscriptionAsync(long id, CancelSubscriptionRequest cancelSubscriptionRequest)
        {
            ValidateModel(cancelSubscriptionRequest);

            var response = await PostAsJsonAsync($"/subscriptions/{id}/cancel", JsonConvert.SerializeObject(cancelSubscriptionRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
        }
        public async Task<Subscription> ActivateSubscriptionAsync(long id)
        {
            var response = await PostAsJsonAsync($"/subscriptions/{id}/activate", "{}").ConfigureAwait(false);

            if ((await response.Content.ReadAsStringAsync()).Contains("item already set to active"))
            {
                return await GetSubscriptionAsync(id);
            }
            else
            {
                return JsonConvert.DeserializeObject<SubscriptionResponse>(
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
            }
        }
        public async Task<Subscription> UpdateSubscriptionAsync(long id, UpdateSubscriptionRequest updateSubscriptionRequest)
        {
            ValidateModel(updateSubscriptionRequest);

            var response = await PutAsJsonAsync($"/subscriptions/{id}", JsonConvert.SerializeObject(updateSubscriptionRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
        }
        public async Task<Subscription> DelayChargeRegenAsync(long id, DelayChargeRegenRequest delayChargeRegenRequest)
        {
            ValidateModel(delayChargeRegenRequest);

            var response = await PutAsJsonAsync($"/subscriptions/{id}", JsonConvert.SerializeObject(delayChargeRegenRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SubscriptionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Subscription;
        }

        public async Task DeleteSubscriptionAsync(long id)
        {
            var response = await DeleteAsync($"/subscriptions/{id}").ConfigureAwait(false);
        }
    }
}
