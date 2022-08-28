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
    public partial class AddressDelete : System.Web.UI.Page
    {
        public IRepository<Addresses> _addressRepository;
        public AddressDelete()
        {
            _addressRepository = new AddressRepository();
        }
        public AddressDelete(IRepository<Addresses> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var addressIDReq = Convert.ToInt32(Request.QueryString["addressID"]);
            _addressRepository.Delete(addressIDReq);
            Response.Redirect("AddressesList.aspx");
        }
    }
}