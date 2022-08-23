using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Repositories;
using FluentAssertions;
using Xunit;

namespace Customer.Datalayer.Tests
{
    public class AddressRepositoryTests
    {
        public AddressRepositoryFixture Fixture => new AddressRepositoryFixture();

        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new AddressRepository();
            repository.Should().NotBeNull();
        }

        public class AddressRepositoryFixture
        {
            public void DeleteAll()
            {
                var repository = new AddressRepository();
                repository.DeleteAll();
            }
            public Addresses CreateMockAddress()
            {
                var customers = new Addresses
                {
                    CustomerID = 1,
                    AddressLine = "line1",
                    AddressLine2 = "line2",
                    AddressType = AddressType.Billing,
                    City = "Chicago",
                    PostalCode = "60666",
                    State = "Illinois",
                    Country = "USA"
                };
                var addressRepository = new AddressRepository();
                addressRepository.Create(customers);
                return customers;
            }
            public AddressRepository CreateAddressRepository()
            {
                return new AddressRepository();
            }
        }
    }
}
