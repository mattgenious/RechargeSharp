using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Orders
{
    public class UpdateLineItemsRequest
    {
        [JsonProperty("line_items")]
        public List<UpdateLineItemRequestLineItem> LineItems { get; set; }
    }
}
