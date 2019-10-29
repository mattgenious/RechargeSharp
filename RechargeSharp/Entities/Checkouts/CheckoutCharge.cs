using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutCharge : IEquatable<CheckoutCharge>
    {
        public bool Equals(CheckoutCharge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return PaymentProcessorTransactionId == other.PaymentProcessorTransactionId && ChargeId == other.ChargeId && PaymentProcessor == other.PaymentProcessor && PaymentToken == other.PaymentToken && PaymentProcessorCustomerId == other.PaymentProcessorCustomerId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CheckoutCharge) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (PaymentProcessorTransactionId != null ? PaymentProcessorTransactionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ChargeId.GetHashCode();
                hashCode = (hashCode * 397) ^ (PaymentProcessor != null ? PaymentProcessor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaymentToken != null ? PaymentToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaymentProcessorCustomerId != null ? PaymentProcessorCustomerId.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(CheckoutCharge left, CheckoutCharge right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckoutCharge left, CheckoutCharge right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("payment_processor_transaction_id")]
        public string PaymentProcessorTransactionId { get; set; }

        [JsonProperty("charge_id")]
        public long ChargeId { get; set; }

        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("payment_token")]
        public string PaymentToken { get; set; }

        [JsonProperty("payment_processor_customer_id")]
        public string PaymentProcessorCustomerId { get; set; }
    }
}