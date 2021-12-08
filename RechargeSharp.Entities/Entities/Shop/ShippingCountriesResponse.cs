using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class ShippingCountriesResponse : IEquatable<ShippingCountriesResponse>
    {
        public bool Equals(ShippingCountriesResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ShippingCountries.SequenceEqual(other.ShippingCountries);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShippingCountriesResponse) obj);
        }

        public override int GetHashCode()
        {
            return (ShippingCountries != null ? ShippingCountries.GetHashCode() : 0);
        }

        public static bool operator ==(ShippingCountriesResponse left, ShippingCountriesResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShippingCountriesResponse left, ShippingCountriesResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("shipping_countries")]
        public IEnumerable<ShippingCountry> ShippingCountries { get; set; }
    }
}
