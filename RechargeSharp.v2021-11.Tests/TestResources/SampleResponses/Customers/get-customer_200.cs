using System;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class get_customer_200
{
    public static CustomerService.GetCustomerTypes.Response CorrectlyDeserializedJson()
    {
        return new CustomerService.GetCustomerTypes.Response()
        {
            Customer = new CustomerService.SharedTypes.Customer()
            {
                Id = 82940007,
                AnalyticsData = new AnalyticsData()
                {
                    UtmParams = Array.Empty<UtmParam>()
                },
                CreatedAt = DateTime.Parse("2022-03-09T02:36:35"),
                Email = "testtesttest5@test.dk",
                ExternalCustomerId = new CustomerService.SharedTypes.ExternalCustomerId() {Ecommerce = null},
                FirstChargeProcessedAt = null,
                FirstName = "Niels",
                HasPaymentMethodInDunning = false,
                HasValidPaymentMethod = false,
                Hash = "6edd4a4f6ca8b1658c581e597ce492",
                LastName = "Bohr",
                SubscriptionsActiveCount = 0,
                SubscriptionsTotalCount = 0,
                UpdatedAt = DateTime.Parse("2022-03-09T02:36:35")
            }
        };
    }
}