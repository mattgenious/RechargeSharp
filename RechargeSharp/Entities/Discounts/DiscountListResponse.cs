using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    class DiscountListResponse
    {
        [JsonProperty("discounts")]
        public Discount[] Discounts { get; set; }
    }
}
