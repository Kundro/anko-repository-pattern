using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Datalayer.BusinessEntities
{
    public class Addresses
    {
        public int AddressID { get; set; }
        public int CustomerID { get; set; }
        public string AddressLine { get; set; } = string.Empty;
        public string AddressLine2 { get; set; }
        public AddressType AddressType { get; set; } = AddressType.Unknown;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
