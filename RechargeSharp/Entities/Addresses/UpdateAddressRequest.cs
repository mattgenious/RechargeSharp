using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Addresses
{
    public class UpdateAddressRequest
    {
        [JsonProperty("address1", NullValueHandling = NullValueHandling.Ignore)]
        public string Address1 { get; set; }

        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string Address2 { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("province", NullValueHandling = NullValueHandling.Ignore)]
        public string Province { get; set; }

        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public long? Zip { get; set; }

        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("original_shipping_lines", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShippingLine> ShippingLinesOverride { get; set; }
    }
}
