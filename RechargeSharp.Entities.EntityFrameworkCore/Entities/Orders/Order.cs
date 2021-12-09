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

        [JsonProperty("billing_address")]
        [NotMapped]
        public new Address? BillingAddress { get; set; }

        [JsonProperty("note_attributes")]
        [NotMapped]
        public new ICollection<Property>? NoteAttributes { get; set; }

        [JsonProperty("shipping_address")]
        [NotMapped]
        public new Address? ShippingAddress { get; set; }

        [JsonProperty("shipping_lines")]
        [NotMapped]
        public new ICollection<ShippingLine>? ShippingLines { get; set; }

        [JsonProperty("tax_lines")]
        [NotMapped]
        public new ICollection<TaxLine>? TaxLines { get; set; }
    }
}
