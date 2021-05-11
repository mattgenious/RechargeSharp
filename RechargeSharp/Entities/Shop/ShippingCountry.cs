using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class ShippingCountry : IEquatable<ShippingCountry>
    {
        public bool Equals(ShippingCountry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && CountryId == other.CountryId && Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShippingCountry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CountryId.GetHashCode();
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ShippingCountry left, ShippingCountry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShippingCountry left, ShippingCountry right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("country_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CountryId { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }


}
