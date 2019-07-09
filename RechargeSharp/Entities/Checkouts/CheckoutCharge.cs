using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CheckoutCharge
    {
        [JsonProperty("payment_processor_transaction_id")]
        public string PaymentProcessorTransactionId { get; set; }

        [JsonProperty("charge_id")]
        public long ChargeId { get; set; }

        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("payment_token")]
        public string PaymentToken { get; set; }

        [JsonProperty("payment_processor_customer_id")]
        public string PaymentProcessorCustomerId { get; set; }
    }
}