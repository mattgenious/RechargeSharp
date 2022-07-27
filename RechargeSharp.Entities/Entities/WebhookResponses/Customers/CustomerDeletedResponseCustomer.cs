using Newtonsoft.Json;

namespace RechargeSharp.Entities.WebhookResponses.Customers
{
    public class CustomerDeletedResponseCustomer
    {
        // is type object because we don't actually know if its a string or a long because the example from Recharge's slack channel shows a string, but the customer id is a long.
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
