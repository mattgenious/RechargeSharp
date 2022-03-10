using System;
using RechargeSharp.v2021_11.Entities.Addresses;
using RechargeSharp.v2021_11.Entities.Customers;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class create_address_201
{
    public static AddressesService.CreateAddressTypes.Response CorrectlyDeserializedJson()
    {
        return new AddressesService.CreateAddressTypes.Response(
            new AddressesService.CreateAddressTypes.Address(
                Id: 89907581,
                CustomerId: 82947450,
                PaymentMethodId: null,
                Address1: "1776 Washington Street",
                Address2: null,
                City: "Los Angeles",
                Company: "Recharge",
                CountryCode: "US",
                CreatedAt: DateTime.Parse("2022-03-10T10:28:40+00:00"),
                Discounts: Array.Empty<AddressesService.CreateAddressTypes.Discount>(),
                FirstName: "Niels",
                LastName: "Doe",
                OrderAttributes: new AddressesService.CreateAddressTypes.OrderAttribute[]
                {
                    new AddressesService.CreateAddressTypes.OrderAttribute(
                        Name: "custom name",
                        Value: "custom value"
                    )
                },
                OrderNote:null,
                Phone:"5551234567",
                PresentmentCurrency:"DKK",
                Province:"California",
                ShippingLinesOverride: Array.Empty<AddressesService.CreateAddressTypes.ShippingLineOverride>(),
                UpdatedAt: DateTime.Parse("2022-03-10T10:28:40+00:00"),
                Zip:"90404"
            ));
    }
}