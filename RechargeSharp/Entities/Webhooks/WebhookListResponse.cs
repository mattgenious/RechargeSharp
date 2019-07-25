using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class WebhookListResponse
    {
        [JsonProperty("webhooks")]
        public List<Webhook> Webhooks { get; set; }
    }
}
