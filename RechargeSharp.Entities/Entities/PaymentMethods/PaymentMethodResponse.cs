using Newtonsoft.Json;
using RechargeSharp.Utilities;

namespace RechargeSharp.Entities.PaymentMethods
{
    public class PaymentMethodResponse
    {
        [JsonProperty("payment_method")]
        public PaymentMethod? PaymentMethod { get; set; }
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
