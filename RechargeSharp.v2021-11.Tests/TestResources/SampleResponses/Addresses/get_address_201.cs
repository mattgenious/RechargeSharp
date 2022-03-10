using System;
using RechargeSharp.v2021_11.Entities.Addresses;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Addresses;

public static class list_addresses_201
{
    public static AddressesService.ListAddressesTypes.Response CorrectlyDeserializedJson()
    {
        return new AddressesService.ListAddressesTypes.Response(
            NextCursor:
            "eyJzdGFydGluZ19iZWZvcmVfaWQiOjg3OTExMDMxLCJsYXN0X3ZhbHVlIjo4NzkxMTAzMSwic29ydF9ieSI6ImlkLWRlc2MiLCJjdXJzb3JfZGlyIjoibmV4dCJ9",
            PreviousCursor: null,
            new AddressesService.SharedAddressTypes.Address[]
            {
                new AddressesService.SharedAddressTypes.Address(
                    Id: 123123,
                    CustomerId: 22222222,
                    PaymentMethodId: 33333333,
                    Address1: "Teststreet 1",
                    Address2: "Teststreet 1",
                    City: "København",
                    Company: null,
                    CountryCode: "DK",
                    CreatedAt: DateTime.Parse("2022-03-10T12:13:28+00:00"),
                    Discounts: Array.Empty<AddressesService.SharedAddressTypes.Discount>(),
                    FirstName: "Firstname",
                    LastName: "Lastname",
                    OrderAttributes: Array.Empty<AddressesService.SharedAddressTypes.OrderAttribute>(),
                    OrderNote: null,
                    Phone: "22222222",
                    PresentmentCurrency: null,
                    Province: null,
                    ShippingLinesOverride: Array.Empty<AddressesService.SharedAddressTypes.ShippingLineOverride>(),
                    UpdatedAt: DateTime.Parse("2022-03-10T12:13:28+00:00"),
                    Zip: "1000"
                ),
                new AddressesService.SharedAddressTypes.Address(
                    Id: 2342342,
                    CustomerId: 4444444,
                    PaymentMethodId: 5555555,
                    Address1: "Teststreet 1",
                    Address2: "Teststreet 1",
                    City: "København",
                    Company: null,
                    CountryCode: "DK",
                    CreatedAt: DateTime.Parse("2022-03-10T11:58:29+00:00"),
                    Discounts: Array.Empty<AddressesService.SharedAddressTypes.Discount>(),
                    FirstName: "Firstname",
                    LastName: "Lastname",
                    OrderAttributes: Array.Empty<AddressesService.SharedAddressTypes.OrderAttribute>(),
                    OrderNote: null,
                    Phone: "22222222",
                    PresentmentCurrency: null,
                    Province: null,
                    ShippingLinesOverride: Array.Empty<AddressesService.SharedAddressTypes.ShippingLineOverride>(),
                    UpdatedAt: DateTime.Parse("2022-03-10T11:58:29+00:00"),
                    Zip: "1000"
                )
            }
        );


    }
}