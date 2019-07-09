using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class PaymentSourceListResponse
    {
        [JsonProperty("payment_sources")]
        public PaymentSource[] PaymentSources { get; set; }
    }
}
