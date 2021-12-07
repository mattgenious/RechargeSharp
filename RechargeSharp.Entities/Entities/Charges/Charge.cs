using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Charges
{
    /// <summary>
    /// See documentation <see href="https://developer.rechargepayments.com/2021-01/charges/charge_object">https://developer.rechargepayments.com/2021-01/charges/charge_object</see>
    /// </summary>
    public class Charge : IEquatable<Charge>
    {
        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("analytics_data")]
        public AnalyticsData AnalyticsData { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }

        [JsonProperty("client_details")]
        public ChargeClientDetails ClientDetails { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("customer_hash")]
        public string CustomerHash { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("discount_codes")]
        public IEnumerable<ChargeDiscountCode> DiscountCodes { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("has_uncommited_changes")]
        public bool HasUncommitedChanges { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("line_items")]
        public IEnumerable<LineItem> LineItems { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("note_attributes")]
        public IEnumerable<Property> NoteAttributes { get; set; }

        [JsonProperty("processed_at")]
        public DateTimeOffset? ProcessedAt { get; set; }

        [JsonProperty("processor_name")]
        public string ProcessorName { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTimeOffset? ScheduledAt { get; set; }

        [JsonProperty("shipments_count")]
        public long? ShipmentsCount { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("shipping_lines")]
        public IEnumerable<ShippingLine> ShippingLines { get; set; }

        [JsonProperty("shopify_order_id")]
        public long? ShopifyOrderId { get; set; }

        [JsonProperty("status")]
        public ChargeStatus? Status { get; set; }

        [JsonProperty("sub_total")]
        public string SubTotal { get; set; }

        [JsonProperty("subtotal_price")]
        public decimal? SubtotalPrice { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("tax_lines")]
        public decimal TaxLines { get; set; }

        [JsonProperty("total_discounts")]
        public string TotalDiscounts { get; set; }

        [JsonProperty("total_line_items_price")]
        public string TotalLineItemsPrice { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("total_refunds")]
        public string TotalRefunds { get; set; }

        [JsonProperty("total_tax")]
        public decimal TotalTax { get; set; }

        [JsonProperty("total_weight")]
        public decimal TotalWeight { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// only present for failed charges
        /// </summary>
        [JsonProperty("last_charge_attempt_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastChargeAttemptDate { get; set; }

        /// <summary>
        /// only present for failed charges
        /// </summary>
        [JsonProperty("retry_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? RetryDate { get; set; }

        /// <summary>
        /// only present for failed charges
        /// </summary>
        [JsonProperty("number_times_tried", NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberTimesTried { get; set; }

        /// <summary>
        /// only present for failed charges
        /// </summary>
        [JsonProperty("shopify_variant_id_not_found", NullValueHandling = NullValueHandling.Ignore)]
        public string ShopifyVariantIdNotFound { get; set; }

        /// <summary>
        /// only present for failed charges
        /// </summary>
        [JsonProperty("error_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorType { get; set; }

        /// <summary>
        /// only present for failed charges
        /// </summary>
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }


        public bool Equals(Charge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AddressId == other.AddressId && CreatedAt.Equals(other.CreatedAt) &&
                   CustomerHash == other.CustomerHash && CustomerId == other.CustomerId && Email == other.Email &&
                   FirstName == other.FirstName && HasUncommitedChanges == other.HasUncommitedChanges &&
                   Id == other.Id && LastName == other.LastName && Note == other.Note &&
                   Nullable.Equals(ProcessedAt, other.ProcessedAt) && ProcessorName == other.ProcessorName &&
                   Nullable.Equals(ScheduledAt, other.ScheduledAt) && ShipmentsCount == other.ShipmentsCount && 
                   ShopifyOrderId == other.ShopifyOrderId &&
                   Status == other.Status && SubTotal == other.SubTotal && SubtotalPrice == other.SubtotalPrice &&
                   Tags == other.Tags && TaxLines == other.TaxLines && TotalDiscounts == other.TotalDiscounts &&
                   TotalLineItemsPrice == other.TotalLineItemsPrice && TotalPrice == other.TotalPrice &&
                   TotalRefunds == other.TotalRefunds && TotalTax == other.TotalTax &&
                   TotalWeight == other.TotalWeight && TransactionId == other.TransactionId && Type == other.Type &&
                   UpdatedAt.Equals(other.UpdatedAt) &&
                   Nullable.Equals(LastChargeAttemptDate, other.LastChargeAttemptDate) &&
                   Nullable.Equals(RetryDate, other.RetryDate) && NumberTimesTried == other.NumberTimesTried &&
                   ShopifyVariantIdNotFound == other.ShopifyVariantIdNotFound && ErrorType == other.ErrorType &&
                   Error == other.Error;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Charge)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(AddressId);
            hashCode.Add(CreatedAt);
            hashCode.Add(CustomerHash);
            hashCode.Add(CustomerId);
            hashCode.Add(Email);
            hashCode.Add(FirstName);
            hashCode.Add(HasUncommitedChanges);
            hashCode.Add(Id);
            hashCode.Add(LastName);
            hashCode.Add(Note);
            hashCode.Add(ProcessedAt);
            hashCode.Add(ProcessorName);
            hashCode.Add(ScheduledAt);
            hashCode.Add(ShipmentsCount);
            hashCode.Add(ShopifyOrderId);
            hashCode.Add(Status);
            hashCode.Add(SubTotal);
            hashCode.Add(SubtotalPrice);
            hashCode.Add(Tags);
            hashCode.Add(TaxLines);
            hashCode.Add(TotalDiscounts);
            hashCode.Add(TotalLineItemsPrice);
            hashCode.Add(TotalPrice);
            hashCode.Add(TotalRefunds);
            hashCode.Add(TotalTax);
            hashCode.Add(TotalWeight);
            hashCode.Add(TransactionId);
            hashCode.Add(Type);
            hashCode.Add(UpdatedAt);
            hashCode.Add(LastChargeAttemptDate);
            hashCode.Add(RetryDate);
            hashCode.Add(NumberTimesTried);
            hashCode.Add(ShopifyVariantIdNotFound);
            hashCode.Add(ErrorType);
            hashCode.Add(Error);
            return hashCode.ToHashCode();
        }
    }
}
