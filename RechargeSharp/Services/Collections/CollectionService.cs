using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Collections;
using RechargeSharp.Entities.Shared;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Collections
{
    public class CollectionService : RechargeSharpService
    {
        public CollectionService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> CollectionExistsAsync(long id)
        {
            var response = await GetAsync($"/collections/{id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Collection> GetCollectionAsync(long id)
        {
            var response = await GetAsync($"/collections/{id}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CollectionResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Collection;
        }

        public async Task<IEnumerable<Collection>> GetCollectionsAsync()
        {
            var response = await GetAsync($"/collections").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CollectionListResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Products;
        }

        public async Task<long> CountCollectionsAsync()
        {
            var response = await GetAsync("/collections/count").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<CountResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter()).Count;
        }


    }
}
