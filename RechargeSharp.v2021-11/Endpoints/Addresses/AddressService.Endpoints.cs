using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Addresses;

public partial class AddressService
{
    private readonly ILogger<AddressService> _logger;
    private readonly IRechargeApiCaller _rechargeApiCaller;

    public AddressService(ILogger<AddressService> logger, IRechargeApiCaller rechargeApiCaller)
    {
        _logger = logger;
        _rechargeApiCaller = rechargeApiCaller;
    }

    public async Task<CreateAddressTypes.Response> CreateAddress(CreateAddressTypes.Request request)
    {
        var requestUri = $"/addresses";
        var responseJson =
            await _rechargeApiCaller.Post<CreateAddressTypes.Request, CreateAddressTypes.Response>(request, requestUri);
        return responseJson;
    }

    public async Task<GetAddressTypes.Response> GetAddress(int addressId)
    {
        var requestUri = $"/addresses/{addressId}";
        var responseJson = await _rechargeApiCaller.Get<GetAddressTypes.Response>(requestUri);
        return responseJson;
    }

    public async Task<UpdateAddressTypes.Response> UpdateAddress(int addressId, UpdateAddressTypes.Request request)
    {
        var requestUri = $"/addresses/{addressId}";
        var responseJson =
            await _rechargeApiCaller.Put<UpdateAddressTypes.Request, UpdateAddressTypes.Response>(request, requestUri);
        return responseJson;
    }

    public async Task<DeleteAddressTypes.Response> DeleteAddress(int addressId)
    {
        var requestUri = $"/addresses/{addressId}";
        await _rechargeApiCaller.Delete(requestUri);
        return new DeleteAddressTypes.Response();
    }

    public async Task<ListAddressesTypes.Response> ListAddresses(ListAddressesTypes.Request request)
    {
        var queryString = ObjectToQueryStringSerializer.SerializeObjectToQueryString(request);
        var requestUri = $"/addresses{queryString.Value}";
        var responseJson = await _rechargeApiCaller.Get<ListAddressesTypes.Response>(requestUri);
        return responseJson;
    }
}