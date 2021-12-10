using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class ShippingLine : IEquatable<ShippingLine>
    {
        public bool Equals(ShippingLine? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Price == other.Price && Code == other.Code && Title == other.Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShippingLine) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Price, Code, Title);
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
        public string? Price { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}
