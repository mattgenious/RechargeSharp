using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Microsoft.Extensions.DependencyInjection;
using RechargeSharp.Entities.Subscriptions;
using RechargeSharp.Services.Subscriptions;
using RechargeSharp.Tests.Fixtures;

namespace RechargeSharp.Tests.Benchmarks
{
    [SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 0, iterationCount: 1, id: "FastAndImprecise")]
    public class SubscriptionServiceBenchmarks
    {
        private readonly SubscriptionService _sut;
        private TestFixture _testFixture;
        private readonly Consumer consumer = new Consumer();
        public SubscriptionServiceBenchmarks()
        {
            _testFixture = new TestFixture();
            _sut = _testFixture.ServiceProvider.GetRequiredService<SubscriptionService>();
        }

        [Benchmark]
        public void GetAllSubscriptionsWithParamsParallelAsync() => _sut.GetAllSubscriptionsWithParamsAsync().GetAwaiter().GetResult().Consume(consumer);


        [Benchmark]
        public void GetAllSubscriptionsWithParamsSynchronousAsync() => GetAllSubscriptionsWithParamsSynchronousAsyncRecursive(new List<Subscription>(), 1).GetAwaiter().GetResult().Consume(consumer);


        private async Task<List<Subscription>> GetAllSubscriptionsWithParamsSynchronousAsyncRecursive(List<Subscription> accumulator, int page)
        {
            var lastGet = await _sut.GetSubscriptionsAsync(page, 250);
            if (lastGet != null && lastGet.Any())
            {
                accumulator.AddRange(lastGet);
                page++;
                return await GetAllSubscriptionsWithParamsSynchronousAsyncRecursive(accumulator, page);
            }
            else
            {
                return accumulator;
            }
        }
    }
}
