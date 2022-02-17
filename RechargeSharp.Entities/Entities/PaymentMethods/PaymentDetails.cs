using Newtonsoft.Json;

namespace RechargeSharp.Entities.PaymentMethods
{
    public class PaymentDetails
    {
        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string? Brand { get; set; }

        [JsonProperty("exp_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpMonth { get; set; }

        [JsonProperty("exp_year", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpYear { get; set; }

        [JsonProperty("last4", NullValueHandling = NullValueHandling.Ignore)]
        public string? Last4 { get; set; }
    }
}
