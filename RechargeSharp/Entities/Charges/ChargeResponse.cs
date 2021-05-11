using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChargeResponse : IEquatable<ChargeResponse>
    {
        public bool Equals(ChargeResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Charge == other.Charge;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChargeResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Charge != null ? Charge.GetHashCode() : 0);
        }

        public static bool operator ==(ChargeResponse left, ChargeResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeResponse left, ChargeResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("charge")]
        public Charge Charge { get; set; }
    }
}
