using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class UpdateWebhookRequest
    {
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Address { get; set; }

        [JsonProperty("topic", NullValueHandling = NullValueHandling.Ignore)]
        public string Topic { get; set; }
    }
}
