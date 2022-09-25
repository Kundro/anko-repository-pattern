using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Datalayer.EFRepositories
{
    public class EfCustomerRepository : IRepository<Customers>
    {
        public void Create(Customers entity)
        {
            using (var db = new CustomerDbContext())
            {
                db
                    .Customers
                    .Add(entity);
                db.SaveChanges();

            }
        }

        public Customers Read(int entityId)
        {
            using (var db = new CustomerDbContext())
            {
                return db
                    .Customers
                    .FirstOrDefault(x => x.CustomerId == entityId);
            }
        }

        public void Update(Customers entity)
        {
            using (var db = new CustomerDbContext())
            {
                var oldCustomer = db
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

                db.SaveChanges();
            }
        }

        public void Delete(int entityId)
        {
            using (var db = new CustomerDbContext())
            {
                Customers customer = Read(entityId);
                if (customer == null) throw new("Not found customer with id = " + entityId);
                else db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public List<Customers> GetAll()
        {
            using (var db = new CustomerDbContext())
            {
                var customers = db
                    .Customers
                    .ToList();

                return customers;
            }
        }

        public void DeleteAll()
        {
            using (var db = new CustomerDbContext())
            {
                var customers = db
                    .Customers
                    .ToList();

                // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Addresses");
                // _dbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.Customer");

                foreach (var customer in customers)
                {
                    db.Customers.Remove(customer);
                }

                db.SaveChanges();
            }
        }

        public List<int> GetAllIDs()
        {
            using (var db = new CustomerDbContext())
            {
                var customers = db
                    .Customers
                    .ToList();
                List<int> ids = new();

                foreach (var customer in customers)
                {
                    ids.Add(customer.CustomerId);
                }

                return ids;
            }
        }
    }
}
