using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class Metafield : IEquatable<Metafield>
    {
        public bool Equals(Metafield? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return CreatedAt.Equals(other.CreatedAt) && Description == other.Description && Id == other.Id && Key == other.Key && Namespace == other.Namespace && OwnerId == other.OwnerId && OwnerResource == other.OwnerResource && UpdatedAt.Equals(other.UpdatedAt) && Value == other.Value && ValueType == other.ValueType;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Metafield) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(CreatedAt);
            hash.Add(Description);
            hash.Add(Id);
            hash.Add(Key);
            hash.Add(Namespace);
            hash.Add(OwnerId);
            hash.Add(OwnerResource);
            hash.Add(UpdatedAt);
            hash.Add(Value);
            hash.Add(ValueType);
            return hash.ToHashCode();
        }

        public static bool operator ==(Metafield left, Metafield right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Metafield left, Metafield right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("namespace")]
        public string? Namespace { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("owner_resource")]
        public OwnerResource? OwnerResource { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("value_type")]
        public string? ValueType { get; set; }
    }
}
