using System;
using RechargeSharp.v2021_11.Endpoints.Customers;
using RechargeSharp.v2021_11.Endpoints.Subscriptions;
using RechargeSharp.v2021_11.SharedModels;

namespace RechargeSharp.v2021_11.Tests.TestResources.SampleResponses.Subscriptions;

public static class get_subscription_200
{
    public static SubscriptionService.GetSubscriptionTypes.Response CorrectlyDeserializedJson()
    {
        return new SubscriptionService.GetSubscriptionTypes.Response() {
            Subscription = new SubscriptionService.SharedSubscriptionTypes.Subscription() {
                Id = 1111111,
                AddressId = 2222222,
                CustomerId = 33333333,
                AnalyticsData = new AnalyticsData() {
                    UtmParams = Array.Empty<UtmParam>()
                },
                CancellationReason = null,
                CancellationReasonComments = null,
                CancelledAt = null,
                ChargeIntervalFrequency = 30,
                CreatedAt = DateTime.Parse("2022-03-10T12:13:28+00:00"),
                ExpireAfterSpecificNumberOfCharges = null,
                ExternalProductId = new SubscriptionService.SharedSubscriptionTypes.ExternalProductId() {
                    Ecommerce = "123123"
                },
                ExternalVariantId = new SubscriptionService.SharedSubscriptionTypes.ExternalVariantId() {
                    Ecommerce = "23123123123"
                },
                HasQueuedCharges = true,
                IsPrepaid = false,
                IsSkippable = true,
                IsSwappable = false,
                MaxRetriesReached = false,
                NextChargeScheduledAt = DateOnly.Parse("2022-04-09"),
                OrderDayOfMonth = null,
                OrderDayOfWeek = null,
                OrderIntervalFrequency = 30,
                OrderIntervalUnit = "day",
                PresentmentCurrency = null,
                Price = 49.00m,
                ProductTitle = "Test product",
                Properties = new SubscriptionService.SharedSubscriptionTypes.Property[]
                {
                     new SubscriptionService.SharedSubscriptionTypes.Property() {
                                     Name = "charge_interval_frequency",
                                     Value = "30"
                     },
                     new SubscriptionService.SharedSubscriptionTypes.Property() {
                         Name = "shipping_interval_frequency",
                         Value = "30"
                     },
                     new SubscriptionService.SharedSubscriptionTypes.Property() {
                         Name = "shipping_interval_unit_type",
                         Value = "day"
                     },
                },
                Quantity = 1,
                Sku = null,
                SkuOverride = false,
                Status = "active",
                UpdatedAt = DateTime.Parse("2022-03-10T12:13:28+00:00"),
                VariantTitle = "972-1"
            }
        };
    }
}