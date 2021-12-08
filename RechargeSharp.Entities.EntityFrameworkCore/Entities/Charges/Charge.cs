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

        [JsonProperty("analytics_data")]
        [NotMapped]
        public new AnalyticsData? AnalyticsData { get; set; }

        [JsonProperty("billing_address")]
        [NotMapped]
        public new Address? BillingAddress { get; set; }

        [JsonProperty("client_details")]
        [NotMapped]
        public new ChargeClientDetails? ClientDetails { get; set; }

        [JsonProperty("discount_codes")]
        [NotMapped]
        public new ICollection<ChargeDiscountCode>? DiscountCodes { get; set; }

        [JsonProperty("note_attributes")]
        [NotMapped]
        public new ICollection<Property>? NoteAttributes { get; set; }

        [JsonProperty("shipping_address")]
        [NotMapped]
        public new Address? ShippingAddress { get; set; }

        [JsonProperty("shipping_lines")]
        [NotMapped]
        public new ICollection<ShippingLine>? ShippingLines { get; set; }
    }
}
