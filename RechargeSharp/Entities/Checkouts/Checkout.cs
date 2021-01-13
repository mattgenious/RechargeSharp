using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Newtonsoft.Json;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class Checkout : IEquatable<Checkout>
    {

        [JsonProperty("analytics_data", NullValueHandling = NullValueHandling.Ignore)]
        public AnalyticsData AnalyticsData { get; set; }

        [JsonProperty("applied_discount")]
        public CheckoutAppliedDiscount AppliedDiscount { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("buyer_accepts_marketing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BuyerAcceptsMarketing { get; set; }

        [JsonProperty("charge_id")]
        public long? ChargeId { get; set; }

        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("discount_code", NullValueHandling = NullValueHandling.Ignore)]
        public string DiscountCode { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("external_checkout_id")]
        public string ExternalCheckoutId { get; set; }

        [JsonProperty("external_checkout_source")]
        public string ExternalCheckoutSource { get; set; }

        [JsonProperty("external_customer_id")]
        public object ExternalCustomerId { get; set; }

        [JsonProperty("line_items", NullValueHandling = NullValueHandling.Ignore)]
        public List<CheckoutLineItem> LineItems { get; set; }

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }

        [JsonProperty("note_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Property> NoteAttributes { get; set; }

        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("payment_processor_customer_id")]
        public string PaymentProcessorCustomerId { get; set; }

        [JsonProperty("payment_processor_transaction_id")]
        public string PaymentProcessorTransactionId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("requires_shipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequiresShipping { get; set; }

        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_address_validations", NullValueHandling = NullValueHandling.Ignore)]
        public ShippingAddressValidations ShippingAddressValidations { get; set; }

        [JsonProperty("shipping_line")]
        public ShippingLine ShippingLine { get; set; }

        [JsonProperty("shipping_rate")]
        public List<ShippingRate> ShippingRate { get; set; }

        [JsonProperty("subtotal_price", NullValueHandling = NullValueHandling.Ignore)]
        public string SubtotalPrice { get; set; }

        [JsonProperty("tax_lines", NullValueHandling = NullValueHandling.Ignore)]
        public List<TaxLine> TaxLines { get; set; }

        [JsonProperty("taxes_included", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TaxesIncluded { get; set; }

        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        [JsonProperty("total_price", NullValueHandling = NullValueHandling.Ignore)]
        public string TotalPrice { get; set; }

        [JsonProperty("total_tax", NullValueHandling = NullValueHandling.Ignore)]
        public string TotalTax { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        public bool Equals(Checkout other)
        {
	        if (ReferenceEquals(null, other)) return false;
	        if (ReferenceEquals(this, other)) return true;
	        return Equals(AnalyticsData, other.AnalyticsData) && Equals(AppliedDiscount, other.AppliedDiscount) && Equals(BillingAddress, other.BillingAddress) && BuyerAcceptsMarketing == other.BuyerAcceptsMarketing && ChargeId == other.ChargeId && Nullable.Equals(CompletedAt, other.CompletedAt) && Nullable.Equals(CreatedAt, other.CreatedAt) && Currency == other.Currency && DiscountCode == other.DiscountCode && Email == other.Email && ExternalCheckoutId == other.ExternalCheckoutId && ExternalCheckoutSource == other.ExternalCheckoutSource && Equals(ExternalCustomerId, other.ExternalCustomerId) && Note == other.Note && PaymentProcessor == other.PaymentProcessor && PaymentProcessorCustomerId == other.PaymentProcessorCustomerId && PaymentProcessorTransactionId == other.PaymentProcessorTransactionId && Phone == other.Phone && RequiresShipping == other.RequiresShipping && Equals(ShippingAddress, other.ShippingAddress) && Equals(ShippingAddressValidations, other.ShippingAddressValidations) && Equals(ShippingLine, other.ShippingLine) && SubtotalPrice == other.SubtotalPrice && TaxesIncluded == other.TaxesIncluded && Token == other.Token && TotalPrice == other.TotalPrice && TotalTax == other.TotalTax && Nullable.Equals(UpdatedAt, other.UpdatedAt);
        }

        public override bool Equals(object obj)
        {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((Checkout) obj);
        }

        public override int GetHashCode()
        {
	        var hashCode = new HashCode();
	        hashCode.Add(AnalyticsData);
	        hashCode.Add(AppliedDiscount);
	        hashCode.Add(BillingAddress);
	        hashCode.Add(BuyerAcceptsMarketing);
	        hashCode.Add(ChargeId);
	        hashCode.Add(CompletedAt);
	        hashCode.Add(CreatedAt);
	        hashCode.Add(Currency);
	        hashCode.Add(DiscountCode);
	        hashCode.Add(Email);
	        hashCode.Add(ExternalCheckoutId);
	        hashCode.Add(ExternalCheckoutSource);
	        hashCode.Add(ExternalCustomerId);
	        hashCode.Add(Note);
	        hashCode.Add(PaymentProcessor);
	        hashCode.Add(PaymentProcessorCustomerId);
	        hashCode.Add(PaymentProcessorTransactionId);
	        hashCode.Add(Phone);
	        hashCode.Add(RequiresShipping);
	        hashCode.Add(ShippingAddress);
	        hashCode.Add(ShippingAddressValidations);
	        hashCode.Add(ShippingLine);
	        hashCode.Add(SubtotalPrice);
	        hashCode.Add(TaxesIncluded);
	        hashCode.Add(Token);
	        hashCode.Add(TotalPrice);
	        hashCode.Add(TotalTax);
	        hashCode.Add(UpdatedAt);
	        return hashCode.ToHashCode();
        }

        public static bool operator ==(Checkout left, Checkout right)
        {
	        return Equals(left, right);
        }

        public static bool operator !=(Checkout left, Checkout right)
        {
	        return !Equals(left, right);
        }
    }
}
