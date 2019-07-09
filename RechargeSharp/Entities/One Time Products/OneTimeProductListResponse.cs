﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.One_Time_Products
{
    class OneTimeProductListResponse
    {
        [JsonProperty("onetimes")]
        public List<OneTimeProduct> OneTimeProducts { get; set; }
    }
}