using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Subscriptions
{
    public class CreateSubscriptionRequest
    {
        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("next_charge_scheduled_at")]
        public DateTimeOffset NextChargeScheduledAt { get; set; }

        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("shopify_variant_id")]
        public long ShopifyVariantId { get; set; }

        [JsonProperty("sku_override")]
        public bool SkuOverride { get; set; }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("order_interval_frequency")]
        public string OrderIntervalFrequency { get; set; }

        [JsonProperty("number_charges_until_expiration", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberChargesUntilExpiration { get; set; }

        [JsonProperty("charge_interval_frequency")]
        public string ChargeIntervalFrequency { get; set; }

        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }
    }
}
