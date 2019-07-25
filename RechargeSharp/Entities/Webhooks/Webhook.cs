using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Webhooks
{
    public class Webhook
    {
        [JsonProperty("address")]
        public Uri Address { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("topic")]
        public string Topic { get; set; }
    }
}
