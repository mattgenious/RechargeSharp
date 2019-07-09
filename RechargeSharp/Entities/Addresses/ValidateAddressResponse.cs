using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressResponse
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("errors")]
        public ValidateAddressErrors Errors { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }

        [JsonProperty("zipcode")]
        public long Zipcode { get; set; }
    }
}
