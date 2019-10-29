using System;
using System.Collections.Generic;
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
            return AddressId == other.AddressId && Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) && ProductTitle == other.ProductTitle && Price.Equals(other.Price) && Quantity == other.Quantity && ShopifyVariantId == other.ShopifyVariantId && SkuOverride == other.SkuOverride && OrderIntervalUnit == other.OrderIntervalUnit && OrderIntervalFrequency == other.OrderIntervalFrequency && NumberChargesUntilExpiration == other.NumberChargesUntilExpiration && ChargeIntervalFrequency == other.ChargeIntervalFrequency;
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
                hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ SkuOverride.GetHashCode();
                hashCode = (hashCode * 397) ^ (OrderIntervalUnit != null ? OrderIntervalUnit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OrderIntervalFrequency != null ? OrderIntervalFrequency.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ NumberChargesUntilExpiration.GetHashCode();
                hashCode = (hashCode * 397) ^ (ChargeIntervalFrequency != null ? ChargeIntervalFrequency.GetHashCode() : 0);
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

        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("next_charge_scheduled_at")]
        public DateTime? NextChargeScheduledAt { get; set; }

        [JsonProperty("product_title")]
        public string ProductTitle { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("shopify_variant_id")]
        public long ShopifyVariantId { get; set; }

        [JsonProperty("sku_override")]
        public bool SkuOverride { get; set; }

        [JsonProperty("order_interval_unit")]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("order_interval_frequency")]
        public string OrderIntervalFrequency { get; set; }

        [JsonProperty("number_charges_until_expiration", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberChargesUntilExpiration { get; set; }

        [JsonProperty("charge_interval_frequency")]
        public string ChargeIntervalFrequency { get; set; }

        [JsonProperty("properties")]
        public List<Property> Properties { get; set; }
    }
}
