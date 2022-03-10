using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RechargeSharp.v2021_11.Utilities;

namespace RechargeSharp.v2021_11.Entities.Addresses;

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
        var responseJson = await _rechargeApiCaller.Post<CreateAddressTypes.Request, CreateAddressTypes.Response> (request, requestUri);
        return responseJson;
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
            IReadOnlyList<Discount> Discounts,
            string FirstName,
            string LastName,
            IReadOnlyList<OrderAttribute> OrderAttributes,
            string? OrderNote,
            int? PaymentMethodId,
            string Phone,
            string? Province,
            IReadOnlyList<ShippingLineOverride> ShippingLinesOverride,
            string Zip
        );
        
        public record ShippingLineOverride(
            string? Code,
            decimal? Price,
            string Title
            );

        public record Response(
            Address Address
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
            string Address2,
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

}

