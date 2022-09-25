using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.EFRepositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Customer.Datalayer.Tests
{
    public class CustomerDBContextTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerDBContext()
        {
            var context = new CustomerDbContext();
            Assert.NotNull(context);
            Assert.NotNull(context.Customers);
            Assert.NotNull(context.Addresses);
        }
    }
}
