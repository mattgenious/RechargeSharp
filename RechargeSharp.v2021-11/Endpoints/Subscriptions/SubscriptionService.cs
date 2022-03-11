using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Subscriptions;

public class SubscriptionService
{
    private readonly ILogger<SubscriptionService> _logger;
    private readonly IRechargeApiCaller _rechargeApiCaller;

    public SubscriptionService(ILogger<SubscriptionService> logger, IRechargeApiCaller rechargeApiCaller)
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
    
    
    public async Task<GetSubscriptionTypes.Response> GetSubscription(int subscriptionId)
    {
        var requestUri = $"/subscriptions/{subscriptionId}";
        var responseJson = await _rechargeApiCaller.Get<GetSubscriptionTypes.Response> (requestUri);
        return responseJson;
    }
    
    public async Task<UpdateSubscriptionTypes.Response> UpdateSubscription(int subscriptionId, UpdateSubscriptionTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}";
        var responseJson = await _rechargeApiCaller.Put<UpdateSubscriptionTypes.Request, UpdateSubscriptionTypes.Response>(request,requestUri);
        return responseJson;
    }
    
    public async Task<DeleteSubscriptionTypes.Response> DeleteSubscription(int subscriptionId)
    {
        var requestUri = $"/subscriptions/{subscriptionId}";
        await _rechargeApiCaller.Delete(requestUri);
        return new DeleteSubscriptionTypes.Response();
    }
    
    public async Task<ListSubscriptionsTypes.Response> ListSubscriptions(ListSubscriptionsTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/subscriptions{queryString.Value}";
        var responseJson = await _rechargeApiCaller.Get<ListSubscriptionsTypes.Response>(requestUri);
        return responseJson;
    }
    
    public async Task<ChangeSubscriptionsNextChargeDateTypes.Response> ChangeSubscriptionsNextChargeDate(int subscriptionId, ChangeSubscriptionsNextChargeDateTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/set_next_charge_date";
        var responseJson = await _rechargeApiCaller.Post<ChangeSubscriptionsNextChargeDateTypes.Request, ChangeSubscriptionsNextChargeDateTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<ChangeSubscriptionsAddressTypes.Response> ChangeSubscriptionsAddress(int subscriptionId, ChangeSubscriptionsAddressTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/change_address";
        var responseJson = await _rechargeApiCaller.Post<ChangeSubscriptionsAddressTypes.Request, ChangeSubscriptionsAddressTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<CancelSubscriptionTypes.Response> CancelSubscription(int subscriptionId, CancelSubscriptionTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/cancel";
        var responseJson = await _rechargeApiCaller.Post<CancelSubscriptionTypes.Request, CancelSubscriptionTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<ActivateSubscriptionTypes.Response> ActivateSubscription(int subscriptionId)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/activate";
        var responseJson = await _rechargeApiCaller.Post<ActivateSubscriptionTypes.Response>(requestUri);
        return responseJson;
    }
    

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