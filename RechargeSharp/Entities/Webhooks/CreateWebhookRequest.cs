using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class CreateWebhookRequest
    {
        [JsonProperty("address")]
        public Uri Address { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}
