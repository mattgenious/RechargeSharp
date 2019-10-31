using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Discounts
{
    public class UpdateDiscountRequest : IEquatable<UpdateDiscountRequest>
    {
        public bool Equals(UpdateDiscountRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(StartsAt, other.StartsAt) && UsageLimit == other.UsageLimit && Status == other.Status && Nullable.Equals(EndsAt, other.EndsAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateDiscountRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StartsAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UsageLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EndsAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UpdateDiscountRequest left, UpdateDiscountRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateDiscountRequest left, UpdateDiscountRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("starts_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartsAt { get; set; }

        [JsonProperty("usage_limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsageLimit { get; set; }

        [StringValues(AllowableValues = new[] { "enabled", "disabled", "fully_disabled" })]
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("ends_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndsAt { get; set; }
    }
}
