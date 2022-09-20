using Customer.Datalayer.Repositories;
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
        public void Create(Addresses entity)
        {
            throw new NotImplementedException();
        }

        public Addresses Read(int entityID)
        {
            throw new NotImplementedException();
        }

        public void Update(Addresses entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityID)
        {
            throw new NotImplementedException();
        }

        public List<Addresses> GetAll()
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
