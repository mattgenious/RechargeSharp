using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class TaxLine : IEquatable<TaxLine>
    {
        public bool Equals(TaxLine other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Price == other.Price && Rate == other.Rate && Title == other.Title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TaxLine) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Price != null ? Price.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Rate != null ? Rate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                return hashCode;
            }
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
        public string Price { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
