using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Entities.SharedModels;
using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Customers;

public class CustomerService
{
    private readonly ILogger<CustomerService> _logger;
    private readonly IRechargeApiCaller _rechargeApiCaller;

    public CustomerService(ILogger<CustomerService> logger, IRechargeApiCaller rechargeApiCaller)
    {
        _logger = logger;
        _rechargeApiCaller = rechargeApiCaller;
    }
    
    public async Task<CreateCustomerTypes.Response> CreateCustomer(CreateCustomerTypes.Request request)
    {
        var requestUri = $"/customers";
        var responseJson = await _rechargeApiCaller.Post<CreateCustomerTypes.Request, CreateCustomerTypes.Response> (request, requestUri);
        return responseJson;
    }

    public async Task<GetCustomerTypes.Response> GetCustomer(int customerId)
    {
        var requestUri = $"/customers/{customerId}";
        var responseJson = await _rechargeApiCaller.Get<GetCustomerTypes.Response>(requestUri);
        return responseJson;
    }
    
    public async Task<UpdateCustomerTypes.Response> UpdateCustomer(int customerId, UpdateCustomerTypes.Request request)
    {
        var requestUri = $"/customers/{customerId}";
        var responseJson = await _rechargeApiCaller.Put<UpdateCustomerTypes.Request, UpdateCustomerTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<DeleteCustomerTypes.Response> DeleteCustomer(int customerId)
    {
        var requestUri = $"/customers/{customerId}";
        await _rechargeApiCaller.Delete(requestUri);
        return new DeleteCustomerTypes.Response();
    }

    public async Task<ListCustomersTypes.Response> ListCustomers(ListCustomersTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/customers{queryString.Value}";
        var responseJson = await _rechargeApiCaller.Get<ListCustomersTypes.Response>(requestUri);
        return responseJson;
    }
    
    public async Task<GetCustomerDeliveryScheduleTypes.Response> GetCustomerDeliverySchedule(int customerId, GetCustomerDeliveryScheduleTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/customers/{customerId}/delivery_schedule{queryString}";
        var responseJson = await _rechargeApiCaller.Get<GetCustomerDeliveryScheduleTypes.Response>(requestUri);
        return responseJson;
    }

    public static class SharedTypes
    {
        public record UtmParam(
            string? UtmSource,
            string? UtmMedium
        );
        
        public record AnalyticsData(
            IReadOnlyList<UtmParam> UtmParams
        );
        
        public record ExternalCustomerId(string? Ecommerce);
        
        public record Customer(
            int Id,
            AnalyticsData? AnalyticsData,
            DateTime CreatedAt,
            string Email,
            ExternalCustomerId? ExternalCustomerId,
            DateTime? FirstChargeProcessedAt,
            string FirstName,
            bool HasPaymentMethodInDunning,
            bool HasValidPaymentMethod,
            string Hash,
            string LastName,
            int SubscriptionsActiveCount,
            int SubscriptionsTotalCount,
            DateTime UpdatedAt
        );
    }

    public static class CreateCustomerTypes
    {
        public record Request(string Email, string FirstName, string LastName, SharedTypes.ExternalCustomerId? ExternalCustomerId);
        
        public record Response(SharedTypes.Customer Customer);
    }

    public static class UpdateCustomerTypes
    {
        public record Request(string? Email, string? FirstName, string? LastName, SharedTypes.ExternalCustomerId? ExternalCustomerId);
        
        public record Response(SharedTypes.Customer Customer);
    }

    public static class ListCustomersTypes
    {
        public record Request(string? Email, DateTime? CreatedAtMax, DateTime? CreatedAtMin, string? Hash, int? Limit, int? Page, string? ExternalCustomerId, DateTime? UpdatedAtMax, DateTime? UpdatedAtMin, string Cursor);
        
        public record Response(string? NextCursor, string? PreviousCursor, IReadOnlyList<SharedTypes.Customer> Customers);
    }

    public static class GetCustomerTypes
    {
        public record Response(SharedTypes.Customer Customer);
    }

    public static class GetCustomerDeliveryScheduleTypes
    {
        public record Request(int? DeliveryCountFuture, int? FutureInterval, DateTime? DateMin, DateTime? DateMax);
        
        public record Response(
            Customer Customer,
            IReadOnlyList<Delivery> Deliveries
        );
        
        public record Customer(
            int Id,
            string Email,
            string FirstName,
            string LastName
        );

        public record ExternalProductId(
            string? Ecommerce
        );

        public record ExternalVariantId(
            string? Ecommerce
        );

        public record Images(
            string? Large,
            string? Medium,
            string? Small,
            string? Original,
            int? SortOrder
        );

        public record Property(
            string Name,
            string Value
        );

        public record LineItem(
            int SubscriptionId,
            ExternalProductId? ExternalProductId,
            ExternalVariantId? ExternalVariantId,
            Images? Images,
            bool IsSkippable,
            string? PlanType,
            string ProductTitle,
            IReadOnlyList<Property>? Properties,
            int Quantity,
            decimal? SubtotalPrice,
            decimal? UnitPrice,
            string VariantTitle
        );

        public record PaymentDetails(
        );

        public record PaymentMethod(
            int Id,
            Address BillingAddress,
            PaymentDetails PaymentDetails
        );

        public record Order(
            string? Id,
            int AddressId,
            int? ChargeId,
            IReadOnlyList<LineItem> LineItems,
            PaymentMethod PaymentMethod,
            Address ShippingAddress
        );

        public record Delivery(
            DateOnly? Date,
            IReadOnlyList<Order> Orders
        );
    }

    public static class DeleteCustomerTypes
    {
        public record Response();
    }
}







