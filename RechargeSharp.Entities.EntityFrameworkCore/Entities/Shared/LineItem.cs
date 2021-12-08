using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Subscriptions;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Shared
{
    public class LineItem : RechargeSharp.Entities.Shared.LineItem
    {
        [JsonIgnore]
        public string? Id { get; set; }

        [JsonIgnore]
        public virtual Subscription? Subscription { get; set; }

        [JsonProperty("images")]
        [NotMapped]
        public new Images? Images { get; set; }

        [JsonProperty("properties")]
        [NotMapped]
        public new ICollection<Property>? Properties { get; set; }
    }
}