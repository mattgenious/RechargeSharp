using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class SubscriptionDeletedResponse
    {
        [JsonProperty("subscription")]
        public WebhookSubscriptionDeleted Subscription { get; set; }
    }
}
