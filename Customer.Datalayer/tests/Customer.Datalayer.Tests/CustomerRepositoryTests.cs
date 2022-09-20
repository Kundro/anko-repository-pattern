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
            var customer = Fixture.CreateMockCustomer();
            repository.Update(customer);
            Assert.NotNull(repository.Read(repository.GetID()));
            Assert.Equal("name", repository.Read(repository.GetID()).FirstName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repository = Fixture.CreateCustomerRepository();
            var customers = new Customers()
            {
                FirstName = "newName",
                LastName = "newSurname",
                PhoneNumber = "+11234567890123",
                Email = "newMail@mail.ru",
                Notes = "newNote",
                TotalPurchasesAmount = 1
            };
            repository.Update(customers);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var repository = Fixture.CreateCustomerRepository();
            var id = repository.GetID();
            repository.Delete(1);
        }
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
        var customerRepository = new CustomerRepository();
        var customers = new Customers
        {
            FirstName = "name",
            LastName = "surname",
            PhoneNumber = "+11234567891123",
            Email = "mail@mail.ru",
            Notes = "note1",
            TotalPurchasesAmount = 1
        };
        customerRepository.Create(customers);
        return customers;
    }
    public CustomerRepository CreateCustomerRepository()
    {
        return new CustomerRepository();
    }
}

