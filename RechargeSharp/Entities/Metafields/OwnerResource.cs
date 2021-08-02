using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Metafields
{
    public enum OwnerResource
    {
        [EnumMember(Value = "store")]
        Store,
        [EnumMember(Value = "customer")]
        Customer,
        [EnumMember(Value = "subscription")]
        Subscription,
        [EnumMember(Value = "order")]
        Order,
        [EnumMember(Value = "charge")]
        Charge
    }
}
