using MyTunes.Models;
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

                                temp.CustomerId= reader.GetInt32(0);
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
    throw new NotImplementedException();
}

}
}
