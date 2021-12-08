using RechargeSharp.Entities.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RechargeSharpTests
{
    public class RechargeSharpValidationTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RechargeSharpValidationTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ValidateUpdateCustomerRequestTest()
        {
            var updateCustomerRequest = new UpdateCustomerRequest()
            {
                ShopifyCustomerId = 0,
            };

            ValidateModel(updateCustomerRequest);
        }
        protected void ValidateModel(object objectToValidate)
        {
            var context = new ValidationContext(objectToValidate);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(objectToValidate, context, results, true))
            {
                throw new ArgumentException(string.Join(", ", results), nameof(objectToValidate));
            }
        }

    }
}
