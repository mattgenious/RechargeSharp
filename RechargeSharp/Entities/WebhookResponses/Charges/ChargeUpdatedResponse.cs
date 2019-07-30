using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class ChargeUpdatedResponse
    {
        [JsonProperty("charge")]
        public WebhookChargeUpdated Charge { get; set; }
    }
}
