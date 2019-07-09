using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    class CreateCheckoutRequest
    {
        [JsonProperty("line_items")]
        public CreateCheckoutRequestLineItem[] LineItems { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
