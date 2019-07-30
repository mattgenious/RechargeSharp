using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class OrderDeletedResponse
    {
        [JsonProperty("order")]
        public WebhookOrderDeleted Order { get; set; }
    }
}
