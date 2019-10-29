using System;
using System.Linq;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class PaymentSourceListResponse : IEquatable<PaymentSourceListResponse>
    {
        public bool Equals(PaymentSourceListResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return PaymentSources.SequenceEqual(other.PaymentSources);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
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
        public PaymentSource[] PaymentSources { get; set; }
    }
}
