using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class AddressListResponse
    {
        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
    }
}
