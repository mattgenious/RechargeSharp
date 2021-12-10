using Newtonsoft.Json;

namespace RechargeSharp.Entities.Charges
{
    public class TotalRefundChargeRequest : IEquatable<TotalRefundChargeRequest>
    {
        public bool Equals(TotalRefundChargeRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return FullRefund == other.FullRefund;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TotalRefundChargeRequest) obj);
        }

        public override int GetHashCode()
        {
            return FullRefund.GetHashCode();
        }

        public static bool operator ==(TotalRefundChargeRequest left, TotalRefundChargeRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TotalRefundChargeRequest left, TotalRefundChargeRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("full_refund", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FullRefund { get; set; }
    }
}
