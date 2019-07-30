using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class WebhookOrderDeleted
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
