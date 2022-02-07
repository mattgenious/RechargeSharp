using Newtonsoft.Json;

namespace RechargeSharp.Entities.Entities.Checkouts
{
    public partial class CheckoutErrorResponse
    {
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public Errors Errors { get; set; }
    }

    public partial class Errors
    {
        [JsonProperty("payment", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Payment { get; set; }
    }
}
