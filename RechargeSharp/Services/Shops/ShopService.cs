using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shop;
using RechargeSharp.Utilities;

namespace RechargeSharp.Services.Shops
{
    public interface IShopService
    {
        Task<bool> ShopExistsAsync();
        Task<Shop?> GetShopAsync();
        Task<IEnumerable<ShippingCountry>?> GetShippingCountries();
    }

    public class ShopService : RechargeSharpService, IShopService
    {
        public ShopService(ILogger<RechargeSharpService> logger, IHttpClientFactory httpClientFactory, IOptions<RechargeServiceOptions> rechargeServiceOptions) : base(logger, httpClientFactory, rechargeServiceOptions)
        {
        }

        public async Task<bool> ShopExistsAsync()
        {
            var response = await GetAsync($"/shop").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<Shop?> GetShopAsync()
        {
            var response = await GetAsync($"/shop").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ShopResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.Shop;
        }
        public async Task<IEnumerable<ShippingCountry>?> GetShippingCountries()
        {
            var response = await GetAsync($"/shop/shipping_countries").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ShippingCountriesResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false), new DateTimeOffsetJsonConverter())?.ShippingCountries;
        }

    }
}
