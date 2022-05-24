using Newtonsoft.Json;
using RechargeSharp.Utilities;

namespace RechargeSharp.Entities.PaymentMethods
{
    public partial class PaymentMethodsResponse
    {
        [JsonProperty("payment_methods")]
        public List<PaymentMethod>? PaymentMethods { get; set; }
    }
}
