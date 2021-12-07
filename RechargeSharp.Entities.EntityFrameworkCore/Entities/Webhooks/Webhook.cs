using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Webhooks
{
    public class Webhook : RechargeSharp.Entities.Webhooks.Webhook
    {
        [JsonProperty("address")]
        [NotMapped]
        public new Uri? Address { get; set; }
    }
}
