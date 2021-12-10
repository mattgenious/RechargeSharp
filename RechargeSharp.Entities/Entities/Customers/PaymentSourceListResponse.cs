using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class PaymentSourceListResponse : IEquatable<PaymentSourceListResponse>
    {
        public bool Equals(PaymentSourceListResponse? other)
        {
            if (other is null) return false;
            if (other.PaymentSources is null) return false;
            if (PaymentSources is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return PaymentSources.SequenceEqual(other.PaymentSources);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PaymentSourceListResponse) obj);
        }

        public override int GetHashCode()
        {
            return (PaymentSources != null ? PaymentSources.GetHashCode() : 0);
        }

        public static bool operator ==(PaymentSourceListResponse left, PaymentSourceListResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaymentSourceListResponse left, PaymentSourceListResponse right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("payment_sources")]
        public IEnumerable<PaymentSource>? PaymentSources { get; set; }
    }
}
