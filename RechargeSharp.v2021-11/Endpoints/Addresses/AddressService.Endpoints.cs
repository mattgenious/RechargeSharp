using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Addresses;

public partial class AddressService
{
    private readonly IRechargeApiCaller _rechargeApiCaller;

    public AddressService(IRechargeApiCaller rechargeApiCaller)
    {
        _rechargeApiCaller = rechargeApiCaller;
    }

    public async Task<CreateAddressTypes.Response> CreateAddressAsync(CreateAddressTypes.Request request)
    {
        var requestUri = $"/addresses";
        var responseJson =
            await _rechargeApiCaller.PostAsync<CreateAddressTypes.Request, CreateAddressTypes.Response>(request, requestUri);
        return responseJson;
    }

    public async Task<GetAddressTypes.Response> GetAddressAsync(int addressId)
    {
        var requestUri = $"/addresses/{addressId}";
        var responseJson = await _rechargeApiCaller.GetAsync<GetAddressTypes.Response>(requestUri);
        return responseJson;
    }

    public async Task<UpdateAddressTypes.Response> UpdateAddressAsync(int addressId, UpdateAddressTypes.Request request)
    {
        var requestUri = $"/addresses/{addressId}";
        var responseJson =
            await _rechargeApiCaller.PutAsync<UpdateAddressTypes.Request, UpdateAddressTypes.Response>(request, requestUri);
        return responseJson;
    }

    public async Task<DeleteAddressTypes.Response> DeleteAddressAsync(int addressId)
    {
        var requestUri = $"/addresses/{addressId}";
        await _rechargeApiCaller.DeleteAsync(requestUri);
        return new DeleteAddressTypes.Response();
    }

    public async Task<ListAddressesTypes.Response> ListAddressesAsync(ListAddressesTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/addresses{queryString.Value}";
        var responseJson = await _rechargeApiCaller.GetAsync<ListAddressesTypes.Response>(requestUri);
        return responseJson;
    }
}