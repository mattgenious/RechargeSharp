using System;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Customers;

public static class create_subscription_201
{
    public static SubscriptionService.CreateSubscriptionTypes.Response CorrectlyDeserializedJson()
    {
        return new SubscriptionService.CreateSubscriptionTypes.Response(
            Subscription: new SubscriptionService.CreateSubscriptionTypes.Subscription(
                Id: 123123123,
                AddressId: 22222222,
                CustomerId: 333333333,
                AnalyticsData: new SubscriptionService.CreateSubscriptionTypes.AnalyticsData(
                    UtmParams: Array.Empty<CustomerService.SharedTypes.UtmParam>()
                ),
                CancellationReason: null,
                CancellationReasonComments: null,
                CancelledAt: null,
                ChargeIntervalFrequency: 30,
                CreatedAt: DateTime.Parse("2022-03-10T14:14:30+00:00"),
                ExpireAfterSpecificNumberOfCharges: 1,
                ExternalProductId: new SubscriptionService.CreateSubscriptionTypes.ExternalProductId(
                    Ecommerce: "44444444444"
                ),
                ExternalVariantId: new SubscriptionService.CreateSubscriptionTypes.ExternalVariantId(
                    Ecommerce: "555555555555"
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
                ProductTitle: "Vuffeli Prøvepakke",
                Properties: new SubscriptionService.CreateSubscriptionTypes.Property[]
                {
                     new SubscriptionService.CreateSubscriptionTypes.Property(
                                     Name: "Colour",
                                     Value: "Yellow"
                         ),
                     new SubscriptionService.CreateSubscriptionTypes.Property(
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
            )
        );
    }
}