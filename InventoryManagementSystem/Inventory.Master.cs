using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem
{
    public partial class Inventory : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                lblUserName.Text = "Welcome "+Session["user"];
            }
            else
            {
                btnLogout.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Login/Login.aspx");
        }


        protected void lbAdminMenu_Click(object sender, EventArgs e)
        {
            if(blAdminMenu.Visible == false)
                blAdminMenu.Visible = true;
            else
                blAdminMenu.Visible = false;
        }
    }
}