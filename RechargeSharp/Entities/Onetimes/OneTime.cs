using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Onetimes
{
    public class Onetime : IEquatable<Onetime>
    {
        public bool Equals(Onetime other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId && CreatedAt.Equals(other.CreatedAt) && CustomerId == other.CustomerId && Id == other.Id && Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) && Price == other.Price && ProductTitle == other.ProductTitle && Quantity == other.Quantity && RechargeProductId == other.RechargeProductId && ShopifyProductId == other.ShopifyProductId && ShopifyVariantId == other.ShopifyVariantId && Sku == other.Sku && Status == other.Status && UpdatedAt.Equals(other.UpdatedAt) && VariantTitle == other.VariantTitle;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Onetime) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AddressId.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ NextChargeScheduledAt.GetHashCode();
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ RechargeProductId.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyProductId.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Sku != null ? Sku.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (VariantTitle != null ? VariantTitle.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Onetime left, Onetime right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Onetime left, Onetime right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("next_charge_scheduled_at")]
        public DateTimeOffset? NextChargeScheduledAt { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("properties")]
        public IEnumerable<Property> Properties { get; set; }

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
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("variant_title")]
        public string VariantTitle { get; set; }
    }
}
