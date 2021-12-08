using System;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;

namespace RechargeSharp.Entities.WebhookResponses.Charges
{
    public class ChargeMaxRetriesReachedResponse : IEquatable<ChargeMaxRetriesReachedResponse>
    {
        public bool Equals(ChargeMaxRetriesReachedResponse other)
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
            return Equals((ChargeMaxRetriesReachedResponse) obj);
        }

        public override int GetHashCode()
        {
            return (Charge != null ? Charge.GetHashCode() : 0);
        }

        public static bool operator ==(ChargeMaxRetriesReachedResponse left, ChargeMaxRetriesReachedResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChargeMaxRetriesReachedResponse left, ChargeMaxRetriesReachedResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("charge")]
        public Charge Charge { get; set; }
    }
}
