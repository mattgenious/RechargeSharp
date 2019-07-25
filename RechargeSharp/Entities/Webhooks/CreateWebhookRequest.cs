using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class CreateWebhookRequest
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}
