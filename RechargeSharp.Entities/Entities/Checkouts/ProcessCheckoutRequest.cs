using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Checkouts
{
    public class ProcessCheckoutRequest : IEquatable<ProcessCheckoutRequest>
    {
        public bool Equals(ProcessCheckoutRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return PaymentProcessor == other.PaymentProcessor && PaymentToken == other.PaymentToken;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
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

        [Required]
        [StringValues(AllowableValues = new []{ "stripe", "braintree" })]
        [JsonProperty("payment_processor")]
        public string? PaymentProcessor { get; set; }

        [Required]
        [JsonProperty("payment_token")]
        public string? PaymentToken { get; set; }

        [JsonProperty("authorization_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? AuthorizationToken { get; set; }
        
        [JsonProperty("free", NullValueHandling = NullValueHandling.Ignore)]
        public bool Free { get; set; }
    }
}
