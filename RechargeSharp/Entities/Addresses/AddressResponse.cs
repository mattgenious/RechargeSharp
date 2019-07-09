using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class AddressResponse
    {
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
