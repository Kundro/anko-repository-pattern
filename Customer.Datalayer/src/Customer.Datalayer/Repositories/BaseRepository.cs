using System.Data.SqlClient;

namespace Customer.Datalayer.Repositories
{
    public class BaseRepository
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=.\\SQLEXPRESS;Database=CustomerLib_Kundro;Trusted_Connection=True;");
        }
    }
}
