using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class ChangeNextChargeDateRequest : IEquatable<ChangeNextChargeDateRequest>
    {
        public bool Equals(ChangeNextChargeDateRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Nullable.Equals(NextChargeDate, other.NextChargeDate);
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
            return NextChargeDate.GetHashCode();
        }

        public static bool operator ==(ChangeNextChargeDateRequest left, ChangeNextChargeDateRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChangeNextChargeDateRequest left, ChangeNextChargeDateRequest right)
        {
            return !Equals(left, right);
        }


        [Required]
        [JsonProperty("next_charge_date")]
        public DateTime? NextChargeDate { get; set; }
    }
}
