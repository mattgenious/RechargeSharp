using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.One_Time_Products
{
    public class OneTimeProductResponse
    {
        [JsonProperty("onetime")]
        public OneTimeProduct OneTimeProduct { get; set; }
    }
}
