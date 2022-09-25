using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.EFRepositories;
using FluentAssertions;

namespace Customer.Datalayer.IntegrationTests
{
    public class EFCustomerRepositoryTests
    {
        private EfCustomersRepositoryFixture Fixture => new();

        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            var repository = Fixture.CreateEfCustomerRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            var customerRepository = new EfCustomerRepository();
            // customerRepository.DeleteAll();
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
            var repository = Fixture.CreateEfCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            var customerId = customer.CustomerId;
            repository.Read(customerId);
            Assert.NotNull(repository.Read(customerId));
            Assert.Equal("nameCheck", repository.Read(customerId).FirstName);
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var repository = Fixture.CreateEfCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            customer.FirstName = "EF_test_name";

            var customerId = customer.CustomerId;
            repository.Update(customer);

            Assert.Equal("EF_test_name", repository.Read(customerId).FirstName);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var repository = Fixture.CreateEfCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            repository.Delete(customer.CustomerId);
        }

        [Fact]
        public void ShouldBeAbleToGetCustomerIds()
        {
            var repository = Fixture.CreateEfCustomerRepository();
            var customer = Fixture.CreateMockCustomer();
            var customerIds = repository.GetAllIDs();
            Assert.Contains(customer.CustomerId, customerIds);
        }

        [Fact] public void ShouldBeAbleToGetAllCustomers()
        {
            var repository = Fixture.CreateEfCustomerRepository();
            var customers = repository.GetAll();
            Assert.NotNull(customers);
        }
    }
}
public class EfCustomersRepositoryFixture
{
    public Customers CreateMockCustomer()
    {
        var customerRepository = this.CreateEfCustomerRepository();

        // customerRepository.DeleteAll();
        
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
    public EfCustomerRepository CreateEfCustomerRepository()
    {
        return new EfCustomerRepository();
    }
}
