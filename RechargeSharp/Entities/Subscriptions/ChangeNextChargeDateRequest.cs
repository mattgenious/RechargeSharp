using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    class ChangeNextChargeDateRequest : IEquatable<ChangeNextChargeDateRequest>
    {
        public bool Equals(ChangeNextChargeDateRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Date == other.Date;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ChangeNextChargeDateRequest) obj);
        }

        public override int GetHashCode()
        {
            return (Date != null ? Date.GetHashCode() : 0);
        }

        public static bool operator ==(ChangeNextChargeDateRequest left, ChangeNextChargeDateRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeNextChargeDateRequest left, ChangeNextChargeDateRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
