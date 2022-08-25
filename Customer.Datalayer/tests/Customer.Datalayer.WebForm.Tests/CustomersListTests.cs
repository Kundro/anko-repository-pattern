using System;
using Xunit;

namespace Customer.Datalayer.WebForm.Tests
{
    public class CustomersListTests
    {
        [Fact]
        public void ShouldBeAbleToLoadCustomersFromDatabase()
        {
            var customersList = new CustomersList();
            customersList.LoadCustomersFromDatabase();
        }
    }
}
