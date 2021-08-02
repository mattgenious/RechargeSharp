using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Orders
{
    public enum OrderStatus
    {
        [EnumMember(Value = "SUCCESS")]
        Success,
        [EnumMember(Value = "QUEUED")]
        Queued,
        [EnumMember(Value = "CANCELLED")]
        Cancelled,
        [EnumMember(Value = "ERROR")]
        Error,
        [EnumMember(Value = "REFUNDED")]
        Refunded,
        [EnumMember(Value = "SKIPPED")]
        Skipped
    }
}
