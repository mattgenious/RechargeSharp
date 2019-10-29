using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class ChargeUpdatedResponse : IEquatable<ChargeUpdatedResponse>
    {
        public bool Equals(ChargeUpdatedResponse other)
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
            return Equals((ChargeUpdatedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Charge != null ? Charge.GetHashCode() : 0);
        }

        public static bool operator ==(ChargeUpdatedResponse left, ChargeUpdatedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeUpdatedResponse left, ChargeUpdatedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("charge")]
        public WebhookChargeUpdated Charge { get; set; }
    }
}
