using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutShippingRate : IEquatable<CheckoutShippingRate>
    {
        public bool Equals(CheckoutShippingRate? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return SubtotalPrice == other.SubtotalPrice && TotalPrice == other.TotalPrice && TotalTax == other.TotalTax;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CheckoutShippingRate) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SubtotalPrice, TotalPrice, TotalTax);
        }

        public static bool operator ==(CheckoutShippingRate left, CheckoutShippingRate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckoutShippingRate left, CheckoutShippingRate right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("subtotal_price")]
        public string? SubtotalPrice { get; set; }

        [JsonProperty("total_price")]
        public string? TotalPrice { get; set; }

        [JsonProperty("total_tax")]
        public string? TotalTax { get; set; }
    }
}