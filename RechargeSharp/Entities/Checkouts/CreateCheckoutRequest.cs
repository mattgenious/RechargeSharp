using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class CreateCheckoutRequest
    {
        [JsonProperty("line_items")]
        public List<CreateCheckoutRequestLineItem> LineItems { get; set; }

        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Address ShippingAddress { get; set; }
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Address BillingAddress { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }
        [JsonProperty("note_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> NoteAttributes { get; set; }
        [JsonProperty("shipping_line", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> ShippingLine { get; set; }
        [JsonProperty("discount_code", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountCode { get; set; }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
        [JsonProperty("buyer_accepts_marketing", NullValueHandling = NullValueHandling.Ignore)]
        public bool BuyerAcceptsMarketing { get; set; }
    }
}
