using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscription
{
    public class SubscriptionListResponse
    {
        [JsonProperty("subscriptions")]
        public List<Subscription> Subscriptions { get; set; }
    }
}
