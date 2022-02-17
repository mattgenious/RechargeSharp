using Newtonsoft.Json;
using RechargeSharp.Entities.PaymentMethods;

namespace RechargeSharp.Entities.Utilities
{
    public class PaymentTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PaymentType) || t == typeof(PaymentType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "CREDIT_CARD" => PaymentType.CreditCard,
                "PAYPAL" => PaymentType.Paypal,
                "APPLE_PAY" => PaymentType.ApplePay,
                "GOOGLE_PAY" => PaymentType.GooglePay,
                "SEPA_DEBIT" => PaymentType.SepaDebit
            };
            throw new Exception("Cannot unmarshal type PaymentType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PaymentType)untypedValue;
            switch (value)
            {
                case PaymentType.CreditCard:
                    serializer.Serialize(writer, "CREDIT_CARD");
                    return;
                case PaymentType.Paypal:
                    serializer.Serialize(writer, "PAYPAL");
                    return;
                case PaymentType.ApplePay:
                    serializer.Serialize(writer, "APPLE_PAY");
                    return;
                case PaymentType.GooglePay:
                    serializer.Serialize(writer, "GOOGLE_PAY");
                    return;
                case PaymentType.SepaDebit:
                    serializer.Serialize(writer, "SEPA_DEBIT");
                    return;
            };
            throw new Exception("Cannot marshal type PaymentType");
        }

        public static readonly PaymentTypeConverter Singleton = new PaymentTypeConverter();
    }
}
