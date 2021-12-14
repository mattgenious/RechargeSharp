using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Utilities;
using Address = RechargeSharp.Entities.Addresses.Address;

namespace RechargeSharp.Services.Addresses
{
    public class AddressService : RechargeSharpService
    {
        public AddressService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> AddressExistsAsync(long id)
        {
            var response = await GetAsync($"/addresses/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Address?> GetAddressAsync(long id)
        {
            var response = await GetAsync($"/addresses/{id}").ConfigureAwait(false);
            if(!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Address;
        }

        public async Task<IEnumerable<Address>?> GetAllAddressesForCustomerAsync(long customerId)
        {
            var response = await GetAsync($"/customers/{customerId}/addresses").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Addresses;
        }

        private async Task<IEnumerable<Address>?> GetAddressesAsync(string queryParams)
        {
            var response = await GetAsync($"/addresses?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Addresses;
        }

        public Task<IEnumerable<Address>?> GetAddressesAsync(int page = 1, int limit = 50, long? discountId = null, string? discountCode = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += discountId != null ? $"&discount_id={discountId}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetAddressesAsync(queryParams);
        }

        public Task<IEnumerable<Address>> GetAllAddressesWithParamsAsync(long? discountId = null, string? discountCode = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += discountId != null ? $"&discount_id={discountId}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetAllAddressesAsync(queryParams);
        }

        private async Task<IEnumerable<Address>> GetAllAddressesAsync(string queryParams)
        {
            var count = await CountAddressesAsync(queryParams);

            var taskList = new List<Task<IEnumerable<Address>?>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetAddressesAsync($"page={i}&limit=250{queryParams}"));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Address>();

            foreach (var addresses in computed)
            {
                if (addresses is null)
                    continue;
                result.AddRange(addresses);
            }

            return result;
        }

        public async Task<long?> CountAddressesAsync(long? discountId = null, string? discountCode = null, DateTimeOffset? createdAtMin = null, DateTimeOffset? createdAtMax = null, DateTimeOffset? updatedAtMin = null, DateTimeOffset? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += discountId != null ? $"&discount_id={discountId}" : "";
            queryParams += discountCode != null ? $"&discount_code={discountCode}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createdAtMax != null ? $"&created_at_max={createdAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return await CountAddressesAsync(queryParams);
        }
        private async Task<long?> CountAddressesAsync(string queryParams)
        {
            var response = await GetAsync($"/addresses/count?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Count;
        }

        public async Task<Address?> CreateAddressAsync(CreateAddressRequest createAddressRequest, long customerId)
        {
            ValidateModel(createAddressRequest);

            var response = await PostAsJsonAsync($"/customers/{customerId}/addresses", JsonConvert.SerializeObject(createAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Address;
        }

        public async Task<Address?> UpdateAddressAsync(long id, UpdateAddressRequest updateAddressRequest)
        {
            ValidateModel(updateAddressRequest);

            var response = await PutAsJsonAsync($"/addresses/{id}", JsonConvert.SerializeObject(updateAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Address;
        }
        public async Task<Address?> OverrideShippingLines(long id, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            ValidateModel(overrideShippingLinesRequest);

            var response = await PutAsJsonAsync($"/addresses/{id}", JsonConvert.SerializeObject(overrideShippingLinesRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Address;
        }

        public async Task<ValidateAddressResponse?> ValidateAddress(ValidateAddressRequest validateAddressRequest)
        {
            ValidateModel(validateAddressRequest);

            var response = await PostAsJsonAsync("/addresses/validate", JsonConvert.SerializeObject(validateAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ValidateAddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter());
        }

        public async Task DeleteAddressAsync(long id)
        {
            _ = await DeleteAsync($"/addresses/{id}").ConfigureAwait(false);
        }


    }
}
