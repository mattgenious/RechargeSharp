using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities
{
    public class SubscriptionListJsonResponse
    {
        [JsonProperty("subscriptions")]
        public List<Subscription> Subscriptions { get; set; }
    }
}
