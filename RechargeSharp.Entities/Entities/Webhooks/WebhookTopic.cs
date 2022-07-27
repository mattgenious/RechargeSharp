using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Webhooks
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebhookTopic
    {
        [EnumMember(Value = "subscription/created")]
        SubscriptionCreated,
        [EnumMember(Value = "subscription/updated")]
        SubscriptionUpdated,
        [EnumMember(Value = "subscription/activated")]
        SubscriptionActivated,
        [EnumMember(Value = "subscription/cancelled")]
        SubscriptionCancelled,
        [EnumMember(Value = "subscription/deleted")]
        SubscriptionDeleted,
        [EnumMember(Value = "subscription/skipped")]
        SubscriptionSkipped,
        [EnumMember(Value = "subscription/unskipped")]
        SubscriptionUnskipped,

        [EnumMember(Value = "onetime/created")]
        OnetimeCreated,
        [EnumMember(Value = "onetime/updated")]
        OnetimeUpdated,
        [EnumMember(Value = "onetime/deleted")]
        OnetimeDeleted,

        [EnumMember(Value = "customer/created")]
        CustomerCreated,
        [EnumMember(Value = "customer/updated")]
        CustomerUpdated,
        [EnumMember(Value = "customer/payment_method_updated")]
        CustomerPaymentMethodUpdated,
        [EnumMember(Value = "customer/activated")]
        CustomerActivated,
        [EnumMember(Value = "customer/deactivated")]
        CustomerDeactivated,
        [EnumMember(Value = "customer/deleted")]
        CustomerDeleted,

        [EnumMember(Value = "address/created")]
        AddressCreated,
        [EnumMember(Value = "address/updated")]
        AddressUpdated,

        [EnumMember(Value = "order/created")]
        OrderCreated,
        [EnumMember(Value = "order/processed")]
        OrderProcessed,
        [EnumMember(Value = "order/deleted")]
        OrderDeleted,
        [EnumMember(Value = "order/updated")]
        OrderUpdated,
        [EnumMember(Value = "order/upcoming")]
        OrderUpcoming,
        [EnumMember(Value = "order/cancelled")]
        OrderCancelled,

        [EnumMember(Value = "charge/created")]
        ChargeCreated,
        [EnumMember(Value = "charge/paid")]
        ChargePaid,
        [EnumMember(Value = "charge/failed")]
        ChargeFailed,
        [EnumMember(Value = "charge/max_retries_reached")]
        ChargeMaxRetriesReached,
        [EnumMember(Value = "charge/updated")]
        ChargeUpdated,
        [EnumMember(Value = "charge/upcoming")]
        ChargeUpcoming,
        [EnumMember(Value = "charge/refunded")]
        ChargeRefunded,
        [EnumMember(Value = "charge/uncaptured")]
        ChargeUncaptured,

        [EnumMember(Value = "checkout/created")]
        CheckoutCreated,
        [EnumMember(Value = "checkout/updated")]
        CheckoutUpdated,
        [EnumMember(Value = "checkout/processed")]
        CheckoutProcessed,

        [EnumMember(Value = "product/created")]
        ProductCreated,
        [EnumMember(Value = "product/updated")]
        ProductUpdated,
        [EnumMember(Value = "product/deleted")]
        ProductDeleted,

        [EnumMember(Value = "app/uninstalled")]
        AppUninstalled,

        [EnumMember(Value = "recharge/uninstalled")]
        RechargeUninstalled,

        [EnumMember(Value = "async_batch/processed")]
        AsyncBatchProcessed
    }
}
