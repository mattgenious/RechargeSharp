using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class OrderProcessedResponse
    {
        [JsonProperty("order")]
        public WebhookOrder Order { get; set; }
    }
}
