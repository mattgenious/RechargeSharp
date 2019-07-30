using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Customers;

namespace RechargeSharp.Entities.WebhookResponses.Checkouts
{
    public class WebhookCheckout
    {
        [JsonProperty("customer")]
        public WebhookCheckoutCustomer Customer { get; set; }

        [JsonProperty("store_id")]
        public long StoreId { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

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
