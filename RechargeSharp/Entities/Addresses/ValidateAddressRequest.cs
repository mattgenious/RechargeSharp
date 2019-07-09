using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressRequest
    {
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
