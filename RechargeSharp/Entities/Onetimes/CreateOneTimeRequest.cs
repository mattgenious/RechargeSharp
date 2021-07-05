using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Onetimes
{
    public class CreateOneTimeRequest : IEquatable<CreateOneTimeRequest>
    {
        public bool Equals(CreateOneTimeRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) && Price == other.Price && Quantity == other.Quantity && ShopifyVariantId == other.ShopifyVariantId && ProductTitle == other.ProductTitle && ShopifyProductId == other.ShopifyProductId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateOneTimeRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = NextChargeScheduledAt.GetHashCode();
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShopifyProductId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CreateOneTimeRequest left, CreateOneTimeRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateOneTimeRequest left, CreateOneTimeRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("add_to_next_charge")]
        public bool? AddToNextCharge { get; set; }

        [Required]
        [JsonProperty("next_charge_scheduled_at")]
        public DateTime? NextChargeScheduledAt { get; set; }

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
        public string ProductTitle { get; set; }

        [JsonProperty("shopify_product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyProductId { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Property> Properties { get; set; }
    }
}
