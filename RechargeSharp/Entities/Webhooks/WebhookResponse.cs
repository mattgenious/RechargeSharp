using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class WebhookResponse
    {
        [JsonProperty("webhook")]
        public Webhook Webhook { get; set; }
    }
}
