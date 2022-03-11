using System;
using RechargeSharp.v2021_11.Endpoints.PaymentMethods;
using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.PaymentMethods;

public static class list_payment_methods_200
{
    public static PaymentMethodService.ListPaymentMethodTypes.Response CorrectlyDeserializedJson()
    {
        return new PaymentMethodService.ListPaymentMethodTypes.Response(
            new []
            {
                new PaymentMethodService.SharedTypes.PaymentMethod(
                    Id: 324534534,
                    CustomerId: 132123123,
                    BillingAddress: new Address(
                        Address1: "Teststreet 1",
                        Address2: null,
                        City: "København",
                        Company: "",
                        Country: "Denmark",
                        CountryCode: "DK",
                        FirstName: "Firstname",
                        LastName: "Lastname",
                        Phone: "11223344",
                        Province: null,
                        Zip: "1000"
                    ),
                    CreatedAt: DateTime.Parse("2022-03-09T10:27:40"),
                    Default: true,
                    PaymentDetails: new PaymentMethodService.SharedTypes.PaymentDetails(
                        Brand: "visa",
                        ExpMonth: 3,
                        ExpYear: 2023,
                        Last4: "0001",
                        PaypalEmail: null,
                        PaypalPayerId: null,
                        WalletType: null,
                        FundingType: null
                    ),
                    PaymentType: "CREDIT_CARD",
                    ProcessorCustomerToken: "cus_testtest1",
                    ProcessorName: "stripe",
                    ProcessorPaymentMethodToken: "pm_testtest1",
                    Status: null,
                    StatusReason: null,
                    UpdatedAt: DateTime.Parse("2022-03-09T10:27:40")
                ),
                new PaymentMethodService.SharedTypes.PaymentMethod(
                    Id: 123123123,
                    CustomerId: 23232323,
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
                    CreatedAt: DateTime.Parse("2022-03-09T10:27:40"),
                    Default: null,
                    PaymentDetails: new PaymentMethodService.SharedTypes.PaymentDetails(
                        Brand: null,
                        ExpMonth: null,
                        ExpYear: null,
                        Last4: null,
                        PaypalEmail: null,
                        PaypalPayerId: null,
                        WalletType: null,
                        FundingType: null
                    ),
                    PaymentType: null,
                    ProcessorCustomerToken: null,
                    ProcessorName: "stripe",
                    ProcessorPaymentMethodToken: null,
                    Status: null,
                    StatusReason: null,
                    UpdatedAt: DateTime.Parse("2022-03-09T10:27:33")
                )
            }
        );
    }
}