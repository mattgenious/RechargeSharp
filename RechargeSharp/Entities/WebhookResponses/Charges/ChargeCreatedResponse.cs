using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class ChargeCreatedResponse
    {
        [JsonProperty("charge")]
        public WebhookChargeCreated Charge { get; set; }
    }
}
