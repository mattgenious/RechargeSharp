using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    public class CreateDiscountRequest : IEquatable<CreateDiscountRequest>
    {
        public bool Equals(CreateDiscountRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && Value == other.Value && DiscountType == other.DiscountType && AppliesToProductType == other.AppliesToProductType && Duration == other.Duration && DurationUsageLimit == other.DurationUsageLimit && Status == other.Status && UsageLimit == other.UsageLimit && Nullable.Equals(StartsAt, other.StartsAt) && Nullable.Equals(EndsAt, other.EndsAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateDiscountRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (DiscountType != null ? DiscountType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AppliesToProductType != null ? AppliesToProductType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Duration != null ? Duration.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DurationUsageLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UsageLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ StartsAt.GetHashCode();
                hashCode = (hashCode * 397) ^ EndsAt.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CreateDiscountRequest left, CreateDiscountRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateDiscountRequest left, CreateDiscountRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        [JsonProperty("applies_to_product_type")]
        public string AppliesToProductType { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("duration_usage_limit")]
        public long DurationUsageLimit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("usage_limit")]
        public long UsageLimit { get; set; }

        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }

        [JsonProperty("ends_at")]
        public DateTime? EndsAt { get; set; }
    }
}
