using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Repositories;

namespace Customer.Datalayer.Business
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressRepository _addressRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new AddressRepository();
        }
        public CustomerService(CustomerRepository customerRepository, AddressRepository addressRepository = null)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository ?? new AddressRepository();
        }
        public List<Customers> GetCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customers ReadCustomer(int id)
        {
            return _customerRepository.Read(id);
        }

        public void CreateCustomer(Customers entity)
        {
            _customerRepository.Create(entity);
        }

        public void UpdateCustomer(Customers entity)
        {
            _customerRepository.Update(entity);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }
    }
}
