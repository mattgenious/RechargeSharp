using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Discounts;
using RechargeSharp.Entities.Shared;
using Address = RechargeSharp.Entities.Addresses.Address;

namespace RechargeSharp.Services.Discounts
{
    public class DiscountService : RechargeSharpService
    {
        public DiscountService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> DiscountExistsAsync(long id)
        {
            var response = await GetAsync($"/discounts/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
        public async Task<Discount> GetDiscountAsync(long id)
        {
            var response = await GetAsync($"/discounts/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Discount;
        }

        private async Task<IEnumerable<Discount>> GetDiscountsAsync(string queryParams)
        {
            var response = await GetAsync($"/discounts?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Discounts;
        }

        public async Task<IEnumerable<Discount>> GetDiscountsAsync(int page = 1, int limit = 50, string status = null, string discountType = null, string discountCode = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
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

        public async Task<IEnumerable<Discount>> GetAllDiscountsWithParamsAsync(string status = null, string discountType = null, string discountCode = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = $"";
            queryParams += discountType != null ? $"&discount_type={discountType}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return await GetAllDiscountsAsync(queryParams);
        }

        private async Task<IEnumerable<Discount>> GetAllDiscountsAsync(string queryParams)
        {
            var count = await CountDiscountsAsync();

            var taskList = new List<Task<IEnumerable<Discount>>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetDiscountsAsync($"page={i}&limit=250" + queryParams));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Discount>();

            foreach (var discounts in computed)
            {
                result.AddRange(discounts);
            }

            return result;
        }

        public async Task<long> CountDiscountsAsync()
        {
            var response = await GetAsync("/discounts/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Count;
        }

        public async Task<Address> AddDiscountToAddressByIdAsync(long discountId, long addressId)
        {
            var response = await PostAsJsonAsync($"/addresses/{addressId}/apply_discount", $"{{ \"discount_id\":\"{discountId}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Address;
        }

        public async Task<Address> AddDiscountToAddressByCodeAsync(string discountCode, long addressId)
        {
            var response = await PostAsJsonAsync($"/addresses/{addressId}/apply_discount", $"{{ \"discount_code\":\"{discountCode}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Address;
        }

        public async Task<Address> RemoveDiscountFromAddress(long addressId)
        {
            var response = await PostAsJsonAsync($"/addresses/{addressId}/remove_discount", $"{{}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Address;
        }

        public async Task<Charge> AddDiscountToChargeByIdAsync(long discountId, long chargeId)
        {
            var response = await PostAsJsonAsync($"/charges/{chargeId}/apply_discount", $"{{ \"discount_id\":\"{discountId}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Charge;
        }

        public async Task<Charge> AddDiscountToChargeByCodeAsync(string discountCode, long chargeId)
        {
            var response = await PostAsJsonAsync($"/charges/{chargeId}/apply_discount", $"{{ \"discount_code\":\"{discountCode}\"}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Charge;
        }

        public async Task<Charge> RemoveDiscountFromCharge(long chargeId)
        {
            var response = await PostAsJsonAsync($"/charges/{chargeId}/remove_discount", $"{{}}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Charge;
        }

        public async Task<Discount> CreateDiscountAsync(CreateDiscountRequest createDiscountRequest)
        {
            ValidateModel(createDiscountRequest);

            var response = await PostAsJsonAsync("/discounts", JsonConvert.SerializeObject(createDiscountRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Discount;
        }

        public async Task<Discount> UpdateDiscountAsync(long id, UpdateDiscountRequest updateDiscountRequest)
        {
            ValidateModel(updateDiscountRequest);

            var response = await PutAsJsonAsync($"/discounts/{id}", JsonConvert.SerializeObject(updateDiscountRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<DiscountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Discount;
        }

        public async Task DeleteDiscountAsync(long id)
        {
            var response = await DeleteAsync($"/discounts/{id}").ConfigureAwait(false);
        }
    }

}
