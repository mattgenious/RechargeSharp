using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Products
{
    public class ProductSubscriptionDefaults : IEquatable<ProductSubscriptionDefaults>
    {
        public bool Equals(ProductSubscriptionDefaults other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ChargeIntervalFrequency == other.ChargeIntervalFrequency && CutoffDayOfMonth == other.CutoffDayOfMonth && CutoffDayOfWeek == other.CutoffDayOfWeek && ExpireAfterSpecificNumberOfCharges == other.ExpireAfterSpecificNumberOfCharges && Handle == other.Handle && NumberChargesUntilExpiration == other.NumberChargesUntilExpiration && OrderDayOfMonth == other.OrderDayOfMonth && OrderDayOfWeek == other.OrderDayOfWeek && OrderIntervalFrequency == other.OrderIntervalFrequency && OrderIntervalUnit == other.OrderIntervalUnit && StorefrontPurchaseOptions == other.StorefrontPurchaseOptions;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductSubscriptionDefaults) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ChargeIntervalFrequency.GetHashCode();
                hashCode = (hashCode * 397) ^ CutoffDayOfMonth.GetHashCode();
                hashCode = (hashCode * 397) ^ CutoffDayOfWeek.GetHashCode();
                hashCode = (hashCode * 397) ^ ExpireAfterSpecificNumberOfCharges.GetHashCode();
                hashCode = (hashCode * 397) ^ (Handle != null ? Handle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NumberChargesUntilExpiration.GetHashCode();
                hashCode = (hashCode * 397) ^ OrderDayOfMonth.GetHashCode();
                hashCode = (hashCode * 397) ^ (OrderDayOfWeek != null ? OrderDayOfWeek.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrderIntervalFrequency.GetHashCode();
                hashCode = (hashCode * 397) ^ (OrderIntervalUnit != null ? OrderIntervalUnit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StorefrontPurchaseOptions != null ? StorefrontPurchaseOptions.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ProductSubscriptionDefaults left, ProductSubscriptionDefaults right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductSubscriptionDefaults left, ProductSubscriptionDefaults right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("charge_interval_frequency")]
        public long ChargeIntervalFrequency { get; set; }

        [JsonProperty("cutoff_day_of_month")]
        public long CutoffDayOfMonth { get; set; }

        [JsonProperty("cutoff_day_of_week")]
        public long CutoffDayOfWeek { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges")]
        public long ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("number_charges_until_expiration")]
        public long NumberChargesUntilExpiration { get; set; }

        [JsonProperty("order_day_of_month")]
        public long OrderDayOfMonth { get; set; }

        [JsonProperty("order_day_of_week")]
        public string OrderDayOfWeek { get; set; }

        [JsonProperty("order_interval_frequency")]
        public long OrderIntervalFrequency { get; set; }

        [JsonProperty("order_interval_frequency_options")]
        public IEnumerable<long> OrderIntervalFrequencyOptions { get; set; }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("storefront_purchase_options")]
        public string StorefrontPurchaseOptions { get; set; }
    }
}
