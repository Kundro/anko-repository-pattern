using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customer.Datalayer.WebForm
{
    public partial class AddressesList : System.Web.UI.Page
    {
        private readonly IRepository<Addresses> _addressRepository;
        public List<Addresses> Addresses { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAddressesFromDatabase();
        }
        public AddressesList()
        {
            _addressRepository = new AddressRepository();
        }
        public AddressesList(IRepository<Addresses> addressesRepository)
        {
            _addressRepository = addressesRepository;
        }
        public void LoadAddressesFromDatabase()
        {
            Addresses = _addressRepository.GetAll();
        }

    }
}