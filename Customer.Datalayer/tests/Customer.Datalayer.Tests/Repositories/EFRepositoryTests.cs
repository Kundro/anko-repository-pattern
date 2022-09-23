using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.EFRepositories;
using Customer.Datalayer.Interfaces;
using Xunit;

namespace Customer.Datalayer.Tests.Repositories
{
    public class EFRepositoryTests
    {
        [Fact]
        public void ShouldCreateEFCustomerRepository()
        {
            var efRepository = new EfCustomerRepository();
            Assert.NotNull(efRepository);
            Assert.IsAssignableFrom<IRepository<Customers>>(efRepository); // check for types similarity
        }

        [Fact]
        public void ShouldBeAbleToCreateEFAddressRepository()
        {
            var efRepository = new EfAddressRepository();
            Assert.NotNull(efRepository);
            Assert.IsAssignableFrom<IRepository<Addresses>>(efRepository); // check for types similarity
        }
    }
}
