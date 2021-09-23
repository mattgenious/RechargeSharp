using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChargeResponse : IEquatable<ChargeResponse>
    {

        [JsonProperty("charge")]
        public Charge Charge { get; set; }

        public bool Equals(ChargeResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Charge, other.Charge);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChargeResponse)obj);
        }

        public override int GetHashCode()
        {
            return (Charge != null ? Charge.GetHashCode() : 0);
        }
    }
}
