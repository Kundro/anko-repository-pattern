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
    public class AddressEditTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var mockAddressRepository = new Mock<IRepository<Addresses>>();
            var addressEdit = new AddressEdit(mockAddressRepository.Object);
            addressEdit.OnClickSave(this, EventArgs.Empty);
            mockAddressRepository.Verify(x => x.Create(It.IsAny<Addresses>()));
        }

    }
}
