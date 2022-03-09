using System;
using RechargeSharp.v2021_11.Entities.Customers;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class create_customer_201
{
    public static CustomerService.CreateCustomerTypes.Response CorrectlyDeserializedJson()
    {
        return new CustomerService.CreateCustomerTypes.Response(
            new CustomerService.SharedTypes.Customer(
                Id: 82939898,
                AnalyticsData: new CustomerService.SharedTypes.AnalyticsData(
                    Array.Empty<CustomerService.SharedTypes.UtmParam>()),
                CreatedAt: DateTime.Parse("2022-03-09T02:31:39"),
                Email: "testtesttest4@test.dk",
                ExternalCustomerId: new CustomerService.SharedTypes.ExternalCustomerId(null),
                FirstChargeProcessedAt: null,
                FirstName: "Niels",
                HasPaymentMethodInDunning: false,
                HasValidPaymentMethod: false,
                Hash: "5c67cf72683ba786c29af7dc3948f0",
                LastName: "Bohr",
                SubscriptionsActiveCount: 0,
                SubscriptionsTotalCount: 0,
                UpdatedAt: DateTime.Parse("2022-03-09T02:31:39")
            ));
    }
}