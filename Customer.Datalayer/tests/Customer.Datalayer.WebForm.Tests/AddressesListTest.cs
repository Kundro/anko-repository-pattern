using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.Datalayer.WebForm.Tests
{
    public class AddressesListTest
    {
        [Fact]
        public void ShouldBeAbleToLoadAddressesFromDatabase()
        {
            var mockAddressRepository = new Mock<IRepository<Addresses>>();
            mockAddressRepository.Setup(x => x.GetAll()).Returns(() => new List<Addresses>()
            {
                new Addresses(),
                new Addresses(),
                new Addresses()
            });
            var addressesList = new AddressesList(mockAddressRepository.Object);
            addressesList.LoadAddressesFromDatabase();
            Assert.Equal(3, addressesList.Addresses.Count);
        }
    }
}
