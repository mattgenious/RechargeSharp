using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class UpdateLineItemRequestLineItem : IEquatable<UpdateLineItemRequestLineItem>
    {
        public bool Equals(UpdateLineItemRequestLineItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Price == other.Price && ProductTitle == other.ProductTitle && Properties.SequenceEqual(other.Properties) && Quantity == other.Quantity && ProductId == other.ProductId && VariantId == other.VariantId && Sku == other.Sku && SubscriptionId == other.SubscriptionId && Title == other.Title && VariantTitle == other.VariantTitle && Grams == other.Grams && Vendor == other.Vendor;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateLineItemRequestLineItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Price != null ? Price.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Properties != null ? Properties.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ ProductId.GetHashCode();
                hashCode = (hashCode * 397) ^ VariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Sku != null ? Sku.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SubscriptionId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VariantTitle != null ? VariantTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Grams.GetHashCode();
                hashCode = (hashCode * 397) ^ (Vendor != null ? Vendor.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(UpdateLineItemRequestLineItem left, UpdateLineItemRequestLineItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateLineItemRequestLineItem left, UpdateLineItemRequestLineItem right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Properties { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("variant_id")]
        public long VariantId { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("subscription_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? SubscriptionId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string VariantTitle { get; set; }

        [JsonProperty("grams", NullValueHandling = NullValueHandling.Ignore)]
        public long? Grams { get; set; }

        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public string Vendor { get; set; }
    }
}
