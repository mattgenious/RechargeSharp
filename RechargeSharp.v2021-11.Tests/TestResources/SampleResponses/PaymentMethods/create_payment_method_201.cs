using System;
using RechargeSharp.v2021_11.Endpoints.PaymentMethods;
using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.PaymentMethods;

public static class create_payment_method_201
{
    public static PaymentMethodsService.CreatePaymentMethodTypes.Response CorrectlyDeserializedJson()
    {
        return new PaymentMethodsService.CreatePaymentMethodTypes.Response(
            PaymentMethod: new PaymentMethodsService.SharedTypes.PaymentMethod(
                Id: 123123,
                CustomerId: 2222222,
                BillingAddress: new Address(
                    Address1: null,
                    Address2: null,
                    City: null,
                    Company: null,
                    Country: null,
                    CountryCode: null,
                    FirstName: null,
                    LastName: null,
                    Phone: null,
                    Province: null,
                    Zip: null
                ),
                CreatedAt: DateTime.Parse("2022-03-09T08:45:03"),
                Default: true,
                PaymentDetails: new PaymentMethodsService.SharedTypes.PaymentDetails(
                    Brand: "visa",
                    ExpMonth: 4,
                    ExpYear: 2024,
                    Last4: "1234",
                    PaypalEmail: null,
                    PaypalPayerId: null,
                    WalletType: null,
                    FundingType: null
                ),
                PaymentType: "CREDIT_CARD",
                ProcessorCustomerToken: "cus_testtest",
                ProcessorName: "stripe",
                ProcessorPaymentMethodToken: "pm_testtest",
                Status: null,
                StatusReason: null,
                UpdatedAt: DateTime.Parse("2022-03-09T08:45:03")
            )
        );
    }
}