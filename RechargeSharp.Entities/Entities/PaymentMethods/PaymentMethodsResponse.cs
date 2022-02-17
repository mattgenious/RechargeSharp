using Newtonsoft.Json;
using RechargeSharp.Utilities;

namespace RechargeSharp.Entities.PaymentMethods
{
    public partial class PaymentMethodsResponse
    {
        [JsonProperty("payment_methods")]
        public List<PaymentMethod>? PaymentMethods { get; set; }
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
