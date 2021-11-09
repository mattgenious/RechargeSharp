using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RechargeSharp.Entities.Metafields
{
    public class Metafield : IEquatable<Metafield>
    {
        public bool Equals(Metafield other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CreatedAt.Equals(other.CreatedAt) && Description == other.Description && Id == other.Id && Key == other.Key && Namespace == other.Namespace && OwnerId == other.OwnerId && OwnerResource == other.OwnerResource && UpdatedAt.Equals(other.UpdatedAt) && Value == other.Value && ValueType == other.ValueType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Metafield) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Key != null ? Key.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Namespace != null ? Namespace.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OwnerId.GetHashCode();
                hashCode = (hashCode * 397) ^ OwnerResource.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ValueType != null ? ValueType.GetHashCode() : 0);
                return hashCode;
            }
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
        public string Description { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("owner_resource")]
        public OwnerResource? OwnerResource { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("value_type")]
        public string ValueType { get; set; }
    }
}
