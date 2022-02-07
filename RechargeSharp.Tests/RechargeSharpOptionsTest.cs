using RechargeSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RechargeSharp.Tests
{
    public class RechargeSharpOptionsTest
    {
        private readonly RechargeServiceOptions _sut;

        public RechargeSharpOptionsTest()
        {
            var guidStringList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                guidStringList.Add(Guid.NewGuid().ToString());
            }

            guidStringList.Add("");

            _sut = new RechargeServiceOptions()
            {
                ApiKeyArray = guidStringList,
                WebhookApiKey = guidStringList.First()
            };
        }

        [Fact]
        public void GetApiKeyFlakeTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var token = _sut.GetApiKey();
                Assert.True(!string.IsNullOrEmpty(token));
            }
        }
    }
}
