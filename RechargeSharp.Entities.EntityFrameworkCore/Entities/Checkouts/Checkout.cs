using Newtonsoft.Json;
using RechargeSharp.Entities.Checkouts;
using RechargeSharp.Entities.EntityFrameworkCore.Entities.Charges;
using RechargeSharp.Entities.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace RechargeSharp.Entities.EntityFrameworkCore.Entities.Checkouts
{
    public class Checkout : RechargeSharp.Entities.Checkouts.Checkout
    {

        [JsonIgnore]
        public Charge? Charge { get; set; }

        [JsonProperty("analytics_data", NullValueHandling = NullValueHandling.Ignore)]
        [NotMapped]
        public new AnalyticsData? AnalyticsData { get; set; }

        [JsonProperty("applied_discount")]
        [NotMapped]
        public new CheckoutAppliedDiscount? AppliedDiscount { get; set; }

        [JsonProperty("billing_address")]
        [NotMapped]
        public new Address? BillingAddress { get; set; }

        [JsonProperty("line_items", NullValueHandling = NullValueHandling.Ignore)]
        [NotMapped]
        public new ICollection<CheckoutLineItem>? LineItems { get; set; }

        [JsonProperty("note_attributes", NullValueHandling = NullValueHandling.Ignore)]
        [NotMapped]
        public new ICollection<Property>? NoteAttributes { get; set; }

        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        [NotMapped]
        public new Address? ShippingAddress { get; set; }

        [JsonProperty("shipping_address_validations", NullValueHandling = NullValueHandling.Ignore)]
        [NotMapped]
        public new ShippingAddressValidations? ShippingAddressValidations { get; set; }

        [JsonProperty("shipping_line")]
        [NotMapped]
        public new ShippingLine? ShippingLine { get; set; }

        [JsonProperty("shipping_rate")]
        [NotMapped]
        public new ShippingRate? ShippingRate { get; set; }

        [JsonProperty("tax_lines", NullValueHandling = NullValueHandling.Ignore)]
        [NotMapped]
        public new ICollection<TaxLine>? TaxLines { get; set; }
    }
}
