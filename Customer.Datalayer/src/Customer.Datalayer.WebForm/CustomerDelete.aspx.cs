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
    public partial class CustomerDelete : System.Web.UI.Page
    {
        public IRepository<Customers> _customerRepository;
        public CustomerDelete()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerDelete (IRepository<Customers> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIDReq = Convert.ToInt32(Request.QueryString["customerID"]);
            _customerRepository.Delete(customerIDReq);
            Response.Redirect("CustomersList.aspx");
        }
    }
}