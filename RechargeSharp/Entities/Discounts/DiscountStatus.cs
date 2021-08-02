using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    public enum DiscountStatus
    {
        [EnumMember(Value = "enabled")]
        Enabled,
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "fully_disabled")]
        FullyDisabled
    }
}
