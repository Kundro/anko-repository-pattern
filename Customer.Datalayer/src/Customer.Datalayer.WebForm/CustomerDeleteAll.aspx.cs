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
    public partial class CustomerDeleteAll : System.Web.UI.Page
    {
        public IRepository<Customers> _customerRepository;
        public CustomerDeleteAll()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerDeleteAll(IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _customerRepository.DeleteAll();
            Response.Redirect("CustomersList.aspx");
        }
    }
}