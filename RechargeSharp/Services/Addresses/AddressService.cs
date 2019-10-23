using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Shared;
using Address = RechargeSharp.Entities.Addresses.Address;

namespace RechargeSharp.Services.Addresses
{
    public class AddressService : RechargeSharpService
    {
        public AddressService(string apiKey) : base(apiKey)
        {
        }

        public async Task<Address> GetAddressAsync(string id)
        {
            var response = await GetAsync($"/addresses/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Address;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesForCustomerAsync(string customerId)
        {
            var response = await GetAsync($"/customers/{customerId}/addresses").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Addresses;
        }

        private async Task<IEnumerable<Address>> GetAddressesAsync(string queryParams)
        {
            var response = await GetAsync($"/addresses?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Addresses;
        }

        public Task<IEnumerable<Address>> GetAddressesAsync(int page = 1, int limit = 50, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetAddressesAsync(queryParams);
        }

        public Task<IEnumerable<Address>> GetAllAddressesWithParamsAsync(string email = null, string status = null, string shopifyCustomerId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null, string hash = null)
        {
            var queryParams = "";
            queryParams += email != null ? $"&email={email}" : "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";
            queryParams += hash != null ? $"&hash={hash}" : "";

            return GetAllAddressesAsync(queryParams);
        }

        private async Task<IEnumerable<Address>> GetAllAddressesAsync(string queryParams)
        {
            var count = await CountAddressesAsync(queryParams);

            var taskList = new List<Task<IEnumerable<Address>>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetAddressesAsync($"page={i}&limit=250" + queryParams));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Address>();

            foreach (var addresses in computed)
            {
                result.AddRange(addresses);
            }

            return result;
        }

        public async Task<long> CountAddressesAsync(string status = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = "";
            queryParams += status != null ? $"&status={status}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return await CountAddressesAsync(queryParams);
        }
        private async Task<long> CountAddressesAsync(string queryParams)
        {
            var response = await GetAsync($"/addresses/count?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Count;
        }

        public async Task<Address> CreateAddressAsync(CreateAddressRequest createAddressRequest, string customerId)
        {
            var response = await PostAsJsonAsync($"/customers/{customerId}/addresses", JsonConvert.SerializeObject(createAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Address;
        }

        public async Task<Address> UpdateAddressAsync(string id, UpdateAddressRequest updateAddressRequest)
        {
            var response = await PutAsync($"/addresses/{id}", JsonConvert.SerializeObject(updateAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Address;
        }
        public async Task<Address> OverrideShippingLines(string id, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            var response = await PutAsync($"/addresses/{id}", JsonConvert.SerializeObject(overrideShippingLinesRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Address;
        }

        public async Task<ValidateAddressResponse> ValidateAddress(ValidateAddressRequest validateAddressRequest)
        {
            var response = await PostAsync("/addresses/validate", JsonConvert.SerializeObject(validateAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ValidateAddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task DeleteAddressAsync(string id)
        {
            var response = await DeleteAsync($"/addresses/{id}").ConfigureAwait(false);
        }
    }
}
