using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    /// <summary>
    /// See documentation <see href="https://developer.rechargepayments.com/2021-01/charges/charge_change_next_date">https://developer.rechargepayments.com/2021-01/charges/charge_change_next_date</see>
    /// </summary>
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
        public DateTimeOffset? NextChargeDate { get; set; }
    }
}
