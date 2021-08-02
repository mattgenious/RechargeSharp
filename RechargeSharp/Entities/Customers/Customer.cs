using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RechargeSharp.Entities.Customers
{
    public class Customer : IEquatable<Customer>
    {
        public bool Equals(Customer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Hash == other.Hash && ShopifyCustomerId == other.ShopifyCustomerId && Email == other.Email && CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt) && FirstName == other.FirstName && LastName == other.LastName && BillingAddress1 == other.BillingAddress1 && BillingAddress2 == other.BillingAddress2 && BillingZip == other.BillingZip && BillingCity == other.BillingCity && BillingCompany == other.BillingCompany && BillingProvince == other.BillingProvince && BillingCountry == other.BillingCountry && BillingPhone == other.BillingPhone && ProcessorType == other.ProcessorType && Status == other.Status && StripeCustomerToken == other.StripeCustomerToken && HasValidPaymentMethod == other.HasValidPaymentMethod && ReasonPaymentMethodNotValid == other.ReasonPaymentMethodNotValid && HasCardErrorInDunning == other.HasCardErrorInDunning && NumberActiveSubscriptions == other.NumberActiveSubscriptions && NumberSubscriptions == other.NumberSubscriptions && Nullable.Equals(FirstChargeProcessedAt, other.FirstChargeProcessedAt);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Hash != null ? Hash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShopifyCustomerId != null ? ShopifyCustomerId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress1 != null ? BillingAddress1.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress2 != null ? BillingAddress2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingZip != null ? BillingZip.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingCity != null ? BillingCity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingCompany != null ? BillingCompany.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingProvince != null ? BillingProvince.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingCountry != null ? BillingCountry.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingPhone != null ? BillingPhone.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ProcessorType != null ? ProcessorType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Status.GetHashCode();
                hashCode = (hashCode * 397) ^ (StripeCustomerToken != null ? StripeCustomerToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HasValidPaymentMethod.GetHashCode();
                hashCode = (hashCode * 397) ^ (ReasonPaymentMethodNotValid != null ? ReasonPaymentMethodNotValid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HasCardErrorInDunning.GetHashCode();
                hashCode = (hashCode * 397) ^ NumberActiveSubscriptions.GetHashCode();
                hashCode = (hashCode * 397) ^ NumberSubscriptions.GetHashCode();
                hashCode = (hashCode * 397) ^ FirstChargeProcessedAt.GetHashCode();
                return hashCode;
            }
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
        public string Hash { get; set; }

        [JsonProperty("shopify_customer_id")]
        public string ShopifyCustomerId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("billing_address1")]
        public string BillingAddress1 { get; set; }

        [JsonProperty("billing_address2")]
        public string BillingAddress2 { get; set; }

        [JsonProperty("billing_zip")]
        public string BillingZip { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_company")]
        public string BillingCompany { get; set; }

        [JsonProperty("billing_province")]
        public string BillingProvince { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("billing_phone")]
        public string BillingPhone { get; set; }

        [JsonProperty("processor_type")]
        public string ProcessorType { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CustomerStatus Status { get; set; }

        [JsonProperty("stripe_customer_token")]
        public string StripeCustomerToken { get; set; }

        [JsonProperty("has_valid_payment_method")]
        public bool HasValidPaymentMethod { get; set; }

        [JsonProperty("reason_payment_method_not_valid")]
        public string ReasonPaymentMethodNotValid { get; set; }

        [JsonProperty("has_card_error_in_dunning")]
        public bool HasCardErrorInDunning { get; set; }

        [JsonProperty("number_active_subscriptions")]
        public long NumberActiveSubscriptions { get; set; }

        [JsonProperty("number_subscriptions")]
        public long NumberSubscriptions { get; set; }

        [JsonProperty("first_charge_processed_at")]
        public DateTime? FirstChargeProcessedAt { get; set; }
    }
}
