using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Subscriptions;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Subscriptions
{
    public class SubscriptionService : RechargeSharpService
    {
        public SubscriptionService(string apiKey) : base(apiKey)
        {
        }

        public async Task<Entities.Subscriptions.Subscription> GetSubscriptionAsync(string id)
        {
            var response = await GetAsync($"/subscriptions/{id}");
            return JsonConvert.DeserializeObject<Entities.Subscriptions.Subscription>(
                await response.Content.ReadAsStringAsync());
        }

        private async Task<SubscriptionListResponse> GetSubscriptionsAsync(string queryParams)
        {
            var response = await GetAsync($"/Subscriptions?{queryParams}");
            return JsonConvert.DeserializeObject<SubscriptionListResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<SubscriptionListResponse> GetSubscriptionsAsync(int page = 1, int limit = 50, string customerId = null, string addressId = null, string status = null, string shopifyCustomerId = null, string shopifyVariantId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
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


            return await GetSubscriptionsAsync(queryParams);
        }

        public async Task<CountResponse> CountSubscriptionsAsync()
        {
            var response = await GetAsync("/Subscriptions/count");
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionRequest createSubscriptionRequest)
        {
            var response = await PostAsync("/Subscriptions", JsonConvert.SerializeObject(createSubscriptionRequest));
            return JsonConvert.DeserializeObject<Subscription>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Subscription> ChangeNextChargeDateAsync(string id, DateTimeOffset date)
        {
            var response = await PostAsync($"/Subscriptions/{id}/set_next_charge_date", JsonConvert.SerializeObject(new ChangeNextChargeDateRequest(){Date = date.ToString("yyyy-MM-dd")}));
            return JsonConvert.DeserializeObject<Subscription>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Subscription> ChangeAddressAsync(string id, ChangeAddressRequest changeAddressRequest)
        {
            var response = await PostAsync($"/Subscriptions/{id}/change_address", JsonConvert.SerializeObject(changeAddressRequest));
            return JsonConvert.DeserializeObject<Subscription>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Subscription> CancelSubscriptionAsync(string id, CancelSubscriptionRequest cancelSubscriptionRequest)
        {
            var response = await PostAsync($"/Subscriptions/{id}/cancel", JsonConvert.SerializeObject(cancelSubscriptionRequest));
            return JsonConvert.DeserializeObject<Subscription>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Subscription> ActivateSubscriptionAsync(string id)
        {
            var response = await PostAsync($"/Subscriptions/{id}/activate", "{}");
            return JsonConvert.DeserializeObject<Subscription>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Subscription> UpdateSubscriptionAsync(string id, UpdateSubscriptionRequest updateSubscriptionRequest)
        {
            var response = await PutAsync($"/Subscriptions/{id}", JsonConvert.SerializeObject(updateSubscriptionRequest));
            return JsonConvert.DeserializeObject<Subscription>(
                await response.Content.ReadAsStringAsync());
        }
        public async Task<Subscription> DelayChargeRegenAsync(string id, DelayChargeRegenRequest delayChargeRegenRequest)
        {
            var response = await PutAsync($"/Subscriptions/{id}", JsonConvert.SerializeObject(delayChargeRegenRequest));
            return JsonConvert.DeserializeObject<Subscription>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteSubscriptionAsync(string id)
        {
            var response = await DeleteAsync($"/Subscriptions/{id}");
        }
    }
}
