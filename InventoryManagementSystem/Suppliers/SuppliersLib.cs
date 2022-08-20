using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Suppliers
{
    public class SuppliersLib
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4A1KN01;Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        private const string _spAddUpdateSupplier = "sp_AddUpdateSupplier";
        private const string _spGetAllSuppliers = "sp_GetAllSuppliers";

        public int supplierID { get; set; }
        public string companyName { get; set; }
        public string GSTNumber { get; set; }
        public Int64 mobileNo { get; set; }
        public string address { get; set; }

        public int AddUpdateSupplier()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand(_spAddUpdateSupplier, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@supplierID", supplierID);
            command.Parameters.AddWithValue("@companyName", companyName);
            command.Parameters.AddWithValue("@GSTNumber", GSTNumber);
            command.Parameters.AddWithValue("@mobileNo", mobileNo);
            command.Parameters.AddWithValue("@address", address);
            SqlParameter id = new SqlParameter();
            id.ParameterName = "ID";
            id.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(id);
            command.ExecuteNonQuery();
            supplierID = (int)command.Parameters["ID"].Value;
            connection.Close();
            return supplierID;
        }

        public DataSet GetAllSuppliers()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(_spGetAllSuppliers, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet suppliers = new DataSet();
            adapter.Fill(suppliers);
            connection.Close();
            return suppliers;
        }
    }
}