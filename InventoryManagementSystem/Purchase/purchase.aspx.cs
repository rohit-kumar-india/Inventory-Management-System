using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem.Purchase
{
    public partial class purchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            FillGridView();
            if (!IsPostBack)
            {
                BindComapnyName();
                BindProductName();
            }
        }

        private void BindComapnyName()
        {
            PurchaseLib purchaseDetails = new PurchaseLib();
            ddlCompanyName.DataSource = purchaseDetails.GetCompanyNames();
            ddlCompanyName.DataTextField = "companyName";
            ddlCompanyName.DataValueField = "supplierID";
            ddlCompanyName.DataBind();
            ddlCompanyName.Items.Insert(0,new ListItem("Please Select Company",""));
        }

        private void BindProductName()
        {
            PurchaseLib purchaseDetails = new PurchaseLib();
            ddlProductName.DataSource = purchaseDetails.GetProductNames();
            ddlProductName.DataTextField = "productName";
            ddlProductName.DataValueField = "productID";
            ddlProductName.DataBind();
            ddlProductName.Items.Insert(0, new ListItem("-Please Select Product-",""));
        }

        private void FillGridView()
        {
            PurchaseLib purchaseDetails = new PurchaseLib();
            gvPurchaseData.DataSource = purchaseDetails.GetPurchaseDetails();
            gvPurchaseData.DataBind();
        }

        protected void btnAddUpdatePurchase_Click(object sender, EventArgs e)
        {
            if (ddlProductName.SelectedValue== string.Empty)
            {
                lblError.Text = "Please select Product Name.";
                return;
            }
            if (ddlCompanyName.SelectedValue == string.Empty)
            {
                lblError.Text = "Please select Company Name.";
                return;
            }
            if (txtQuantity.Text == string.Empty)
            {
                lblError.Text = "Please enter Quantity.";
                return;
            }
            if (txtPrice.Text == string.Empty)
            {
                lblError.Text = "Please enter Price.";
                return;
            }
            if (txtDate.Text == string.Empty)
            {
                lblError.Text = "Please enter Date.";
                return;
            }
            PurchaseLib purchaseDetails = new PurchaseLib();
            purchaseDetails.purchaseID = lblPurchaseIDValue.Text == "" ? 0 : Convert.ToInt32(lblPurchaseIDValue.Text);
            purchaseDetails.productId = Convert.ToInt32(ddlProductName.SelectedValue);
            purchaseDetails.supplierId = Convert.ToInt32(ddlCompanyName.SelectedValue);
            purchaseDetails.quantity = Convert.ToInt32(txtQuantity.Text);
            purchaseDetails.price = Convert.ToDecimal(txtPrice.Text);
            purchaseDetails.date = Convert.ToDateTime(txtDate.Text);

            lblPurchaseIDValue.Text = purchaseDetails.AddUpdatePurchase().ToString();
            FillGridView();
            lblError.Text = string.Empty;

        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProductName.SelectedValue == string.Empty)
                lblAvailableQuantityValue.Text = string.Empty;
            else
            {
                PurchaseLib purchaseDetails = new PurchaseLib();
                purchaseDetails.productId = Convert.ToInt32(ddlProductName.SelectedValue);
                lblAvailableQuantityValue.Text = purchaseDetails.GetAvailableQuantity().ToString();
            }
        }

        protected void gvPurchaseData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvPurchaseData, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvPurchaseData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvPurchaseData.Rows)
            {
                if (row.RowIndex == gvPurchaseData.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    EditPurchaseDetails(row);
                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        private void EditPurchaseDetails(GridViewRow row)
        {
            ddlProductName.SelectedValue = row.Cells[0].Text;
            ddlCompanyName.SelectedValue = row.Cells[1].Text;
            txtDate.Text = row.Cells[2].Text;
            lblPurchaseIDValue.Text = row.Cells[3].Text;
            txtQuantity.Text = row.Cells[6].Text;
            txtPrice.Text = row.Cells[7].Text;
            lblError.Text = string.Empty;
            PurchaseLib purchaseDetails = new PurchaseLib();
            purchaseDetails.productId = Convert.ToInt32(ddlProductName.SelectedValue);
            lblAvailableQuantityValue.Text = purchaseDetails.GetAvailableQuantity().ToString();
        }

        protected void btnNewPurchase_Click(object sender, EventArgs e)
        {
            lblPurchaseIDValue.Text = string.Empty;
            txtDate.Text = string.Empty;
            ddlProductName.SelectedValue = string.Empty;
            ddlCompanyName.SelectedValue = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            lblAvailableQuantityValue.Text = string.Empty;
            lblError.Text = string.Empty;
        }
    }
}