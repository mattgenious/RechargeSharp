using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Endpoints.PaymentMethods;

public partial class PaymentMethodService
{
    public static class SharedTypes
    {
        public record PaymentMethod
        {
            public int? Id { get; init; }
            public int? CustomerId { get; init; }
            public Address? BillingAddress { get; init; }
            public DateTime? CreatedAt { get; init; }
            public bool? Default { get; init; }
            public PaymentDetails? PaymentDetails { get; init; }
            public string? PaymentType { get; init; }
            public string? ProcessorCustomerToken { get; init; }
            public string? ProcessorName { get; init; }
            public string? ProcessorPaymentMethodToken { get; init; }
            public string? Status { get; init; }
            public string? StatusReason { get; init; }
            public DateTime? UpdatedAt { get; init; }
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
    }

    public static class CreatePaymentMethodTypes
    {
        public record Request
        {
            public int? CustomerId { get; init; }
            public bool? Default { get; init; }
            public string? PaymentType { get; init; }
            public string? ProcessorCustomerToken { get; init; }
            public string? ProcessorName { get; init; }
            public string? ProcessorPaymentMethodToken { get; init; }
            public Address? BillingAddress { get; init; }
        }

        public record Response
        {
            public SharedTypes.PaymentMethod? PaymentMethod { get; init; }
        }
    }

    public static class GetPaymentMethodTypes
    {
        public record Response
        {
            public SharedTypes.PaymentMethod? PaymentMethod { get; init; }
        }
    }

    public static class UpdatePaymentMethodTypes
    {
        public record Request
        {
            public bool? Default { get; init; }
            public string? ProcessorName { get; init; }
            public Address? BillingAddress { get; init; }
        }

        public record Response
        {
            public SharedTypes.PaymentMethod? PaymentMethod { get; init; }
        }
    }

    public static class DeletePaymentMethodTypes
    {
        public record Response
        {
            public Response()
            {
            }
        }
    }

    public static class ListPaymentMethodTypes
    {
        public record Request
        {
            public string? CustomerId { get; init; }
            public int? Page { get; init; }
            public int? Limit { get; init; }
        }

        public record Response
        {
            public IReadOnlyList<SharedTypes.PaymentMethod>? PaymentMethods { get; init; }
        }
    }
}