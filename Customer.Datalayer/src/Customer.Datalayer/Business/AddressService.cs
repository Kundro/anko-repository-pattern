using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Repositories;

namespace Customer.Datalayer.Business
{
    public class AddressService : IService<Addresses>
    {

        private readonly AddressRepository _addressRepository;

        public AddressService()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressService(AddressRepository addressRepository = null)
        {
            _addressRepository = addressRepository ?? new AddressRepository();
        }
        public void Create(Addresses entity)
        {
            _addressRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _addressRepository.Delete(id);
        }

        public List<Addresses> Get()
        {
            return _addressRepository.GetAll();
        }

        public Addresses Read(int id)
        {
            return _addressRepository.Read(id);
        }

        public void Update(Addresses entity)
        {
            _addressRepository.Update(entity);
        }
    }
}
