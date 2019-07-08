# RechargeSharp, a C\# library for RechargePayments
### built to work with the api documented at [https://developer.rechargepayments.com/](https://developer.rechargepayments.com/)
Please feel free to submit pull requests on github
I am currently prioritizing getting the entities created, services will come afterwards.

## Missing items
A lot of minor objects such as update requests, are still missing.

Implementation of SubscriptionService has begun, the intention is to build them using HttpClient and Polly to handle transient errors and bucket overflow behind the scenes.