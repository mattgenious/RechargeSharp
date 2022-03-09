using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Entities.SharedModels;
using RechargeSharp.v2021_11.Utilities;

namespace RechargeSharp.v2021_11.Entities.PaymentMethods;

public class PaymentMethodsService
{
    private readonly ILogger<PaymentMethodsService> _logger;
    private readonly RechargeApiCaller _rechargeApiCaller;

    public PaymentMethodsService(ILogger<PaymentMethodsService> logger, RechargeApiCaller rechargeApiCaller)
    {
        _logger = logger;
        _rechargeApiCaller = rechargeApiCaller;
    }

    public async Task<CreatePaymentMethodTypes.Response> CreatePaymentMethod(CreatePaymentMethodTypes.Request request)
    {
        var requestUri = $"/payment_methods";
        var responseJson = await _rechargeApiCaller.Post<CreatePaymentMethodTypes.Request, CreatePaymentMethodTypes.Response> (request, requestUri);
        return responseJson;
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
            PaymentMethod PaymentMethod
        );
        
        public record PaymentMethod(
            int Id,
            int CustomerId,
            Address BillingAddress,
            DateTime CreatedAt,
            bool Default,
            PaymentDetails PaymentDetails,
            string PaymentType,
            string ProcessorCustomerToken,
            string ProcessorName,
            string ProcessorPaymentMethodToken,
            string Status,
            string StatusReason,
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
}