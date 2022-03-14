namespace RechargeSharp.v2021_11.Endpoints.Addresses;

public partial class AddressService
{
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
        public record Request
        {
            public string Address1 { get; init; }
            public string? Address2 { get; init; }
            public string City { get; init; }
            public string? Company { get; init; }
            public string CountryCode { get; init; }
            public IReadOnlyList<SharedAddressTypes.Discount> Discounts { get; init; }
            public string FirstName { get; init; }
            public string LastName { get; init; }
            public IReadOnlyList<SharedAddressTypes.OrderAttribute> OrderAttributes { get; init; }
            public string? OrderNote { get; init; }
            public int? PaymentMethodId { get; init; }
            public string Phone { get; init; }
            public string? Province { get; init; }
            public IReadOnlyList<SharedAddressTypes.ShippingLineOverride> ShippingLinesOverride { get; init; }
            public string Zip { get; init; }
        }

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