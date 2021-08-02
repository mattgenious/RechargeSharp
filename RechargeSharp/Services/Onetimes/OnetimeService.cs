using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Onetimes;

namespace RechargeSharp.Services.Onetimes
{
    public class OnetimeService : RechargeSharpService
    {
        public OnetimeService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> OnetimeExistsAsync(long id)
        {
            var response = await GetAsync($"/onetimes/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Onetime> GetOnetimeAsync(long id)
        {
            var response = await GetAsync($"/onetimes/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OnetimeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        private async Task<IEnumerable<Onetime>> GetOnetimesAsync(string queryParams)
        {
            var response = await GetAsync($"/onetimes?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OnetimeListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProducts;
        }

        public Task<IEnumerable<Onetime>> GetOnetimesAsync(long limit = 50, long page = 1, long? customerId = null, long? addressId = null, long? shopifyCustomerId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetOnetimesAsync(queryParams);
        }

        public async Task<Onetime> CreateOnetimeAsync(CreateOnetimeRequest createOneTimeProductRequest, long addressId)
        {
            ValidateModel(createOneTimeProductRequest);

            var response = await PostAsJsonAsync($"/addresses/{addressId}/onetimes", JsonConvert.SerializeObject(createOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OnetimeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task<Onetime> UpdateOnetimeAsync(long id, UpdateOnetimeRequest updateOneTimeProductRequest)
        {
            ValidateModel(updateOneTimeProductRequest);

            var response = await PutAsJsonAsync($"/onetimes/{id}", JsonConvert.SerializeObject(updateOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OnetimeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task DeleteOnetimeAsync(long id)
        {
            var response = await DeleteAsync($"/onetimes/{id}").ConfigureAwait(false);
        }
    }
}
