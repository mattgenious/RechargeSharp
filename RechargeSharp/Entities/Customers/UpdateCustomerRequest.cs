using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class UpdateCustomerRequest
    {
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("billing_first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingFirstName { get; set; }

        [JsonProperty("billing_last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingLastName { get; set; }

        [JsonProperty("billing_address1", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingAddress1 { get; set; }

        [JsonProperty("billing_zip", NullValueHandling = NullValueHandling.Ignore)]
        public long? BillingZip { get; set; }

        [JsonProperty("billing_city", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingCity { get; set; }

        [JsonProperty("billing_province", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingProvince { get; set; }

        [JsonProperty("billing_country", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingCountry { get; set; }

        [JsonProperty("billing_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string BillingPhone { get; set; }
        [JsonProperty("stripe_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string StripeCustomerToken { get; set; }
    }
}
