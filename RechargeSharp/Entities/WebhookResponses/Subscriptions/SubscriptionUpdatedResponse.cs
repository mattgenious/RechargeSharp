using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class SubscriptionUpdatedResponse
    {
        [JsonProperty("subscription")]
        public WebhookSubscription Subscription { get; set; }
    }
}
