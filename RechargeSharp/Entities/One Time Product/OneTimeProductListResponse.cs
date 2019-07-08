using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.One_Time_Product
{
    class OneTimeProductListResponse
    {
        [JsonProperty("onetimes")]
        public List<OneTimeProduct> OneTimeProducts { get; set; }
    }
}
