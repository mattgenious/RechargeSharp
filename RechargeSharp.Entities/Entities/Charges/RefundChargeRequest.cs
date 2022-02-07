using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class RefundChargeRequest : IEquatable<RefundChargeRequest>
    {
        public bool Equals(RefundChargeRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RefundChargeRequest) obj);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }

        public static bool operator ==(RefundChargeRequest left, RefundChargeRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RefundChargeRequest left, RefundChargeRequest right)
        {
            return !Equals(left, right);
        }


        [Required]
        [JsonProperty("amount")]
        public decimal? Amount { get; set; }
    }
}
