using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Endpoints.Customers;

public partial class CustomerService
{
    public static class SharedTypes
    {
        public record ExternalCustomerId
        {
            public string? Ecommerce { get; init; }
        }

        public record Customer
        {
            public long? Id { get; init; }
            public AnalyticsData? AnalyticsData { get; init; }
            public DateTime? CreatedAt { get; init; }
            public string? Email { get; init; }
            public ExternalCustomerId? ExternalCustomerId { get; init; }
            public DateTime? FirstChargeProcessedAt { get; init; }
            public string? FirstName { get; init; }
            public bool? HasPaymentMethodInDunning { get; init; }
            public bool? HasValidPaymentMethod { get; init; }
            public string? Hash { get; init; }
            public string? LastName { get; init; }
            public int? SubscriptionsActiveCount { get; init; }
            public int? SubscriptionsTotalCount { get; init; }
            public DateTime? UpdatedAt { get; init; }
        }
    }

    public static class CreateCustomerTypes
    {
        public record Request
        {
            public string? Email { get; init; }
            public string? FirstName { get; init; }
            public string? LastName { get; init; }
            public SharedTypes.ExternalCustomerId? ExternalCustomerId { get; init; }
        }

        public record Response
        {
            public SharedTypes.Customer? Customer { get; init; }
        }
    }

    public static class UpdateCustomerTypes
    {
        public record Request
        {
            public string? Email { get; init; }
            public string? FirstName { get; init; }
            public string? LastName { get; init; }
            public SharedTypes.ExternalCustomerId? ExternalCustomerId { get; init; }
        }

        public record Response
        {
            public SharedTypes.Customer? Customer { get; init; }
        }
    }

    public static class ListCustomersTypes
    {
        public record Request
        {
            public string? Email { get; init; }
            public DateTime? CreatedAtMax { get; init; }
            public DateTime? CreatedAtMin { get; init; }
            public string? Hash { get; init; }
            public int? Limit { get; init; }
            public int? Page { get; init; }
            public string? ExternalCustomerId { get; init; }
            public DateTime? UpdatedAtMax { get; init; }
            public DateTime? UpdatedAtMin { get; init; }
            public string? Cursor { get; init; }
        }

        public record Response
        {
            public string? NextCursor { get; init; }
            public string? PreviousCursor { get; init; }
            public IReadOnlyList<SharedTypes.Customer>? Customers { get; init; }
        }
    }

    public static class GetCustomerTypes
    {
        public record Response
        {
            public SharedTypes.Customer? Customer { get; init; }
        }
    }

    public static class GetCustomerDeliveryScheduleTypes
    {
        public record Request
        {
            public int? DeliveryCountFuture { get; init; }
            public int? FutureInterval { get; init; }
            public DateTime? DateMin { get; init; }
            public DateTime? DateMax { get; init; }
        }

        public record Response
        {
            public Customer? Customer { get; init; }
            public IReadOnlyList<Delivery>? Deliveries { get; init; }
        }

        public record Customer
        {
            public long? Id { get; init; }
            public string? Email { get; init; }
            public string? FirstName { get; init; }
            public string? LastName { get; init; }
        }

        public record ExternalProductId
        {
            public string? Ecommerce { get; init; }
        }

        public record ExternalVariantId
        {
            public string? Ecommerce { get; init; }
        }

        public record Images
        {
            public string? Large { get; init; }
            public string? Medium { get; init; }
            public string? Small { get; init; }
            public string? Original { get; init; }
            public int? SortOrder { get; init; }
        }

        public record Property
        {
            public string? Name { get; init; }
            public string? Value { get; init; }
        }

        public record LineItem
        {
            public long? SubscriptionId { get; init; }
            public ExternalProductId? ExternalProductId { get; init; }
            public ExternalVariantId? ExternalVariantId { get; init; }
            public Images? Images { get; init; }
            public bool? IsSkippable { get; init; }
            public string? PlanType { get; init; }
            public string? ProductTitle { get; init; }
            public IReadOnlyList<Property>? Properties { get; init; }
            public int? Quantity { get; init; }
            public decimal? SubtotalPrice { get; init; }
            public decimal? UnitPrice { get; init; }
            public string? VariantTitle { get; init; }
        }
        
        public record PaymentDetails
        {
            public string? Brand { get; init; }
            public int? ExpMonth { get; init; }
            public int? ExpYear { get; init; }
            public string? Last4 { get; init; }
            public string? PaypalEmail { get; init; }
            public string? PaypalPayerId { get; init; }
            public string? WalletType { get; init; }
            public string? FundingType { get; init; }
        }

        public record PaymentMethod
        {
            public long? Id { get; init; }
            public Address? BillingAddress { get; init; }
            public PaymentDetails? PaymentDetails { get; init; }
        }

        public record Order
        {
            public long? Id { get; init; }
            public long? AddressId { get; init; }
            public long? ChargeId { get; init; }
            public IReadOnlyList<LineItem>? LineItems { get; init; }
            public PaymentMethod? PaymentMethod { get; init; }
            public Address? ShippingAddress { get; init; }
        }

        public record Delivery
        {
            public DateOnly? Date { get; init; }
            public IReadOnlyList<Order>? Orders { get; init; }
        }
    }
}