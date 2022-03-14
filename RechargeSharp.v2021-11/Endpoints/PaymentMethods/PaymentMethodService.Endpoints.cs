using RechargeSharp.v2021_11.SharedModels;
using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.PaymentMethods;

public partial class PaymentMethodService
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

    public async Task<GetPaymentMethodTypes.Response> GetPaymentMethodAsync(int paymentMethodId)
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        var responseJson = await _rechargeApiCaller.GetAsync<GetPaymentMethodTypes.Response>(requestUri);
        return responseJson;
    }

    public async Task<UpdatePaymentMethodTypes.Response> UpdatePaymentMethodAsync(int paymentMethodId, UpdatePaymentMethodTypes.Request request)
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        var responseJson = await _rechargeApiCaller.PutAsync<UpdatePaymentMethodTypes.Request, UpdatePaymentMethodTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<DeletePaymentMethodTypes.Response> DeletePaymentMethodAsync(int paymentMethodId)
    {
        var requestUri = $"/payment_methods/{paymentMethodId}";
        await _rechargeApiCaller.DeleteAsync(requestUri);
        return new DeletePaymentMethodTypes.Response();
    }
    
    public async Task<ListPaymentMethodTypes.Response> ListPaymentMethodsAsync(ListPaymentMethodTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/payment_methods{queryString.Value}";
        var responseJson = await _rechargeApiCaller.GetAsync<ListPaymentMethodTypes.Response>(requestUri);
        return responseJson;
    }
}