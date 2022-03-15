using System;
using RechargeSharp.v2021_11.Endpoints.Addresses;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Addresses;

public static class update_address_200
{
    public static AddressService.UpdateAddressTypes.Response CorrectlyDeserializedJson()
    {
        return new AddressService.UpdateAddressTypes.Response()
        {
            Address = new AddressService.SharedAddressTypes.Address()
            {
                Id = 123123,
                CustomerId = 12312312,
                PaymentMethodId = null,
                Address1 = "200 Washington Street",
                Address2 = null,
                City = "Los Angeles",
                Company = "Recharge",
                CountryCode = "US",
                CreatedAt = DateTime.Parse("2022-03-10T10:28:40+00:00"),
                Discounts = Array.Empty<AddressService.SharedAddressTypes.Discount>(),
                FirstName = "Niels",
                LastName = "Doe",
                OrderAttributes = new AddressService.SharedAddressTypes.OrderAttribute[]
                {
                    new AddressService.SharedAddressTypes.OrderAttribute()
                    {
                        Name = "custom name",
                        Value = "custom value"
                    }
                },
                OrderNote = null,
                Phone = "5551234567",
                PresentmentCurrency = "DKK",
                Province = "California",
                ShippingLinesOverride = Array.Empty<AddressService.SharedAddressTypes.ShippingLineOverride>(),
                UpdatedAt = DateTime.Parse("2022-03-10T12:02:14+00:00"),
                Zip = "90404"
            }
        };
    }
}