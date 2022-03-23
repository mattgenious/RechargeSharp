using Microsoft.Extensions.DependencyInjection;
using RechargeSharp.Services.Addresses;
using RechargeSharp.Services.Charges;
using RechargeSharp.Services.Checkouts;
using RechargeSharp.Services.Collections;
using RechargeSharp.Services.Customers;
using RechargeSharp.Services.Discounts;
using RechargeSharp.Services.Metafields;
using RechargeSharp.Services.Onetimes;
using RechargeSharp.Services.Orders;
using RechargeSharp.Services.PaymentMethods;
using RechargeSharp.Services.Products;
using RechargeSharp.Services.Shops;
using RechargeSharp.Services.Subscriptions;
using RechargeSharp.Services.Webhooks;
using RechargeSharp.Tests.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace RechargeSharp.Tests.Services
{
    public class DependencyInjectionTests
    {
        private TestFixture _testFixture;
        public DependencyInjectionTests()
        {
            _testFixture = new TestFixture();
        }

        [Fact]
        public void CanGetAllServicesByInterfaceAndImplementation()
        {
            _ = _testFixture.ServiceProvider.GetRequiredService<IAddressService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IChargeService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<ICheckoutService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<ICollectionService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<ICustomerService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IDiscountService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IMetafieldService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IOnetimeService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IOrderService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IProductService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IShopService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<ISubscriptionService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IWebhookService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<IPaymentMethodService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<AddressService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<ChargeService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<CheckoutService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<CollectionService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<CustomerService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<DiscountService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<MetafieldService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<OnetimeService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<OrderService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<ProductService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<ShopService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<SubscriptionService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<WebhookService>();
            _ = _testFixture.ServiceProvider.GetRequiredService<PaymentMethodService>();
        }
    }
}
