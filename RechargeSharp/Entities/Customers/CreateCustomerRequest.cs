using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class CreateCustomerRequest : IEquatable<CreateCustomerRequest>
    {
        public bool Equals(CreateCustomerRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Email == other.Email && FirstName == other.FirstName && LastName == other.LastName && BillingFirstName == other.BillingFirstName && BillingLastName == other.BillingLastName && BillingAddress1 == other.BillingAddress1 && BillingZip == other.BillingZip && BillingCity == other.BillingCity && BillingProvince == other.BillingProvince && BillingCountry == other.BillingCountry && BillingPhone == other.BillingPhone && StripeCustomerToken == other.StripeCustomerToken;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateCustomerRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingFirstName != null ? BillingFirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingLastName != null ? BillingLastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress1 != null ? BillingAddress1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingZip != null ? BillingZip.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingCity != null ? BillingCity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingProvince != null ? BillingProvince.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingCountry != null ? BillingCountry.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingPhone != null ? BillingPhone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StripeCustomerToken != null ? StripeCustomerToken.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(CreateCustomerRequest left, CreateCustomerRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateCustomerRequest left, CreateCustomerRequest right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("billing_first_name")]
        public string BillingFirstName { get; set; }

        [JsonProperty("billing_last_name")]
        public string BillingLastName { get; set; }

        [JsonProperty("billing_address1")]
        public string BillingAddress1 { get; set; }

        [JsonProperty("billing_zip")]
        public string BillingZip { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_province")]
        public string BillingProvince { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("billing_phone")]
        public string BillingPhone { get; set; }
        [JsonProperty("stripe_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string StripeCustomerToken { get; set; }
    }
}
