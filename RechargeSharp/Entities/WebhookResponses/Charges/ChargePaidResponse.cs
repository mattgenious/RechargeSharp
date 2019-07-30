using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class ChargePaidResponse
    {
        [JsonProperty("charge")]
        public WebhookChargePaid Charge { get; set; }
    }
}
