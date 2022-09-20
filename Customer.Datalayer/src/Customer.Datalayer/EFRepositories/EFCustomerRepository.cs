using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;

namespace Customer.Datalayer.EFRepositories
{
    public class EFCustomerRepository : IRepository<Customers>
    {
        public void Create(Customers entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
