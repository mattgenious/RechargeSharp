using Microsoft.Extensions.Logging;
using RechargeSharp.v2021_11.Utilities;
using RechargeSharp.v2021_11.Utilities.Queries;

namespace RechargeSharp.v2021_11.Endpoints.Addresses;

public class AddressesService
{
    private readonly ILogger<AddressesService> _logger;
    private readonly RechargeApiCaller _rechargeApiCaller;

    public AddressesService(ILogger<AddressesService> logger, RechargeApiCaller rechargeApiCaller)
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

    public static class SharedAddressTypes
    {
        public record ShippingLineOverride(
            string? Code,
            decimal? Price,
            string Title
        );

        public record OrderAttribute(
            string Name,
            string Value
        );

        public record Address(
            int Id,
            int CustomerId,
            int? PaymentMethodId,
            string Address1,
            string? Address2,
            string City,
            string Company,
            string CountryCode,
            DateTime CreatedAt,
            IReadOnlyList<Discount> Discounts,
            string FirstName,
            string LastName,
            IReadOnlyList<OrderAttribute> OrderAttributes,
            string? OrderNote,
            string Phone,
            string? PresentmentCurrency,
            string Province,
            IReadOnlyList<ShippingLineOverride> ShippingLinesOverride,
            DateTime UpdatedAt,
            string Zip
        );

        public record Discount(int Id);
    }

    public static class CreateAddressTypes
    {
        public record Request(
            int CustomerId,
            string Address1,
            string? Address2,
            string City,
            string? Company,
            string CountryCode,
            IReadOnlyList<SharedAddressTypes.Discount> Discounts,
            string FirstName,
            string LastName,
            IReadOnlyList<SharedAddressTypes.OrderAttribute> OrderAttributes,
            string? OrderNote,
            int? PaymentMethodId,
            string Phone,
            string? Province,
            IReadOnlyList<SharedAddressTypes.ShippingLineOverride> ShippingLinesOverride,
            string Zip
        );

        public record Response(
            SharedAddressTypes.Address Address
        );
    }

    public static class GetAddressTypes
    {
        public record Response(SharedAddressTypes.Address Address);
    }

    public static class UpdateAddressTypes
    {
        public record Request(
            string Address1,
            string? Address2,
            string City,
            string? Company,
            string CountryCode,
            IReadOnlyList<SharedAddressTypes.Discount> Discounts,
            string FirstName,
            string LastName,
            IReadOnlyList<SharedAddressTypes.OrderAttribute> OrderAttributes,
            string? OrderNote,
            int? PaymentMethodId,
            string Phone,
            string? Province,
            IReadOnlyList<SharedAddressTypes.ShippingLineOverride> ShippingLinesOverride,
            string Zip
        );

        public record Response(SharedAddressTypes.Address Address);
    }

    public record DeleteAddressTypes
    {
        public record Response();
    }

    public record ListAddressesTypes
    {
        public record Request(
            DateTime? CreatedAtMax,
            DateTime? CreatedAtMin,
            string? DiscountCode,
            string? DiscountId,
            int? Limit,
            int? Page,
            string? UpdatedAtMax,
            string? UpdatedAtMin,
            bool? IsActive);

        public record Response(
            string? NextCursor,
            string? PreviousCursor,
            IReadOnlyList<SharedAddressTypes.Address> Addresses
        );
    }
}