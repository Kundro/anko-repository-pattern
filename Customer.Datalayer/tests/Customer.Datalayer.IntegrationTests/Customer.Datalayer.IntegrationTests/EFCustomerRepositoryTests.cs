using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.EFRepositories;
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
            customerRepository.DeleteAll();
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
            var customerId = customer.CustomerID;
            repository.Read(customerId);
            Assert.NotNull(repository.Read(customerId));
            Assert.Equal("nameCheck", repository.Read(customerId).FirstName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repository = Fixture.CreateEFCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            customer.FirstName = "EF_test_name";

            var customerId = customer.CustomerID;
            repository.Update(customer);

            Assert.Equal("EF_test_name", repository.Read(customerId).FirstName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var repository = Fixture.CreateEFCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            repository.Delete(customer.CustomerID);
        }

        [Fact]
        public void ShouldBeAbleToGetCustomerIds()
        {
            var repository = Fixture.CreateEFCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            var customerIds = repository.GetAllIDs();
            Assert.Contains(customer.CustomerID, customerIds);
        }

        [Fact] public void ShouldBeAbleToGetAllCustomers()
        {
            var repository = Fixture.CreateEFCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            var newCustomer = repository.Read(customer.CustomerID);
            var customers = repository.GetAll();
            Assert.Contains(newCustomer, customers);
        }
    }
}
public class EFCustomersRepositoryFixture
{
    public Customers CreateMockCustomer()
    {
        var customerRepository = this.CreateEFCustomerRepository();

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

