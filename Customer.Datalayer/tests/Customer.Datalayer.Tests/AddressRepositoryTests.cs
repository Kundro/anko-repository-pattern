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
            Fixture.DeleteAll();
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
            Fixture.DeleteAll();
            var repository = Fixture.CreateAddressRepository();
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var repository = Fixture.CreateAddressRepository();
            Fixture.DeleteAll();
            var addresses = Fixture.CreateMockAddress();
            addresses.AddressID = repository.GetID();
            addresses.CustomerID = repository.GetCustomerID();
            addresses.AddressLine = "newLine1";
            addresses.AddressLine2 = "newLine2";
            addresses.AddressType = "Shipping";
            addresses.City = "Chicago";
            addresses.PostalCode = "60666";
            addresses.StateName = "Illinois";
            addresses.Country = "USA";
            repository.Update(addresses);
            repository.Read(repository.GetID()).AddressLine.Should().Be("newLine1");
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
            var addressRepository = new AddressRepository();
            var addresses = new Addresses()
            {
                CustomerID = addressRepository.GetCustomerID(),
                AddressLine2 = "line2",
                AddressType = "Shipping",
                City = "Chicago",
                AddressLine = "line1",
                PostalCode = "60666",
                StateName = "Illinois",
                Country = "USA"
            };
            addressRepository.Create(addresses);
            return addresses;
        }
        public AddressRepository CreateAddressRepository()
        {
            return new AddressRepository();
        }
    }
}
