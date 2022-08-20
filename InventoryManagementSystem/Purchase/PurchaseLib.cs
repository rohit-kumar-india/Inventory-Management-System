using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Purchase
{
    public class PurchaseLib
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4A1KN01;Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        private const string _spAddUpdatePurchase = "sp_AddUpdatePurchase";
        private const string _spGetPurchaseDetails = "sp_GetPurchaseDetails";
        private const string _spGetCompanyNames = "sp_GetCompanyNames";
        private const string _spGetProductNames = "sp_GetProductNames";
        private const string _spGetAvailableQuantity = "sp_GetAvailableQuantity";

        public int purchaseID { get; set; }
        public int productId { get; set; }
        public int supplierId { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public DateTime date { get; set; }

        public DataSet GetCompanyNames()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(_spGetCompanyNames, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet companyNames = new DataSet();
            adapter.Fill(companyNames);
            connection.Close();
            return companyNames;
        }

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

        public int AddUpdatePurchase()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand(_spAddUpdatePurchase, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@purchaseID", purchaseID);
            command.Parameters.AddWithValue("@productId", productId);
            command.Parameters.AddWithValue("@supplierId", supplierId);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@date", date);
            SqlParameter id = new SqlParameter();
            id.ParameterName = "ID";
            id.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(id);
            command.ExecuteNonQuery();
            purchaseID = (int)command.Parameters["ID"].Value;
            connection.Close();
            return purchaseID;
        }

        public DataSet GetPurchaseDetails()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(_spGetPurchaseDetails, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet purchaseDetails = new DataSet();
            adapter.Fill(purchaseDetails);
            connection.Close();
            return purchaseDetails;
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