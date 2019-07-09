using Newtonsoft.Json;

namespace RechargeSharp.Entities.Addresses
{
    public class ValidateAddressErrors
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
    }
}