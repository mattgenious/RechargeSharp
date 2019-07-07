using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkout
{
    class Checkout
    {
        [JsonProperty("applied_discount")]
        public string AppliedDiscount { get; set; }

        [JsonProperty("billing_address")]
        public Shared.Address BillingAddress { get; set; }

        [JsonProperty("buyer_accepts_marketing")]
        public bool BuyerAcceptsMarketing { get; set; }

        [JsonProperty("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("discount_code")]
        public string DiscountCode { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("line_items")]
        public LineItem[] LineItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_attributes")]
        public Property[] NoteAttributes { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("shipping_address")]
        public Shared.Address ShippingAddress { get; set; }

        [JsonProperty("shipping_line")]
        public ShippingLine ShippingLine { get; set; }

        [JsonProperty("shipping_rate")]
        public ShippingRate[] ShippingRate { get; set; }

        [JsonProperty("subtotal_price")]
        public string SubtotalPrice { get; set; }

        [JsonProperty("tax_lines")]
        public object[] TaxLines { get; set; }

        [JsonProperty("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
