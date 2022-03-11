using System;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Subscriptions;

public class cancel_subscription_200
{
    public static SubscriptionService.CancelSubscriptionTypes.Response CorrectlyDeserializedJson()
    {
        return new SubscriptionService.CancelSubscriptionTypes.Response(
            Subscription: new SubscriptionService.SharedSubscriptionTypes.Subscription(
                Id: 11111,
                AddressId: 22222,
                CustomerId: 333333,
                AnalyticsData: new SubscriptionService.SharedSubscriptionTypes.AnalyticsData(
                    UtmParams: Array.Empty<CustomerService.SharedTypes.UtmParam>()
                ),
                CancellationReason: "some reason",
                CancellationReasonComments: "comments go here",
                CancelledAt: DateTime.Parse("2022-03-11T10:19:18.637636+00:00"), 
                ChargeIntervalFrequency: 30,
                CreatedAt: DateTime.Parse("2022-03-10T12:13:28+00:00"),
                ExpireAfterSpecificNumberOfCharges: null,
                ExternalProductId: new SubscriptionService.SharedSubscriptionTypes.ExternalProductId(
                    Ecommerce: "123123123"
                ),
                ExternalVariantId: new SubscriptionService.SharedSubscriptionTypes.ExternalVariantId(
                    Ecommerce: "23434345"
                ),
                HasQueuedCharges: false,
                IsPrepaid: false,
                IsSkippable: true,
                IsSwappable: false,
                MaxRetriesReached: false,
                NextChargeScheduledAt: null,
                OrderDayOfMonth: null,
                OrderDayOfWeek: null,
                OrderIntervalFrequency: 30,
                OrderIntervalUnit: "day",
                PresentmentCurrency: null,
                Price: 49.00m,
                ProductTitle: "Test product",
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
                Status: "cancelled",
                UpdatedAt: DateTime.Parse("2022-03-11T10:19:18+00:00"),
                VariantTitle: "972-1"
            )
        );
    }
}