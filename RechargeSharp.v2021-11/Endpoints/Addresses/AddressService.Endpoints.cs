using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Addresses;

public interface IAddressService
{
    Task<AddressService.CreateAddressTypes.Response> CreateAddressAsync(AddressService.CreateAddressTypes.Request request);
    Task<AddressService.GetAddressTypes.Response?> GetAddressAsync(long addressId);
    Task<AddressService.UpdateAddressTypes.Response> UpdateAddressAsync(long addressId, AddressService.UpdateAddressTypes.Request request);
    Task DeleteAddressAsync(long addressId);
    Task<AddressService.ListAddressesTypes.Response> ListAddressesAsync(AddressService.ListAddressesTypes.Request? request);
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

    public async Task<GetAddressTypes.Response?> GetAddressAsync(long addressId)
    {
        var requestUri = $"/addresses/{addressId}";
        var responseJson = await _rechargeApiCaller.GetNullableAsync<GetAddressTypes.Response>(requestUri);
        return responseJson;
    }

    public async Task<UpdateAddressTypes.Response> UpdateAddressAsync(long addressId, UpdateAddressTypes.Request request)
    {
        var requestUri = $"/addresses/{addressId}";
        var responseJson =
            await _rechargeApiCaller.PutAsync<UpdateAddressTypes.Request, UpdateAddressTypes.Response>(request, requestUri);
        return responseJson;
    }

    public async Task DeleteAddressAsync(long addressId)
    {
        var requestUri = $"/addresses/{addressId}";
        await _rechargeApiCaller.DeleteAsync(requestUri);
    }

    public async Task<ListAddressesTypes.Response> ListAddressesAsync(ListAddressesTypes.Request? request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/addresses{queryString.Value}";
        var responseJson = await _rechargeApiCaller.GetAsync<ListAddressesTypes.Response>(requestUri);
        return responseJson;
    }
}