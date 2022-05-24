﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Products;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Products
{
    public interface IProductService
    {
        Task<bool> ProductExistsAsync(long id);
        Task<Product?> GetProductAsync(long id);
        Task<IEnumerable<Product>?> GetProductsAsync(int page = 1, int limit = 50, List<long>? id = null, List<long>? shopifyProductId = null, string? collectionId = null);
        Task<IEnumerable<Product>> GetAllProductsWithParamsAsync(List<long>? id = null, List<long>? shopifyProductId = null, string? collectionId = null);
        Task<long?> CountProducts(long? collectionId = null, string? storefrontPurchaseOptions = null);
    }

    public class ProductService : RechargeSharpService, IProductService
    {
        public ProductService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> ProductExistsAsync(long id)
        {
            var response = await GetAsync($"/products/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
        public async Task<Product?> GetProductAsync(long id)
        {
            var response = await GetAsync($"/products/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProductResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Product;
        }

        private async Task<IEnumerable<Product>?> GetProductsAsync(string queryParams)
        {
            var response = await GetAsync($"/products?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProductListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Products;
        }

        public Task<IEnumerable<Product>?> GetProductsAsync(int page = 1, int limit = 50, List<long>? id = null, List<long>? shopifyProductId = null, string? collectionId = null)
        {
            var queryParams = $"page={page}&limit={limit}";
            queryParams += collectionId != null ? $"&collection_id={collectionId}" : "";
            queryParams += id != null && id.Count != 0 ? $"&ids={string.Join(",", id)}" : "";
            queryParams += shopifyProductId != null && shopifyProductId.Count != 0 ? $"&shopify_product_ids={string.Join(",", shopifyProductId)}" : "";


            return GetProductsAsync(queryParams);
        }

        public Task<IEnumerable<Product>> GetAllProductsWithParamsAsync(List<long>? id = null, List<long>? shopifyProductId = null, string? collectionId = null)
        {
            var queryParams = "";
            queryParams += collectionId != null ? $"&collection_id={collectionId}" : "";
            queryParams += id != null && id.Count != 0 ? $"&ids={string.Join(",", id)}" : "";
            queryParams += shopifyProductId != null && shopifyProductId.Count != 0 ? $"&shopify_product_ids={string.Join(",", shopifyProductId)}" : "";

            return GetProductsRecAsync(queryParams, 1, new ProductListResponse() { Products = new List<Product>() });
        }

        private async Task<IEnumerable<Product>> GetProductsRecAsync(string queryParams, int page, ProductListResponse accumulator)
        {
            var accumulatorProducts = accumulator.Products.ToList();

            var response = await GetAsync($"/products?page={page}&limit=250{queryParams}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<ProductListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter());
            if (!result?.Products?.Any() ?? false)
            {
                return accumulator.Products;
            }
            else
            {
                page++;
                if (result is not null)
                {
                    accumulatorProducts.AddRange(result.Products);
                }
                accumulator.Products = accumulatorProducts;
                return await GetProductsRecAsync(queryParams, page, accumulator).ConfigureAwait(false);
            }
        }

        public async Task<long?> CountProducts(long? collectionId = null, string? storefrontPurchaseOptions = null)
        {
            var queryParams = $"";
            queryParams += collectionId != null ? $"&collection_id={collectionId}" : "";
            queryParams += storefrontPurchaseOptions != null ? $"&storefront_purchase_options={storefrontPurchaseOptions}" : "";

            return await CountProducts(queryParams);
        }

        private async Task<long?> CountProducts(string queryParams)
        {
            var response = await GetAsync($"/metafields/count?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Count;
        }
    }
}
