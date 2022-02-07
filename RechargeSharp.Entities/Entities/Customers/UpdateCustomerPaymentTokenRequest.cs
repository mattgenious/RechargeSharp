using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class UpdateCustomerPaymentTokenRequest : IEquatable<UpdateCustomerPaymentTokenRequest>
    {
        public bool Equals(UpdateCustomerPaymentTokenRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return StripeCustomerToken == other.StripeCustomerToken && PaypalCustomerToken == other.PaypalCustomerToken && AuthorizeDotnetCustomerToken == other.AuthorizeDotnetCustomerToken;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateCustomerPaymentTokenRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StripeCustomerToken, PaypalCustomerToken, AuthorizeDotnetCustomerToken);
        }

        public static bool operator ==(UpdateCustomerPaymentTokenRequest left, UpdateCustomerPaymentTokenRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateCustomerPaymentTokenRequest left, UpdateCustomerPaymentTokenRequest right)
        {
            return !Equals(left, right);
        }


        [JsonProperty("stripe_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? StripeCustomerToken { get; set; }

        [JsonProperty("paypal_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? PaypalCustomerToken { get; set; }

        [JsonProperty("authorizedotnet_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? AuthorizeDotnetCustomerToken { get; set; }
    }
}
