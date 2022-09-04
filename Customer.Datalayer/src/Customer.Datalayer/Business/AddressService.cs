﻿using System;
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

        private readonly CustomerRepository _customerRepository;
        private readonly AddressRepository _addressRepository;

        public AddressService()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new AddressRepository();
        }

        public AddressService(CustomerRepository customerRepository, AddressRepository addressRepository = null)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository ?? new AddressRepository();
        }
        public void Create(Addresses entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}