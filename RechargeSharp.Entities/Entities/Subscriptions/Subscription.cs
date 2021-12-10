using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Subscriptions
{
    public class Subscription : IEquatable<Subscription>
    {
        public bool Equals(Subscription? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return RechargeProductId == other.RechargeProductId && SkuOverride == other.SkuOverride && Id == other.Id &&
                   AddressId == other.AddressId && CustomerId == other.CustomerId &&
                   CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt) &&
                   Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) &&
                   Nullable.Equals(CancelledAt, other.CancelledAt) && ProductTitle == other.ProductTitle &&
                   VariantTitle == other.VariantTitle && Price == other.Price && Quantity == other.Quantity &&
                   Status == other.Status && ShopifyProductId == other.ShopifyProductId &&
                   ShopifyVariantId == other.ShopifyVariantId && Sku == other.Sku &&
                   OrderIntervalUnit == other.OrderIntervalUnit &&
                   OrderIntervalFrequency == other.OrderIntervalFrequency &&
                   ChargeIntervalFrequency == other.ChargeIntervalFrequency &&
                   CancellationReason == other.CancellationReason &&
                   CancellationReasonComments == other.CancellationReasonComments &&
                   OrderDayOfWeek == other.OrderDayOfWeek && OrderDayOfMonth == other.OrderDayOfMonth &&
                   ExpireAfterSpecificNumberOfCharges == other.ExpireAfterSpecificNumberOfCharges &&
                   MaxRetriesReached == other.MaxRetriesReached && HasQueuedCharges == other.HasQueuedCharges &&
                   CommitUpdate == other.CommitUpdate;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Subscription)obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(RechargeProductId);
            hash.Add(SkuOverride);
            hash.Add(Id);
            hash.Add(AddressId);
            hash.Add(CustomerId);
            hash.Add(CreatedAt);
            hash.Add(UpdatedAt);
            hash.Add(NextChargeScheduledAt);
            hash.Add(CancelledAt);
            hash.Add(ProductTitle);
            hash.Add(VariantTitle);
            hash.Add(Price);
            hash.Add(Quantity);
            hash.Add(Status);
            hash.Add(ShopifyProductId);
            hash.Add(ShopifyVariantId);
            hash.Add(Sku);
            hash.Add(OrderIntervalUnit);
            hash.Add(OrderIntervalFrequency);
            hash.Add(ChargeIntervalFrequency);
            hash.Add(CancellationReason);
            hash.Add(CancellationReasonComments);
            hash.Add(OrderDayOfWeek);
            hash.Add(OrderDayOfMonth);
            hash.Add(ExpireAfterSpecificNumberOfCharges);
            hash.Add(MaxRetriesReached);
            hash.Add(HasQueuedCharges);
            hash.Add(CommitUpdate);
            return hash.ToHashCode();
        }

        public static bool operator ==(Subscription left, Subscription right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Subscription left, Subscription right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("recharge_product_id")] public long? RechargeProductId { get; set; }

        [JsonProperty("sku_override")] public bool SkuOverride { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("address_id")] public long AddressId { get; set; }

        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long CustomerId { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Include)]
        public DateTimeOffset? NextChargeScheduledAt { get; set; }

        [JsonProperty("cancelled_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CancelledAt { get; set; }

        [JsonProperty("product_title")] public string? ProductTitle { get; set; }

        [JsonProperty("variant_title")] public string? VariantTitle { get; set; }

        [JsonProperty("price")] public decimal Price { get; set; }

        [JsonProperty("quantity")] public long Quantity { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public SubscriptionStatus? Status { get; set; }

        [JsonProperty("shopify_product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long ShopifyProductId { get; set; }

        [JsonProperty("shopify_variant_id")] public long ShopifyVariantId { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string? Sku { get; set; }

        [JsonProperty("order_interval_unit")] public string? OrderIntervalUnit { get; set; }

        [JsonProperty("order_interval_frequency")]
        public string? OrderIntervalFrequency { get; set; }

        [JsonProperty("charge_interval_frequency")]
        public string? ChargeIntervalFrequency { get; set; }

        [JsonProperty("cancellation_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string? CancellationReason { get; set; }

        [JsonProperty("cancellation_reason_comments", NullValueHandling = NullValueHandling.Ignore)]
        public string? CancellationReasonComments { get; set; }

        [JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("properties")] public IEnumerable<Property>? Properties { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("max_retries_reached", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxRetriesReached { get; set; }

        [JsonProperty("has_queued_charges", NullValueHandling = NullValueHandling.Ignore)]
        public long? HasQueuedCharges { get; set; }

        [JsonProperty("commit_update", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CommitUpdate { get; set; }
    }
}