using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    public class Collection : IEquatable<Collection>
    {
        public bool Equals(Collection? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return CreatedAt.Equals(other.CreatedAt) && Id == other.Id && Name == other.Name && UpdatedAt.Equals(other.UpdatedAt);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Collection) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CreatedAt, Id, Name, UpdatedAt);
        }

        public static bool operator ==(Collection left, Collection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Collection left, Collection right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
