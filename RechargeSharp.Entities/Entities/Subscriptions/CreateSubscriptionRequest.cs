using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Subscriptions
{
    public class CreateSubscriptionRequest : IEquatable<CreateSubscriptionRequest>
    {
        public bool Equals(CreateSubscriptionRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId && Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) && ShopifyVariantId == other.ShopifyVariantId && Quantity == other.Quantity && OrderIntervalUnit == other.OrderIntervalUnit && OrderIntervalFrequency == other.OrderIntervalFrequency && NumberChargesUntilExpiration == other.NumberChargesUntilExpiration && ChargeIntervalFrequency == other.ChargeIntervalFrequency && CustomerId == other.CustomerId && Status == other.Status && Nullable.Equals(Price, other.Price) && ProductTitle == other.ProductTitle && OrderDayOfMonth == other.OrderDayOfMonth && OrderDayOfWeek == other.OrderDayOfWeek;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateSubscriptionRequest) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(AddressId);
            hash.Add(NextChargeScheduledAt);
            hash.Add(ShopifyVariantId);
            hash.Add(Quantity);
            hash.Add(OrderIntervalUnit);
            hash.Add(OrderIntervalFrequency);
            hash.Add(NumberChargesUntilExpiration);
            hash.Add(ChargeIntervalFrequency);
            hash.Add(CustomerId);
            hash.Add(Status);
            hash.Add(Price);
            hash.Add(ProductTitle);
            hash.Add(OrderDayOfMonth);
            hash.Add(OrderDayOfWeek);
            return hash.ToHashCode();
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
        public DateTimeOffset? NextChargeScheduledAt { get; set; }

        [Required]
        [JsonProperty("shopify_variant_id")]
        public long? ShopifyVariantId { get; set; }

        [Required]
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [Required]
        [JsonProperty("order_interval_unit")]
        public string? OrderIntervalUnit { get; set; }

        [Required]
        [JsonProperty("order_interval_frequency")]
        public string? OrderIntervalFrequency { get; set; }

        [JsonProperty("number_charges_until_expiration", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberChargesUntilExpiration { get; set; }

        [Required]
        [JsonProperty("charge_interval_frequency")]
        public string? ChargeIntervalFrequency { get; set; }

        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)] 
        public long? CustomerId { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string? Status { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        [JsonProperty("product_title", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProductTitle { get; set; }

        [JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Property>? Properties { get; set; }
    }
}
