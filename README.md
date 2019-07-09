# RechargeSharp, a C\# library for RechargePayments
### built to work with the api documented at [https://developer.rechargepayments.com/](https://developer.rechargepayments.com/)
Please feel free to submit pull requests on github
I am currently prioritizing getting the entities created, services will come afterwards.

## Missing items
### Entities
#### Charges
- ChangeNextChargeDateRequest
- SkipChargeRequest
- UnskipChargeRequest
- RefundChargeRequest
- TotalRefundRequest
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

### Services
- ChargeService
- CollectionService
- DiscountService
- MetafieldService
- OneTimeProductService
- OrderService
- ProductService
- ShopService

## Next items to be implemented
- DiscountService
- ChargeService