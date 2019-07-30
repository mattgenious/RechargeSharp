using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Shop
{
    public class ShippingCountriesResponse
    {
        [JsonProperty("shipping_countries")]
        public List<ShippingCountry> ShippingCountries { get; set; }
    }
}
