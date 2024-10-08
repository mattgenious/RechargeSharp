using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Products
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StorefrontPurchaseOptions
    {
        [EnumMember(Value = "onetime_only")]
        OnetimeOnly,
        [EnumMember(Value = "subscription_only")]
        SubscriptionOnly,
        [EnumMember(Value = "subscription_and_onetime")]
        SubscriptionAndOnetime,
        [EnumMember(Value = "inactive")]
        Inactive
    }
}
