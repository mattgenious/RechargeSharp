using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Endpoints.Subscriptions;

public partial class SubscriptionService
{
    public static class SharedSubscriptionTypes
    {
        public record Property
        {
            public string? Name { get; init; }
            public string? Value { get; init; }
        }

        public record ExternalVariantId
        {
            public string? Ecommerce { get; init; }
        }

        public record ExternalProductId
        {
            public string? Ecommerce { get; init; }
        }
        
        public record Subscription
        {
            public long? Id { get; init; }
            public long? AddressId { get; init; }
            public long? CustomerId { get; init; }
            public AnalyticsData? AnalyticsData { get; init; }
            public string? CancellationReason { get; init; }
            public string? CancellationReasonComments { get; init; }
            public DateTime? CancelledAt { get; init; }
            public int? ChargeIntervalFrequency { get; init; }
            public DateTime? CreatedAt { get; init; }
            public int? ExpireAfterSpecificNumberOfCharges { get; init; }
            public ExternalProductId? ExternalProductId { get; init; }
            public ExternalVariantId? ExternalVariantId { get; init; }
            public bool? HasQueuedCharges { get; init; }
            public bool? IsPrepaid { get; init; }
            public bool? IsSkippable { get; init; }
            public bool? IsSwappable { get; init; }
            public bool? MaxRetriesReached { get; init; }
            public DateOnly? NextChargeScheduledAt { get; init; }
            public int? OrderDayOfMonth { get; init; }
            public int? OrderDayOfWeek { get; init; }
            public int? OrderIntervalFrequency { get; init; }
            public string? OrderIntervalUnit { get; init; }
            public string? PresentmentCurrency { get; init; }
            public decimal? Price { get; init; }
            public string? ProductTitle { get; init; }
            public IReadOnlyList<Property>? Properties { get; init; }
            public int? Quantity { get; init; }
            public string? Sku { get; init; }
            public bool? SkuOverride { get; init; }
            public string? Status { get; init; }
            public DateTime? UpdatedAt { get; init; }
            public string? VariantTitle { get; init; }
        }
    }

    public static class CreateSubscriptionTypes
    {
        public record Request
        {
            public long? AddressId { get; init; }
            public int? ChargeIntervalFrequency { get; init; }
            public int? ExpireAfterSpecificNumberOfCharges { get; init; }
            public DateTime? NextChargeScheduledAt { get; init; }
            public int? OrderDayOfMonth { get; init; }
            public int? OrderDayOfWeek { get; init; }
            public int? OrderIntervalFrequency { get; init; }
            public string? OrderIntervalUnit { get; init; }
            public decimal? Price { get; init; }
            public string? ProductTitle { get; init; }
            public IReadOnlyList<SharedSubscriptionTypes.Property>? Properties { get; init; }
            public int? Quantity { get; init; }
            public string? Sku { get; init; }
            public SharedSubscriptionTypes.ExternalProductId? ExternalProductId { get; init; }
            public SharedSubscriptionTypes.ExternalVariantId? ExternalVariantId { get; init; }
            public string? Status { get; init; }
        }

        public record Response
        {
            public SharedSubscriptionTypes.Subscription? Subscription { get; init; }
        }
    }

    public static class GetSubscriptionTypes
    {
        public record Response
        {
            public SharedSubscriptionTypes.Subscription? Subscription { get; init; }
        }
    }

    public static class UpdateSubscriptionTypes
    {
        public record Request
        {
            public bool? CommitUpdate { get; init; }
            public int? ChargeIntervalFrequency { get; init; }
            public int? ExpireAfterSpecificNumberOfCharges { get; init; }
            public SharedSubscriptionTypes.ExternalVariantId? ExternalVariantId { get; init; }
            public DateTime? NextChargeScheduledAt { get; init; }
            public int? OrderDayOfMonth { get; init; }
            public int? OrderDayOfWeek { get; init; }
            public int? OrderIntervalFrequency { get; init; }
            public string? OrderIntervalUnit { get; init; }
            public decimal? Price { get; init; }
            public string? ProductTitle { get; init; }
            public IReadOnlyList<SharedSubscriptionTypes.Property>? Properties { get; init; }
            public int? Quantity { get; init; }
            public string? Sku { get; init; }
            public bool? SkuOverride { get; init; }
            public string? UseExternalVariantDefaults { get; init; }
            public string? VariantTitle { get; init; }
        }

        public record Response
        {
            public SharedSubscriptionTypes.Subscription? Subscription { get; init; }
        }
    }

    public static class ListSubscriptionsTypes
    {
        public record Request
        {
            public string? AddressId { get; init; }
            public IReadOnlyList<string>? AddressIds { get; init; }
            public DateTime? CreatedAtMax { get; init; }
            public DateTime? CreatedAtMin { get; init; }
            public string? Cursor { get; init; }
            public string? CustomerId { get; init; }
            public IReadOnlyList<string>? Ids { get; init; }
            public string? Limit { get; init; }
            public int? Page { get; init; }
            public string? Status { get; init; }
            public DateTime? UpdatedAtMax { get; init; }
            public DateTime? UpdatedAtMin { get; init; }
        }

        public record Response
        {
            public string? NextCursor { get; init; }
            public string? PreviousCursor { get; init; }
            public IReadOnlyList<SharedSubscriptionTypes.Subscription>? Subscriptions { get; init; }
        }
    }

    public static class ChangeSubscriptionsNextChargeDateTypes
    {
        public record Request
        {
            public DateOnly Date { get; init; }
        }

        public record Response
        {
            public SharedSubscriptionTypes.Subscription? Subscription { get; init; }
        }
    }

    public static class ChangeSubscriptionsAddressTypes
    {
        public record Request
        {
            public long? AddressId { get; init; }
            public DateOnly? NextChargeScheduledAt { get; init; }
        }

        public record Response
        {
            public SharedSubscriptionTypes.Subscription? Subscription { get; init; }
        }
    }

    public static class CancelSubscriptionTypes
    {
        public record Request
        {
            public string? CancellationReason { get; init; }
            public string? CancellationReasonComments { get; init; }
            public bool? SendEmail { get; init; }
        }

        public record Response
        {
            public SharedSubscriptionTypes.Subscription? Subscription { get; init; }
        }
    }

    public static class ActivateSubscriptionTypes
    {
        public record Response
        {
            public SharedSubscriptionTypes.Subscription? Subscription { get; init; }
        }
    }
}