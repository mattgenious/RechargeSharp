using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Customers;

namespace RechargeSharp.Entities.WebhookResponses.Checkouts
{
    public class WebhookCheckout : IEquatable<WebhookCheckout>
    {
        public bool Equals(WebhookCheckout other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Customer, other.Customer) && StoreId == other.StoreId && Nullable.Equals(UpdatedAt, other.UpdatedAt) && ShopifyCartToken == other.ShopifyCartToken && SubscriptionId == other.SubscriptionId && Id == other.Id && TotalPriceDollars == other.TotalPriceDollars;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WebhookCheckout) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Customer != null ? Customer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ StoreId.GetHashCode();
                hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
                hashCode = (hashCode * 397) ^ (ShopifyCartToken != null ? ShopifyCartToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SubscriptionId.GetHashCode();
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ TotalPriceDollars.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(WebhookCheckout left, WebhookCheckout right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WebhookCheckout left, WebhookCheckout right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("customer")]
        public WebhookCheckoutCustomer Customer { get; set; }

        [JsonProperty("store_id")]
        public long StoreId { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("shopify_cart_token")]
        public string ShopifyCartToken { get; set; }

        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("total_price_dollars")]
        public long TotalPriceDollars { get; set; }
    }
}
