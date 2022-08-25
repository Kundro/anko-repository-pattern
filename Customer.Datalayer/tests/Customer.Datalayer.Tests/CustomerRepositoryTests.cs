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
            CustomerRepository repository = new CustomerRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var repository = new CustomerRepository();
            var customers = new Customers()
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
            var repository = Fixture.CreateCustomerRepository();
            Assert.NotNull(repository.Read(repository.GetID()));
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repository = Fixture.CreateCustomerRepository();
            var customers = Fixture.CreateMockCustomer();
            customers.FirstName = "newName";

            repository.Update(customers);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var repository = Fixture.CreateCustomerRepository();
            repository.Delete(1);
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
            var customerRepository = new CustomerRepository();
            customerRepository.Create(customers);
            return customers;
        }
        public CustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository();
        }
    }
}
