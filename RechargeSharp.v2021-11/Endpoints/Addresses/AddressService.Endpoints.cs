using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Addresses;

public interface IAddressService
{
    Task<AddressService.CreateAddressTypes.Response> CreateAddressAsync(AddressService.CreateAddressTypes.Request request);
    Task<AddressService.GetAddressTypes.Response> GetAddressAsync(int addressId);
    Task<AddressService.UpdateAddressTypes.Response> UpdateAddressAsync(int addressId, AddressService.UpdateAddressTypes.Request request);
    Task<AddressService.DeleteAddressTypes.Response> DeleteAddressAsync(int addressId);
    Task<AddressService.ListAddressesTypes.Response> ListAddressesAsync(AddressService.ListAddressesTypes.Request request);
}

public partial class AddressService : IAddressService
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