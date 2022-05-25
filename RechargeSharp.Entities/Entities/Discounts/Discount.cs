using Newtonsoft.Json;

namespace RechargeSharp.Entities.Discounts
{
    public class Discount : IEquatable<Discount>
    {
        public bool Equals(Discount? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Code == other.Code && Value == other.Value && Nullable.Equals(EndsAt, other.EndsAt) && Nullable.Equals(StartsAt, other.StartsAt) && Status == other.Status && UsageLimit == other.UsageLimit && AppliesToId == other.AppliesToId && DiscountType == other.DiscountType && AppliesTo == other.AppliesTo && AppliesToResource == other.AppliesToResource && TimesUsed == other.TimesUsed && Duration == other.Duration && DurationUsageLimit == other.DurationUsageLimit && AppliesToProductType == other.AppliesToProductType && CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt) && OncePerCustomer == other.OncePerCustomer;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Discount) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(Code);
            hash.Add(Value);
            hash.Add(EndsAt);
            hash.Add(StartsAt);
            hash.Add(Status);
            hash.Add(UsageLimit);
            hash.Add(AppliesToId);
            hash.Add(DiscountType);
            hash.Add(AppliesTo);
            hash.Add(AppliesToResource);
            hash.Add(TimesUsed);
            hash.Add(Duration);
            hash.Add(DurationUsageLimit);
            hash.Add(AppliesToProductType);
            hash.Add(CreatedAt);
            hash.Add(UpdatedAt);
            hash.Add(OncePerCustomer);
            return hash.ToHashCode();
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
        public string? Code { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("ends_at")]
        public DateTimeOffset? EndsAt { get; set; }

        [JsonProperty("starts_at")]
        public DateTimeOffset? StartsAt { get; set; }

        [JsonProperty("status")]
        public DiscountStatus? Status { get; set; }

        [JsonProperty("usage_limit")]
        public long? UsageLimit { get; set; }

        [JsonProperty("applies_to_id")]
        public long? AppliesToId { get; set; }

        [JsonProperty("discount_type")]
        public DiscountType? DiscountType { get; set; }

        [JsonProperty("applies_to")]
        public string? AppliesTo { get; set; }

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
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("once_per_customer")]
        public bool OncePerCustomer { get; set; }
    }
}
