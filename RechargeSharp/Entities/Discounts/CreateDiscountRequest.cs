using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Discounts
{
    public class CreateDiscountRequest : IEquatable<CreateDiscountRequest>
    {
        public bool Equals(CreateDiscountRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Code == other.Code && DiscountType == other.DiscountType && Value == other.Value && AppliesToResource == other.AppliesToResource && AppliesToId == other.AppliesToId && AppliesToProductType == other.AppliesToProductType && CreatedAt.Equals(other.CreatedAt) && Duration == other.Duration && DurationUsageLimit == other.DurationUsageLimit && Nullable.Equals(EndsAt, other.EndsAt) && Nullable.Equals(StartsAt, other.StartsAt) && OncePerCustomer == other.OncePerCustomer && Status == other.Status && UsageLimit == other.UsageLimit && PrerequisiteSubtotalMin == other.PrerequisiteSubtotalMin;
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
                hashCode = (hashCode * 397) ^ (DiscountType != null ? DiscountType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (AppliesToResource != null ? AppliesToResource.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AppliesToId != null ? AppliesToId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AppliesToProductType != null ? AppliesToProductType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (Duration != null ? Duration.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DurationUsageLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ EndsAt.GetHashCode();
                hashCode = (hashCode * 397) ^ StartsAt.GetHashCode();
                hashCode = (hashCode * 397) ^ OncePerCustomer.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UsageLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ PrerequisiteSubtotalMin.GetHashCode();
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

        [Required]
        [JsonProperty("code")]
        public string Code { get; set; }

        [Required]
        [StringValues(AllowableValues = new[] { "percentage", "fixed_amount" })]
        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        [Required]
        [JsonProperty("value")]
        public long? Value { get; set; }

        [StringValues(AllowableValues = new[] { "shopify_product", "shopify_collection_id", null })]
        [JsonProperty("applies_to_resource", NullValueHandling = NullValueHandling.Ignore)]
        public string AppliesToResource { get; set; }

        [JsonProperty("applies_to_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppliesToId { get; set; }

        [StringValues(AllowableValues = new[] { "ALL", "ONETIME", "SUBSCRIPTION" })]
        [JsonProperty("applies_to_product_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AppliesToProductType { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [StringValues(AllowableValues = new[] { "forever", "usage_limit", "single_use" })]
        [JsonProperty("duration")]
        public string Duration { get; set; }
        
        // is required when duration has value usage_limit
        [JsonProperty("duration_usage_limit")]
        public long? DurationUsageLimit { get; set; }

        [JsonProperty("ends_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndsAt { get; set; }

        [JsonProperty("starts_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartsAt { get; set; }

        [JsonProperty("once_per_customer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OncePerCustomer { get; set; }

        [StringValues(AllowableValues = new[] { "enabled", "disabled", "fully_disabled" })]
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("usage_limit", NullValueHandling = NullValueHandling.Ignore)]
        public long? UsageLimit { get; set; }

        [JsonProperty("prerequisite_subtotal_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? PrerequisiteSubtotalMin { get; set; }
    }
}
