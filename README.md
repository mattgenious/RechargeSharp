# RechargeSharp, a C\# library for RechargePayments
### built to work with the api documented at [https://developer.rechargepayments.com/](https://developer.rechargepayments.com/)
Please feel free to submit pull requests on github
I am currently prioritizing getting the entities created, services will come afterwards.

## Missing items
### Entities
#### Addresses
- UpdateAddressRequest
- OverrideShippingLinesRequest
- ValidateAddressRequest
#### Charges
- ChangeNextChargeDateRequest
- SkipChargeRequest
- UnskipChargeRequest
- RefundChargeRequest
- TotalRefundRequest
#### Checkouts
- UpdateCheckoutRequest
- UpdateCheckoutShippingLineRequest
#### Discounts
- UpdateDiscountRequest
- AddDiscountToAddressRequest
- AddDiscountToChargeRequest
- RemoveDiscountRequest(seems to be an empty post request?)
#### Metafields
- UpdateMetafieldRequest
#### One Time Products
- UpdateOneTimeProductRequest
#### Orders
- UpdateOrderRequest
- UpdateLineItemsRequest
- ChangeOrderDateRequest
- ChangeOrderVariantRequest
- CloneOrdersRequest
#### Subscriptions
- UpdateSubscriptionRequest
- ChangeNextChargeDateSubscriptionRequest
- ChangeAddressRequest
- CancelSubscriptionRequest
- ActivateSubscriptionRequest
- DelayChargeRegenRequest

### Services
- AddressService
- ChargeService
- CheckoutService
- CollectionService
- DiscountService
- MetafieldService
- OneTimeProductService
- OrderService
- ProductService
- ShopService

## Items being currently being implemented
- SubscriptionService