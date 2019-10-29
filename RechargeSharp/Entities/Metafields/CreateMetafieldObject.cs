using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Metafields
{
    public class CreateMetafieldObject : IEquatable<CreateMetafieldObject>
    {
        public bool Equals(CreateMetafieldObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Description == other.Description && Namespace == other.Namespace && Value == other.Value && ValueType == other.ValueType && Key == other.Key && OwnerResource == other.OwnerResource && OwnerId == other.OwnerId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateMetafieldObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Namespace != null ? Namespace.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ValueType != null ? ValueType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Key != null ? Key.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OwnerResource != null ? OwnerResource.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OwnerId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CreateMetafieldObject left, CreateMetafieldObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateMetafieldObject left, CreateMetafieldObject right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("value_type")]
        public string ValueType { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("owner_resource")]
        public string OwnerResource { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }
    }
}