using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class SkipNextChargeRequestWithMultipleSubscriptionIds : ISkipNextChargeRequest
    {
        [Required]
        [JsonProperty("subscription_ids")]
        public string[]? SubscriptionIds { get; set; }
    }
}
