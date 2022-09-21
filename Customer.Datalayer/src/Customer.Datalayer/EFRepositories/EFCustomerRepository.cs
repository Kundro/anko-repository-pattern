using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Datalayer.EFRepositories
{
    public class EFCustomerRepository : IRepository<Customers>
    {
        private readonly CustomerDBContext _dbContext;

        public EFCustomerRepository()
        {
            _dbContext = new CustomerDBContext();
        }
        public void Create(Customers entity)
        {
            _dbContext.Customers.Add(entity);
            _dbContext.SaveChanges();
        }

        public Customers Read(int entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityID)
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            var customers = _dbContext.Customers.ToList();

            // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Addresses");
            // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Customer");

            foreach (var customer in customers)
            {
                _dbContext.Customers.Remove(customer);
            }

            _dbContext.SaveChanges();
        }

        public int GetID()
        {
            throw new NotImplementedException();
        }

        public List<int> GetAllIDs()
        {
            throw new NotImplementedException();
        }
    }
}
