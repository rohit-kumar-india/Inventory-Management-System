using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem.Suppliers
{
    public partial class suppliers : System.Web.UI.Page
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
            SuppliersLib product = new SuppliersLib();
            gvSuppliersData.DataSource = product.GetAllSuppliers();
            gvSuppliersData.DataBind();
        }

        protected void btnAddUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == string.Empty)
            {
                lblError.Text = "Please enter Company Name.";
                return;
            }
            if (txtGSTNumber.Text == string.Empty)
            {
                lblError.Text = "Please enter GST Number.";
                return;
            }
            if (txtMobileNo.Text == string.Empty)
            {
                lblError.Text = "Please enter Mobile Number.";
                return;
            }
            if (txtMobileNo.Text.Length != 10)
            {
                lblError.Text = "Please enter Valid Mobile Number.";
                return;
            }
            if (txtAddress.Text == string.Empty)
            {
                lblError.Text = "Please enter Address.";
                return;
            }
            SuppliersLib supplier = new SuppliersLib();
            supplier.supplierID = lblSupplierIDValue.Text == "" ? 0 : Convert.ToInt32(lblSupplierIDValue.Text);
            supplier.companyName = txtCompanyName.Text;
            supplier.GSTNumber = txtGSTNumber.Text;
            supplier.address = txtAddress.Text;
            supplier.mobileNo = Convert.ToInt64(txtMobileNo.Text);

            lblSupplierIDValue.Text = supplier.AddUpdateSupplier().ToString();
            FillGridView();
        }

        

        protected void gvSuppliersData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvSuppliersData, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvSuppliersData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvSuppliersData.Rows)
            {
                if (row.RowIndex == gvSuppliersData.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    EditSupplierDetails(row);
                    btnAddUpdateSupplier.Text = "Update Supplier";
                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        private void EditSupplierDetails(GridViewRow row)
        {
            lblSupplierIDValue.Text = row.Cells[0].Text;
            txtCompanyName.Text = row.Cells[1].Text;
            txtGSTNumber.Text = row.Cells[2].Text;
            txtMobileNo.Text = row.Cells[3].Text;
            txtAddress.Text = row.Cells[4].Text;
            lblError.Text = string.Empty;
        }

        protected void btnNewsupplier_Click(object sender, EventArgs e)
        {
            lblSupplierIDValue.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtGSTNumber.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            btnAddUpdateSupplier.Text = "Add Supplier";
            lblError.Text = string.Empty;
        }
    }
}