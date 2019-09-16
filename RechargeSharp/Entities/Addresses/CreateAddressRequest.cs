using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class CreateAddressRequest
    {
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("original_shipping_lines", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> ShippingLinesOverride { get; set; }
        [JsonProperty("cart_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CartNote { get; set; }
    }
}
