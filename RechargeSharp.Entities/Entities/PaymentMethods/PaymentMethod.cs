using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RechargeSharp.Utilities;

namespace RechargeSharp.Entities.PaymentMethods
{

    public class PaymentMethod
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; }

        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CustomerId { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentMethodBillingAddress? BillingAddress { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }

        [JsonProperty("include", NullValueHandling = NullValueHandling.Ignore)]
        public object? Include { get; set; }

        [JsonProperty("payment_details", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentDetails? PaymentDetails { get; set; }

        [JsonProperty("payment_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PaymentTypeConverter))]
        public PaymentType? PaymentType { get; set; }

        [JsonProperty("processor_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProcessorCustomerToken { get; set; }

        [JsonProperty("processor_name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ProcessorNameConverter))]
        public ProcessorName? ProcessorName { get; set; }

        [JsonProperty("processor_payment_method_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProcessorPaymentMethodToken { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("status_reason")]
        public string? StatusReason { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
