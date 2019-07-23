using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.One_Time_Products
{
    public class UpdateOneTimeProductRequest
    {
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string VariantTitle { get; set; }

        [JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string NextChargeScheduledAt { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public long? Price { get; set; }

        [JsonProperty("shopify_variant_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Property Properties { get; set; }
    }
}
