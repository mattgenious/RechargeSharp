using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Products;

namespace RechargeSharp.Services.Products
{
    public class ProductService : RechargeSharpService
    {
        public ProductService(string apiKey) : base(apiKey)
        {
        }
        public async Task<Product> GetProductAsync(string id)
        {
            var response = await GetAsync($"/products/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProductResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Product;
        }

        private async Task<IEnumerable<Product>> GetProductsAsync(string queryParams)
        {
            var response = await GetAsync($"/products?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProductListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Products;
        }

        public Task<IEnumerable<Product>> GetProductsAsync(int page = 1, int limit = 50, List<string> id = null, List<string> shopifyProductId = null, string collectionId = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += collectionId != null ? $"&collection_id={collectionId}" : "";
            queryParams += id != null ? $"&ids={string.Join(",", id)}" : "";
            queryParams += shopifyProductId != null ? $"&shopify_product_ids={string.Join(",", shopifyProductId)}" : "";


            return GetProductsAsync(queryParams);
        }

        public Task<IEnumerable<Product>> GetAllProductsWithParamsAsync(List<string> id = null, List<string> shopifyProductId = null, string collectionId = null)
        {
            var queryParams = "";
            queryParams += collectionId != null ? $"&collection_id={collectionId}" : "";
            queryParams += id != null ? $"&ids={string.Join(",", id)}" : "";
            queryParams += shopifyProductId != null ? $"&shopify_product_ids={string.Join(",", shopifyProductId)}" : "";

            return GetProductsRecAsync(queryParams, 1, new ProductListResponse() { Products = new List<Product>() });
        }

        private async Task<IEnumerable<Product>> GetProductsRecAsync(string queryParams, int page, ProductListResponse accumulator)
        {
            var response = await GetAsync($"/products?page={page}&limit=250{queryParams}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<ProductListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            if (result.Products.Count == 0)
            {
                return accumulator.Products;
            }
            else
            {
                page++;
                accumulator.Products.AddRange(result.Products);
                return await GetProductsRecAsync(queryParams, page, accumulator).ConfigureAwait(false);
            }
        }
    }
}
