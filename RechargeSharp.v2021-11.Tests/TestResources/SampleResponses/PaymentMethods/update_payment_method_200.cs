using System;
using RechargeSharp.v2021_11.Endpoints.PaymentMethods;
using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.PaymentMethods;

public static class update_payment_method_200
{
    public static PaymentMethodService.UpdatePaymentMethodTypes.Response CorrectlyDeserializedJson()
    {
        return new PaymentMethodService.UpdatePaymentMethodTypes.Response()
        {
            PaymentMethod = new PaymentMethodService.SharedTypes.PaymentMethod()
            {
                Id = 123123,
                CustomerId = 2222222,
                BillingAddress = new Address()
                {
                    Address1 = "Teststreet 2",
                    Address2 = null,
                    City = "København",
                    Company = null,
                    Country = "Denmark",
                    CountryCode = "DK",
                    FirstName = "Firstname",
                    LastName = "Lastname",
                    Phone = "22222222",
                    Province = "",
                    Zip = "1000"
                },
                CreatedAt = DateTime.Parse("2022-03-09T10:25:10"),
                Default = true,
                PaymentDetails = new PaymentMethodService.SharedTypes.PaymentDetails()
                {
                    Brand = "visa",
                    ExpMonth = 4,
                    ExpYear = 2024,
                    Last4 = "2222",
                    PaypalEmail = null,
                    PaypalPayerId = null,
                    WalletType = null,
                    FundingType = null
                },
                PaymentType = "CREDIT_CARD",
                ProcessorCustomerToken = "cus_testcustomertoken",
                ProcessorName = "stripe",
                ProcessorPaymentMethodToken = "card_testpaymenttoken",
                Status = null,
                StatusReason = null,
                UpdatedAt = DateTime.Parse("2022-03-10T03:07:50")
            }
        };
    }
}