using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;

namespace Customer.Datalayer.EFRepositories
{
    public class EFAddressRepository : IRepository<Addresses>

    {
        private readonly CustomerDBContext _dbContext;

        public EFAddressRepository()
        {
            _dbContext = new CustomerDBContext();
        }
        public void Create(Addresses entity)
        {
            _dbContext.Addresses.Add(entity);

            _dbContext.SaveChanges();
        }

        public Addresses Read(int entityID)
        {
            return _dbContext.Addresses.FirstOrDefault(x => x.AddressID == entityID);
        }

        public void Update(Addresses entity)
        {
            var oldAddress = _dbContext
                .Addresses
                .FirstOrDefault(x => x.AddressID == entity.AddressID);

            if (oldAddress != null)
            {
                oldAddress.CustomerID = entity.CustomerID;
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

        public void Delete(int entityID)
        {
            var address = _dbContext.Addresses.FirstOrDefault(x => x.AddressID == entityID);
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
            List<int> ids = new List<int>();

            foreach (var address in addresses)
            {
                ids.Add(address.AddressID);
            }

            return ids;
        }
    }
}
