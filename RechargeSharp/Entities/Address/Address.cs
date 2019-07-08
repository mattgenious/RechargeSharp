using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Address
{
    class Address
    {
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("cart_attributes")]
        public Property[] CartAttributes { get; set; }

        [JsonProperty("cart_note")]
        public string CartNote { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("customer_id")]
        public long CustomerId { get; set; }

        [JsonProperty("discount_id")]
        public long DiscountId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("note_attributes")]
        public Property[] NoteAttributes { get; set; }

        [JsonProperty("original_shipping_lines")]
        public List<ShippingLine> OriginalShippingLines { get; set; }

        [JsonProperty("shipping_lines_override")]
        public ShippingLine[] ShippingLinesOverride { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("zip")]
        public long Zip { get; set; }
    }
}
