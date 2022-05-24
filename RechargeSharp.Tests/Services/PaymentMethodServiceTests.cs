using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RechargeSharp.Services.PaymentMethods;
using RechargeSharp.Tests.Fixtures;
using Xunit;

namespace RechargeSharp.Tests.Services
{
    public class PaymentMethodServiceTests
    {
        private readonly IPaymentMethodService _sut;
        private TestFixture _testFixture;

        public PaymentMethodServiceTests()
        {
            _testFixture = new TestFixture();
            _sut = _testFixture.ServiceProvider.GetRequiredService<IPaymentMethodService>();
        }

        [Fact]
        public async Task GetPaymentMethodsTest()
        {
            var paymentMethods = await _sut.GetPaymentMethodsAsync();
        }

        [Fact]
        public async Task GetPaymentMethodTest()
        {
            var paymentMethods = await _sut.GetPaymentMethodsAsync();

            var paymentMethod = await _sut.GetPaymentMethodAsync(paymentMethods.First().Id);
        }

        [Fact]
        public async Task CreatePaymentMethodTest()
        {
            var stripePaymentMethodService = _testFixture.ServiceProvider.GetRequiredService<Stripe.PaymentMethodService>();
            var stripeCustomerService = _testFixture.ServiceProvider.GetRequiredService<Stripe.CustomerService>();

            var paymentMethods = await _sut.GetPaymentMethodsAsync(customerId: 44605345);

            Assert.NotNull(paymentMethods);

            var firstPaymentMethod = paymentMethods.First();

            Assert.NotNull(firstPaymentMethod);

            var stripePaymentMethod = await stripePaymentMethodService.CreateAsync(new Stripe.PaymentMethodCreateOptions()
            {
                Type = "card",
                Card = new Stripe.PaymentMethodCardOptions()
                {
                    Token = "tok_visa"
                }
            });

            await stripePaymentMethodService.AttachAsync(stripePaymentMethod.Id, new Stripe.PaymentMethodAttachOptions()
            {
                Customer = firstPaymentMethod.ProcessorCustomerToken
            });

            await stripeCustomerService.UpdateAsync(firstPaymentMethod.ProcessorCustomerToken, new Stripe.CustomerUpdateOptions()
            {
                InvoiceSettings = new Stripe.CustomerInvoiceSettingsOptions()
                {
                    DefaultPaymentMethod = stripePaymentMethod.Id
                }
            });

            var paymentMethod = await _sut.CreatePaymentMethodAsync(new Entities.PaymentMethods.CreatePaymentMethodRequest()
            {
                BillingAddress = new Entities.PaymentMethods.PaymentMethodBillingAddress()
                {
                    Address1 = firstPaymentMethod.BillingAddress.Address1,
                    Address2 = firstPaymentMethod.BillingAddress.Address2,
                    City = firstPaymentMethod.BillingAddress.City,
                    Company = firstPaymentMethod.BillingAddress.Company,
                    Country = firstPaymentMethod.BillingAddress.Country,
                    CountryCode = null,
                    FirstName = firstPaymentMethod.BillingAddress.FirstName,
                    LastName = firstPaymentMethod.BillingAddress.LastName,
                    Phone = firstPaymentMethod.BillingAddress.Phone,
                    Province= firstPaymentMethod.BillingAddress.Province,
                    Zip = firstPaymentMethod.BillingAddress.Zip

                },
                CustomerId = firstPaymentMethod.CustomerId,
                Default = true,
                PaymentType = Entities.PaymentMethods.PaymentType.CreditCard,
                ProcessorCustomerToken = firstPaymentMethod.ProcessorCustomerToken,
                ProcessorName = Entities.PaymentMethods.ProcessorName.Stripe,
                ProcessorPaymentMethodToken = stripePaymentMethod.Id
            });

            Assert.NotNull(paymentMethod);
        }
    }
}
