using RechargeSharp.v2021_11.SharedModels;
using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.PaymentMethods;

public interface IPaymentMethodService
{
    Task<PaymentMethodService.CreatePaymentMethodTypes.Response> CreatePaymentMethodAsync(PaymentMethodService.CreatePaymentMethodTypes.Request request);
    Task<PaymentMethodService.GetPaymentMethodTypes.Response?> GetPaymentMethodAsync(long paymentMethodId);
    Task<PaymentMethodService.UpdatePaymentMethodTypes.Response> UpdatePaymentMethodAsync(long paymentMethodId, PaymentMethodService.UpdatePaymentMethodTypes.Request request);
    Task DeletePaymentMethodAsync(long paymentMethodId);
    Task<PaymentMethodService.ListPaymentMethodTypes.Response> ListPaymentMethodsAsync(PaymentMethodService.ListPaymentMethodTypes.Request? request);
}

public partial class PaymentMethodService : IPaymentMethodService
{
    private readonly IRechargeApiCaller _rechargeApiCaller;

    public PaymentMethodService(IRechargeApiCaller rechargeApiCaller)
    {
        _rechargeApiCaller = rechargeApiCaller;
    }

    public async Task<CreatePaymentMethodTypes.Response> CreatePaymentMethodAsync(CreatePaymentMethodTypes.Request request)
    {
        var requestUri = $"/payment_methods";
        var responseJson = await _rechargeApiCaller.PostAsync<CreatePaymentMethodTypes.Request, CreatePaymentMethodTypes.Response> (request, requestUri);
        return responseJson;
    }

    public async Task<GetPaymentMethodTypes.Response?> GetPaymentMethodAsync(long paymentMethodId)
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        var responseJson = await _rechargeApiCaller.GetNullableAsync<GetPaymentMethodTypes.Response>(requestUri);
        return responseJson;
    }

    public async Task<UpdatePaymentMethodTypes.Response> UpdatePaymentMethodAsync(long paymentMethodId,
        UpdatePaymentMethodTypes.Request request)
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        var responseJson = await _rechargeApiCaller.PutAsync<UpdatePaymentMethodTypes.Request, UpdatePaymentMethodTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task DeletePaymentMethodAsync(long paymentMethodId)
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        await _rechargeApiCaller.DeleteAsync(requestUri);
    }
    
    public async Task<ListPaymentMethodTypes.Response> ListPaymentMethodsAsync(ListPaymentMethodTypes.Request? request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/payment_methods{queryString.Value}";
        var responseJson = await _rechargeApiCaller.GetAsync<ListPaymentMethodTypes.Response>(requestUri);
        return responseJson;
    }
}