using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class ShopResponse
    {
        [JsonProperty("shop")]
        public Shop Shop { get; set; }
    }
}
