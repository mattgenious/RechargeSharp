using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Customers
{
    public enum CustomerStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "INACTIVE")]
        Inactive
    }
}
