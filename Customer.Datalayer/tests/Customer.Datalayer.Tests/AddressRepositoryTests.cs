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

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var repository = new AddressRepository();
            var address = new Addresses()
            {
                CustomerID = repository.GetCustomerID(),
                AddressLine = "line1",
                AddressLine2 = "line2",
                AddressType = "Shipping",
                City = "Chicago",
                PostalCode = "60666",
                StateName = "Illinois",
                Country = "USA"
            };
            repository.Create(address);
        }
        
        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            var repository = Fixture.CreateAddressRepository();
            Assert.NotNull(repository.Read(repository.GetID()));
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var repository = Fixture.CreateAddressRepository();
            var addresses = new Addresses()
            {
                AddressID = repository.GetID(),
                CustomerID = repository.GetCustomerID(),
                AddressLine = "newLine1",
                AddressLine2 = "newLine2",
                AddressType = "Shipping",
                City = "Chicago",
                PostalCode = "60666",
                StateName = "Illinois",
                Country = "USA"
            };
            repository.Update(addresses);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            Fixture.DeleteAll();
            var repository = Fixture.CreateAddressRepository();

            repository.Delete(1);
        }
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
            var addresses = new Addresses()
            {
                CustomerID = 1,
                AddressLine2 = "line2",
                AddressType = "Shipping",
                City = "Chicago",
                AddressLine = "line1",
                PostalCode = "60666",
                StateName = "Illinois",
                Country = "USA"
            };
            var addressRepository = new AddressRepository();
            addressRepository.Create(addresses);
            return addresses;
        }
        public AddressRepository CreateAddressRepository()
        {
            return new AddressRepository();
        }
    }
}
