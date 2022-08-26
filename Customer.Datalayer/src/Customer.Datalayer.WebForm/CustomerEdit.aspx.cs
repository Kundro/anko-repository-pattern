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
    public partial class CustomerEdit : System.Web.UI.Page
    {
        private IRepository<Customers> _customerRepository;
        public CustomerEdit()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerEdit(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void OnClickSave(object sender, EventArgs e)
        {
            var customer = new Customers()
            {
                FirstName = firstName?.Text,
                LastName = lastName?.Text,
                PhoneNumber = phoneNumber?.Text,
                Email = email?.Text,
                Notes = notes?.Text,
                TotalPurchasesAmount = Convert.ToDecimal(totalPurchasesAmount?.Text)
            };
            _customerRepository.Create(customer);
        }
    }
}