using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Endpoints.PaymentMethods;

public partial class PaymentMethodService
{
    public static class SharedTypes
    {
        public record PaymentMethod(
            int Id,
            int CustomerId,
            Address BillingAddress,
            DateTime CreatedAt,
            bool? Default,
            PaymentDetails? PaymentDetails,
            string? PaymentType,
            string? ProcessorCustomerToken,
            string ProcessorName,
            string? ProcessorPaymentMethodToken,
            string? Status,
            string? StatusReason,
            DateTime UpdatedAt
        );

        public record PaymentDetails(
            string? Brand,
            int? ExpMonth,
            int? ExpYear,
            string? Last4,
            string? PaypalEmail,
            string? PaypalPayerId,
            string? WalletType,
            string? FundingType
        );
    }

    public static class CreatePaymentMethodTypes
    {
        public record Request(
            int CustomerId,
            bool Default,
            string PaymentType,
            string ProcessorCustomerToken,
            string ProcessorName,
            string ProcessorPaymentMethodToken,
            Address? BillingAddress
        );

        public record Response(
            SharedTypes.PaymentMethod PaymentMethod
        );
    }

    public static class GetPaymentMethodTypes
    {
        public record Response(
            SharedTypes.PaymentMethod PaymentMethod
        );
    }

    public static class UpdatePaymentMethodTypes
    {
        public record Request(
            bool? Default,
            string? ProcessorName,
            Address? BillingAddress
        );

        public record Response(
            SharedTypes.PaymentMethod PaymentMethod
        );
    }

    public static class DeletePaymentMethodTypes
    {
        public record Response();
    }

    public static class ListPaymentMethodTypes
    {
        public record Request(string? CustomerId, int? Page, int? Limit);

        public record Response(IReadOnlyList<SharedTypes.PaymentMethod> PaymentMethods);
    }
}