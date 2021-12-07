using Newtonsoft.Json;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Customers;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Products;
using RechargeSharp.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Subscriptions
{
    public class Subscription : RechargeSharp.Entities.Subscriptions.Subscription
    {
        [JsonIgnore]
        public Product? Product { get; set; }

        [JsonIgnore]
        public Addresses.Address? Address { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }

        [JsonIgnore]
        public Shared.LineItem? LineItem { get; set; }

        [JsonProperty("properties")]
        [NotMapped]
        public new IEnumerable<Property>? Properties { get; set; }
    }
}