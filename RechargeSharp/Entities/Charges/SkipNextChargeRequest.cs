using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class SkipNextChargeRequest : IEquatable<SkipNextChargeRequest>
    {
        public bool Equals(SkipNextChargeRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return SubscriptionId == other.SubscriptionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SkipNextChargeRequest) obj);
        }

        public override int GetHashCode()
        {
            return (SubscriptionId != null ? SubscriptionId.GetHashCode() : 0);
        }

        public static bool operator ==(SkipNextChargeRequest left, SkipNextChargeRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SkipNextChargeRequest left, SkipNextChargeRequest right)
        {
            return !Equals(left, right);
        }

        [Required]
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }
    }
}
