using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem.Users
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            FillGridView();
        }

        private void FillGridView()
        {
            UsersLib product = new UsersLib();
            gvUsersData.DataSource = product.GetAllUsers();
            gvUsersData.DataBind();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == string.Empty)
            {
                lblError.Text = "Please enter First Name.";
                return;
            }
            if (txtLastName.Text == string.Empty)
            {
                lblError.Text = "Please enter Last Name.";
                return;
            }
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
            if (txtMobileNumber.Text == string.Empty)
            {
                lblError.Text = "Please enter Mobile Number.";
                return;
            }
            if (txtMobileNumber.Text.Length!=10)
            {
                lblError.Text = "Please enter 10 digits Mobile Number.";
                return;
            }
            if (txtPassword.Text == string.Empty)
            {
                lblError.Text = "Please enter Password.";
                return;
            }
            if (txtAddress1.Text == string.Empty)
            {
                lblError.Text = "Please enter Address1.";
                return;
            }
            if (txtAddress2.Text == string.Empty)
            {
                lblError.Text = "Please enter Address2.";
                return;
            }
            if (txtPinCode.Text == string.Empty)
            {
                lblError.Text = "Please enter Pincode.";
                return;
            }
            if (txtPinCode.Text.Length!=6)
            {
                lblError.Text = "Please enter 6 digits Pincode.";
                return;
            }
            UsersLib supplier = new UsersLib();
            supplier.userID = lblUserIDValue.Text == "" ? 0 : Convert.ToInt32(lblUserIDValue.Text);
            supplier.firstName = txtFirstName.Text;
            supplier.lastName = txtLastName.Text;
            supplier.emailId = txtEmailId.Text;
            supplier.mobileNumber = Convert.ToInt64(txtMobileNumber.Text);
            supplier.password = txtPassword.Text;
            supplier.address1 = txtAddress1.Text;
            supplier.address2 = txtAddress2.Text;
            supplier.pincode = Convert.ToInt32(txtPinCode.Text);

            lblUserIDValue.Text = supplier.AddUpdateUser().ToString();
            FillGridView();
            lblError.Text = string.Empty;
        }

        protected void gvUsersData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUsersData, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvUsersData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvUsersData.Rows)
            {
                if (row.RowIndex == gvUsersData.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    EditUserDetails(row);
                    btnAddUser.Text = "Update User";
                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        private void EditUserDetails(GridViewRow row)
        {
            lblUserIDValue.Text = row.Cells[0].Text;
            txtFirstName.Text = row.Cells[1].Text;
            txtLastName.Text = row.Cells[2].Text;
            txtEmailId.Text = row.Cells[3].Text;
            txtMobileNumber.Text = row.Cells[4].Text;
            txtPassword.Text = row.Cells[5].Text;
            txtPassword.Text = gvUsersData.SelectedRow.Cells[5].Text;
            txtAddress1.Text = row.Cells[6].Text;
            txtAddress2.Text = row.Cells[7].Text;
            txtPinCode.Text = row.Cells[8].Text;
            lblError.Text = string.Empty;
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            lblUserIDValue.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtPinCode.Text = string.Empty;
            btnAddUser.Text = "Add User";
            lblError.Text = string.Empty;
        }
    }
}