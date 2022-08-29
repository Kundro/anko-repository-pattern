using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using Customer.Datalayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customer.Datalayer.WebForm
{
    public partial class AddressEdit : System.Web.UI.Page
    {
        private readonly IRepository<Addresses> _addressRepository;
        public AddressEdit()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressEdit(IRepository<Addresses> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> IDs = _addressRepository.GetAllIDs();
            foreach(int ID in IDs)
            {
                dropDownCustomerID.Items.Add(ID.ToString());
            }
            if (!IsPostBack)
            {
                var addressIDReq = Convert.ToInt32(Request.QueryString["addressID"]);
                if (addressIDReq != 0)
                {
                    var address = _addressRepository.Read(addressIDReq);
                    
                    dropDownCustomerID.Text = Convert.ToString(address.CustomerID);
                    addressLine1.Text = address.AddressLine;
                    addressLine2.Text = address.AddressLine2;
                    addressType.Text = address.AddressType;
                    city.Text = address.City;
                    postalCode.Text = address.PostalCode;
                    state.Text = address.StateName;
                    country.Text = address.Country;
                }
            }
            
        }

        public void OnClickSave(object sender, EventArgs e)
        {
            var address = new Addresses()
            {
                AddressID = Convert.ToInt32(Request.QueryString["addressID"]),
                CustomerID = Convert.ToInt32(dropDownCustomerID.SelectedValue),
                AddressLine = addressLine1?.Text,
                AddressLine2 = addressLine2?.Text,
                AddressType = addressType?.Text,
                City = city?.Text,
                PostalCode = postalCode?.Text,
                StateName = postalCode?.Text,
                Country = country?.Text
            };
            if (Convert.ToInt32(Request.QueryString["addressID"]) == 0)
            {
            _addressRepository.Create(address);
            } else
            {
                _addressRepository.Update(address);
            }
            HttpContext.Current.Response.Redirect("AddressesList.aspx");
        }
    }
}