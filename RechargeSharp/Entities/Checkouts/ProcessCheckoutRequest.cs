using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class ProcessCheckoutRequest : IEquatable<ProcessCheckoutRequest>
    {
        public bool Equals(ProcessCheckoutRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return PaymentProcessor == other.PaymentProcessor && PaymentToken == other.PaymentToken;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProcessCheckoutRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((PaymentProcessor != null ? PaymentProcessor.GetHashCode() : 0) * 397) ^ (PaymentToken != null ? PaymentToken.GetHashCode() : 0);
            }
        }

        public static bool operator ==(ProcessCheckoutRequest left, ProcessCheckoutRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProcessCheckoutRequest left, ProcessCheckoutRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("payment_token")]
        public string PaymentToken { get; set; }
    }
}
