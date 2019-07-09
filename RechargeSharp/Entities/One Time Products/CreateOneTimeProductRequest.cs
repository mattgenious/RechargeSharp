using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.One_Time_Products
{
    class CreateOneTimeProductRequest
    {
        [JsonProperty("next_charge_scheduled_at")]
        public DateTimeOffset NextChargeScheduledAt { get; set; }

        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("shopify_variant_id")]
        public long ShopifyVariantId { get; set; }

        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }
    }
}
