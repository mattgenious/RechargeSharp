using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class ShippingRateCheckout
    {
        [JsonProperty("subtotal_price")]
        public string SubtotalPrice { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }
    }
}