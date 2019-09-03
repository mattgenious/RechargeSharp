using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Metafields;

namespace RechargeSharp.Services.Metafields
{
    public class MetafieldService : RechargeSharpService
    {
        public MetafieldService(string apiKey) : base(apiKey)
        {
        }

        public async Task<Metafield> GetMetafieldAsync(string id)
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

        public Task<IEnumerable<Metafield>> GetMetafieldsAsync(string owner_resource = "store", string _namespace  = null, string owner_id = null)
        {
            var queryParams = $"owner_resource={owner_resource}";
            queryParams += _namespace != null ? $"&namespace={_namespace}" : "";
            queryParams += owner_id != null ? $"&owner_id={owner_id}" : "";

            return GetMetafieldsAsync(queryParams);
        }

        public async Task<Metafield> CreateMetafieldAsync(CreateMetafieldRequest createMetafieldRequest)
        {
            var response = await PostAsync("/metafields", JsonConvert.SerializeObject(createMetafieldRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MetafieldResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Metafield;
        }

        public async Task<Metafield> UpdateMetafieldAsync(string id, UpdateMetafieldRequest updateMetafieldRequest)
        {
            var response = await PutAsync($"/metafields/{id}", JsonConvert.SerializeObject(updateMetafieldRequest)).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MetafieldResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Metafield;
        }

        public async Task DeleteMetafieldAsync(string id)
        {
            var response = await DeleteAsync($"/metafields/{id}").ConfigureAwait(false);
        }
    }
}
