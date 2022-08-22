using Customer.Datalayer.Interfaces;
using Customer.Datalayer.BusinessEntities;
using System.Data.SqlClient;

namespace Customer.Datalayer.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customers>
    {
        public void Create(Customers entity)
        {
            using var connection = GetConnection();
            DeleteAll();
            connection.Open();
            var command = new SqlCommand(
                "INSERT INTO Customer(FirstName, LastName, PhoneNumber, Email, Notes, TotalPurchasesAmount)" +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Notes, @TotalPurchasesAmount)",
                connection);

            var customerFirstNameParam = new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
            {
                Value = entity.FirstName
            };
            var customerLastNameParam = new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 50)
            {
                Value = entity.LastName
            };
            var customerPhoneNumberParam = new SqlParameter("@PhoneNumber", System.Data.SqlDbType.NVarChar, 15)
            {
                Value = entity.PhoneNumber
            };
            var customerEmailParam = new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 100)
            {
                Value = entity.Email
            };
            var customerNotesParam = new SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, int.MaxValue)
            {
                Value = entity.Notes
            };
            var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", System.Data.SqlDbType.Decimal)
            {
                Value = entity.TotalPurchasesAmount
            };
            command.Parameters.Add(customerFirstNameParam);
            command.Parameters.Add(customerLastNameParam);
            command.Parameters.Add(customerPhoneNumberParam);
            command.Parameters.Add(customerEmailParam);
            command.Parameters.Add(customerNotesParam);
            command.Parameters.Add(customerTotalPurchasesAmountParam);
            command.ExecuteNonQuery();
        }

        public void Delete(string entityCode)
        {
            throw new System.NotImplementedException();
        }

        public Customers Read(string entityCode)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customers entity)
        {
            throw new System.NotImplementedException();
        }
        public void DeleteAll()
        {
            using var connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=CustomerLib_Kundro;Trusted_Connection=True;");
            connection.Open();

            var command = new SqlCommand(
                "DELETE FROM [Customer]",
                connection);
            command.ExecuteNonQuery();
        }
    }
}
