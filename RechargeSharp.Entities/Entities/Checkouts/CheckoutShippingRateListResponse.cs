using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutShippingRateListResponse : IEquatable<CheckoutShippingRateListResponse>
    {
        public bool Equals(CheckoutShippingRateListResponse? other)
        {
            if (other is null) return false;
            if (other.ShippingRates is null) return false;
            if (ShippingRates is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return ShippingRates.SequenceEqual(other.ShippingRates);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CheckoutShippingRateListResponse)obj);
        }

        public override int GetHashCode()
        {
            return (ShippingRates != null ? ShippingRates.GetHashCode() : 0);
        }

        public static bool operator ==(CheckoutShippingRateListResponse left, CheckoutShippingRateListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckoutShippingRateListResponse left, CheckoutShippingRateListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("shipping_rates")]
        public IEnumerable<ShippingRate>? ShippingRates { get; set; }
    }
}
