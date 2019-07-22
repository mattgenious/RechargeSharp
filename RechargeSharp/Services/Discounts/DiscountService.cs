using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Discounts;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Discounts
{
    class DiscountService : RechargeSharpService
    {
        protected DiscountService(string apiKey) : base(apiKey)
        {
        }
        public async Task<DiscountResponse> GetDiscountAsync(string id)
        {
            var response = await GetAsync($"/discounts/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private async Task<DiscountListResponse> GetDiscountsAsync(string queryParams)
        {
            var response = await GetAsync($"/discounts?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<DiscountListResponse> GetDiscountsAsync(int page = 1, int limit = 50, string status = null, string discountType = null, string discountCode = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += discountType != null ? $"&discount_type={discountType}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";


            return await GetDiscountsAsync(queryParams).ConfigureAwait(false);
        }

        public async Task<CountResponse> CountDiscountsAsync()
        {
            var response = await GetAsync("/discounts/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<AddressResponse> AddDiscountToAddressByIdAsync(long discountId, long addressId)
        {
            var response = await PostAsync($"/addresses/{addressId}/apply_discount", $"{{ \"discount_id\":\"{discountId}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<AddressResponse> AddDiscountToAddressByCodeAsync(string discountCode, long addressId)
        {
            var response = await PostAsync($"/addresses/{addressId}/apply_discount", $"{{ \"discount_code\":\"{discountCode}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> RemoveDiscountFromAddress(long chargeId)
        {
            var response = await PostAsync($"/addresses/{chargeId}/remove_discount", $"{{}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> AddDiscountToChargeByIdAsync(long discountId, long chargeId)
        {
            var response = await PostAsync($"/charges/{chargeId}/apply_discount", $"{{ \"discount_id\":\"{discountId}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> AddDiscountToChargeByCodeAsync(string discountCode, long chargeId)
        {
            var response = await PostAsync($"/charges/{chargeId}/apply_discount", $"{{ \"discount_code\":\"{discountCode}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<ChargeResponse> RemoveDiscountFromCharge(long chargeId)
        {
            var response = await PostAsync($"/charges/{chargeId}/remove_discount", $"{{}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<DiscountResponse> CreateDiscountAsync(CreateDiscountRequest createDiscountRequest)
        {
            var response = await PostAsync("/discounts", JsonConvert.SerializeObject(createDiscountRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<DiscountResponse> UpdateDiscountAsync(string id, UpdateDiscountRequest updateDiscountRequest)
        {
            var response = await PutAsync($"/discounts/{id}", JsonConvert.SerializeObject(updateDiscountRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task DeleteDiscountAsync(string id)
        {
            var response = await DeleteAsync($"/discounts/{id}").ConfigureAwait(false);
        }
    }

}
