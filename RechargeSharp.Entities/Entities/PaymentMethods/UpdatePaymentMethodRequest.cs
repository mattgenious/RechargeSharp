using Newtonsoft.Json;
using RechargeSharp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace RechargeSharp.Entities.PaymentMethods
{
    public class UpdatePaymentMethodRequest
    {

        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }

        [Required]
        [JsonProperty("processor_name")]
        public ProcessorName ProcessorName { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentMethodBillingAddress? BillingAddress { get; set; }


        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                PaymentTypeConverter.Singleton,
                ProcessorNameConverter.Singleton,
                DateTimeOffsetJsonConverter.Singleton
            },
            };
        }
    }
}
