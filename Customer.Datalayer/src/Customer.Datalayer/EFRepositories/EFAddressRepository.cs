using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Datalayer.EFRepositories
{
    public class EfAddressRepository : IRepository<Addresses>

    {
        public void Create(Addresses entity)
        {
            using (var _dbContext = new CustomerDbContext())
            {
                _dbContext.Addresses.Add(entity);

                _dbContext.SaveChanges();
            }
        }

        public Addresses Read(int entityId)
        {
            using (var _dbContext = new CustomerDbContext())
            {
                return _dbContext.Addresses.FirstOrDefault(x => x.AddressId == entityId);
            }
        }

        public void Update(Addresses entity)
        {
            using (var _dbContext = new CustomerDbContext())
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
        }

        public void Delete(int entityId)
        {
            using (var _dbContext = new CustomerDbContext())
            {
                var address = _dbContext.Addresses.FirstOrDefault(x => x.AddressId == entityId);
                _dbContext.Addresses.Remove(address);

                _dbContext.SaveChanges();
            }
        }

        public List<Addresses> GetAll()
        {
            using (var _dbContext = new CustomerDbContext())
            {
                var addresses = _dbContext
                    .Addresses
                    .ToList();

                return addresses;
            }
        }

        public void DeleteAll()
        {
            using (var _dbContext = new CustomerDbContext())
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
        }

        public List<int> GetAllIDs()
        {
            using (var _dbContext = new CustomerDbContext())
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
}
