using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RechargeSharp.Entities.Customer
{
    class CreateCustomerRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("billing_first_name")]
        public string BillingFirstName { get; set; }

        [JsonProperty("billing_last_name")]
        public string BillingLastName { get; set; }

        [JsonProperty("billing_address1")]
        public string BillingAddress1 { get; set; }

        [JsonProperty("billing_zip")]
        public long BillingZip { get; set; }

        [JsonProperty("billing_city")]
        public string BillingCity { get; set; }

        [JsonProperty("billing_province")]
        public string BillingProvince { get; set; }

        [JsonProperty("billing_country")]
        public string BillingCountry { get; set; }

        [JsonProperty("billing_phone")]
        public string BillingPhone { get; set; }
    }
}
