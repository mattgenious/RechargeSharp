using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Metafields
{
    [JsonConverter(typeof(StringEnumConverter))]
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
