using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class UpdateCustomerPaymentTokenRequest : IEquatable<UpdateCustomerPaymentTokenRequest>
    {
        public bool Equals(UpdateCustomerPaymentTokenRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return StripeCustomerToken == other.StripeCustomerToken && PaypalCustomerToken == other.PaypalCustomerToken && AuthorizeDotnetCustomerToken == other.AuthorizeDotnetCustomerToken;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateCustomerPaymentTokenRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (StripeCustomerToken != null ? StripeCustomerToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaypalCustomerToken != null ? PaypalCustomerToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AuthorizeDotnetCustomerToken != null ? AuthorizeDotnetCustomerToken.GetHashCode() : 0);
                return hashCode;
            }
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
        public string StripeCustomerToken { get; set; }

        [JsonProperty("paypal_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string PaypalCustomerToken { get; set; }

        [JsonProperty("authorizedotnet_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizeDotnetCustomerToken { get; set; }
    }
}
