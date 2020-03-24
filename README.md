# RechargeSharp, a C\# library for RechargePayments
### Get it here [https://www.nuget.org/packages/RechargeSharp/](https://www.nuget.org/packages/RechargeSharp/)
### Built to work with the api documented at [https://developer.rechargepayments.com/](https://developer.rechargepayments.com/)
Please feel free to submit issues and pull requests on github

## Quickstart

### Dependency injection
Add RechargeSharp to dependency injection.
After that the services will be constructor injected.

```cs
// this example shows how you can get a list of api keys from configuration that the services will swap between automatically when encountering throttling.
services.AddRechargeSharp(opts =>
                {
                    opts.ApiKeyArray = _configuration.GetSection("RechargeConfiguration:ApiKey").GetChildren().Select(x => x.Value).ToArray();
                })
```
```cs
// if you only have 1 api key you wish to work with you can do the following.
services.AddRechargeSharp(opts => opts.ApiKeyArray = new[] { "apikey" })
```


### Subscriptions


```cs
public class SubscriptionTestClass {
    private readonly SubscriptionService _subscriptionService;

    // constructor inject the subscription service to start working with subscriptions.
    public SubscriptionTestClass(SubscriptionService subscriptionService){
        _subscriptionService = subscriptionService;
    }

    public async Task DoStuff(){
        // get all subscriptions with status ACTIVE and created after two months ago.
        var subscriptions = await subscriptionService.GetAllSubscriptionsWithParamsAsync(status: "ACTIVE", createdAtMin: DateTime.Today.AddMonths(-2));

        // iterate results and print subscription Id.
        foreach (var subscription in subscriptions)
        {
            Console.WriteLine(subscription.Id);
        }
    }
}
```

### Customers
```cs
public class CustomerTestClass {
    private readonly CustomerService _customerService;

    // constructor inject the customer service to start working with customers.
    public CustomerTestClass(CustomerService customerService){
        _customerService = customerService;
    }

    public async Task DoStuff(){
        // get all customers created in the last two days.
        var customers = await _customerService.GetAllCustomersWithParamsAsync(createdAtMin: DateTime.Now.AddDays(-2));

        // iterate results and print whether the customer has a valid payment method.
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.HasValidPaymentMethod);
        }
    }
}
```