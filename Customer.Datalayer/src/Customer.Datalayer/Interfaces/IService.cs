using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Datalayer.Interfaces
{
    public interface IService<TEntity>
    {
        List<TEntity> Get();
        TEntity Read(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
