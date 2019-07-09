using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class ProcessCheckoutRequest
    {
        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("payment_token")]
        public string PaymentToken { get; set; }
    }
}
