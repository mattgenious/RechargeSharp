using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses
{
    public class WebhookProductDeleted
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
