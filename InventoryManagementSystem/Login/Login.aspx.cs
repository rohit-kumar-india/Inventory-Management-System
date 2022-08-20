using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem.Login
{
    public partial class Login : System.Web.UI.Page
    {
        static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4A1KN01;Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("../Home/home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmailId.Text == string.Empty)
            {
                lblError.Text = "Please enter Email Id.";
                return;
            }
            try
            {
                MailAddress address = new MailAddress(txtEmailId.Text);
                if (address.Address != txtEmailId.Text)
                {
                    lblError.Text = "Please enter valid Email Id.";
                    return;
                }
            }
            catch (FormatException)
            {
                lblError.Text = "Please enter valid Email Id.";
                return;
            }
            if (txtPassword.Text == string.Empty)
            {
                lblError.Text = "Please enter Password.";
                return;
            }
            if (connection.State==ConnectionState.Closed)
                connection.Open();
            string checkquery = "Select firstName,lastName from users where emailId='" + txtEmailId.Text + "' and password='" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter cmd = new SqlDataAdapter(checkquery, connection);
            DataTable user = new DataTable();
            cmd.Fill(user);
            //int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (user.Rows.Count == 1)
            {
                //lblerror.Text = "login Successful!";

                Session["user"] = user.Rows[0]["firstName"]+ " " +user.Rows[0]["lastName"];
                Response.Redirect("../Home/home.aspx");

            }
            else
            {
                lblError.Text = "Login Failed. Incorrect Username or Password!";
            }
            connection.Close();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtEmailId.Text = "";
            txtPassword.Text = "";
            lblError.Text = "";
        }
    }
}