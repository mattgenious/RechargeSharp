using RechargeSharp.Entities.Charges;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Charges
{
    public interface IChargeService
    {
        Task<bool?> ChargeExistsAsync(long id);
        Task<Charge?> GetChargeAsync(long id);
        Task<IEnumerable<Charge>?> GetChargesAsync(int page = 1, int limit = 50, long? discountId = null, string? discountCode = null, string? status = null, long? customerId = null, long? addressId = null, long? shopifyOrderId = null, long? subscriptionId = null, DateTimeOffset? date = null, DateTimeOffset? dateMin = null, DateTimeOffset? dateMax = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null);
        Task<IEnumerable<Charge>> GetAllChargesWithParamsAsync(long? discountId = null, string? discountCode = null, string? status = null, long? customerId = null, long? addressId = null, long? shopifyOrderId = null, long? subscriptionId = null, DateTimeOffset? date = null, DateTimeOffset? dateMin = null, DateTimeOffset? dateMax = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null);
        Task<long?> CountChargesAsync(long? discountId = null, string? discountCode = null, string? status = null, long? customerId = null, long? addressId = null, long? shopifyOrderId = null, long? subscriptionId = null, DateTimeOffset? date = null, DateTimeOffset? dateMin = null, DateTimeOffset? dateMax = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null);
        Task<Charge?> ChangeNextChargeDateAsync(long chargeId, ChangeNextChargeDateRequest changeNextChargeDateRequest);
        Task<Charge?> SkipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest);
        Task<Charge?> UnskipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest);
        Task<Charge?> RefundChargeAsync(long chargeId, RefundChargeRequest refundChargeRequest);
        Task<Charge?> TotalRefundChargeAsync(long chargeId, TotalRefundChargeRequest totalRefundChargeRequest);
        Task DeleteChargeAsync(long id);
        Task<Charge?> ProcessChargeAsync(long id);
    }

    public class ChargeService : RechargeSharpService, IChargeService
    {
        public ChargeService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool?> ChargeExistsAsync(long id)
        {
            var response = await GetAsync($"/charges/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Charge?> GetChargeAsync(long id)
        {
            var response = await GetAsync($"/charges/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charge;
        }

        private async Task<IEnumerable<Charge>?> GetChargesAsync(string queryParams)
        {
            var response = await GetAsync($"/charges?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charges;
        }

        public Task<IEnumerable<Charge>?> GetChargesAsync(int page = 1, int limit = 50, long? discountId = null, string? discountCode = null, string? status = null, long? customerId = null, long? addressId = null, long? shopifyOrderId = null, long? subscriptionId = null, DateTimeOffset? date = null, DateTimeOffset? dateMin = null, DateTimeOffset? dateMax = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += discountId != null ? $"&discount_id={discountId}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += shopifyOrderId != null ? $"&shopify_order_id={shopifyOrderId}" : "";
            queryParams += subscriptionId != null ? $"&subscription_id={subscriptionId}" : "";
            queryParams += date != null ? $"&date={date?.ToString("s")}" : "";
            queryParams += dateMin != null ? $"&date_min={dateMin?.ToString("s")}" : "";
            queryParams += dateMax != null ? $"&date_max={dateMax?.ToString("s")}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetChargesAsync(queryParams);
        }

        public Task<IEnumerable<Charge>> GetAllChargesWithParamsAsync(long? discountId = null, string? discountCode = null, string? status = null, long? customerId = null, long? addressId = null, long? shopifyOrderId = null, long? subscriptionId = null, DateTimeOffset? date = null, DateTimeOffset? dateMin = null, DateTimeOffset? dateMax = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += discountId != null ? $"&discount_id={discountId}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += shopifyOrderId != null ? $"&shopify_order_id={shopifyOrderId}" : "";
            queryParams += subscriptionId != null ? $"&subscription_id={subscriptionId}" : "";
            queryParams += date != null ? $"&date={date?.ToString("s")}" : "";
            queryParams += dateMin != null ? $"&date_min={dateMin?.ToString("s")}" : "";
            queryParams += dateMax != null ? $"&date_max={dateMax?.ToString("s")}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetAllChargesAsync(queryParams);
        }

        private async Task<IEnumerable<Charge>> GetAllChargesAsync(string queryParams)
        {
            var count = await CountChargesAsync(queryParams);

            var taskList = new List<Task<IEnumerable<Charge>?>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetChargesAsync($"page={i}&limit=250{queryParams}"));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Charge>();

            foreach (var charges in computed)
            {
                if (charges is null)
                {
                    continue;
                }
                result.AddRange(charges);
            }

            return result;
        }

        public async Task<long?> CountChargesAsync(long? discountId = null, string? discountCode = null, string? status = null, long? customerId = null, long? addressId = null, long? shopifyOrderId = null, long? subscriptionId = null, DateTimeOffset? date = null, DateTimeOffset? dateMin = null, DateTimeOffset? dateMax = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += discountId != null ? $"&discount_id={discountId}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += shopifyOrderId != null ? $"&shopify_order_id={shopifyOrderId}" : "";
            queryParams += subscriptionId != null ? $"&subscription_id={subscriptionId}" : "";
            queryParams += date != null ? $"&date={date?.ToString("s")}" : "";
            queryParams += dateMin != null ? $"&date_min={dateMin?.ToString("s")}" : "";
            queryParams += dateMax != null ? $"&date_max={dateMax?.ToString("s")}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return await CountChargesAsync(queryParams).ConfigureAwait(false);
        }

        private async Task<long?> CountChargesAsync(string queryParams)
        {
            var response = await GetAsync($"/charges/count?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Count;
        }

        public async Task<Charge?> ChangeNextChargeDateAsync(long chargeId, ChangeNextChargeDateRequest changeNextChargeDateRequest)
        {
            ValidateModel(changeNextChargeDateRequest);

            var response = await PostAsJsonAsync($"/charges/{chargeId}/change_next_charge_date", JsonConvert.SerializeObject(changeNextChargeDateRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charge;
        }

        public async Task<Charge?> SkipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest)
        {
            ValidateModel(skipNextChargeRequest);

            var response = await PostAsJsonAsync($"/charges/{chargeId}/skip", JsonConvert.SerializeObject(skipNextChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charge;
        }

        public async Task<Charge?> UnskipNextChargeAsync(long chargeId, SkipNextChargeRequest skipNextChargeRequest)
        {
            ValidateModel(skipNextChargeRequest);

            var response = await PostAsJsonAsync($"/charges/{chargeId}/unskip", JsonConvert.SerializeObject(skipNextChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charge;
        }

        public async Task<Charge?> RefundChargeAsync(long chargeId, RefundChargeRequest refundChargeRequest)
        {
            ValidateModel(refundChargeRequest);

            var response = await PostAsJsonAsync($"/charges/{chargeId}/refund", JsonConvert.SerializeObject(refundChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charge;
        }

        public async Task<Charge?> TotalRefundChargeAsync(long chargeId, TotalRefundChargeRequest totalRefundChargeRequest)
        {
            ValidateModel(totalRefundChargeRequest);

            var response = await PostAsJsonAsync($"/charges/{chargeId}/refund", JsonConvert.SerializeObject(totalRefundChargeRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charge;
        }

        public async Task DeleteChargeAsync(long id)
        {
            _ = await DeleteAsync($"/charges/{id}").ConfigureAwait(false);
        }

        public async Task<Charge?> ProcessChargeAsync(long id)
        {
            var response = await PostAsJsonAsync($"/charges/{id}/process", "{}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ChargeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Charge;
        }
    }
}
