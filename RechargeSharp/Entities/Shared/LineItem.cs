using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Charge
{
    public class LineItem
    {
        [JsonProperty("grams")]
        public long Grams { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("shopify_product_id")]
        public long ShopifyProductId { get; set; }

        [JsonProperty("shopify_variant_id")]
        public string ShopifyVariantId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }
    }
}