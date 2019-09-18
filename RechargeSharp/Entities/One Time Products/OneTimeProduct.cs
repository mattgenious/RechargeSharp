using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.One_Time_Products
{
    public class OneTimeProduct
    {
        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("next_charge_scheduled_at")]
        public DateTime? NextChargeScheduledAt { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("recharge_product_id")]
        public long RechargeProductId { get; set; }

        [JsonProperty("shopify_product_id")]
        public long ShopifyProductId { get; set; }

        [JsonProperty("shopify_variant_id")]
        public long ShopifyVariantId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }
    }
}
