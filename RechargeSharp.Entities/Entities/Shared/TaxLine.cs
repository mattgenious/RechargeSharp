using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class TaxLine : IEquatable<TaxLine>
    {
        public bool Equals(TaxLine? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Price == other.Price && Rate == other.Rate && Title == other.Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TaxLine) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Price, Rate, Title);
        }

        public static bool operator ==(TaxLine left, TaxLine right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TaxLine left, TaxLine right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("rate")]
        public string? Rate { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}
