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
        public IRepository<Customers> _customerRepository;
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
            if (!IsPostBack)
            {
                var customerIDReq = Convert.ToInt32(Request["customerID"]);
                if (customerIDReq != 0)
                {

                    var customer = _customerRepository.Read(customerIDReq);
                    firstName.Text = customer.FirstName;
                    lastName.Text = customer.LastName;
                    phoneNumber.Text = customer.PhoneNumber;
                    email.Text = customer.Email;
                    notes.Text = customer.Notes;
                    totalPurchasesAmount.Text = customer.TotalPurchasesAmount.ToString();
                }
            }
        }

        public void OnClickSave(object sender, EventArgs e)
        {
            var customer = new Customers()
            {
                CustomerID = Convert.ToInt32(Request.QueryString["customerID"]),
                FirstName = firstName?.Text,
                LastName = lastName?.Text, 
                PhoneNumber = phoneNumber?.Text,
                Email = email?.Text,
                Notes = notes?.Text,
                TotalPurchasesAmount = Convert.ToDecimal(totalPurchasesAmount?.Text)
            };
            if (Convert.ToInt32(Request.QueryString["customerID"]) == 0)
            {
                _customerRepository.Create(customer);
            } else
            {
                _customerRepository.Update(customer);
            }
            HttpContext.Current.Response.Redirect("CustomersList.aspx");
        }
    }
}