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
        protected OneTimeProductService(string apiKey) : base(apiKey)
        {
        }

        public async Task<OneTimeProduct> GetOneTimeProductAsync(string id)
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

        public Task<IEnumerable<OneTimeProduct>> GetOneTimeProductsAsync(string owner_resource = "store", string _namespace = null, string owner_id = null)
        {
            var queryParams = $"owner_resource={owner_resource}";
            queryParams += _namespace != null ? $"&namespace={_namespace}" : "";
            queryParams += owner_id != null ? $"&owner_id={owner_id}" : "";

            return GetOneTimeProductsAsync(queryParams);
        }

        public async Task<OneTimeProduct> CreateOneTimeProductAsync(CreateOneTimeProductRequest createOneTimeProductRequest)
        {
            var response = await PostAsync("/onetimes", JsonConvert.SerializeObject(createOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeProductResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task<OneTimeProduct> UpdateOneTimeProductAsync(string id, UpdateOneTimeProductRequest updateOneTimeProductRequest)
        {
            var response = await PutAsync($"/onetimes/{id}", JsonConvert.SerializeObject(updateOneTimeProductRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<OneTimeProductResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).OneTimeProduct;
        }

        public async Task DeleteOneTimeProductAsync(string id)
        {
            var response = await DeleteAsync($"/onetimes/{id}").ConfigureAwait(false);
        }
    }
}
