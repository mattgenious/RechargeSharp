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
        protected ChargeService(string apiKey) : base(apiKey)
        {
        }

        public async Task<ChargeResponse> GetChargeAsync(string id)
        {
            var response = await GetAsync($"/charges/{id}");
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync());
        }

        private async Task<ChargeListResponse> GetChargesAsync(string queryParams)
        {
            var response = await GetAsync($"/charges?{queryParams}");
            return JsonConvert.DeserializeObject<ChargeListResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<ChargeListResponse> GetChargesAsync(int page = 1, int limit = 50, string email = null, string shopifyChargeId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, string hash = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += email != null ? $"&email={email}" : "";
            queryParams += shopifyChargeId != null ? $"&shopify_customer_id={shopifyChargeId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";
            queryParams += hash != null ? $"&hash={hash}" : "";


            return await GetChargesAsync(queryParams);
        }

        public async Task<CountResponse> CountChargesAsync()
        {
            var response = await GetAsync("/charges/count");
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<ChargeResponse> ChangeNextChargeDateAsync(long chargeId, ChangeNextChargeDateRequest changeNextChargeDateRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/change_next_charge_date", JsonConvert.SerializeObject(changeNextChargeDateRequest));
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<ChargeResponse> SkipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/skip", JsonConvert.SerializeObject(skipNextChargeRequest));
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<ChargeResponse> UnskipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/unskip", JsonConvert.SerializeObject(skipNextChargeRequest));
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<ChargeResponse> RefundChargeAsync(long chargeId, RefundChargeRequest refundChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/refund", JsonConvert.SerializeObject(refundChargeRequest));
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<ChargeResponse> TotalRefundChargeAsync(long chargeId, TotalRefundChargeRequest totalRefundChargeRequest)
        {
            var response = await PostAsync($"/charges/{chargeId}/refund", JsonConvert.SerializeObject(totalRefundChargeRequest));
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteChargeAsync(string id)
        {
            var response = await DeleteAsync($"/charges/{id}");
        }


    }
}
