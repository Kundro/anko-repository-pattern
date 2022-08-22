using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Repositories;
using FluentAssertions;
using Xunit;

namespace Customer.Datalayer.Tests
{
    public class CustomerRepositoryTests
    {
        public CustomersRepositoryFixture Fixture => new CustomersRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = new CustomerRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            Fixture.DeleteAll();
            var repository = new CustomerRepository();
            var customers = new Customers
            {
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "+11234567891123",
                Email = "mail@mail.ru",
                TotalPurchasesAmount = 1,
                Notes = "note1"
            };
            repository.Create(customers);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            Fixture.DeleteAll();
            var customer = Fixture.CreateMockCustomer();
            var createdCustomer = Fixture.CreateCustomerRepository();

            createdCustomer.Read(customer.CustomerID);
            customer.Should().NotBe(null);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            Fixture.DeleteAll();
            var customer = Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();
            customer.FirstName = "newName";

            repository.Update(customer);
            customer.FirstName.Should().Be("newName");
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            Fixture.DeleteAll();
            var customer = Fixture.CreateMockCustomer();
            var repository = Fixture.CreateCustomerRepository();

            repository.Delete(customer.CustomerID);
            var deletedCustomer = repository.Read(1);
            deletedCustomer.Should().Be(null);
        }
    }

    public class CustomersRepositoryFixture
    {
        public void DeleteAll()
        {
            var repository = new CustomerRepository();
            repository.DeleteAll();
        }
        public Customers CreateMockCustomer()
        {
            var customers = new Customers
            {
                FirstName = "name",
                LastName = "surname",
                PhoneNumber = "+11234567891123",
                Email = "mail@mail.ru",
                TotalPurchasesAmount = 1,
                Notes = "note1"
            };
            var countryRepository = new CustomerRepository();
            countryRepository.Create(customers);
            return customers;
        }
        public CustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }
    }
}
