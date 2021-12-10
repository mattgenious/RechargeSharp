using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    public class CollectionListResponse : IEquatable<CollectionListResponse>
    {
        public bool Equals(CollectionListResponse? other)
        {
            if (other is null) return false;
            if (other.Products is null) return false;
            if (Products is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Products.SequenceEqual(other.Products);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CollectionListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Products != null ? Products.GetHashCode() : 0);
        }

        public static bool operator ==(CollectionListResponse left, CollectionListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CollectionListResponse left, CollectionListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("products")]
        public IEnumerable<Collection>? Products { get; set; }
    }
}
