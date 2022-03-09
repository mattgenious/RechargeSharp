using System;
using RechargeSharp.v2021_11.Entities.Customers;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class list_customers_200
{
    public static CustomerService.ListCustomersTypes.Response CorrectlyDeserializedJson()
    {
        return new CustomerService.ListCustomersTypes.Response(
            NextCursor:
            "eyJzdGFydGluZ19iZWZvcmVfaWQiOjcwNDgwODQ0LCJsYXN0X3ZhbHVlIjo3MDQ4MDg0NCwic29ydF9ieSI6ImlkLWRlc2MiLCJjdXJzb3JfZGlyIjoibmV4dCJ9",
            PreviousCursor: null,
            Customers: new[]
            {
                new CustomerService.SharedTypes.Customer(
                    Id: 82940007,
                    AnalyticsData: new CustomerService.SharedTypes.AnalyticsData(
                        Array.Empty<CustomerService.SharedTypes.UtmParam>()),
                    CreatedAt: DateTime.Parse("2022-03-09T02:36:35"),
                    Email: "testtesttest5@test.dk",
                    ExternalCustomerId: new CustomerService.SharedTypes.ExternalCustomerId("5624561795145"),
                    FirstChargeProcessedAt: null,
                    FirstName: "Niels",
                    HasPaymentMethodInDunning: false,
                    HasValidPaymentMethod: false,
                    Hash: "6edd4a4f6ca8b1658c581e597ce492",
                    LastName: "Bohr",
                    SubscriptionsActiveCount: 0,
                    SubscriptionsTotalCount: 0,
                    UpdatedAt: DateTime.Parse("2022-03-09T02:37:31")
                ),
                new CustomerService.SharedTypes.Customer(
                    Id: 82939898,
                    AnalyticsData: new CustomerService.SharedTypes.AnalyticsData(
                        Array.Empty<CustomerService.SharedTypes.UtmParam>()),
                    CreatedAt: DateTime.Parse("2022-03-09T02:31:39"),
                    Email: "testtesttest4@test.dk",
                    ExternalCustomerId: new CustomerService.SharedTypes.ExternalCustomerId("5624559960137"),
                    FirstChargeProcessedAt: null,
                    FirstName: "Niels",
                    HasPaymentMethodInDunning: false,
                    HasValidPaymentMethod: false,
                    Hash: "5c67cf72683ba786c29af7dc3948f0",
                    LastName: "Bohr",
                    SubscriptionsActiveCount: 0,
                    SubscriptionsTotalCount: 0,
                    UpdatedAt: DateTime.Parse("2022-03-09T02:31:58")
                ),
            }
        );
    }
}