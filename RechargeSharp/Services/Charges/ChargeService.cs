using RechargeSharp.Entities.Charges;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Charges
{
    public class ChargeService : RechargeSharpService
    {
        public ChargeService(string apiKey) : base(apiKey)
        {
        }

        public async Task<ChargeResponse> GetChargeAsync(string id)
        {
            var response = await GetAsync($"/charges/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private async Task<ChargeListResponse> GetChargesAsync(string queryParams)
        {
            var response = await GetAsync($"/charges?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public Task<ChargeListResponse> GetChargesAsync(int page = 1, int limit = 50, string status = null, string customerId = null, string addressId = null, string shopifyOrderId = null, string subscriptionId = null, DateTime? date = null, DateTime? dateMin = null, DateTime? dateMax = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += shopifyOrderId != null ? $"&shopify_order_id={shopifyOrderId}" : "";
            queryParams += subscriptionId != null ? $"&subscription_id={subscriptionId}" : "";
            queryParams += date != null ? $"&date={date?.ToString("s")}" : "";
            queryParams += dateMin != null ? $"&date_min={dateMin?.ToString("s")}" : "";
            queryParams += dateMax != null ? $"&date_max={dateMax?.ToString("s")}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetChargesAsync(queryParams);
        }

        public Task<ChargeListResponse> GetAllChargesWithParamsAsync(string status = null, string customerId = null, string addressId = null, string shopifyOrderId = null, string subscriptionId = null, DateTime? date = null, DateTime? dateMin = null, DateTime? dateMax = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += shopifyOrderId != null ? $"&shopify_order_id={shopifyOrderId}" : "";
            queryParams += subscriptionId != null ? $"&subscription_id={subscriptionId}" : "";
            queryParams += date != null ? $"&date={date?.ToString("s")}" : "";
            queryParams += dateMin != null ? $"&date_min={dateMin?.ToString("s")}" : "";
            queryParams += dateMax != null ? $"&date_max={dateMax?.ToString("s")}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetChargesRecAsync(queryParams, 1, new ChargeListResponse() { Charges = new List<Charge>() });
        }

        private async Task<ChargeListResponse> GetChargesRecAsync(string queryParams, int page, ChargeListResponse accumulator)
        {
            var response = await GetAsync($"/charges?page={page}&limit=250{queryParams}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<ChargeListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            if (result.Charges.Count == 0)
            {
                return accumulator;
            }
            else
            {
                page++;
                accumulator.Charges.AddRange(result.Charges);
                return await GetChargesRecAsync(queryParams, page, accumulator).ConfigureAwait(false);
            }
        }

        public async Task<CountResponse> CountChargesAsync()
        {
            var response = await GetAsync("/charges/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> ChangeNextChargeDateAsync(long chargeId, ChangeNextChargeDateRequest changeNextChargeDateRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/change_next_charge_date", JsonConvert.SerializeObject(changeNextChargeDateRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> SkipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/skip", JsonConvert.SerializeObject(skipNextChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> UnskipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/unskip", JsonConvert.SerializeObject(skipNextChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> RefundChargeAsync(long chargeId, RefundChargeRequest refundChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/refund", JsonConvert.SerializeObject(refundChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> TotalRefundChargeAsync(long chargeId, TotalRefundChargeRequest totalRefundChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/refund", JsonConvert.SerializeObject(totalRefundChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task DeleteChargeAsync(string id)
        {
            var response = await DeleteAsync($"/charges/{id}").ConfigureAwait(false);
        }


    }
}
