using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Subscriptions
{
    public class UpdateSubscriptionRequest : IEquatable<UpdateSubscriptionRequest>
    {
        public bool Equals(UpdateSubscriptionRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return OrderIntervalUnit == other.OrderIntervalUnit && OrderIntervalFrequency == other.OrderIntervalFrequency && ChargeIntervalFrequency == other.ChargeIntervalFrequency && ProductTitle == other.ProductTitle && VariantTitle == other.VariantTitle && Nullable.Equals(Price, other.Price) && Quantity == other.Quantity && ShopifyVariantId == other.ShopifyVariantId && OrderDayOfWeek == other.OrderDayOfWeek && OrderDayOfMonth == other.OrderDayOfMonth && ExpireAfterSpecificNumberOfCharges == other.ExpireAfterSpecificNumberOfCharges && Equals(Properties, other.Properties) && Sku == other.Sku && SkuOverride == other.SkuOverride;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateSubscriptionRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (OrderIntervalUnit != null ? OrderIntervalUnit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrderIntervalFrequency.GetHashCode();
                hashCode = (hashCode * 397) ^ ChargeIntervalFrequency.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (VariantTitle != null ? VariantTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ OrderDayOfWeek.GetHashCode();
                hashCode = (hashCode * 397) ^ OrderDayOfMonth.GetHashCode();
                hashCode = (hashCode * 397) ^ ExpireAfterSpecificNumberOfCharges.GetHashCode();
                hashCode = (hashCode * 397) ^ (Properties != null ? Properties.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Sku != null ? Sku.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SkuOverride.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UpdateSubscriptionRequest left, UpdateSubscriptionRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateSubscriptionRequest left, UpdateSubscriptionRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("order_interval_frequency")]
        public long OrderIntervalFrequency { get; set; }

        [JsonProperty("charge_interval_frequency")]
        public long ChargeIntervalFrequency { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string VariantTitle { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Quantity { get; set; }

        [JsonProperty("shopify_variant_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyVariantId { get; set; }

        [JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Properties { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("sku_override", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkuOverride { get; set; }
    }
}
