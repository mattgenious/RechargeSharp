using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Address
{
    class AddressListResponse
    {
        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
    }
}
