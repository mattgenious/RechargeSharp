using System;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutCharge : IEquatable<CheckoutCharge>
    {
        [JsonProperty("authorization_token")] public string AuthorizationToken { get; set; }

        [JsonProperty("free")] public bool Free { get; set; }

        [JsonProperty("payment_type")] public string PaymentType { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("payment_processor_transaction_id")]
        public string PaymentProcessorTransactionId { get; set; }

        [JsonConverter(typeof(ParseNoneStringConverter))]
        [JsonProperty("charge_id")]
        public long? ChargeId { get; set; }

        [JsonProperty("payment_processor")] public string PaymentProcessor { get; set; }

        [JsonProperty("payment_token")] public string PaymentToken { get; set; }

        [JsonProperty("payment_processor_customer_id")]
        public string PaymentProcessorCustomerId { get; set; }

        public bool Equals(CheckoutCharge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AuthorizationToken == other.AuthorizationToken && Free == other.Free &&
                   PaymentType == other.PaymentType && Status == other.Status &&
                   PaymentProcessorTransactionId == other.PaymentProcessorTransactionId && ChargeId == other.ChargeId &&
                   PaymentProcessor == other.PaymentProcessor && PaymentToken == other.PaymentToken &&
                   PaymentProcessorCustomerId == other.PaymentProcessorCustomerId;
        }

        public static bool operator ==(CheckoutCharge left, CheckoutCharge right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckoutCharge left, CheckoutCharge right)
        {
            return !Equals(left, right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CheckoutCharge) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(AuthorizationToken);
            hashCode.Add(Free);
            hashCode.Add(PaymentType);
            hashCode.Add(Status);
            hashCode.Add(PaymentProcessorTransactionId);
            hashCode.Add(ChargeId);
            hashCode.Add(PaymentProcessor);
            hashCode.Add(PaymentToken);
            hashCode.Add(PaymentProcessorCustomerId);
            return hashCode.ToHashCode();
        }

        internal class ParseNoneStringConverter : JsonConverter
        {
            public static readonly ParseNoneStringConverter Singleton = new ParseNoneStringConverter();

            public override bool CanConvert(Type t)
            {
                return t == typeof(long) || t == typeof(long?);
            }

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value.Equals("None", StringComparison.InvariantCultureIgnoreCase)) return null;

                long l;
                if (long.TryParse(value, out l)) return l;

                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }

                var value = (long) untypedValue;
                serializer.Serialize(writer, value);
            }
        }
    }
}