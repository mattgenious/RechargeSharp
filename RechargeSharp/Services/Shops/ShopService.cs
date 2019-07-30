using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shop;

namespace RechargeSharp.Services.Shops
{
    public class ShopService : RechargeSharpService
    {
        public ShopService(string apiKey) : base(apiKey)
        {
        }

        public async Task<ShopResponse> GetShopAsync(string id)
        {
            var response = await GetAsync($"/shop").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ShopResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
        public async Task<ShippingCountriesResponse> GetShippingCountries(string id)
        {
            var response = await GetAsync($"/shop/shipping_countries").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ShippingCountriesResponse>(
                await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }

    }
}
