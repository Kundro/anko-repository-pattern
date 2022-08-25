using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Customer.Datalayer.WebForm.Tests
{
    public class CustomersListTests
    {
        [Fact]
        public void ShouldBeAbleToLoadCustomersFromDatabase()
        {
            var customerRepositoryMock = new Mock<IRepository<Customers>>();
            customerRepositoryMock.Setup(x => x.GetAll()).Returns(() => new List<Customers>()
            {
                new Customers(),
                new Customers(),
                new Customers()
            });
            var customersList = new CustomersList(customerRepositoryMock.Object);

            customersList.LoadCustomersFromDatabase();
            Assert.Equal(3, customersList.Customers.Count);
        }
    }
}
