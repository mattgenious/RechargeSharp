using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Collections
{
    public class Collection : IEquatable<Collection>
    {
        public bool Equals(Collection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CreatedAt.Equals(other.CreatedAt) && Id == other.Id && Name == other.Name && UpdatedAt.Equals(other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Collection) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                return hashCode;
            }
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
        public string Name { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
