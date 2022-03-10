using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RechargeSharp.v2021_11.Utilities;

namespace RechargeSharp.v2021_11.Endpoints.Subscriptions;

public class SubscriptionService
{
    private readonly ILogger<SubscriptionService> _logger;
    private readonly RechargeApiCaller _rechargeApiCaller;

    public SubscriptionService(ILogger<SubscriptionService> logger, RechargeApiCaller rechargeApiCaller)
    {
        _logger = logger;
        _rechargeApiCaller = rechargeApiCaller;
    }

    public async Task<CreateSubscriptionTypes.Response> CreateSubscription(CreateSubscriptionTypes.Request request)
    {
        var requestUri = $"/subscriptions";
        var responseJson = await _rechargeApiCaller.Post<CreateSubscriptionTypes.Request, CreateSubscriptionTypes.Response> (request, requestUri);
        return responseJson;
    }
    
    public static class CreateSubscriptionTypes
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
            IReadOnlyList<Property> Properties,
            int Quantity,
            ExternalProductId ExternalProductId,
            ExternalVariantId ExternalVariantId,
            string? Status
        );
        
        public record AnalyticsData(
            IReadOnlyList<object> UtmParams
        );
        
        public record Response(Subscription Subscription);
        
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
            DateOnly NextChargeScheduledAt,
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
}