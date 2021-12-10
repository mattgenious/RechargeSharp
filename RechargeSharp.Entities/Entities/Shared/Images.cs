using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shared
{
    public class Images : IEquatable<Images>
    {
        public bool Equals(Images? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Large, other.Large) && Equals(Medium, other.Medium) && Equals(Original, other.Original) && Equals(Small, other.Small);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Images) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Large, Medium, Original, Small);
        }

        public static bool operator ==(Images left, Images right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Images left, Images right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("large")]
        public Uri? Large { get; set; }

        [JsonProperty("medium")]
        public Uri? Medium { get; set; }

        [JsonProperty("original")]
        public Uri? Original { get; set; }

        [JsonProperty("small")]
        public Uri? Small { get; set; }
    }
}