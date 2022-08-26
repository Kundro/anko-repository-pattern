using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Customer.Datalayer.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customers>
    {
        public void Create(Customers entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO [Customer](FirstName, LastName, PhoneNumber, Email, Notes, TotalPurchasesAmount)" +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Notes, @TotalPurchasesAmount)",
                    connection);

                var customerFirstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var customerLastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var customerPhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = entity.PhoneNumber
                };
                var customerEmailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 100)
                {
                    Value = entity.Email
                };
                var customerNotesParam = new SqlParameter("@Notes", SqlDbType.NVarChar, int.MaxValue)
                {
                    Value = entity.Notes
                };
                var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Decimal)
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
        }

        public Customers Read(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customer] WHERE CustomerID = @CustomerID", connection);
                var customerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(customerIDParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customers
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Notes = reader["Notes"].ToString(),
                            TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"])
                        };
                    }
                }
                return null;
            }
        }

        public void Update(Customers entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE [Customer] SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Email = @Email, Notes = @Notes, TotalPurchasesAmount = @TotalPurchasesAmount WHERE CustomerID = @CustomerID", connection);
                var customerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Value = entity.CustomerID
                };
                var customerFirstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.FirstName
                };
                var customerLastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, 50)
                {
                    Value = entity.LastName
                };
                var customerPhoneNumberParam = new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15)
                {
                    Value = entity.PhoneNumber
                };
                var customerEmailParam = new SqlParameter("@Email", SqlDbType.NVarChar, 100)
                {
                    Value = entity.Email
                };
                var customerNotesParam = new SqlParameter("@Notes", SqlDbType.NVarChar, int.MaxValue)
                {
                    Value = entity.Notes
                };
                var customerTotalPurchasesAmountParam = new SqlParameter("@TotalPurchasesAmount", SqlDbType.Decimal)
                {
                    Value = entity.TotalPurchasesAmount
                };
                command.Parameters.Add(customerIDParam);
                command.Parameters.Add(customerFirstNameParam);
                command.Parameters.Add(customerLastNameParam);
                command.Parameters.Add(customerPhoneNumberParam);
                command.Parameters.Add(customerEmailParam);
                command.Parameters.Add(customerNotesParam);
                command.Parameters.Add(customerTotalPurchasesAmountParam);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Addresses WHERE CustomerID = @CustomerID DELETE FROM [Customer] WHERE CustomerID = @CustomerID", connection);
                var customerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(customerIDParam);
                command.ExecuteNonQuery();
            }
        }
        public int GetID()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT CustomerID FROM Customer", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["CustomerID"]);
                }
                return 0;
            }
        }
        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM Customer WHERE CustomerID>498",
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Customers> GetAll()
        {
            using (var connection = GetConnection())
            {
                var customers = new List<Customers>();
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [Customer]", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customers
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            Notes = reader["Notes"].ToString(),
                            TotalPurchasesAmount = Convert.ToDecimal(reader["TotalPurchasesAmount"])
                        });
                    }
                }
                return customers;
            }
        }
    }
}
