using Customer.Datalayer.BusinessEntities;
using Customer.Datalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Customer.Datalayer.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Addresses>
    {
        public void Create(Addresses entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO Addresses(CustomerID, AddressLine, AddressLine2, AddressType, City, PostalCode, StateName, Country)" +
                    "VALUES (@CustomerID, @AddressLine, @AddressLine2, @AddressType, @City, @PostalCode, @StateName, @Country)",
                    connection);
                var addressCustomerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Value = entity.CustomerID
                };
                var addressAddressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine
                };
                var addressAddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine2
                };
                var addressAddressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 10)
                {
                    Value = entity.AddressType
                };
                var addressCityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = entity.City
                };
                var addressPostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = entity.PostalCode
                };
                var addressStateNameParam = new SqlParameter("@StateName", SqlDbType.NVarChar, 20)
                {
                    Value = entity.StateName
                };
                var addressCountryNameParam = new SqlParameter("@Country", SqlDbType.NVarChar)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressAddressLineParam);
                command.Parameters.Add(addressAddressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateNameParam);
                command.Parameters.Add(addressCountryNameParam);
                command.ExecuteNonQuery();
            }
        }
        public Addresses Read(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Addresses WHERE AddressID = @AddressID", connection);
                var addressIDParam = new SqlParameter("@AddressID", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(addressIDParam);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Addresses
                        {
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            StateName = reader["StateName"].ToString(),
                            Country = reader["Country"].ToString()
                        };
                    }
                }
                return null;
            }

        }
        public void Update(Addresses entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Addresses SET CustomerID = @CustomerID, AddressLine = @AddressLine, AddressLine2 = @AddressLine2, AddressType = @AddressType, City = @City, PostalCode = @PostalCode, StateName = @StateName, Country = @Country WHERE AddressID = @AddressID", connection);
                var addressAddressIDParam = new SqlParameter("@AddressID", SqlDbType.Int)
                {
                    Value = entity.AddressID
                };
                var addressCustomerIDParam = new SqlParameter("@CustomerID", SqlDbType.Int)
                {
                    Value = entity.CustomerID
                };
                var addressAddressLineParam = new SqlParameter("@AddressLine", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine
                };
                var addressAddressLine2Param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100)
                {
                    Value = entity.AddressLine2
                };
                var addressAddressTypeParam = new SqlParameter("@AddressType", SqlDbType.NVarChar, 10)
                {
                    Value = entity.AddressType
                };
                var addressCityParam = new SqlParameter("@City", SqlDbType.NVarChar, 50)
                {
                    Value = entity.City
                };
                var addressPostalCodeParam = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 6)
                {
                    Value = entity.PostalCode
                };
                var addressStateNameParam = new SqlParameter("@StateName", SqlDbType.NVarChar, 20)
                {
                    Value = entity.StateName
                };
                var addressCountryNameParam = new SqlParameter("@Country", SqlDbType.NVarChar)
                {
                    Value = entity.Country
                };
                command.Parameters.Add(addressAddressIDParam);
                command.Parameters.Add(addressCustomerIDParam);
                command.Parameters.Add(addressAddressLineParam);
                command.Parameters.Add(addressAddressLine2Param);
                command.Parameters.Add(addressAddressTypeParam);
                command.Parameters.Add(addressCityParam);
                command.Parameters.Add(addressPostalCodeParam);
                command.Parameters.Add(addressStateNameParam);
                command.Parameters.Add(addressCountryNameParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int entityID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Addresses WHERE AddressID = @AddressID", connection);
                var addressIDParam = new SqlParameter("@AddressID", SqlDbType.Int)
                {
                    Value = entityID
                };
                command.Parameters.Add(addressIDParam);
                command.ExecuteNonQuery();
            }
        }

        public int GetCustomerID()
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
        public int GetID()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT AddressID FROM Addresses", connection);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["AddressID"]);
                }
                return 0;
            }
        }

        public List<int> GetAllIDs()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM Addresses",
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Addresses> GetAll()
        {
            List<Addresses> addresses = new List<Addresses>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Addresses", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addresses.Add(new Addresses
                        {
                            AddressID = Convert.ToInt32(reader["AddressID"]),
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            AddressLine = reader["AddressLine"].ToString(),
                            AddressLine2 = reader["AddressLine2"].ToString(),
                            AddressType = reader["AddressType"].ToString(),
                            City = reader["City"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            StateName = reader["StateName"].ToString(),
                            Country = reader["Country"].ToString()
                        });
                    }
                }
                return addresses;
            }
        }
    }
}
