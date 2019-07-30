using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class ChargeMaxRetriesReachedResponse
    {
        [JsonProperty("charge")]
        public WebhookChargeMaxRetriesReached Charge { get; set; }
    }
}
