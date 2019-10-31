using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Checkouts
{
    public class CreateCheckoutRequestLineItem : IEquatable<CreateCheckoutRequestLineItem>
    {
        public bool Equals(CreateCheckoutRequestLineItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ChargeIntervalFrequency == other.ChargeIntervalFrequency && CutoffDayOfMonth == other.CutoffDayOfMonth && CutoffDayOfWeek == other.CutoffDayOfWeek && ExpireAfterSpecificNumberOfCharges == other.ExpireAfterSpecificNumberOfCharges && FulfillmentService == other.FulfillmentService && Grams == other.Grams && LinePrice == other.LinePrice && OrderDayOfMonth == other.OrderDayOfMonth && OrderDayOfWeek == other.OrderDayOfWeek && OrderIntervalFrequency == other.OrderIntervalFrequency && OrderIntervalUnit == other.OrderIntervalUnit && Price == other.Price && ProductId == other.ProductId && Quantity == other.Quantity && RequiresShipping == other.RequiresShipping && Sku == other.Sku && Taxable == other.Taxable && Title == other.Title && VariantId == other.VariantId && VariantTitle == other.VariantTitle && Vendor == other.Vendor;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateCheckoutRequestLineItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ChargeIntervalFrequency.GetHashCode();
                hashCode = (hashCode * 397) ^ CutoffDayOfMonth.GetHashCode();
                hashCode = (hashCode * 397) ^ CutoffDayOfWeek.GetHashCode();
                hashCode = (hashCode * 397) ^ ExpireAfterSpecificNumberOfCharges.GetHashCode();
                hashCode = (hashCode * 397) ^ (FulfillmentService != null ? FulfillmentService.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Grams.GetHashCode();
                hashCode = (hashCode * 397) ^ (LinePrice != null ? LinePrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrderDayOfMonth.GetHashCode();
                hashCode = (hashCode * 397) ^ OrderDayOfWeek.GetHashCode();
                hashCode = (hashCode * 397) ^ OrderIntervalFrequency.GetHashCode();
                hashCode = (hashCode * 397) ^ (OrderIntervalUnit != null ? OrderIntervalUnit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Price != null ? Price.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ProductId.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ RequiresShipping.GetHashCode();
                hashCode = (hashCode * 397) ^ (Sku != null ? Sku.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Taxable.GetHashCode();
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ VariantId.GetHashCode();
                hashCode = (hashCode * 397) ^ (VariantTitle != null ? VariantTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Vendor != null ? Vendor.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(CreateCheckoutRequestLineItem left, CreateCheckoutRequestLineItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateCheckoutRequestLineItem left, CreateCheckoutRequestLineItem right)
        {
            return !Equals(left, right);
        }


        [JsonProperty("charge_interval_frequency", NullValueHandling = NullValueHandling.Ignore)]
        public long? ChargeIntervalFrequency { get; set; }

        [JsonProperty("cutoff_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? CutoffDayOfMonth { get; set; }

        [JsonProperty("cutoff_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? CutoffDayOfWeek { get; set; }

        [JsonProperty("expire_after_specific_number_of_charges", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpireAfterSpecificNumberOfCharges { get; set; }

        [JsonProperty("fulfillment_service", NullValueHandling = NullValueHandling.Ignore)]
        public string FulfillmentService { get; set; }

        [JsonProperty("grams", NullValueHandling = NullValueHandling.Ignore)]
        public long? Grams { get; set; }

        [JsonProperty("line_price", NullValueHandling = NullValueHandling.Ignore)]
        public string LinePrice { get; set; }

        [JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfMonth { get; set; }

        [JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderDayOfWeek { get; set; }

        [JsonProperty("order_interval_frequency", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrderIntervalFrequency { get; set; }

        [JsonProperty("order_interval_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderIntervalUnit { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("product_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProductId { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,string> Properties { get; set; }

        [Required]
        [JsonProperty("quantity")]
        public long? Quantity { get; set; }

        [JsonProperty("requires_shipping", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RequiresShipping { get; set; }

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("taxable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Taxable { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [Required]
        [JsonProperty("variant_id")]
        public long? VariantId { get; set; }

        [JsonProperty("variant_title", NullValueHandling = NullValueHandling.Ignore)]
        public string VariantTitle { get; set; }

        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public string Vendor { get; set; }
    }
}
