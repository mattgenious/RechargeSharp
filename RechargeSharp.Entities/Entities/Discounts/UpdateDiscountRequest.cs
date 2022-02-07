using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Discounts
{
    public class UpdateDiscountRequest : IEquatable<UpdateDiscountRequest>
    {
        public bool Equals(UpdateDiscountRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(StartsAt, other.StartsAt) && UsageLimit == other.UsageLimit && Status == other.Status && Nullable.Equals(EndsAt, other.EndsAt);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateDiscountRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartsAt, UsageLimit, Status, EndsAt);
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
        public DateTimeOffset? StartsAt { get; set; }

        [JsonProperty("usage_limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsageLimit { get; set; }

        [StringValues(AllowableValues = new[] { "enabled", "disabled", "fully_disabled" })]
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string? Status { get; set; }

        [JsonProperty("ends_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndsAt { get; set; }
    }
}
