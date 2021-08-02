using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Discounts
{
    public enum DiscountType
    {
        [EnumMember(Value = "percentage")]
        Percentage,
        [EnumMember(Value = "fixed_amount")] 
        FixedAmount
    }
}
