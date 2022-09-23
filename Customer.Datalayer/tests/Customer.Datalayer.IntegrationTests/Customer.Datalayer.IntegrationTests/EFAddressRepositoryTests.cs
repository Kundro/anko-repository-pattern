using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Customer.Datalayer.IntegrationTests
{
    public class EFAddressRepositoryTests
    {
        public EFAddressRepositoryFixture Fixture => new();

        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new EfAddressRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var repository = new EfAddressRepository();
            const int customerId = 6;
            var address = new Addresses(customerId)
            {
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
            var repository = Fixture.EFCreateAddressRepository();
            var address = Fixture.CreateMockAddress();
            var addressId = address.AddressId;

            var newAddress = repository.Read(addressId);
            Assert.NotNull(newAddress);
            Assert.Equal(addressId, newAddress.AddressId);
            Assert.Equal("line1", repository.Read(addressId).AddressLine);
        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var repository = Fixture.EFCreateAddressRepository();
            var addresses = Fixture.CreateMockAddress();
            addresses.AddressLine = "newLine1";
            addresses.AddressLine2 = "newLine2";

            var addressId = addresses.AddressId;
            repository.Update(addresses);

            Assert.Equal("newLine1", repository.Read(addressId).AddressLine);
            Assert.Equal("newLine2", repository.Read(addressId).AddressLine2);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var repository = Fixture.EFCreateAddressRepository();
            var address = Fixture.CreateMockAddress();
            repository.Delete(address.AddressId);
        }

        [Fact]
        public void ShouldBeAbleToGetAddressIds()
        {
            var repository = Fixture.EFCreateAddressRepository();
            var address = Fixture.CreateMockAddress();
            var addressAllIDs = repository.GetAllIDs();
            Assert.Contains(address.AddressId, addressAllIDs);
        }

        [Fact]
        public void ShouldBeAbleToDeleteAllAddresses()
        {
            var repository = Fixture.EFCreateAddressRepository();
            repository.DeleteAll();

            Assert.Empty(repository.GetAllIDs());
        }
        [Fact]
        public void ShouldBeAbleToGetAllAddresses()
        {
            var repository = Fixture.EFCreateAddressRepository();
            var customers = repository.GetAll();
            Assert.NotEmpty(customers);
        }
    }

    public class EFAddressRepositoryFixture
    {
        public Addresses CreateMockAddress()
        {

            var addressRepository = this.EFCreateAddressRepository();
            const int id = 6;
            var addresses = new Addresses(id)
            {
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

        public EfAddressRepository EFCreateAddressRepository()
        {
            return new EfAddressRepository();
        }
    }
}
