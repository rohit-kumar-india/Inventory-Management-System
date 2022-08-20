using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Sales
{
    public class SalesLib
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4A1KN01;Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        private const string _spGetProductNames = "sp_GetProductNames";
        private const string _spGetSalesDetails = "sp_GetSalesDetails";
        private const string _spAddUpdateSales = "sp_AddUpdateSales";
        private const string _spGetAvailableQuantity = "sp_GetAvailableQuantity";

        public int saleID { get; set; }
        public int productId { get; set; }
        public int orderId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public DateTime date { get; set; }
        public string customerName { get; set; }

        public DataSet GetProductNames()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(_spGetProductNames, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet productNames = new DataSet();
            adapter.Fill(productNames);
            connection.Close();
            return productNames;
        }
        
        public DataSet GetSalesDetails()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(_spGetSalesDetails, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet salesDetails = new DataSet();
            adapter.Fill(salesDetails);
            connection.Close();
            return salesDetails;
        }

        public int AddUpdateSales(DataTable sales)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand(_spAddUpdateSales, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@saleID", saleID);
            command.Parameters.AddWithValue("@orderID", orderId);
            command.Parameters.AddWithValue("@customerName", customerName);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@tableSales", sales);
            SqlParameter id = new SqlParameter();
            id.ParameterName = "ID";
            id.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(id);
            command.ExecuteNonQuery();
            orderId = (int)command.Parameters["ID"].Value;
            connection.Close();
            return orderId;
        }

        public int GetAvailableQuantity()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand(_spGetAvailableQuantity, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@productID", productId);
            int availableQuantity = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return availableQuantity;
        }
    }
}