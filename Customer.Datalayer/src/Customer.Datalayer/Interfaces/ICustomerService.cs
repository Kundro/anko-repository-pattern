using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Datalayer.Interfaces
{
    public interface ICustomerService<Customers>
    {
        List<Customers> GetCustomers();
        Customers ReadCustomer(int id);
        void CreateCustomer(Customers entity);
        void UpdateCustomer(Customers entity);
        void DeleteCustomer(int id);
    }
}
