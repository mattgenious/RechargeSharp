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

        public async Task<Collection> GetCollectionAsync(string id)
        {
            var response = await GetAsync($"/collections/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CollectionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Collection;
        }

        public async Task<IEnumerable<Collection>> GetCollectionsAsync()
        {
            var response = await GetAsync($"/collections").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CollectionListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Products;
        }

        public async Task<long> CountCollectionsAsync()
        {
            var response = await GetAsync("/collections/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)).Count;
        }


    }
}
