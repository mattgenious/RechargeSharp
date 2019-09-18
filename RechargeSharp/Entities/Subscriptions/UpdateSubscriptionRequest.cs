using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Subscriptions
{
    public class UpdateSubscriptionRequest
    {
        [JsonProperty("address_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? AddressId { get; set; }

        [JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NextChargeScheduledAt { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("shopify_variant_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("sku_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkuOverride { get; set; }

        [JsonProperty("number_charges_until_expiration", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberChargesUntilExpiration { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Properties { get; set; }
        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("order_interval_frequency")]
        public long OrderIntervalFrequency { get; set; }

        [JsonProperty("charge_interval_frequency")]
        public long ChargeIntervalFrequency { get; set; }
    }
}
