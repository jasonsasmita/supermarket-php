using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Supermarket.Model;
using System.Security.Cryptography.X509Certificates;

namespace Supermarket.Repository
{
    class ProductRepository
    {
        public void Insert(Product product)
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info = False;Initial Catalog=marketDB;
               ; Data Source = LAPTOP-0NPBM86K\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query = "INSERT INTO msProduct (ProductName,Price,Quantity) VALUES (@ProductName,@Price,@Quantity)";

            command.Parameters.Add("@ProductName", SqlDbType.VarChar, 25).Value = product.ProductName;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = product.Price;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

        }

        public List<Product> GetAll()
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info = False;Initial Catalog = marketDB;
             ;Data Source = LAPTOP-0NPBM86K\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            List<Product> productlist = new List<Product>();

            string query = "SELECT * FROM msProduct";

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product product = new Model.Product();
                    product.ProductID = int.Parse(reader["ProductID"].ToString());
                    product.ProductName = reader["ProductName"].ToString();
                    product.Price = int.Parse(reader["Price"].ToString());
                    product.Quantity = int.Parse(reader["Quantity"].ToString());

                    productlist.Add(product);

                }
            }

            reader.Close();
            command.Dispose();
            connection.Close();

            return productlist;

        }

        public void Update(Product product)
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info = False;Initial Catalog = marketDB;
             ;Data Source = LAPTOP-0NPBM86K\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query = "UPDATE msProduct SET ProductName= @ProductName,Price = @Price,Quantity= @Quantity WHERE ProductID=@ProductID";

            command.Parameters.Add("@ProductID", SqlDbType.Int).Value = product.ProductID;
            command.Parameters.Add("@ProductName", SqlDbType.VarChar, 25).Value = product.ProductName;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = product.Price;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

        }


        public void Delete(Product product)
        {
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info = False;Initial Catalog = marketDB;
             ;Data Source = LAPTOP-0NPBM86K\SQLEXPRESS");
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;

            string query = "DELETE FROM msProduct WHERE ProductID = @ProductID ";
            command.Parameters.Add("@ProductID", SqlDbType.Int).Value = product.ProductID;

            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            connection.Open();
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

    }
}
