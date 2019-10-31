using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Subscriptions
{
    public class CreateSubscriptionRequest : IEquatable<CreateSubscriptionRequest>
    {
        public bool Equals(CreateSubscriptionRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId && Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) && ShopifyVariantId == other.ShopifyVariantId && Quantity == other.Quantity && OrderIntervalUnit == other.OrderIntervalUnit && OrderIntervalFrequency == other.OrderIntervalFrequency && NumberChargesUntilExpiration == other.NumberChargesUntilExpiration && ChargeIntervalFrequency == other.ChargeIntervalFrequency && CustomerId == other.CustomerId && Status == other.Status && Nullable.Equals(Price, other.Price) && ProductTitle == other.ProductTitle && OrderDayOfMonth == other.OrderDayOfMonth && OrderDayOfWeek == other.OrderDayOfWeek;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateSubscriptionRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AddressId.GetHashCode();
                hashCode = (hashCode * 397) ^ NextChargeScheduledAt.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ (OrderIntervalUnit != null ? OrderIntervalUnit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrderIntervalFrequency != null ? OrderIntervalFrequency.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NumberChargesUntilExpiration.GetHashCode();
                hashCode = (hashCode * 397) ^ (ChargeIntervalFrequency != null ? ChargeIntervalFrequency.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrderDayOfMonth.GetHashCode();
                hashCode = (hashCode * 397) ^ OrderDayOfWeek.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CreateSubscriptionRequest left, CreateSubscriptionRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateSubscriptionRequest left, CreateSubscriptionRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("address_id")]
        public long? AddressId { get; set; }

        [Required]
        [JsonProperty("next_charge_scheduled_at")]
        public DateTime? NextChargeScheduledAt { get; set; }

        [Required]
        [JsonProperty("shopify_variant_id")]
        public long? ShopifyVariantId { get; set; }

        [Required]
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [Required]
        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [Required]
        [JsonProperty("order_interval_frequency")]
        public string OrderIntervalFrequency { get; set; }

        [JsonProperty("number_charges_until_expiration", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberChargesUntilExpiration { get; set; }

        [Required]
        [JsonProperty("charge_interval_frequency")]
        public string ChargeIntervalFrequency { get; set; }

        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)] 
        public long? CustomerId { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTitle { get; set; }

        [JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> Properties { get; set; }
    }
}
