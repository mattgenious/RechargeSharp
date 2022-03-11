using System;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Subscriptions;

public static class list_subscriptions_200
{
    public static SubscriptionService.ListSubscriptionsTypes.Response CorrectlyDeserializedJson()
    {
        return new SubscriptionService.ListSubscriptionsTypes.Response(
            NextCursor:
            "eyJzdGFydGluZ19iZWZvcmVfaWQiOjIxOTQwNTgzNywibGFzdF92YWx1ZSI6MjE5NDA1ODM3LCJzb3J0X2J5IjoiaWQtZGVzYyIsImN1cnNvcl9kaXIiOiJuZXh0In0",
            PreviousCursor: null,
            Subscriptions: new[]
            {
                new SubscriptionService.SharedSubscriptionTypes.Subscription(
                    Id: 1111,
                    AddressId: 222222,
                    CustomerId: 33333,
                    AnalyticsData: new SubscriptionService.SharedSubscriptionTypes.AnalyticsData(
                        UtmParams: Array.Empty<CustomerService.SharedTypes.UtmParam>()
                    ),
                    CancellationReason: null,
                    CancellationReasonComments: null,
                    CancelledAt: null,
                    ChargeIntervalFrequency: 30,
                    CreatedAt: DateTime.Parse("2022-03-10T14:14:30+00:00"),
                    ExpireAfterSpecificNumberOfCharges: 1,
                    ExternalProductId: new SubscriptionService.SharedSubscriptionTypes.ExternalProductId(
                        Ecommerce: "123123123"
                    ),
                    ExternalVariantId: new SubscriptionService.SharedSubscriptionTypes.ExternalVariantId(
                        Ecommerce: "234324234"
                    ),
                    HasQueuedCharges: true,
                    IsPrepaid: false,
                    IsSkippable: true,
                    IsSwappable: false,
                    MaxRetriesReached: false,
                    NextChargeScheduledAt: DateOnly.Parse("2022-12-17"),
                    OrderDayOfMonth: null,
                    OrderDayOfWeek: null,
                    OrderIntervalFrequency: 30,
                    OrderIntervalUnit: "day",
                    PresentmentCurrency: "DKK",
                    Price: 49.00m,
                    ProductTitle: "Test producttitle",
                    Properties: new SubscriptionService.SharedSubscriptionTypes.Property[]
                    {
                        new SubscriptionService.SharedSubscriptionTypes.Property(
                            Name: "Colour",
                            Value: "Yellow"
                        ),
                        new SubscriptionService.SharedSubscriptionTypes.Property(
                            Name: "Bottle Material",
                            Value: "Glass"
                        ),
                    },
                    Quantity: 3,
                    Sku: null,
                    SkuOverride: false,
                    Status: "active",
                    UpdatedAt: DateTime.Parse("2022-03-10T14:14:30+00:00"),
                    VariantTitle: "972-1"
                ),
                new SubscriptionService.SharedSubscriptionTypes.Subscription(
                Id: 555555,
                AddressId: 666666,
                CustomerId: 777777,
                AnalyticsData: new SubscriptionService.SharedSubscriptionTypes.AnalyticsData(
                    UtmParams: Array.Empty<CustomerService.SharedTypes.UtmParam>()
                ),
                CancellationReason: null,
                CancellationReasonComments: null,
                CancelledAt: null,
                ChargeIntervalFrequency: 30,
                CreatedAt: DateTime.Parse("2022-03-10T12:13:28+00:00"),
                ExpireAfterSpecificNumberOfCharges: null,
                ExternalProductId: new SubscriptionService.SharedSubscriptionTypes.ExternalProductId(
                    Ecommerce: "12341234"
                ),
                ExternalVariantId: new SubscriptionService.SharedSubscriptionTypes.ExternalVariantId(
                    Ecommerce: "213432142"
                ),
                HasQueuedCharges: true,
                IsPrepaid: false,
                IsSkippable: true,
                IsSwappable: false,
                MaxRetriesReached: false,
                NextChargeScheduledAt: DateOnly.Parse("2022-04-09"),
                OrderDayOfMonth: null,
                OrderDayOfWeek: null,
                OrderIntervalFrequency: 30,
                OrderIntervalUnit: "day",
                PresentmentCurrency: null,
                Price: 49.00m,
                ProductTitle: "Test producttitle",
                Properties: new SubscriptionService.SharedSubscriptionTypes.Property[]
                {
                     new SubscriptionService.SharedSubscriptionTypes.Property(
                                     Name: "charge_interval_frequency",
                                     Value: "30"
                         ),
                     new SubscriptionService.SharedSubscriptionTypes.Property(
                         Name: "shipping_interval_frequency",
                         Value: "30"
                     ),
                     new SubscriptionService.SharedSubscriptionTypes.Property(
                         Name: "shipping_interval_unit_type",
                         Value: "day"
                     ),
                },
                Quantity: 4,
                Sku: null,
                SkuOverride: false,
                Status: "active",
                UpdatedAt: DateTime.Parse("2022-03-11T07:01:12+00:00"),
                VariantTitle: "972-1"
            )
            }
        );
    }
}