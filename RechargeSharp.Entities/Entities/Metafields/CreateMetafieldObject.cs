using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Metafields
{
    public class CreateMetafieldObject : IEquatable<CreateMetafieldObject>
    {
        public bool Equals(CreateMetafieldObject? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Namespace == other.Namespace && Value == other.Value && ValueType == other.ValueType && Key == other.Key && OwnerResource == other.OwnerResource && OwnerId == other.OwnerId && Description == other.Description;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateMetafieldObject) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Namespace, Value, ValueType, Key, OwnerResource, OwnerId, Description);
        }

        public static bool operator ==(CreateMetafieldObject left, CreateMetafieldObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateMetafieldObject left, CreateMetafieldObject right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("namespace")]
        public string? Namespace { get; set; }

        [Required]
        [JsonProperty("value")]
        public string? Value { get; set; }

        [Required]
        [StringValues(AllowableValues = new[] { "string", "integer" })]
        [JsonProperty("value_type")]
        public string? ValueType { get; set; }

        [Required]
        [JsonProperty("key")]
        public string? Key { get; set; }

        [Required]
        [StringValues(AllowableValues = new[] { "store", "customer", "subscription" })]
        [JsonProperty("owner_resource")]
        public string? OwnerResource { get; set; }

        [Required]
        [JsonProperty("owner_id")]
        public long? OwnerId { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }
    }
}