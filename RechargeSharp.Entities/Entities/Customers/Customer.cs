using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class Customer : IEquatable<Customer>
    {
        public bool Equals(Customer? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Hash == other.Hash && ShopifyCustomerId == other.ShopifyCustomerId && Email == other.Email && CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt) && FirstName == other.FirstName && LastName == other.LastName && BillingAddress1 == other.BillingAddress1 && BillingAddress2 == other.BillingAddress2 && BillingZip == other.BillingZip && BillingCity == other.BillingCity && BillingCompany == other.BillingCompany && BillingProvince == other.BillingProvince && BillingCountry == other.BillingCountry && BillingPhone == other.BillingPhone && ProcessorType == other.ProcessorType && Status == other.Status && StripeCustomerToken == other.StripeCustomerToken && HasValidPaymentMethod == other.HasValidPaymentMethod && ReasonPaymentMethodNotValid == other.ReasonPaymentMethodNotValid && HasCardErrorInDunning == other.HasCardErrorInDunning && NumberActiveSubscriptions == other.NumberActiveSubscriptions && NumberSubscriptions == other.NumberSubscriptions && Nullable.Equals(FirstChargeProcessedAt, other.FirstChargeProcessedAt);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(Hash);
            hash.Add(ShopifyCustomerId);
            hash.Add(Email);
            hash.Add(CreatedAt);
            hash.Add(UpdatedAt);
            hash.Add(FirstName);
            hash.Add(LastName);
            hash.Add(BillingAddress1);
            hash.Add(BillingAddress2);
            hash.Add(BillingZip);
            hash.Add(BillingCity);
            hash.Add(BillingCompany);
            hash.Add(BillingProvince);
            hash.Add(BillingCountry);
            hash.Add(BillingPhone);
            hash.Add(ProcessorType);
            hash.Add(Status);
            hash.Add(StripeCustomerToken);
            hash.Add(HasValidPaymentMethod);
            hash.Add(ReasonPaymentMethodNotValid);
            hash.Add(HasCardErrorInDunning);
            hash.Add(NumberActiveSubscriptions);
            hash.Add(NumberSubscriptions);
            hash.Add(FirstChargeProcessedAt);
            return hash.ToHashCode();
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("hash")]
        public string? Hash { get; set; }

        [JsonProperty("shopify_customer_id")]
        public string? ShopifyCustomerId { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("billing_address1")]
        public string? BillingAddress1 { get; set; }

        [JsonProperty("billing_address2")]
        public string? BillingAddress2 { get; set; }

        [JsonProperty("billing_zip")]
        public string? BillingZip { get; set; }

        [JsonProperty("billing_city")]
        public string? BillingCity { get; set; }

        [JsonProperty("billing_company")]
        public string? BillingCompany { get; set; }

        [JsonProperty("billing_province")]
        public string? BillingProvince { get; set; }

        [JsonProperty("billing_country")]
        public string? BillingCountry { get; set; }

        [JsonProperty("billing_phone")]
        public string? BillingPhone { get; set; }

        [JsonProperty("processor_type")]
        public string? ProcessorType { get; set; }

        [JsonProperty("status")]
        public CustomerStatus? Status { get; set; }

        [JsonProperty("stripe_customer_token")]
        public string? StripeCustomerToken { get; set; }

        [JsonProperty("has_valid_payment_method")]
        public bool HasValidPaymentMethod { get; set; }

        [JsonProperty("reason_payment_method_not_valid")]
        public string? ReasonPaymentMethodNotValid { get; set; }

        [JsonProperty("has_card_error_in_dunning")]
        public bool HasCardErrorInDunning { get; set; }

        [JsonProperty("number_active_subscriptions")]
        public long NumberActiveSubscriptions { get; set; }

        [JsonProperty("number_subscriptions")]
        public long NumberSubscriptions { get; set; }

        [JsonProperty("first_charge_processed_at")]
        public DateTimeOffset? FirstChargeProcessedAt { get; set; }
    }
}
