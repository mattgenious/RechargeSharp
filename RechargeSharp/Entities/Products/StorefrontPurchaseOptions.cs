using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Products
{
    public enum StorefrontPurchaseOptions
    {
        [EnumMember(Value = "subscription_only")]
        SubscriptionOnly,
        [EnumMember(Value = "subscription_and_onetime")]
        SubscriptionAndOnetime
    }
}
