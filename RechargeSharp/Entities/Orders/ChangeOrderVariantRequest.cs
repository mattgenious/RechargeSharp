using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Orders
{
    public class ChangeOrderVariantRequest
    {
        [JsonProperty("new_shopify_variant_id")]
        public string NewShopifyVariantId { get; set; }
    }
}
