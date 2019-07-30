using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Subscriptions
{
    public class WebhookSubscriptionDeleted
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
