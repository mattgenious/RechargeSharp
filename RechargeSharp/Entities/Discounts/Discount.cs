using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RechargeSharp.Entities.Discounts
{
    public class Discount : IEquatable<Discount>
    {
        public bool Equals(Discount other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Code == other.Code && Value == other.Value && Nullable.Equals(EndsAt, other.EndsAt) && Nullable.Equals(StartsAt, other.StartsAt) && Status == other.Status && UsageLimit == other.UsageLimit && AppliesToId == other.AppliesToId && DiscountType == other.DiscountType && AppliesTo == other.AppliesTo && AppliesToResource == other.AppliesToResource && TimesUsed == other.TimesUsed && Duration == other.Duration && DurationUsageLimit == other.DurationUsageLimit && AppliesToProductType == other.AppliesToProductType && CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt) && OncePerCustomer == other.OncePerCustomer;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Discount) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ EndsAt.GetHashCode();
                hashCode = (hashCode * 397) ^ StartsAt.GetHashCode();
                hashCode = (hashCode * 397) ^ Status.GetHashCode();
                hashCode = (hashCode * 397) ^ UsageLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ AppliesToId.GetHashCode();
                hashCode = (hashCode * 397) ^ (DiscountType != null ? DiscountType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AppliesTo != null ? AppliesTo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AppliesToResource.GetHashCode();
                hashCode = (hashCode * 397) ^ TimesUsed.GetHashCode();
                hashCode = (hashCode * 397) ^ Duration.GetHashCode();
                hashCode = (hashCode * 397) ^ DurationUsageLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ AppliesToProductType.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ OncePerCustomer.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Discount left, Discount right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Discount left, Discount right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("ends_at")]
        public DateTime? EndsAt { get; set; }

        [JsonProperty("starts_at")]
        public DateTime? StartsAt { get; set; }

        [JsonProperty("status")]
        public DiscountStatus? Status { get; set; }

        [JsonProperty("usage_limit")]
        public long? UsageLimit { get; set; }

        [JsonProperty("applies_to_id")]
        public long? AppliesToId { get; set; }

        [JsonProperty("discount_type")]
        public DiscountType? DiscountType { get; set; }

        [JsonProperty("applies_to")]
        public string AppliesTo { get; set; }

        [JsonProperty("applies_to_resource")]
        public AppliesToResource? AppliesToResource { get; set; }

        [JsonProperty("times_used")]
        public long TimesUsed { get; set; }

        [JsonProperty("duration")]
        public Duration? Duration { get; set; }

        [JsonProperty("duration_usage_limit")]
        public long? DurationUsageLimit { get; set; }

        [JsonProperty("applies_to_product_type")]
        public AppliesToProductType? AppliesToProductType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("once_per_customer")]
        public bool OncePerCustomer { get; set; }
    }
}
