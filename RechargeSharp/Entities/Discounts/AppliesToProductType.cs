using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    public enum AppliesToProductType
    {
        [EnumMember(Value = "ALL")]
        All,
        [EnumMember(Value = "ONETIME")]
        Onetime,
        [EnumMember(Value = "SUBSCRIPTION")]
        Subscription
    }
}
