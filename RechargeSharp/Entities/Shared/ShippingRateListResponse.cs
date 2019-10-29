using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class ShippingRateListResponse : IEquatable<ShippingRateListResponse>
    {
        public bool Equals(ShippingRateListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ShippingRates.SequenceEqual(other.ShippingRates);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShippingRateListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (ShippingRates != null ? ShippingRates.GetHashCode() : 0);
        }

        public static bool operator ==(ShippingRateListResponse left, ShippingRateListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShippingRateListResponse left, ShippingRateListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("shipping_rates")]
        public List<ShippingRate> ShippingRates { get; set; }
    }
}
