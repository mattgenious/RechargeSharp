using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class UpdateCustomerRequest : IEquatable<UpdateCustomerRequest>
    {
        public bool Equals(UpdateCustomerRequest? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Email == other.Email && ShopifyCustomerId == other.ShopifyCustomerId && FirstName == other.FirstName && LastName == other.LastName && BillingFirstName == other.BillingFirstName && BillingLastName == other.BillingLastName && BillingAddress1 == other.BillingAddress1 && BillingAddress2 == other.BillingAddress2 && BillingZip == other.BillingZip && BillingCity == other.BillingCity && BillingCompany == other.BillingCompany && BillingProvince == other.BillingProvince && BillingCountry == other.BillingCountry && BillingPhone == other.BillingPhone;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UpdateCustomerRequest) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Email);
            hash.Add(ShopifyCustomerId);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(BillingFirstName);
            hash.Add(BillingLastName);
            hash.Add(BillingAddress1);
            hash.Add(BillingAddress2);
            hash.Add(BillingZip);
            hash.Add(BillingCity);
            hash.Add(BillingCompany);
            hash.Add(BillingProvince);
            hash.Add(BillingCountry);
            hash.Add(BillingPhone);
            return hash.ToHashCode();
        }

        public static bool operator ==(UpdateCustomerRequest left, UpdateCustomerRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateCustomerRequest left, UpdateCustomerRequest right)
        {
            return !Equals(left, right);
        }


        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; }

        [JsonProperty("shopify_customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShopifyCustomerId { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }

        [JsonProperty("billing_first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingFirstName { get; set; }

        [JsonProperty("billing_last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingLastName { get; set; }

        [JsonProperty("billing_address1", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingAddress1 { get; set; }

        [JsonProperty("billing_address2", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingAddress2 { get; set; }

        [JsonProperty("billing_zip", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingZip { get; set; }

        [JsonProperty("billing_city", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingCity { get; set; }

        [JsonProperty("billing_company", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingCompany { get; set; }

        [JsonProperty("billing_province", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingProvince { get; set; }

        [JsonProperty("billing_country", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingCountry { get; set; }

        [JsonProperty("billing_phone", NullValueHandling = NullValueHandling.Ignore)]
        public string? BillingPhone { get; set; }
    }
}
