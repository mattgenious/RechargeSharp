using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class SubscriptionResponse
    {
        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
    }
}
