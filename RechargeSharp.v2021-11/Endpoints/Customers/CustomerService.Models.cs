using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Endpoints.Customers;

public partial class CustomerService
{
    

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