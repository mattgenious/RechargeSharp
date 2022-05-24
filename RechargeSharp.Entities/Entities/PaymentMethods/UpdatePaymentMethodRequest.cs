using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RechargeSharp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace RechargeSharp.Entities.PaymentMethods
{
    public class UpdatePaymentMethodRequest
    {

        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }

        [Required]
        [JsonConverter(typeof(ProcessorNameConverter))]
        [JsonProperty("processor_name")]
        public ProcessorName ProcessorName { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentMethodBillingAddress? BillingAddress { get; set; }
    }
}
