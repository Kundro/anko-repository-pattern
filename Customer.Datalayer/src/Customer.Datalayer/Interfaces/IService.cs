using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Datalayer.Interfaces
{
    public interface IService<TEntity>
    {
        List<TEntity> GetCustomers();
        TEntity ReadCustomer(int id);
        void CreateCustomer(TEntity entity);
        void UpdateCustomer(TEntity entity);
        void DeleteCustomer(int id);
    }
}
