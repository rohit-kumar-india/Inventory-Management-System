using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Products
{
    public class ProductsLib
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4A1KN01;Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        private const string _spAddUpdateProduct = "sp_AddUpdateProduct";
        private const string _spGetAllProducts = "sp_GetAllProducts";

        public int productID { get; set; }
        public string productName { get; set; }
        public string brandName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }

        public int AddUpdateProduct()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand(_spAddUpdateProduct, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@productID", productID);
            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@brandName", brandName);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@description", description);
            SqlParameter id = new SqlParameter();
            id.ParameterName = "ID";
            id.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(id);
            command.ExecuteNonQuery();
            productID = (int)command.Parameters["ID"].Value;
            connection.Close();
            return productID;
        }

        public DataSet GetAllProducts()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(_spGetAllProducts, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet products = new DataSet();
            adapter.Fill(products);
            connection.Close();
            return products;
        }

    }
}