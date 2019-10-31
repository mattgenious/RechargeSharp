using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Metafields
{
    public class UpdateMetafieldObject : IEquatable<UpdateMetafieldObject>
    {
        public bool Equals(UpdateMetafieldObject other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return OwnerId == other.OwnerId && OwnerResource == other.OwnerResource && Value == other.Value && ValueType == other.ValueType && Description == other.Description;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateMetafieldObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = OwnerId.GetHashCode();
                hashCode = (hashCode * 397) ^ (OwnerResource != null ? OwnerResource.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ValueType != null ? ValueType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(UpdateMetafieldObject left, UpdateMetafieldObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateMetafieldObject left, UpdateMetafieldObject right)
        {
            return !Equals(left, right);
        }


        [JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? OwnerId { get; set; }

        [StringValues(AllowableValues = new[] { "store", "customer", "subscription" })]
        [JsonProperty("owner_resource", NullValueHandling = NullValueHandling.Ignore)]
        public string OwnerResource { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [StringValues(AllowableValues = new[] { "string", "integer" })]
        [JsonProperty("value_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ValueType { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}
