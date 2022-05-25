using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RechargeSharp.Entities.Charges;
using RechargeSharp.Services.Charges;
using RechargeSharp.Tests.Fixtures;
using Xunit;

namespace RechargeSharp.Tests.Services
{
    public class ChargeServiceTests
    {
        private readonly IChargeService _sut;
        private TestFixture _testFixture;

        public ChargeServiceTests()
        {
            _testFixture = new TestFixture();
            _sut = _testFixture.ServiceProvider.GetRequiredService<IChargeService>();
        }

        //[Fact]
        //public async Task ProcessChargeTest()
        //{
        //    var queuedCharges = await _sut.GetChargesAsync(status:ChargeStatus.Queued.ToString());

        //    Assert.NotNull(queuedCharges);
        //    Assert.NotEmpty(queuedCharges);

        //    var processedCharge = await _sut.ProcessChargeAsync(queuedCharges.First().Id);

        //    Assert.NotNull(processedCharge);

        //    Assert.Equal(ChargeStatus.Success, processedCharge.Status);
        //}
    }
}
