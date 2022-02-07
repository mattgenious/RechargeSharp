using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Discounts
{
    public class CreateDiscountRequest : IEquatable<CreateDiscountRequest>
    {
        public bool Equals(CreateDiscountRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && DiscountType == other.DiscountType && Value == other.Value && AppliesToResource == other.AppliesToResource && AppliesToId == other.AppliesToId && AppliesToProductType == other.AppliesToProductType && CreatedAt.Equals(other.CreatedAt) && Duration == other.Duration && DurationUsageLimit == other.DurationUsageLimit && Nullable.Equals(EndsAt, other.EndsAt) && Nullable.Equals(StartsAt, other.StartsAt) && OncePerCustomer == other.OncePerCustomer && Status == other.Status && UsageLimit == other.UsageLimit && PrerequisiteSubtotalMin == other.PrerequisiteSubtotalMin;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateDiscountRequest) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Code);
            hash.Add(DiscountType);
            hash.Add(Value);
            hash.Add(AppliesToResource);
            hash.Add(AppliesToId);
            hash.Add(AppliesToProductType);
            hash.Add(CreatedAt);
            hash.Add(Duration);
            hash.Add(DurationUsageLimit);
            hash.Add(EndsAt);
            hash.Add(StartsAt);
            hash.Add(OncePerCustomer);
            hash.Add(Status);
            hash.Add(UsageLimit);
            hash.Add(PrerequisiteSubtotalMin);
            return hash.ToHashCode();
        }

        public static bool operator ==(CreateDiscountRequest left, CreateDiscountRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateDiscountRequest left, CreateDiscountRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("code")]
        public string? Code { get; set; }

        [Required]
        [StringValues(AllowableValues = new[] { "percentage", "fixed_amount" })]
        [JsonProperty("discount_type")]
        public string? DiscountType { get; set; }

        [Required]
        [JsonProperty("value")]
        public long? Value { get; set; }

        [StringValues(AllowableValues = new string?[] { "shopify_product", "shopify_collection_id", null })]
        [JsonProperty("applies_to_resource", NullValueHandling = NullValueHandling.Ignore)]
        public string? AppliesToResource { get; set; }

        [JsonProperty("applies_to_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? AppliesToId { get; set; }

        [StringValues(AllowableValues = new[] { "ALL", "ONETIME", "SUBSCRIPTION" })]
        [JsonProperty("applies_to_product_type", NullValueHandling = NullValueHandling.Ignore)]
        public string? AppliesToProductType { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        [StringValues(AllowableValues = new[] { "forever", "usage_limit", "single_use" })]
        [JsonProperty("duration")]
        public string? Duration { get; set; }
        
        // is required when duration has value usage_limit
        [JsonProperty("duration_usage_limit")]
        public long? DurationUsageLimit { get; set; }

        [JsonProperty("ends_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndsAt { get; set; }

        [JsonProperty("starts_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartsAt { get; set; }

        [JsonProperty("once_per_customer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OncePerCustomer { get; set; }

        [StringValues(AllowableValues = new[] { "enabled", "disabled", "fully_disabled" })]
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string? Status { get; set; }

        [JsonProperty("usage_limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsageLimit { get; set; }

        [JsonProperty("prerequisite_subtotal_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrerequisiteSubtotalMin { get; set; }
    }
}
