using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class ShippingLine : IEquatable<ShippingLine>
    {
        public bool Equals(ShippingLine other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Price == other.Price && Code == other.Code && Title == other.Title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShippingLine) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Price != null ? Price.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ShippingLine left, ShippingLine right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShippingLine left, ShippingLine right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
