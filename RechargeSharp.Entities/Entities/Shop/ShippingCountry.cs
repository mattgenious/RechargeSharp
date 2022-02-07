using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class ShippingCountry : IEquatable<ShippingCountry>
    {
        public bool Equals(ShippingCountry? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && CountryId == other.CountryId && Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShippingCountry) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, CountryId, Id, Name);
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
        public string? Code { get; set; }

        [JsonProperty("country_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CountryId { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }
    }


}
