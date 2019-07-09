using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Customers
{
    public class PaymentSource
    {
        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("card_brand")]
        public object CardBrand { get; set; }

        [JsonProperty("card_exp_month")]
        public object CardExpMonth { get; set; }

        [JsonProperty("card_exp_year")]
        public object CardExpYear { get; set; }

        [JsonProperty("card_last4")]
        public object CardLast4 { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("has_card_error_in_dunning")]
        public bool HasCardErrorInDunning { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("processor_name")]
        public string ProcessorName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("status_reason")]
        public object StatusReason { get; set; }
    }
}
