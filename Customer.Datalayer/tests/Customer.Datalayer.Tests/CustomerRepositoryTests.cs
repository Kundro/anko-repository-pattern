using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Repositories;
using System.Collections.Generic;
using Xunit;

namespace Customer.Datalayer.Tests
{
    public class CustomerRepositoryTests
    {
        [Fact]
            public void ShouldBeAbleToCreateCustomerRepository()
            {
                var repository = new CustomerRepository();
                Assert.NotNull(repository);
            }
        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var repository = new CustomerRepository();
            var customers = new Customers
            {
                CustomerID = 1,
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "+11234567891123",
                Email = "mail@mail.ru",
                TotalPurchasesAmount = 1,
                Notes = new List<string>() { "note1" }
            };
            repository.Create(customers); 
        }
    }
}
