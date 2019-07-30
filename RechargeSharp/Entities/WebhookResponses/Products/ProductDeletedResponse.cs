using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Products
{
    public class ProductDeletedResponse
    {
        [JsonProperty("product")]
        public WebhookProductDeleted Product { get; set; }
    }
}
