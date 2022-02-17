using Newtonsoft.Json;
using RechargeSharp.Entities.PaymentMethods;

namespace RechargeSharp.Utilities
{
    public class ProcessorNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ProcessorName) || t == typeof(ProcessorName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "stripe" => ProcessorName.Stripe,
                "braintree" => ProcessorName.Braintree,
                "authorize" => ProcessorName.Authorize,
                "shopify_payments" => ProcessorName.ShopifyPayments,
                "mollie" => ProcessorName.Mollie
            };
            throw new Exception("Cannot unmarshal type ProcessorName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ProcessorName)untypedValue;
            switch (value)
            {
                case ProcessorName.Stripe:
                    serializer.Serialize(writer, "stripe");
                    return;
                case ProcessorName.Braintree:
                    serializer.Serialize(writer, "braintree");
                    return;
                case ProcessorName.Authorize:
                    serializer.Serialize(writer, "authorize");
                    return;
                case ProcessorName.ShopifyPayments:
                    serializer.Serialize(writer, "shopify_payments");
                    return;
                case ProcessorName.Mollie:
                    serializer.Serialize(writer, "mollie");
                    return;
            };
            throw new Exception("Cannot marshal type ProcessorName");
        }

        public static readonly ProcessorNameConverter Singleton = new ProcessorNameConverter();
    }

}
