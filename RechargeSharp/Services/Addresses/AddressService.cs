using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Addresses;
using RechargeSharp.Entities.Shared;
using Address = RechargeSharp.Entities.Addresses.Address;

namespace RechargeSharp.Services.Addresses
{
    public class AddressService : RechargeSharpService
    {
        protected AddressService(string apiKey) : base(apiKey)
        {
        }

        public async Task<AddressResponse> GetAddressAsync(string id)
        {
            var response = await GetAsync($"/addresses/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        private async Task<AddressListResponse> GetAddressesAsync(string queryParams)
        {
            var response = await GetAsync($"/addresses?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public Task<AddressListResponse> GetAddressesAsync(int page = 1, int limit = 50, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";


            return GetAddressesAsync(queryParams);
        }

        public async Task<AddressResponse> CreateAddressAsync(CreateAddressRequest createAddressRequest)
        {
            var response = await PostAsync("/addresses", JsonConvert.SerializeObject(createAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<AddressResponse> UpdateAddressAsync(string id, UpdateAddressRequest updateAddressRequest)
        {
            var response = await PutAsync($"/addresses/{id}", JsonConvert.SerializeObject(updateAddressRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
        public async Task<AddressResponse> OverrideShippingLines(string id, OverrideShippingLinesRequest overrideShippingLinesRequest)
        {
            var response = await PutAsync($"/addresses/{id}", JsonConvert.SerializeObject(overrideShippingLinesRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<AddressResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
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
