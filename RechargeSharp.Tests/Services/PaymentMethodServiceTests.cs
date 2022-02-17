using Microsoft.Extensions.DependencyInjection;
using RechargeSharp.Services.PaymentMethods;
using RechargeSharp.Tests.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace RechargeSharp.Tests
{
    public class PaymentMethodServiceTests
    {
        private readonly PaymentMethodService _sut;
        private TestFixture _testFixture;

        public PaymentMethodServiceTests()
        {
            _testFixture = new TestFixture();
            _sut = _testFixture.ServiceProvider.GetRequiredService<PaymentMethodService>();
        }

        [Fact]
        public async Task GetPaymentMethodsTest()
        {
            var paymentMethods = await _sut.GetPaymentMethodsAsync();
        }
    }
}
