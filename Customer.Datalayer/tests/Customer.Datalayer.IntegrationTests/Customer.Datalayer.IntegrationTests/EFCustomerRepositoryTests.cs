using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.EFRepositories;
using Customer.Datalayer.Repositories;
using FluentAssertions;

namespace Customer.Datalayer.IntegrationTests
{
    public class EFCustomerRepositoryTests
    {
        public EFCustomersRepositoryFixture Fixture => new EFCustomersRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = Fixture.CreateEFCustomerRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new EFCustomerRepository();
            //customerRepository.DeleteAll();
            var customers = new Customers()
            {
                FirstName = "hello",
                LastName = "surname",
                PhoneNumber = "+11234567891123",
                Email = "mail@mail.ru",
                TotalPurchasesAmount = 1,
                Notes = "note1"
            };
            customerRepository.Create(customers);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            var repository = Fixture.CreateEFCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            repository.Update(customer);
            Assert.NotNull(repository.Read(repository.GetID()));
            Assert.Equal("name", repository.Read(repository.GetID()).FirstName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repository = Fixture.CreateEFCustomerRepository();
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
            var repository = Fixture.CreateEFCustomerRepository();
            repository.Delete(1);
        }
    }
}
public class EFCustomersRepositoryFixture
{
    public Customers CreateMockCustomer()
    {
        var customerRepository = new EFCustomerRepository();
        customerRepository.DeleteAll();
        var customer = new Customers
        {
            FirstName = "nameCheck",
            LastName = "surname",
            PhoneNumber = "+11234567891123",
            Email = "mail@mail.ru",
            Notes = "note1",
            TotalPurchasesAmount = 1
        };
        customerRepository.Create(customer);
        return customer;
    }
    public EFCustomerRepository CreateEFCustomerRepository()
    {
        return new EFCustomerRepository();
    }
}

