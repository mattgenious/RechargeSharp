using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.WebhookResponses.Addresses
{
    public class WebhookAddress
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public long Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("zip")]
        public long Zip { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cart_note")]
        public string CartNote { get; set; }

        [JsonProperty("original_shipping_lines")]
        public List<ShippingLine> OriginalShippingLines { get; set; }

        [JsonProperty("cart_attributes")]
        public List<object> CartAttributes { get; set; }

        [JsonProperty("note_attributes")]
        public List<object> NoteAttributes { get; set; }

        [JsonProperty("discount_id")]
        public object DiscountId { get; set; }
    }
}
