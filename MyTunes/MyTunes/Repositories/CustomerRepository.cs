using MyTunes.Models;
using MyTunes.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyTunes.Repositories
{
    public class CustomerRepository
    {

        public static string SafeGetString(int index, SqlDataReader reader)
        {
            if (!reader.IsDBNull(index))
                return reader.GetString(index);
            return string.Empty;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email FROM Customer";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();

                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = SafeGetString(1, reader);
                                temp.LastName = SafeGetString(2, reader);
                                temp.Country = SafeGetString(3, reader);
                                temp.PostalCode = SafeGetString(4, reader);
                                temp.Phone = SafeGetString(5, reader);
                                temp.Email = SafeGetString(6, reader);

                                custList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return custList;
        }



        internal object GetCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public List<CustomersEachCountryDTO> GetAmountCustomerByCountry()
        {
            List<CustomersEachCountryDTO> cuntList = new List<CustomersEachCountryDTO>();
            string query= " SELECT COUNT(CustomerId), Country FROM [Chinook].[dbo].[Customer] GROUP BY Country ORDER BY COUNT(CustomerID) DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomersEachCountryDTO temp = new CustomersEachCountryDTO();

                                temp.COUNT = reader.GetInt32(0);
                                temp.Country = SafeGetString(1, reader);


                                cuntList.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return cuntList;

        }



        /*
       public Customer GetCustomer(string id)
       {
           Customer customer = new Customer();
           string sql = "SELECT CustomerID, CompanyName, ContactName, City FROM Customers" +
               " WHERE CustomerID = @CustomerID";
           try
           {
               using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
               {
                   conn.Open();
                   using (SqlCommand cmd = new SqlCommand(sql, conn))
                   {
                       cmd.Parameters.AddWithValue("@CustomerID", id);
                       using (SqlDataReader reader = cmd.ExecuteReader())
                       {
                           while (reader.Read())
                           {
                               customer.CustomerID = reader.GetString(0);
                               customer.CompanyName = reader.GetString(1);
                               customer.ContactName = reader.GetString(2);
                               customer.City = reader.GetString(3);
                           }
                       }
                   }
               }
           }
           catch (SqlException ex)
           {
               // Log to console
           }
           return customer;
       }
*/



        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
                        "VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }


        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
            {
                var query = "UPDATE Customer " +
                      "SET FirstName = ISNULL(@FirstName, FirstName), " +
                      "LastName = ISNULL(@LastName, LastName), " +
                      "Company = ISNULL(@Company, Company), " +
                      "Address = ISNULL(@Address, Address), " +
                      "City = ISNULL(@City, City), " +
                      "State = ISNULL(@State, State), " +
                      "Country = ISNULL(@Country, Country), " +
                      "PostalCode = ISNULL(@PostalCode, PostalCode), " +
                      "Phone = ISNULL(@Phone, Phone), " +
                      "Fax = ISNULL(@Fax, Fax), " +
                      "Email = ISNULL(@Email, Email) " +
                      "WHERE CustomerId = @CustomerId";
                ;

             


                try
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Connection.Open();
                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@LastName", customer.LastName ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Company", customer.Company ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Address", customer.Address ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@City", customer.City ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@State", customer.State ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Country", customer.Country ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@PostalCode", customer.PostalCode ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Phone", customer.Phone ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Fax", customer.Fax ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@Email", customer.Email ?? Convert.DBNull);
                    success = command.ExecuteNonQuery() > 0;

                }
                catch (Exception ex)
                {
                    //handle exception
                }
            }
            return success;
        }
    }
}
