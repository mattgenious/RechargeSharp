using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Onetimes;

namespace RechargeSharp.Services.OneTimeProducts
{
    public class OneTimeService : RechargeSharpService
    {
        public OneTimeService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> OneTimeProductExistsAsync(long id)
        {
            var response = await GetAsync($"/onetimes/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<OneTime> GetOneTimeProductAsync(long id)
        {
            var response = await GetAsync($"/onetimes/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        private async Task<IEnumerable<OneTime>> GetOneTimeProductsAsync(string queryParams)
        {
            var response = await GetAsync($"/onetimes?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProducts;
        }

        public Task<IEnumerable<OneTime>> GetOneTimeProductsAsync(long limit = 50, long page = 1, long? customerId = null, long? addressId = null, long? shopifyCustomerId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += customerId != null ? $"&customer_id={customerId}" : "";
            queryParams += addressId != null ? $"&address_id={addressId}" : "";
            queryParams += shopifyCustomerId != null ? $"&shopify_customer_id={shopifyCustomerId}" : "";
            queryParams += createdAtMin != null ? $"&created_at_min={createdAtMin?.ToString("s")}" : "";
            queryParams += createAtMax != null ? $"&created_at_max={createAtMax?.ToString("s")}" : "";
            queryParams += updatedAtMin != null ? $"&updated_at_min={updatedAtMin?.ToString("s")}" : "";
            queryParams += updatedAtMax != null ? $"&updated_at_max={updatedAtMax?.ToString("s")}" : "";

            return GetOneTimeProductsAsync(queryParams);
        }

        public async Task<OneTime> CreateOneTimeProductAsync(CreateOneTimeRequest createOneTimeProductRequest, long addressId)
        {
            ValidateModel(createOneTimeProductRequest);

            var response = await PostAsJsonAsync($"/addresses/{addressId}/onetimes", JsonConvert.SerializeObject(createOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task<OneTime> UpdateOneTimeProductAsync(long id, UpdateOneTimeRequest updateOneTimeProductRequest)
        {
            ValidateModel(updateOneTimeProductRequest);

            var response = await PutAsJsonAsync($"/onetimes/{id}", JsonConvert.SerializeObject(updateOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task DeleteOneTimeProductAsync(long id)
        {
            var response = await DeleteAsync($"/onetimes/{id}").ConfigureAwait(false);
        }
    }
}
