using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class SubscriptionListResponse
    {
        [JsonProperty("subscriptions")]
        public List<Subscription> Subscriptions { get; set; }
    }
}
