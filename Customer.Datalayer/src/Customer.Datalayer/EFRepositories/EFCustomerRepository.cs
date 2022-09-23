using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Datalayer.EFRepositories
{
    public class EfCustomerRepository : IRepository<Customers>
    {
        private readonly CustomerDbContext _dbContext;

        public EfCustomerRepository()
        {
            _dbContext = new CustomerDbContext();
        }
        public void Create(Customers entity)
        {
            _dbContext
                .Customers
                .Add(entity);
            
            _dbContext.SaveChanges();
        }

        public Customers Read(int entityId)
        {
            return _dbContext
                .Customers
                .FirstOrDefault(x => x.CustomerId == entityId);
        }

        public void Update(Customers entity)
        {
            var oldCustomer = _dbContext
                .Customers
                .FirstOrDefault(x => x.CustomerId == entity.CustomerId);

            if (oldCustomer != null)
            {
                oldCustomer.CustomerId = entity.CustomerId;
                oldCustomer.FirstName = entity.FirstName;
                oldCustomer.LastName = entity.LastName;
                oldCustomer.Email = entity.Email;
                oldCustomer.PhoneNumber = entity.PhoneNumber;
                oldCustomer.Notes = entity.Notes;
                oldCustomer.TotalPurchasesAmount = entity.TotalPurchasesAmount;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int entityId)
        {
            Customers customer = Read(entityId);
            if (customer == null) throw new Exception("Not found customer with id = " + entityId);
            else _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public List<Customers> GetAll()
        {
            var customers = _dbContext
                .Customers
                .ToList();

            return customers;
        }

        public void DeleteAll()
        {
            var customers = _dbContext
                .Customers
                .ToList();

            // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Addresses");
            // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Customer");

            foreach (var customer in customers)
            {
                _dbContext.Customers.Remove(customer);
            }

            _dbContext.SaveChanges();
        }

        public List<int> GetAllIDs()
        {
            var customers = _dbContext
                .Customers
                .ToList();
            List<int> ids = new List<int>();

            foreach (var customer in customers)
            {
                ids.Add(customer.CustomerId);
            }

            return ids;
        }
    }
}
