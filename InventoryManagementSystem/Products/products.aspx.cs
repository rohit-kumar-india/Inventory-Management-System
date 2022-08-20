using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem.Products
{
    public partial class products : System.Web.UI.Page
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
            ProductsLib product = new ProductsLib();
            gvProductsData.DataSource = product.GetAllProducts();
            gvProductsData.DataBind();
        }

        protected void btnAddUpdateProduct_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == string.Empty)
            {
                lblError.Text = "Please enter Product Name.";
                return;
            }
            if (txtBrandName.Text == string.Empty)
            {
                lblError.Text = "Please enter Brand Name.";
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
            if (txtDescription.Text == string.Empty)
            {
                lblError.Text = "Please enter Description.";
                return;
            }
            ProductsLib product = new ProductsLib();
            product.productID = lblProductIDValue.Text == "" ? 0 : Convert.ToInt32(lblProductIDValue.Text);
            product.productName = txtProductName.Text;
            product.brandName = txtBrandName.Text;
            product.quantity = Convert.ToInt32(txtQuantity.Text);
            product.price = Convert.ToDecimal(txtPrice.Text);
            product.description = txtDescription.Text;

            lblProductIDValue.Text = product.AddUpdateProduct().ToString();
            FillGridView();
            lblError.Text = string.Empty;
        }

        protected void gvProductsData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvProductsData, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvProductsData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(GridViewRow row in gvProductsData.Rows)
            {
                if (row.RowIndex == gvProductsData.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    EditProductDetails(row);
                    btnAddUpdateProduct.Text = "Update Product";
                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        private void EditProductDetails(GridViewRow row)
        {
            lblProductIDValue.Text = row.Cells[0].Text;
            txtProductName.Text = row.Cells[1].Text;
            txtBrandName.Text = row.Cells[2].Text;
            txtQuantity.Text = row.Cells[3].Text;
            txtPrice.Text = row.Cells[4].Text;
            txtDescription.Text = row.Cells[5].Text;
            lblError.Text = string.Empty;
        }

        protected void btnNewProduct_Click(object sender, EventArgs e)
        {
            lblProductIDValue.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtBrandName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnAddUpdateProduct.Text = "Add Product";
            lblError.Text = string.Empty;
        }
    }
}