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
            _dbContext
                .Customers
                .Add(entity);
            
            _dbContext.SaveChanges();
        }

        public Customers Read(int entityID)
        {
            return _dbContext
                .Customers
                .FirstOrDefault(x => x.CustomerID == entityID);
        }

        public void Update(Customers entity)
        {
            var oldCustomer = _dbContext
                .Customers
                .FirstOrDefault(x => x.CustomerID == entity.CustomerID);

            if (oldCustomer != null)
            {
                oldCustomer.CustomerID = entity.CustomerID;
                oldCustomer.FirstName = entity.FirstName;
                oldCustomer.LastName = entity.LastName;
                oldCustomer.Email = entity.Email;
                oldCustomer.PhoneNumber = entity.PhoneNumber;
                oldCustomer.Notes = entity.Notes;
                oldCustomer.TotalPurchasesAmount = entity.TotalPurchasesAmount;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int entityID)
        {
            Customers customer = Read(entityID);
            if (customer == null) throw new Exception("Not found customer with id = " + entityID);
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

        public int GetID()
        {
            throw new NotImplementedException();
        }

        public List<int> GetAllIDs()
        {
            var customers = _dbContext
                .Customers
                .ToList();
            List<int> ids = new List<int>();

            foreach (var customer in customers)
            {
                ids.Add(customer.CustomerID);
            }

            return ids;
        }
    }
}
