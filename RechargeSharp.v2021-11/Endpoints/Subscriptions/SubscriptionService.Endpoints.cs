using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Subscriptions;

public interface ISubscriptionService
{
    Task<SubscriptionService.CreateSubscriptionTypes.Response> CreateSubscriptionAsync(SubscriptionService.CreateSubscriptionTypes.Request request);
    Task<SubscriptionService.GetSubscriptionTypes.Response?> GetSubscriptionAsync(long subscriptionId);
    Task<SubscriptionService.UpdateSubscriptionTypes.Response> UpdateSubscriptionAsync(long subscriptionId, SubscriptionService.UpdateSubscriptionTypes.Request request);
    Task DeleteSubscriptionAsync(long subscriptionId);
    Task<SubscriptionService.ListSubscriptionsTypes.Response> ListSubscriptionsAsync(SubscriptionService.ListSubscriptionsTypes.Request? request);
    Task<SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Response> ChangeSubscriptionsNextChargeDateAsync(long subscriptionId, SubscriptionService.ChangeSubscriptionsNextChargeDateTypes.Request request);
    Task<SubscriptionService.ChangeSubscriptionsAddressTypes.Response> ChangeSubscriptionsAddressAsync(long subscriptionId, SubscriptionService.ChangeSubscriptionsAddressTypes.Request request);
    Task<SubscriptionService.CancelSubscriptionTypes.Response> CancelSubscriptionAsync(long subscriptionId, SubscriptionService.CancelSubscriptionTypes.Request request);
    Task<SubscriptionService.ActivateSubscriptionTypes.Response> ActivateSubscriptionAsync(long subscriptionId);
}

public partial class SubscriptionService : ISubscriptionService
{
    private readonly IRechargeApiCaller _rechargeApiCaller;

    public SubscriptionService(IRechargeApiCaller rechargeApiCaller)
    {
        _rechargeApiCaller = rechargeApiCaller;
    }

    public async Task<CreateSubscriptionTypes.Response> CreateSubscriptionAsync(CreateSubscriptionTypes.Request request)
    {
        var requestUri = $"/subscriptions";
        var responseJson = await _rechargeApiCaller.PostAsync<CreateSubscriptionTypes.Request, CreateSubscriptionTypes.Response> (request, requestUri);
        return responseJson;
    }

    public async Task<GetSubscriptionTypes.Response?> GetSubscriptionAsync(long subscriptionId)
    {
        var requestUri = $"/subscriptions/{subscriptionId}";
        var responseJson = await _rechargeApiCaller.GetNullableAsync<GetSubscriptionTypes.Response> (requestUri);
        return responseJson;
    }
    
    public async Task<UpdateSubscriptionTypes.Response> UpdateSubscriptionAsync(long subscriptionId,
        UpdateSubscriptionTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}";
        var responseJson = await _rechargeApiCaller.PutAsync<UpdateSubscriptionTypes.Request, UpdateSubscriptionTypes.Response>(request,requestUri);
        return responseJson;
    }
    
    public async Task DeleteSubscriptionAsync(long subscriptionId)
    {
        var requestUri = $"/subscriptions/{subscriptionId}";
        await _rechargeApiCaller.DeleteAsync(requestUri);
    }
    
    public async Task<ListSubscriptionsTypes.Response> ListSubscriptionsAsync(ListSubscriptionsTypes.Request? request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/subscriptions{queryString.Value}";
        var responseJson = await _rechargeApiCaller.GetAsync<ListSubscriptionsTypes.Response>(requestUri);
        return responseJson;
    }
    
    public async Task<ChangeSubscriptionsNextChargeDateTypes.Response> ChangeSubscriptionsNextChargeDateAsync(
        long subscriptionId, ChangeSubscriptionsNextChargeDateTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/set_next_charge_date";
        var responseJson = await _rechargeApiCaller.PostAsync<ChangeSubscriptionsNextChargeDateTypes.Request, ChangeSubscriptionsNextChargeDateTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<ChangeSubscriptionsAddressTypes.Response> ChangeSubscriptionsAddressAsync(long subscriptionId,
        ChangeSubscriptionsAddressTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/change_address";
        var responseJson = await _rechargeApiCaller.PostAsync<ChangeSubscriptionsAddressTypes.Request, ChangeSubscriptionsAddressTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<CancelSubscriptionTypes.Response> CancelSubscriptionAsync(long subscriptionId,
        CancelSubscriptionTypes.Request request)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/cancel";
        var responseJson = await _rechargeApiCaller.PostAsync<CancelSubscriptionTypes.Request, CancelSubscriptionTypes.Response>(request, requestUri);
        return responseJson;
    }
    
    public async Task<ActivateSubscriptionTypes.Response> ActivateSubscriptionAsync(long subscriptionId)
    {
        var requestUri = $"/subscriptions/{subscriptionId}/activate";
        var responseJson = await _rechargeApiCaller.PostAsync<ActivateSubscriptionTypes.Response>(requestUri);
        return responseJson;
    }
}