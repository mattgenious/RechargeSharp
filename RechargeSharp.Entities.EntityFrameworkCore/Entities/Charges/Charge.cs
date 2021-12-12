using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Checkouts;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Customers;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Orders;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Charges
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class Charge : RechargeSharp.Entities.Charges.Charge
    {
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }

        [JsonIgnore]
        public virtual Address? Address { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }

        [JsonIgnore]
        public virtual Checkout? Checkout { get; set; }

        [JsonProperty("line_items")]
        public new virtual ICollection<Shared.LineItem>? LineItems { get; set; }
    }
}
