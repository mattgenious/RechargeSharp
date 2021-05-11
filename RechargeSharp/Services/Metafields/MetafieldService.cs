using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Metafields;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Metafields
{
    public class MetafieldService : RechargeSharpService
    {
        public MetafieldService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> MetafieldExistsAsync(long id)
        {
            var response = await GetAsync($"/metafields/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Metafield> GetMetafieldAsync(long id)
        {
            var response = await GetAsync($"/metafields/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MetafieldResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Metafield;
        }

        private async Task<IEnumerable<Metafield>> GetMetafieldsAsync(string queryParams)
        {
            var response = await GetAsync($"/metafields?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MetafieldListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Metafields;
        }

        public Task<IEnumerable<Metafield>> GetMetafieldsAsync(long limit = 50, long page = 1, string ownerResource = "store", string _namespace  = null, long? ownerId = null)
        {
            var queryParams = $"page={page}&limit={limit}&owner_resource={ownerResource}";
            queryParams += _namespace != null ? $"&namespace={_namespace}" : "";
            queryParams += ownerId != null ? $"&owner_id={ownerId}" : "";

            return GetMetafieldsAsync(queryParams);
        }

        public Task<IEnumerable<Metafield>> GetAllMetafieldsWithParamsAsync(string ownerResource = "store", string _namespace = null, long? ownerId = null)
        {
            var queryParams = $"&owner_resource={ownerResource}";
            queryParams += _namespace != null ? $"&namespace={_namespace}" : "";
            queryParams += ownerId != null ? $"&owner_id={ownerId}" : "";

            return GetAllCustomersAsync(queryParams);
        }

        private async Task<IEnumerable<Metafield>> GetAllCustomersAsync(string queryParams)
        {
            var count = await CountMetafields(queryParams);

            var taskList = new List<Task<IEnumerable<Metafield>>>();

            var pages = Math.Ceiling(Convert.ToDouble(count) / 250d);

            for (int i = 1; i <= Convert.ToInt32(pages); i++)
            {
                taskList.Add(GetMetafieldsAsync($"page={i}&limit=250" + queryParams));
            }

            var computed = await Task.WhenAll(taskList);

            var result = new List<Metafield>();

            foreach (var metafields in computed)
            {
                result.AddRange(metafields);
            }

            return result;
        }

        public async Task<Metafield> CreateMetafieldAsync(CreateMetafieldRequest createMetafieldRequest)
        {
            ValidateModel(createMetafieldRequest);

            var response = await PostAsJsonAsync($"/metafields?owner_resource={createMetafieldRequest.MetafieldObject.OwnerResource}", JsonConvert.SerializeObject(createMetafieldRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MetafieldResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Metafield;
        }

        public async Task<Metafield> UpdateMetafieldAsync(long id, UpdateMetafieldRequest updateMetafieldRequest)
        {
            ValidateModel(updateMetafieldRequest);

            var response = await PutAsJsonAsync($"/metafields/{id}", JsonConvert.SerializeObject(updateMetafieldRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MetafieldResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Metafield;
        }

        public async Task DeleteMetafieldAsync(long id)
        {
            var response = await DeleteAsync($"/metafields/{id}").ConfigureAwait(false);
        }

        public async Task<long> CountMetafields(long limit = 50, long page = 1, string ownerResource = "store", string _namespace = null, long? owner_id = null)
        {
            var queryParams = $"page={page}&limit={limit}&owner_resource={ownerResource}";
            queryParams += _namespace != null ? $"&namespace={_namespace}" : "";
            queryParams += owner_id != null ? $"&owner_id={owner_id}" : "";

            return await CountMetafields(queryParams);
        }

        private async Task<long> CountMetafields(string queryParams)
        {
            var response = await GetAsync($"/metafields/count?{queryParams}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Count;
        }
    }
}
