using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using RechargeSharp.Validation;

namespace RechargeSharp.Entities.Customers
{
    public class CreateCustomerRequest : IEquatable<CreateCustomerRequest>
    {
        public bool Equals(CreateCustomerRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Email == other.Email && FirstName == other.FirstName && LastName == other.LastName && ShopifyCustomerId == other.ShopifyCustomerId && BillingFirstName == other.BillingFirstName && BillingLastName == other.BillingLastName && BillingAddress1 == other.BillingAddress1 && BillingAddress2 == other.BillingAddress2 && BillingZip == other.BillingZip && BillingCity == other.BillingCity && BillingProvince == other.BillingProvince && BillingCountry == other.BillingCountry && BillingPhone == other.BillingPhone && ProcessorType == other.ProcessorType && StripeCustomerToken == other.StripeCustomerToken && PaypalCustomerToken == other.PaypalCustomerToken && AuthorizeDotnetCustomerToken == other.AuthorizeDotnetCustomerToken;
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
                hashCode = (hashCode * 397) ^ ShopifyCustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ (BillingFirstName != null ? BillingFirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingLastName != null ? BillingLastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress1 != null ? BillingAddress1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress2 != null ? BillingAddress2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingZip != null ? BillingZip.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingCity != null ? BillingCity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingProvince != null ? BillingProvince.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingCountry != null ? BillingCountry.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingPhone != null ? BillingPhone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProcessorType != null ? ProcessorType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StripeCustomerToken != null ? StripeCustomerToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaypalCustomerToken != null ? PaypalCustomerToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AuthorizeDotnetCustomerToken != null ? AuthorizeDotnetCustomerToken.GetHashCode() : 0);
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

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("shopify_customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyCustomerId { get; set; }

        [Required]
        [JsonProperty("billing_first_name")]
        public string BillingFirstName { get; set; }

        [Required]
        [JsonProperty("billing_last_name")]
        public string BillingLastName { get; set; }

        [Required]
        [JsonProperty("billing_address1")]
        public string BillingAddress1 { get; set; }

        [JsonProperty("billing_address2", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingAddress2 { get; set; }

        [Required]
        [JsonProperty("billing_zip")]
        public string BillingZip { get; set; }

        [Required]
        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_province")]
        public string BillingProvince { get; set; }

        [Required]
        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [Required]
        [JsonProperty("billing_phone")]
        public string BillingPhone { get; set; }

        [StringValues(AllowableValues = new[] { "stripe", "paypal", "authorizedotnet" })]
        [JsonProperty("processor_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ProcessorType { get; set; }

        [JsonProperty("stripe_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string StripeCustomerToken { get; set; }

        [JsonProperty("paypal_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string PaypalCustomerToken { get; set; }

        [JsonProperty("authorizedotnet_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizeDotnetCustomerToken { get; set; }
    }
}
