using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using System;
using System.Data.SqlClient;

namespace Customer.Datalayer.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Addresses>
    {
        public void Create(Addresses entity)
        {
            
        }
        public Addresses Read(int entityID)
        {
            throw new NotImplementedException();
        }
        public void Update(Addresses entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityID)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            using var connection = GetConnection();
            connection.Open();

            var command = new SqlCommand("DELETE FROM Addresses", connection);
            command.ExecuteNonQuery();
        }
    }
}
