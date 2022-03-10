using System;
using RechargeSharp.v2021_11.Endpoints.Addresses;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Addresses;

public static class create_address_201
{
    public static AddressesService.CreateAddressTypes.Response CorrectlyDeserializedJson()
    {
        return new AddressesService.CreateAddressTypes.Response(
            new AddressesService.SharedAddressTypes.Address(
                Id: 123123,
                CustomerId: 12312312,
                PaymentMethodId: null,
                Address1: "1776 Washington Street",
                Address2: null,
                City: "Los Angeles",
                Company: "Recharge",
                CountryCode: "US",
                CreatedAt: DateTime.Parse("2022-03-10T10:28:40+00:00"),
                Discounts: Array.Empty<AddressesService.SharedAddressTypes.Discount>(),
                FirstName: "Niels",
                LastName: "Doe",
                OrderAttributes: new AddressesService.SharedAddressTypes.OrderAttribute[]
                {
                    new AddressesService.SharedAddressTypes.OrderAttribute(
                        Name: "custom name",
                        Value: "custom value"
                    )
                },
                OrderNote:null,
                Phone:"5551234567",
                PresentmentCurrency:"DKK",
                Province:"California",
                ShippingLinesOverride: Array.Empty<AddressesService.SharedAddressTypes.ShippingLineOverride>(),
                UpdatedAt: DateTime.Parse("2022-03-10T10:28:40+00:00"),
                Zip:"90404"
            ));
    }
}