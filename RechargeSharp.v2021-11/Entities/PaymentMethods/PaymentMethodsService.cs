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
    
    
    public async Task<GetPaymentMethodTypes.Response> GetPaymentMethod(int paymentMethodId)
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        var responseJson = await _rechargeApiCaller.Get<GetPaymentMethodTypes.Response>(requestUri);
        return responseJson;
    }

    public async Task<UpdatePaymentMethodTypes.Response> UpdatePaymentMethod(int paymentMethodId, UpdatePaymentMethodTypes.Request request )
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        var responseJson = await _rechargeApiCaller.Put<UpdatePaymentMethodTypes.Request, UpdatePaymentMethodTypes.Response>(request, requestUri);
        return responseJson;
    }

    public static class SharedTypes
    {
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
}