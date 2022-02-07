using Newtonsoft.Json;

namespace RechargeSharp.Entities.PaymentMethods
{
    public partial class PaymentMethodsResponse
    {
        [JsonProperty("payment_methods", NullValueHandling = NullValueHandling.Ignore)]
        public List<PaymentMethod>? PaymentMethodsPaymentMethods { get; set; }
    }
}
