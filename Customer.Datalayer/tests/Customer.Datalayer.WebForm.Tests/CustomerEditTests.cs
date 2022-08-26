using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.Datalayer.WebForm.Tests
{
    public class CustomerEditTests
    {
        [Fact]
        public void ShouldCreateCustomer()
        {
            var customerMockRepositpry = new Mock<IRepository<Customers>>();
            var customerEdit = new CustomerEdit(customerMockRepositpry.Object);
            customerEdit.OnClickSave(this, EventArgs.Empty);

            customerMockRepositpry.Verify(x => x.Create(It.IsAny<Customers>()));
        }
    }
}
