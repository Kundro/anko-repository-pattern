using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.EFRepositories;
using Xunit;

namespace Customer.Datalayer.Tests
{
    public class CustomerDBContextTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerDBContext()
        {
            var context = new CustomerDBContext();
            Assert.NotNull(context);
            Assert.NotNull(context.Customers);
        }
    }
}
