using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customers
{
    public class UpdateCustomerPaymentTokenRequest
    {
        [JsonProperty("stripe_customer_token")]
        public string StripeCustomerToken { get; set; }
    }
}
