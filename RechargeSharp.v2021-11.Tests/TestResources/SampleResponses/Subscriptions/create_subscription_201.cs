using System;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;
using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Subscriptions;

public static class create_subscription_201
{
    public static SubscriptionService.CreateSubscriptionTypes.Response CorrectlyDeserializedJson()
    {
        return new SubscriptionService.CreateSubscriptionTypes.Response()
        {
            Subscription = new SubscriptionService.SharedSubscriptionTypes.Subscription()
            {
                Id = 123123123,
                AddressId = 22222222,
                CustomerId = 333333333,
                AnalyticsData = new AnalyticsData()
                {
                    UtmParams = Array.Empty<UtmParam>()
                },
                CancellationReason = null,
                CancellationReasonComments = null,
                CancelledAt = null,
                ChargeIntervalFrequency = 30,
                CreatedAt = DateTime.Parse("2022-03-10T14:14:30+00:00"),
                ExpireAfterSpecificNumberOfCharges = 1,
                ExternalProductId = new SubscriptionService.SharedSubscriptionTypes.ExternalProductId()
                {
                    Ecommerce = "44444444444"
                },
                ExternalVariantId = new SubscriptionService.SharedSubscriptionTypes.ExternalVariantId()
                {
                    Ecommerce = "555555555555"
                },
                HasQueuedCharges = true,
                IsPrepaid = false,
                IsSkippable = true,
                IsSwappable = false,
                MaxRetriesReached = false,
                NextChargeScheduledAt = DateOnly.Parse("2022-12-17"),
                OrderDayOfMonth = null,
                OrderDayOfWeek = null,
                OrderIntervalFrequency = 30,
                OrderIntervalUnit = "day",
                PresentmentCurrency = "DKK",
                Price = 49.00m,
                ProductTitle = "Test product",
                Properties = new SubscriptionService.SharedSubscriptionTypes.Property[]
                {
                    new SubscriptionService.SharedSubscriptionTypes.Property()
                    {
                        Name = "Colour",
                        Value = "Yellow"
                    },
                    new SubscriptionService.SharedSubscriptionTypes.Property()
                    {
                        Name = "Bottle Material",
                        Value = "Glass"
                    },
                },
                Quantity = 3,
                Sku = null,
                SkuOverride = false,
                Status = "active",
                UpdatedAt = DateTime.Parse("2022-03-10T14:14:30+00:00"),
                VariantTitle = "972-1"
            }
        };
    }
}