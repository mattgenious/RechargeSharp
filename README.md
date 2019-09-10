# RechargeSharp, a C\# library for RechargePayments
### built to work with the api documented at [https://developer.rechargepayments.com/](https://developer.rechargepayments.com/)
Please feel free to submit pull requests on github

## Quickstart
### Subscriptions

```cs
// initialize a SubscriptionService to start working with subscriptions.
var subscriptionService = new SubscriptionService("APIKEY");

// get all subscriptions with status ACTIVE and created after two months ago.
var subscriptions = await subscriptionService.GetAllSubscriptionsWithParamsAsync(status: "ACTIVE", createdAtMin: DateTime.Today.AddMonths(-2));

// iterate results and print subscription Id.
foreach (var subscription in subscriptions)
{
    Console.WriteLine(subscription.Id);
}
```

### Customers
```cs
// initialize a CustomerService to start working with customers.
var customerService = new CustomerService("APIKEY");

// get all customers created in the last two days.
var customers = await customerService.GetAllCustomersWithParamsAsync(createdAtMin: DateTime.Now.AddDays(-2));

// iterate results and print whether the customer has a valid payment method.
foreach (var customer in customers)
{
    Console.WriteLine(customer.HasValidPaymentMethod);
}
```