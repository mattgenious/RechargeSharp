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
            return StripeCustomerToken == other.StripeCustomerToken;
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
            return (StripeCustomerToken != null ? StripeCustomerToken.GetHashCode() : 0);
        }

        public static bool operator ==(UpdateCustomerPaymentTokenRequest left, UpdateCustomerPaymentTokenRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateCustomerPaymentTokenRequest left, UpdateCustomerPaymentTokenRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("stripe_customer_token")]
        public string StripeCustomerToken { get; set; }
    }
}
