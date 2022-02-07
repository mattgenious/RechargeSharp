using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RechargeSharp.Entities.PaymentMethods
{

    public class PaymentMethod
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? CustomerId { get; set; }

        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>? BillingAddress { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }

        [JsonProperty("include", NullValueHandling = NullValueHandling.Ignore)]
        public object? Include { get; set; }

        [JsonProperty("payment_details", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentDetails? PaymentDetails { get; set; }

        [JsonProperty("payment_type", NullValueHandling = NullValueHandling.Ignore)]
        public PaymentType? PaymentType { get; set; }

        [JsonProperty("processor_customer_token", NullValueHandling = NullValueHandling.Ignore)]
        public string? ProcessorCustomerToken { get; set; }

        [JsonProperty("processor_name", NullValueHandling = NullValueHandling.Ignore)]
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

    public class PaymentDetails
    {
        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string? Brand { get; set; }

        [JsonProperty("exp_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpMonth { get; set; }

        [JsonProperty("exp_year", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpYear { get; set; }

        [JsonProperty("last4", NullValueHandling = NullValueHandling.Ignore)]
        public string? Last4 { get; set; }
    }


    public enum PaymentType { CreditCard, Paypal, ApplePay, GooglePay, SepaDebit };

    public enum ProcessorName { Stripe, Braintree, Authorize, ShopifyPayments, Mollie };

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
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PaymentTypeConverter : JsonConverter
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
                case (PaymentType.CreditCard):
                    serializer.Serialize(writer, "CREDIT_CARD");
                    return;
                case (PaymentType.Paypal):
                    serializer.Serialize(writer, "PAYPAL");
                    return;
                case (PaymentType.ApplePay):
                    serializer.Serialize(writer, "APPLE_PAY");
                    return;
                case (PaymentType.GooglePay):
                    serializer.Serialize(writer, "GOOGLE_PAY");
                    return;
                case (PaymentType.SepaDebit):
                    serializer.Serialize(writer, "SEPA_DEBIT");
                    return;
            };
            throw new Exception("Cannot marshal type PaymentType");
        }

        public static readonly PaymentTypeConverter Singleton = new PaymentTypeConverter();
    }

    internal class ProcessorNameConverter : JsonConverter
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
                case (ProcessorName.Stripe):
                    serializer.Serialize(writer, "stripe");
                    return;
                case (ProcessorName.Braintree):
                    serializer.Serialize(writer, "braintree");
                    return;
                case (ProcessorName.Authorize):
                    serializer.Serialize(writer, "authorize");
                    return;
                case (ProcessorName.ShopifyPayments):
                    serializer.Serialize(writer, "shopify_payments");
                    return;
                case (ProcessorName.Mollie):
                    serializer.Serialize(writer, "mollie");
                    return;
            };
            throw new Exception("Cannot marshal type ProcessorName");
        }

        public static readonly ProcessorNameConverter Singleton = new ProcessorNameConverter();
    }
}
