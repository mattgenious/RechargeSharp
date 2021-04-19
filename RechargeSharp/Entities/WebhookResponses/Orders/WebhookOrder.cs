using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Orders
{
    public class WebhookOrder : IEquatable<WebhookOrder>
    {
        public bool Equals(WebhookOrder other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && TransactionId == other.TransactionId && ChargeStatus == other.ChargeStatus && PaymentProcessor == other.PaymentProcessor && AddressIsActive == other.AddressIsActive && Status == other.Status && Type == other.Type && ChargeId == other.ChargeId && AddressId == other.AddressId && ShopifyId == other.ShopifyId && ShopifyOrderId == other.ShopifyOrderId && ShopifyOrderNumber == other.ShopifyOrderNumber && ShopifyCartToken == other.ShopifyCartToken && Nullable.Equals(ShippingDate, other.ShippingDate) && Nullable.Equals(ScheduledAt, other.ScheduledAt) && Nullable.Equals(ShippedDate, other.ShippedDate) && Nullable.Equals(ProcessedAt, other.ProcessedAt) && CustomerId == other.CustomerId && FirstName == other.FirstName && LastName == other.LastName && Hash == other.Hash && IsPrepaid == other.IsPrepaid && CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt) && Email == other.Email && TotalPrice == other.TotalPrice && Equals(ShippingAddress, other.ShippingAddress) && Equals(BillingAddress, other.BillingAddress);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookOrder) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (TransactionId != null ? TransactionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ChargeStatus != null ? ChargeStatus.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PaymentProcessor != null ? PaymentProcessor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AddressIsActive.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ChargeId.GetHashCode();
                hashCode = (hashCode * 397) ^ AddressId.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShopifyId != null ? ShopifyId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShopifyOrderId != null ? ShopifyOrderId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShopifyOrderNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShopifyCartToken != null ? ShopifyCartToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ShippingDate.GetHashCode();
                hashCode = (hashCode * 397) ^ ScheduledAt.GetHashCode();
                hashCode = (hashCode * 397) ^ ShippedDate.GetHashCode();
                hashCode = (hashCode * 397) ^ ProcessedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
                hashCode = (hashCode * 397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Hash != null ? Hash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsPrepaid.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TotalPrice != null ? TotalPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ShippingAddress != null ? ShippingAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BillingAddress != null ? BillingAddress.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(WebhookOrder left, WebhookOrder right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookOrder left, WebhookOrder right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("charge_status")]
        public string ChargeStatus { get; set; }

        [JsonProperty("payment_processor")]
        public string PaymentProcessor { get; set; }

        [JsonProperty("address_is_active")]
        public long AddressIsActive { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("charge_id")]
        public long ChargeId { get; set; }

        [JsonProperty("address_id")]
        public long AddressId { get; set; }

        [JsonProperty("shopify_id")]
        public string ShopifyId { get; set; }

        [JsonProperty("shopify_order_id")]
        public string ShopifyOrderId { get; set; }

        [JsonProperty("shopify_order_number")]
        public long ShopifyOrderNumber { get; set; }

        [JsonProperty("shopify_cart_token")]
        public string ShopifyCartToken { get; set; }

        [JsonProperty("shipping_date")]
        public DateTime? ShippingDate { get; set; }

        [JsonProperty("scheduled_at")]
        public DateTime? ScheduledAt { get; set; }

        [JsonProperty("shipped_date")]
        public DateTime? ShippedDate { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("is_prepaid")]
        public long IsPrepaid { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("line_items")]
        public IEnumerable<LineItem> LineItems { get; set; }

        [JsonProperty("total_price")]
        public string TotalPrice { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }
    }
}
