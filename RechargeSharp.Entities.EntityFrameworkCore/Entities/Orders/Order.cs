using Newtonsoft.Json;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Charges;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Customers;
using RechargeSharp.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Orders
{
    public class Order : RechargeSharp.Entities.Orders.Order
    {
        [JsonIgnore]
        public Addresses.Address? Address { get; set; }

        [JsonIgnore]
        public Charge? Charge { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }

        [JsonProperty("line_items")]
        public new ICollection<Shared.LineItem>? LineItems { get; set; }
    }
}
