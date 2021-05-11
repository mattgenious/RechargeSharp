using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.One_Time_Products
{
    public class UpdateOneTimeProductRequest : IEquatable<UpdateOneTimeProductRequest>
    {
        public bool Equals(UpdateOneTimeProductRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ProductTitle == other.ProductTitle && VariantTitle == other.VariantTitle && NextChargeScheduledAt == other.NextChargeScheduledAt && Price == other.Price && Quantity == other.Quantity && ShopifyVariantId == other.ShopifyVariantId && Sku == other.Sku;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateOneTimeProductRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VariantTitle != null ? VariantTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (NextChargeScheduledAt != null ? NextChargeScheduledAt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Sku != null ? Sku.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(UpdateOneTimeProductRequest left, UpdateOneTimeProductRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateOneTimeProductRequest left, UpdateOneTimeProductRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string VariantTitle { get; set; }

        [JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string NextChargeScheduledAt { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public long? Price { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("shopify_variant_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Property> Properties { get; set; }
    }
}
