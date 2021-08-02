using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Subscriptions
{
    public enum SubscriptionStatus
    {

        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "CANCELLED")]
        Cancelled,
        [EnumMember(Value = "EXPIRED")]
        Expired
    }
}
