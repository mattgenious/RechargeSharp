using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RechargeSharp.Entities.Charges
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChargeStatus
    {
        [EnumMember(Value = "SUCCESS")] Success,
        [EnumMember(Value = "ERROR")] Error,
        [EnumMember(Value = "QUEUED")] Queued,
        [EnumMember(Value = "SKIPPED")] Skipped,
        [EnumMember(Value = "REFUNDED")] Refunded,
        [EnumMember(Value = "PARTIALLY_REFUNDED")] PartiallyRefunded
    }
}
