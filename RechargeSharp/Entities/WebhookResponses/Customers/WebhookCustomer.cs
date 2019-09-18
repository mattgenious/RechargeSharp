using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Customers
{
    public class WebhookCustomer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("shopify_customer_id")]
        public string ShopifyCustomerId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

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
        public string Status { get; set; }

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
        public string FirstChargeProcessedAt { get; set; }
    }
}
