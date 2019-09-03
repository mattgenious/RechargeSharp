using Newtonsoft.Json;

namespace RechargeSharp.Entities.Checkouts
{
    public class CreateCheckoutRequest
    {
        [JsonProperty("checkout")]
        public CreateCheckoutRequestCheckout Checkout { get; set; }

    }
}
