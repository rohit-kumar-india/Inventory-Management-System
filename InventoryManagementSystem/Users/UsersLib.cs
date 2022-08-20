using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Users
{
    public class UsersLib
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4A1KN01;Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        private const string _spAddUpdateUser = "sp_AddUpdateUser";
        private const string _spGetAllUsers = "sp_GetAllUsers";

        public int userID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailId { get; set; }
        public Int64 mobileNumber { get; set; }
        public string password { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int pincode { get; set; }

        public int AddUpdateUser()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand(_spAddUpdateUser, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@emailId", emailId);
            command.Parameters.AddWithValue("@mobileNumber", mobileNumber);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@address1", address1);
            command.Parameters.AddWithValue("@address2", address2);
            command.Parameters.AddWithValue("@pincode", pincode);
            SqlParameter id = new SqlParameter();
            id.ParameterName = "ID";
            id.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(id);
            command.ExecuteNonQuery();
            userID = (int)command.Parameters["ID"].Value;
            connection.Close();
            return userID;
        }

        public DataSet GetAllUsers()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(_spGetAllUsers, connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet users = new DataSet();
            adapter.Fill(users);
            connection.Close();
            return users;
        }
    }
}