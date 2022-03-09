using System;
using RechargeSharp.v2021_11.Entities.Customers;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class update_customer_200
{
    public static CustomerService.UpdateCustomerTypes.Response CorrectlyDeserializedJson()
    {
        return new CustomerService.UpdateCustomerTypes.Response(
            new CustomerService.SharedTypes.Customer(
                Id: 82940507,
                AnalyticsData: new CustomerService.SharedTypes.AnalyticsData(
                    Array.Empty<CustomerService.SharedTypes.UtmParam>()),
                CreatedAt: DateTime.Parse("2022-03-09T03:03:28"),
                Email: "testtesttest11@test.dk",
                ExternalCustomerId: new CustomerService.SharedTypes.ExternalCustomerId(null),
                FirstChargeProcessedAt: null,
                FirstName: "Niels",
                HasPaymentMethodInDunning: false,
                HasValidPaymentMethod: false,
                Hash: "76c76acc6ee60a756616312a75baba",
                LastName: "Bohr",
                SubscriptionsActiveCount: 0,
                SubscriptionsTotalCount: 0,
                UpdatedAt: DateTime.Parse("2022-03-09T03:03:49")
            )
        );
    }
}