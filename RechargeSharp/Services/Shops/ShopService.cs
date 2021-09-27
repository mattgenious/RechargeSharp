using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shop;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Shops
{
    public class ShopService : RechargeSharpService
    {
        public ShopService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> ShopExistsAsync()
        {
            var response = await GetAsync($"/shop").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Shop> GetShopAsync()
        {
            var response = await GetAsync($"/shop").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ShopResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeJsonConverter()).Shop;
        }
        public async Task<IEnumerable<ShippingCountry>> GetShippingCountries()
        {
            var response = await GetAsync($"/shop/shipping_countries").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ShippingCountriesResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeJsonConverter()).ShippingCountries;
        }

    }
}
