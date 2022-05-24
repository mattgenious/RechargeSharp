namespace RechargeSharp.v2021_11.Endpoints.Addresses;

public partial class AddressService
{
    public static class SharedAddressTypes
    {
        public record ShippingLineOverride
        {
            public string? Code { get; init; }
            public decimal? Price { get; init; }
            public string? Title { get; init; }
        }

        public record OrderAttribute
        {
            public string? Name { get; init; }
            public string? Value { get; init; }
        }

        public record Address
        {
            public long? Id { get; init; }
            public long? CustomerId { get; init; }
            public long? PaymentMethodId { get; init; }
            public string? Address1 { get; init; }
            public string? Address2 { get; init; }
            public string? City { get; init; }
            public string? Company { get; init; }
            public string? CountryCode { get; init; }
            public DateTime? CreatedAt { get; init; }
            public IReadOnlyList<Discount>? Discounts { get; init; }
            public string? FirstName { get; init; }
            public string? LastName { get; init; }
            public IReadOnlyList<OrderAttribute>? OrderAttributes { get; init; }
            public string? OrderNote { get; init; }
            public string? Phone { get; init; }
            public string? PresentmentCurrency { get; init; }
            public string? Province { get; init; }
            public IReadOnlyList<ShippingLineOverride>? ShippingLinesOverride { get; init; }
            public DateTime? UpdatedAt { get; init; }
            public string? Zip { get; init; }
        }

        public record Discount
        {
            public long? Id { get; init; }
        }
    }

    public static class CreateAddressTypes
    {
        public record Request
        {
            public long? CustomerId { get; init; }
            public string? Address1 { get; init; }
            public string? Address2 { get; init; }
            public string? City { get; init; }
            public string? Company { get; init; }
            public string? CountryCode { get; init; }
            public IReadOnlyList<SharedAddressTypes.Discount>? Discounts { get; init; }
            public string? FirstName { get; init; }
            public string? LastName { get; init; }
            public IReadOnlyList<SharedAddressTypes.OrderAttribute>? OrderAttributes { get; init; }
            public string? OrderNote { get; init; }
            public long? PaymentMethodId { get; init; }
            public string? Phone { get; init; }
            public string? Province { get; init; }
            public IReadOnlyList<SharedAddressTypes.ShippingLineOverride>? ShippingLinesOverride { get; init; }
            public string? Zip { get; init; }
        }

        public record Response
        {
            public SharedAddressTypes.Address? Address { get; init; }
        }
    }

    public static class GetAddressTypes
    {
        public record Response
        {
            public SharedAddressTypes.Address? Address { get; init; }
        }
    }

    public static class UpdateAddressTypes
    {
        public record Request
        {
            public string? Address1 { get; init; }
            public string? Address2 { get; init; }
            public string? City { get; init; }
            public string? Company { get; init; }
            public string? CountryCode { get; init; }
            public IReadOnlyList<SharedAddressTypes.Discount>? Discounts { get; init; }
            public string? FirstName { get; init; }
            public string? LastName { get; init; }
            public IReadOnlyList<SharedAddressTypes.OrderAttribute>? OrderAttributes { get; init; }
            public string? OrderNote { get; init; }
            public long? PaymentMethodId { get; init; }
            public string? Phone { get; init; }
            public string? Province { get; init; }
            public IReadOnlyList<SharedAddressTypes.ShippingLineOverride>? ShippingLinesOverride { get; init; }
            public string? Zip { get; init; }
        }

        public record Response
        {
            public SharedAddressTypes.Address? Address { get; init; }
        }
    }

    public record ListAddressesTypes
    {
        public record Request
        {
            public DateTime? CreatedAtMax { get; init; }
            public DateTime? CreatedAtMin { get; init; }
            public long? CustomerId { get; init; }
            public string? DiscountCode { get; init; }
            public long? DiscountId { get; init; }
            public int? Limit { get; init; }
            public int? Page { get; init; }
            public string? UpdatedAtMax { get; init; }
            public string? UpdatedAtMin { get; init; }
            public bool? IsActive { get; init; }
        }

        public record Response
        {
            public string? NextCursor { get; init; }
            public string? PreviousCursor { get; init; }
            public IReadOnlyList<SharedAddressTypes.Address>? Addresses { get; init; }
        }
    }
}