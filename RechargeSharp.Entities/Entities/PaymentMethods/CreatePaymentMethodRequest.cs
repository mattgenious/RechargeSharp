using Newtonsoft.Json;
using RechargeSharp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace RechargeSharp.Entities.PaymentMethods
{
    public partial class CreatePaymentMethodRequest
    {
        [Required]
        [JsonProperty("customer_id")]
        public long? CustomerId { get; set; }

        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }

        [Required]
        [JsonProperty("payment_type")]
        [JsonConverter(typeof(PaymentTypeConverter))]
        public PaymentType PaymentType { get; set; }

        [Required]
        [JsonProperty("processor_customer_token")]
        public string? ProcessorCustomerToken { get; set; }

        [Required]
        [JsonProperty("processor_name")]
        [JsonConverter(typeof(ProcessorNameConverter))]
        public ProcessorName ProcessorName { get; set; }

        [Required]
        [JsonProperty("processor_payment_method_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProcessorPaymentMethodToken { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentMethodBillingAddress? BillingAddress { get; set; }
    }
}
