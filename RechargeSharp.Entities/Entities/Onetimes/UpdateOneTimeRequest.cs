﻿using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Onetimes
{
    public class UpdateOnetimeRequest : IEquatable<UpdateOnetimeRequest>
    {
        public bool Equals(UpdateOnetimeRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return ProductTitle == other.ProductTitle && VariantTitle == other.VariantTitle && NextChargeScheduledAt == other.NextChargeScheduledAt && Price == other.Price && Quantity == other.Quantity && ShopifyVariantId == other.ShopifyVariantId && Sku == other.Sku;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateOnetimeRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductTitle, VariantTitle, NextChargeScheduledAt, Price, Quantity, ShopifyVariantId, Sku);
        }

        public static bool operator ==(UpdateOnetimeRequest left, UpdateOnetimeRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateOnetimeRequest left, UpdateOnetimeRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProductTitle { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? VariantTitle { get; set; }

        [JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string? NextChargeScheduledAt { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public long? Price { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("shopify_variant_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string? Sku { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Property>? Properties { get; set; }
    }
}
