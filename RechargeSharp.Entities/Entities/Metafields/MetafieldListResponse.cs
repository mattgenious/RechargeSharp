using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class MetafieldListResponse : IEquatable<MetafieldListResponse>
    {
        public bool Equals(MetafieldListResponse? other)
        {
            if (other is null) return false;
            if (other.Metafields is null) return false;
            if (Metafields is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Metafields.SequenceEqual(other.Metafields);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MetafieldListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Metafields != null ? Metafields.GetHashCode() : 0);
        }

        public static bool operator ==(MetafieldListResponse left, MetafieldListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MetafieldListResponse left, MetafieldListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("metafields")]
        public IEnumerable<Metafield>? Metafields { get; set; }
    }
}
