﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Onetimes
{
    public class CreateOnetimeRequest : IEquatable<CreateOnetimeRequest>
    {
        public bool Equals(CreateOnetimeRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) && Price == other.Price && Quantity == other.Quantity && ShopifyVariantId == other.ShopifyVariantId && ProductTitle == other.ProductTitle && ShopifyProductId == other.ShopifyProductId;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateOnetimeRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NextChargeScheduledAt, Price, Quantity, ShopifyVariantId, ProductTitle, ShopifyProductId);
        }

        public static bool operator ==(CreateOnetimeRequest left, CreateOnetimeRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateOnetimeRequest left, CreateOnetimeRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("add_to_next_charge")]
        public bool? AddToNextCharge { get; set; }

        [Required]
        [JsonProperty("next_charge_scheduled_at")]
        public DateTimeOffset? NextChargeScheduledAt { get; set; }

        [Required]
        [JsonProperty("price")]
        public long? Price { get; set; }

        [Required]
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [Required]
        [JsonProperty("shopify_variant_id")]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProductTitle { get; set; }

        [JsonProperty("shopify_product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyProductId { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Property>? Properties { get; set; }
    }
}
