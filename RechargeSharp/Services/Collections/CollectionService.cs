using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Collections;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Services.Collections
{
    public class CollectionService : RechargeSharpService
    {
        public CollectionService(string apiKey) : base(apiKey)
        {
        }

        public async Task<CollectionResponse> GetCollectionAsync(string id)
        {
            var response = await GetAsync($"/collections/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CollectionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<CollectionListResponse> GetCollectionsAsync()
        {
            var response = await GetAsync($"/collections").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CollectionListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

        public async Task<CountResponse> CountCollectionsAsync()
        {
            var response = await GetAsync("/collections/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }


    }
}
