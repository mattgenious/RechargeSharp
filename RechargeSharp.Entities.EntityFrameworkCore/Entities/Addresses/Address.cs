using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Customers;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Discounts;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Onetimes;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Orders;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Subscriptions;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Addresses
{
    public class Address : RechargeSharp.Entities.Addresses.Address
    {
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }

        [JsonIgnore]
        public virtual Discount? Discount { get; set; }

        [JsonIgnore]
        public virtual ICollection<Onetime>? Onetimes { get; set; }

        [JsonIgnore]
        public virtual ICollection<Subscription>? Subscriptions { get; set; }

        [JsonIgnore]
        public virtual ICollection<Charge>? Charges { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }

        [JsonProperty("cart_attributes")]
        [NotMapped]
        public new ICollection<Property>? CartAttributes { get; set; }

        [JsonProperty("note_attributes")]
        [NotMapped]
        public new ICollection<Property>? NoteAttributes { get; set; }

        [JsonProperty("original_shipping_lines")]
        [NotMapped]
        public new ICollection<ShippingLine>? OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override")]
        [NotMapped]
        public new ICollection<ShippingLine>? ShippingLinesOverride { get; set; }
    }
}
