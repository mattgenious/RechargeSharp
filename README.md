# RechargeSharp, a C\# library for RechargePayments
### Get it here [https://www.nuget.org/packages/RechargeSharp/](https://www.nuget.org/packages/RechargeSharp/)
### Built to work with the api documented at [https://developer.rechargepayments.com/](https://developer.rechargepayments.com/)
Please feel free to submit issues and pull requests on github

## Supported API versions

* 2021-01: The namespace for this is just `RechargeSharp`.
* 2021-11: The namespace for this is `RechargeSharp.v2021-11`.

You can use services from both namespaces simultaneously without issues.

## Recharge API version 2021-11

### Quickstart

#### Dependency injection

Use the `AddRechargeSharp2021_11()` to add the services to the service collection, like so:

```cs
var hostBuilder = Host.CreateDefaultBuilder()
    .ConfigureServices(collection =>
    {
        var apiKey = "<insert-your-API-key-here>";
        collection.AddRechargeSharp2021_11(options => options.ApiKey = apiKey);
    });
```

After this, the DI container will be able to resolve services for implemented endpoints, such as the `IAddressService`, `ICustomerService`, and so on.

Here is a tiny example of a class that uses the `ICustomerService`.

```cs
private readonly ICustomerService _customerService;

public YourServiceThatUsesRechargeSharp(ICustomerService customerService)
{
    _customerService = customerService;
}

protected async Task PrintCustomerEmail()
{
    GetCustomerTypes.Response? response = await _customerService.GetCustomerAsync(1234);
    Console.WriteLine($"Customer email: {response!.Customer!.Email}");    
}
```


## Recharge API version 2021-01

### Quickstart

#### Dependency injection

If you set up your appsettings.json like this:
```json
{  
    "RechargeConfiguration": {
        "ApiKey": [
            "1",
            "2",
            "3",
            "4"
        ]
  }
}

```

Add RechargeSharp to dependency injection.
After that the services will be constructor injected.



```cs
// this example shows how you can get a list of api keys from configuration that the services will swap between automatically when encountering throttling.
services.AddRechargeSharp(opts =>
                {
                    opts.ApiKeyArray = _configuration.GetSection("RechargeConfiguration:ApiKey").GetChildren().Select(x => x.Value).ToArray();
                    opts.WebhookApiKey = _configuration["RechargeConfiguration:ApiKey:0"];
                })
```

```cs
// if you only have 1 api key you wish to work with you can do the following.
services.AddRechargeSharp(opts => 
                {
                    opts.ApiKeyArray = new[] { "apikey" });
                    opts.WebhookApiKey = "apikey";
                }
```


#### Subscriptions


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

#### Customers
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