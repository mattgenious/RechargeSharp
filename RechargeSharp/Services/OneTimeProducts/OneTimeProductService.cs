using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.One_Time_Products;

namespace RechargeSharp.Services.OneTimeProducts
{
    public class OneTimeProductService : RechargeSharpService
    {
        public OneTimeProductService(string apiKey) : base(apiKey)
        {
        }

        public async Task<bool> OneTimeProductExistsAsync(long id)
        {
            var response = await GetAllowNotFoundAsync($"/onetimes/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<OneTimeProduct> GetOneTimeProductAsync(long id)
        {
            var response = await GetAsync($"/onetimes/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeProductResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        private async Task<IEnumerable<OneTimeProduct>> GetOneTimeProductsAsync(string queryParams)
        {
            var response = await GetAsync($"/onetimes?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeProductListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProducts;
        }

        public Task<IEnumerable<OneTimeProduct>> GetOneTimeProductsAsync(long limit = 50, long page = 1, long? customerId = null, long? addressId = null, long? shopifyCustomerId = null, DateTime? createdAtMin = null, DateTime? createAtMax = null, DateTime? updatedAtMin = null, DateTime? updatedAtMax = null)
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

        public async Task<OneTimeProduct> CreateOneTimeProductAsync(CreateOneTimeProductRequest createOneTimeProductRequest)
        {
            ValidateModel(createOneTimeProductRequest);

            var response = await PostAsJsonAsync("/onetimes", JsonConvert.SerializeObject(createOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeProductResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task<OneTimeProduct> UpdateOneTimeProductAsync(long id, UpdateOneTimeProductRequest updateOneTimeProductRequest)
        {
            ValidateModel(updateOneTimeProductRequest);

            var response = await PutAsJsonAsync($"/onetimes/{id}", JsonConvert.SerializeObject(updateOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeProductResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task DeleteOneTimeProductAsync(long id)
        {
            var response = await DeleteAsync($"/onetimes/{id}").ConfigureAwait(false);
        }
    }
}
