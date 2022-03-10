using System;
using RechargeSharp.v2021_11.Endpoints.PaymentMethods;
using RechargeSharp.v2021_11.Entities.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.PaymentMethods;

public static class get_payment_method_200
{
    public static PaymentMethodsService.GetPaymentMethodTypes.Response CorrectlyDeserializedJson()
    {
        return new PaymentMethodsService.GetPaymentMethodTypes.Response(
            PaymentMethod: new PaymentMethodsService.SharedTypes.PaymentMethod(
                Id: 123123,
                CustomerId: 2222222,
                BillingAddress: new Address(
                    Address1: "Teststreet 1",
                    Address2: null,
                    City: "København",
                    Company: null,
                    Country: "Denmark",
                    CountryCode: "DK",
                    FirstName: "Firstname",
                    LastName: "Lastname",
                    Phone: "22222222",
                    Province: "",
                    Zip: "1000"
                ),
                CreatedAt: DateTime.Parse("2022-03-09T10:25:10"),
                Default: true,
                PaymentDetails: new PaymentMethodsService.SharedTypes.PaymentDetails(
                    Brand: "visa",
                    ExpMonth: 4,
                    ExpYear: 2024,
                    Last4: "2222",
                    PaypalEmail: null,
                    PaypalPayerId: null,
                    WalletType: null,
                    FundingType: null
                ),
                PaymentType: "CREDIT_CARD",
                ProcessorCustomerToken: "cus_testcustomertoken",
                ProcessorName: "stripe",
                ProcessorPaymentMethodToken: "card_testpaymenttoken",
                Status: null,
                StatusReason: null,
                UpdatedAt: DateTime.Parse("2022-03-09T10:25:10")
            )
        );
    }
}