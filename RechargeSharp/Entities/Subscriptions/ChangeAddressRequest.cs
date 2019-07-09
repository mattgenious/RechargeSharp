using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Subscriptions
{
    public class ChangeAddressRequest
    {
        [JsonProperty("address_id")]
        public long AddressId { get; set; }
    }
}
