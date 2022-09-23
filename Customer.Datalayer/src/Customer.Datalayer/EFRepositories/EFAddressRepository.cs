using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;

namespace Customer.Datalayer.EFRepositories
{
    public class EfAddressRepository : IRepository<Addresses>

    {
        private readonly CustomerDbContext _dbContext;

        public EfAddressRepository()
        {
            _dbContext = new CustomerDbContext();
        }
        public void Create(Addresses entity)
        {
            _dbContext.Addresses.Add(entity);

            _dbContext.SaveChanges();
        }

        public Addresses Read(int entityId)
        {
            return _dbContext.Addresses.FirstOrDefault(x => x.AddressId == entityId);
        }

        public void Update(Addresses entity)
        {
            var oldAddress = _dbContext
                .Addresses
                .FirstOrDefault(x => x.AddressId == entity.AddressId);

            if (oldAddress != null)
            {
                oldAddress.CustomerId = entity.CustomerId;
                oldAddress.AddressLine = entity.AddressLine;
                oldAddress.AddressLine2 = entity.AddressLine2;
                oldAddress.AddressType = entity.AddressType;
                oldAddress.City = entity.City;
                oldAddress.PostalCode = entity.PostalCode;
                oldAddress.StateName = entity.StateName;
                oldAddress.Country = entity.Country;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int entityId)
        {
            var address = _dbContext.Addresses.FirstOrDefault(x => x.AddressId == entityId);
            _dbContext.Addresses.Remove(address);

            _dbContext.SaveChanges();
        }

        public List<Addresses> GetAll()
        {
            var addresses = _dbContext
                .Addresses
                .ToList();

            return addresses;
        }

        public void DeleteAll()
        {
            var addresses = _dbContext
                .Addresses
                .ToList();

            // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Addresses");
            // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Customer");

            foreach (var address in addresses)
            {
                _dbContext.Addresses.Remove(address);
            }

            _dbContext.SaveChanges();
        }

        public List<int> GetAllIDs()
        {
            var addresses = _dbContext
                .Addresses
                .ToList();
            List<int> ids = new();

            foreach (var address in addresses)
            {
                ids.Add(address.AddressId);
            }

            return ids;
        }
    }
}
