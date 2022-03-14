namespace RechargeSharp.v2021_11.Endpoints.Subscriptions;

public partial class SubscriptionService
{
    public static class SharedSubscriptionTypes
    {
        public record Property(
            string Name,
            string Value
        );

        public record ExternalVariantId(
            string Ecommerce
        );

        public record ExternalProductId(
            string Ecommerce
        );

        public record AnalyticsData(
            IReadOnlyList<object> UtmParams
        );

        public record Subscription(
            int Id,
            int AddressId,
            int CustomerId,
            AnalyticsData AnalyticsData,
            string? CancellationReason,
            string? CancellationReasonComments,
            DateTime? CancelledAt,
            int ChargeIntervalFrequency,
            DateTime CreatedAt,
            int? ExpireAfterSpecificNumberOfCharges,
            ExternalProductId ExternalProductId,
            ExternalVariantId ExternalVariantId,
            bool HasQueuedCharges,
            bool IsPrepaid,
            bool IsSkippable,
            bool IsSwappable,
            bool MaxRetriesReached,
            DateOnly? NextChargeScheduledAt,
            int? OrderDayOfMonth,
            int? OrderDayOfWeek,
            int OrderIntervalFrequency,
            string OrderIntervalUnit,
            string? PresentmentCurrency,
            decimal Price,
            string? ProductTitle,
            IReadOnlyList<Property> Properties,
            int Quantity,
            string? Sku,
            bool SkuOverride,
            string Status,
            DateTime UpdatedAt,
            string? VariantTitle
        );
    }

    public static class CreateSubscriptionTypes
    {
        public record Request(
            int AddressId,
            int ChargeIntervalFrequency,
            int ExpireAfterSpecificNumberOfCharges,
            DateTime NextChargeScheduledAt,
            int OrderDayOfMonth,
            int OrderDayOfWeek,
            int OrderIntervalFrequency,
            string OrderIntervalUnit,
            decimal? Price,
            string? ProductTitle,
            IReadOnlyList<SharedSubscriptionTypes.Property> Properties,
            int Quantity,
            string? Sku,
            SharedSubscriptionTypes.ExternalProductId ExternalProductId,
            SharedSubscriptionTypes.ExternalVariantId ExternalVariantId,
            string? Status
        );

        public record Response(SharedSubscriptionTypes.Subscription Subscription);
    }

    public static class GetSubscriptionTypes
    {
        public record Response(SharedSubscriptionTypes.Subscription Subscription);
    }

    public static class UpdateSubscriptionTypes
    {
        public record Request(
            bool CommitUpdate,
            int? ChargeIntervalFrequency,
            int? ExpireAfterSpecificNumberOfCharges,
            SharedSubscriptionTypes.ExternalVariantId? ExternalVariantId,
            DateTime? NextChargeScheduledAt,
            int? OrderDayOfMonth,
            int? OrderDayOfWeek,
            int? OrderIntervalFrequency,
            string? OrderIntervalUnit,
            decimal? Price,
            string? ProductTitle,
            IReadOnlyList<SharedSubscriptionTypes.Property>? Properties,
            int? Quantity,
            string? Sku,
            bool? SkuOverride,
            string? UseExternalVariantDefaults,
            string? VariantTitle
        );

        public record Response(SharedSubscriptionTypes.Subscription Subscription);
    }

    public static class DeleteSubscriptionTypes
    {
        public record Response();
    }

    public static class ListSubscriptionsTypes
    {
        public record Request(
            string? AddressId,
            IReadOnlyList<string>? AddressIds,
            DateTime? CreatedAtMax,
            DateTime? CreatedAtMin,
            string? Cursor,
            string? CustomerId,
            IReadOnlyList<string>? Ids,
            string? Limit,
            int? Page,
            string? Status,
            DateTime? UpdatedAtMax,
            DateTime? UpdatedAtMin
        );

        public record Response(
            string? NextCursor,
            string? PreviousCursor,
            IReadOnlyList<SharedSubscriptionTypes.Subscription> Subscriptions
        );
    }

    public static class ChangeSubscriptionsNextChargeDateTypes
    {
        public record Request(DateOnly Date);

        public record Response(SharedSubscriptionTypes.Subscription Subscription);
    }

    public static class ChangeSubscriptionsAddressTypes
    {
        public record Request(int AddressId, DateOnly? NextChargeScheduledAt);

        public record Response(SharedSubscriptionTypes.Subscription Subscription);
    }

    public static class CancelSubscriptionTypes
    {
        public record Request(string CancellationReason, string? CancellationReasonComments, bool SendEmail);

        public record Response(SharedSubscriptionTypes.Subscription Subscription);
    }

    public static class ActivateSubscriptionTypes
    {
        public record Response(SharedSubscriptionTypes.Subscription Subscription);
    }
}