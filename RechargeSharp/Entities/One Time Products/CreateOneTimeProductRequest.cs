using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.One_Time_Products
{
    public class CreateOneTimeProductRequest : IEquatable<CreateOneTimeProductRequest>
    {
        public bool Equals(CreateOneTimeProductRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) && ProductTitle == other.ProductTitle && Price == other.Price && Quantity == other.Quantity && ShopifyVariantId == other.ShopifyVariantId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateOneTimeProductRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = NextChargeScheduledAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CreateOneTimeProductRequest left, CreateOneTimeProductRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateOneTimeProductRequest left, CreateOneTimeProductRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("next_charge_scheduled_at")]
        public DateTime? NextChargeScheduledAt { get; set; }

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
