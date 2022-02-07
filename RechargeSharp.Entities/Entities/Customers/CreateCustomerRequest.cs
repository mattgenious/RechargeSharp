using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class CreateCustomerRequest : IEquatable<CreateCustomerRequest>
    {
        public bool Equals(CreateCustomerRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Email == other.Email && FirstName == other.FirstName && LastName == other.LastName && ShopifyCustomerId == other.ShopifyCustomerId && BillingFirstName == other.BillingFirstName && BillingLastName == other.BillingLastName && BillingAddress1 == other.BillingAddress1 && BillingAddress2 == other.BillingAddress2 && BillingZip == other.BillingZip && BillingCity == other.BillingCity && BillingProvince == other.BillingProvince && BillingCountry == other.BillingCountry && BillingPhone == other.BillingPhone && StripeCustomerToken == other.StripeCustomerToken && PaypalCustomerToken == other.PaypalCustomerToken && AuthorizeDotnetCustomerToken == other.AuthorizeDotnetCustomerToken;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateCustomerRequest) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Email);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(ShopifyCustomerId);
            hash.Add(BillingFirstName);
            hash.Add(BillingLastName);
            hash.Add(BillingAddress1);
            hash.Add(BillingAddress2);
            hash.Add(BillingZip);
            hash.Add(BillingCity);
            hash.Add(BillingProvince);
            hash.Add(BillingCountry);
            hash.Add(BillingPhone);
            hash.Add(StripeCustomerToken);
            hash.Add(PaypalCustomerToken);
            hash.Add(AuthorizeDotnetCustomerToken);
            return hash.ToHashCode();
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
        public string? Email { get; set; }

        [Required]
        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [Required]
        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("shopify_customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyCustomerId { get; set; }

        [Required]
        [JsonProperty("billing_first_name")]
        public string? BillingFirstName { get; set; }

        [Required]
        [JsonProperty("billing_last_name")]
        public string? BillingLastName { get; set; }

        [Required]
        [JsonProperty("billing_address1")]
        public string? BillingAddress1 { get; set; }

        [JsonProperty("billing_address2", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingAddress2 { get; set; }

        [Required]
        [JsonProperty("billing_zip")]
        public string? BillingZip { get; set; }

        [Required]
        [JsonProperty("billing_city")]
        public string? BillingCity { get; set; }

        [JsonProperty("billing_province")]
        public string? BillingProvince { get; set; }

        [Required]
        [JsonProperty("billing_country")]
        public string? BillingCountry { get; set; }

        [Required]
        [JsonProperty("billing_phone")]
        public string? BillingPhone { get; set; }

        [JsonProperty("stripe_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? StripeCustomerToken { get; set; }

        [JsonProperty("paypal_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? PaypalCustomerToken { get; set; }

        [JsonProperty("authorizedotnet_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? AuthorizeDotnetCustomerToken { get; set; }
    }
}
