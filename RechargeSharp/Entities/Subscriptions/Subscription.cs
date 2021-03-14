using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RechargeSharp.Entities.Shared;

namespace RechargeSharp.Entities.Subscriptions
{
	public class Subscription : IEquatable<Subscription>
	{
		public bool Equals(Subscription other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return RechargeProductId == other.RechargeProductId && SkuOverride == other.SkuOverride && Id == other.Id &&
			       AddressId == other.AddressId && CustomerId == other.CustomerId &&
			       CreatedAt.Equals(other.CreatedAt) && UpdatedAt.Equals(other.UpdatedAt) &&
			       Nullable.Equals(NextChargeScheduledAt, other.NextChargeScheduledAt) &&
			       Nullable.Equals(CancelledAt, other.CancelledAt) && ProductTitle == other.ProductTitle &&
			       VariantTitle == other.VariantTitle && Price == other.Price && Quantity == other.Quantity &&
			       Status == other.Status && ShopifyProductId == other.ShopifyProductId &&
			       ShopifyVariantId == other.ShopifyVariantId && Sku == other.Sku &&
			       OrderIntervalUnit == other.OrderIntervalUnit &&
			       OrderIntervalFrequency == other.OrderIntervalFrequency &&
			       ChargeIntervalFrequency == other.ChargeIntervalFrequency &&
			       CancellationReason == other.CancellationReason &&
			       CancellationReasonComments == other.CancellationReasonComments &&
			       OrderDayOfWeek == other.OrderDayOfWeek && OrderDayOfMonth == other.OrderDayOfMonth &&
			       ExpireAfterSpecificNumberOfCharges == other.ExpireAfterSpecificNumberOfCharges &&
			       MaxRetriesReached == other.MaxRetriesReached && HasQueuedCharges == other.HasQueuedCharges &&
			       CommitUpdate == other.CommitUpdate;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Subscription) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = RechargeProductId.GetHashCode();
				hashCode = (hashCode * 397) ^ SkuOverride.GetHashCode();
				hashCode = (hashCode * 397) ^ Id.GetHashCode();
				hashCode = (hashCode * 397) ^ AddressId.GetHashCode();
				hashCode = (hashCode * 397) ^ CustomerId.GetHashCode();
				hashCode = (hashCode * 397) ^ CreatedAt.GetHashCode();
				hashCode = (hashCode * 397) ^ UpdatedAt.GetHashCode();
				hashCode = (hashCode * 397) ^ NextChargeScheduledAt.GetHashCode();
				hashCode = (hashCode * 397) ^ CancelledAt.GetHashCode();
				hashCode = (hashCode * 397) ^ (ProductTitle != null ? ProductTitle.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (VariantTitle != null ? VariantTitle.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Price.GetHashCode();
				hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
				hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ ShopifyProductId.GetHashCode();
				hashCode = (hashCode * 397) ^ ShopifyVariantId.GetHashCode();
				hashCode = (hashCode * 397) ^ (Sku != null ? Sku.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OrderIntervalUnit != null ? OrderIntervalUnit.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^
				           (OrderIntervalFrequency != null ? OrderIntervalFrequency.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^
				           (ChargeIntervalFrequency != null ? ChargeIntervalFrequency.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (CancellationReason != null ? CancellationReason.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^
				           (CancellationReasonComments != null ? CancellationReasonComments.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ OrderDayOfWeek.GetHashCode();
				hashCode = (hashCode * 397) ^ OrderDayOfMonth.GetHashCode();
				hashCode = (hashCode * 397) ^ ExpireAfterSpecificNumberOfCharges.GetHashCode();
				hashCode = (hashCode * 397) ^ MaxRetriesReached.GetHashCode();
				hashCode = (hashCode * 397) ^ HasQueuedCharges.GetHashCode();
				hashCode = (hashCode * 397) ^ CommitUpdate.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(Subscription left, Subscription right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Subscription left, Subscription right)
		{
			return !Equals(left, right);
		}

		[JsonProperty("recharge_product_id")] public long? RechargeProductId { get; set; }

		[JsonProperty("sku_override")] public bool SkuOverride { get; set; }

		[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
		public long Id { get; set; }

		[JsonProperty("address_id")] public long AddressId { get; set; }

		[JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
		public long CustomerId { get; set; }

		[JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty("next_charge_scheduled_at", NullValueHandling = NullValueHandling.Include)]
		public DateTime? NextChargeScheduledAt { get; set; }

		[JsonProperty("cancelled_at", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? CancelledAt { get; set; }

		[JsonProperty("product_title")] public string ProductTitle { get; set; }

		[JsonProperty("variant_title")] public string VariantTitle { get; set; }

		[JsonProperty("price")] public decimal Price { get; set; }

		[JsonProperty("quantity")] public long Quantity { get; set; }

		[JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
		public string Status { get; set; }

		[JsonProperty("shopify_product_id", NullValueHandling = NullValueHandling.Ignore)]
		public long ShopifyProductId { get; set; }

		[JsonProperty("shopify_variant_id")] public long ShopifyVariantId { get; set; }

		[JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
		public string Sku { get; set; }

		[JsonProperty("order_interval_unit")] public string OrderIntervalUnit { get; set; }

		[JsonProperty("order_interval_frequency")]
		public string OrderIntervalFrequency { get; set; }

		[JsonProperty("charge_interval_frequency")]
		public string ChargeIntervalFrequency { get; set; }

		[JsonProperty("cancellation_reason", NullValueHandling = NullValueHandling.Ignore)]
		public string CancellationReason { get; set; }

		[JsonProperty("cancellation_reason_comments", NullValueHandling = NullValueHandling.Ignore)]
		public string CancellationReasonComments { get; set; }

		[JsonProperty("order_day_of_week", NullValueHandling = NullValueHandling.Ignore)]
		public long? OrderDayOfWeek { get; set; }

		[JsonProperty("order_day_of_month", NullValueHandling = NullValueHandling.Ignore)]
		public long? OrderDayOfMonth { get; set; }

		[JsonProperty("properties")] public IEnumerable<Property> Properties { get; set; }

		[JsonProperty("expire_after_specific_number_of_charges", NullValueHandling = NullValueHandling.Ignore)]
		public long? ExpireAfterSpecificNumberOfCharges { get; set; }

		[JsonProperty("max_retries_reached", NullValueHandling = NullValueHandling.Ignore)]
		public long? MaxRetriesReached { get; set; }

		[JsonProperty("has_queued_charges", NullValueHandling = NullValueHandling.Ignore)]
		public long? HasQueuedCharges { get; set; }

		[JsonProperty("commit_update", NullValueHandling = NullValueHandling.Ignore)]
		public bool? CommitUpdate { get; set; }
	}
}