using System;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Customers
{
    public class PaymentSource : IEquatable<PaymentSource>
    {
        public bool Equals(PaymentSource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(BillingAddress, other.BillingAddress) && CardBrand == other.CardBrand && CardExpMonth == other.CardExpMonth && CardExpYear == other.CardExpYear && CardLast4 == other.CardLast4 && CustomerId == other.CustomerId && HasCardErrorInDunning == other.HasCardErrorInDunning && PaymentType == other.PaymentType && ProcessorName == other.ProcessorName && Status == other.Status && StatusReason == other.StatusReason;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PaymentSource) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (BillingAddress != null ? BillingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CardBrand != null ? CardBrand.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CardExpMonth.GetHashCode();
                hashCode = (hashCode * 397) ^ CardExpYear.GetHashCode();
                hashCode = (hashCode * 397) ^ (CardLast4 != null ? CardLast4.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ HasCardErrorInDunning.GetHashCode();
                hashCode = (hashCode * 397) ^ (PaymentType != null ? PaymentType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProcessorName != null ? ProcessorName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StatusReason != null ? StatusReason.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(PaymentSource left, PaymentSource right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaymentSource left, PaymentSource right)
        {
            return !Equals(left, right);
        }


        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("card_brand")]
        public string CardBrand { get; set; }

        [JsonProperty("card_exp_month")]
        public long? CardExpMonth { get; set; }

        [JsonProperty("card_exp_year")]
        public long? CardExpYear { get; set; }

        [JsonProperty("card_last4")]
        public string CardLast4 { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("has_card_error_in_dunning")]
        public bool? HasCardErrorInDunning { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("processor_name")]
        public string ProcessorName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_reason")]
        public string StatusReason { get; set; }
    }
}
