﻿using Newtonsoft.Json;
using RechargeSharp.Entities.Checkouts;

namespace RechargeSharp.Entities.Shared
{
    public class ShippingRate : IEquatable<ShippingRate>
    {
        public bool Equals(ShippingRate? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Checkout, other.Checkout) && Code == other.Code && Handle == other.Handle && Name == other.Name && PhoneRequired == other.PhoneRequired && Price == other.Price && Title == other.Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShippingRate) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Checkout?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Handle != null ? Handle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PhoneRequired.GetHashCode();
                hashCode = (hashCode * 397) ^ (Price != null ? Price.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(ShippingRate left, ShippingRate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShippingRate left, ShippingRate right)
        {
            return !Equals(left, right);
        }

        [JsonProperty("checkout")]
        public CheckoutShippingRate? Checkout { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("delivery_range")]
        public IEnumerable<string>? DeliveryRange { get; set; }

        [JsonProperty("handle")]
        public string? Handle { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("phone_required")]
        public bool? PhoneRequired { get; set; }

        [JsonProperty("price")]
        public string? Price { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }
    }
}
