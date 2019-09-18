using System;
using System.Collections.Generic;
using System.Security;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class Checkout
    {
        [JsonProperty("applied_discount")]
        public CheckoutAppliedDiscount AppliedDiscount { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("buyer_accepts_marketing")]
        public bool BuyerAcceptsMarketing { get; set; }

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("discount_code")]
        public string DiscountCode { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("line_items")]
        public CheckoutLineItem[] LineItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_attributes")]
        public Dictionary<string, string> NoteAttributes { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_line")]
        public ShippingLine ShippingLine { get; set; }

        [JsonProperty("shipping_rate")]
        public ShippingRate[] ShippingRate { get; set; }

        [JsonProperty("subtotal_price")]
        public string SubtotalPrice { get; set; }

        [JsonProperty("tax_lines")]
        public TaxLine[] TaxLines { get; set; }

        [JsonProperty("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
