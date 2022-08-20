using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem.Sales
{
    public partial class sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../Login/Login.aspx");
            FillGridView();
            if (!IsPostBack)
            {
                BindProductName();
            }
            if (Page.IsPostBack == true)
            {
                if (ViewState["Count"] != null)
                {
                    arrViewState = (int)ViewState["Count"];
                }
                CreatePostbackControls(arrViewState);
            }
        }

        private void CreatePostbackControls(int _arrViewState)
        {
            if (_arrViewState != null)
            {
                for (int j = 1; j <= _arrViewState; j++)
                {
                    string _id = j.ToString();
                    TableRow tr = new TableRow();
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    TableCell tc3 = new TableCell();
                    TableCell tc4 = new TableCell();
                    DropDownList ddlProduct = new DropDownList();
                    ddlProduct.ID = "ddlProductName_" + _id;
                    ddlProduct.SelectedIndexChanged += ddlProductsName_SelectedIndexChanged;
                    SalesLib purchaseDetails = new SalesLib();
                    ddlProduct.DataSource = purchaseDetails.GetProductNames();
                    ddlProduct.DataTextField = "productName";
                    ddlProduct.DataValueField = "productID";
                    ddlProduct.DataBind();
                    ddlProduct.Items.Insert(0, new ListItem("-Please Select Product-", ""));
                    ddlProduct.AutoPostBack = true;
                    ddlProduct.EnableViewState = true;
                    tc1.Controls.Add(ddlProduct);
                    tr.Controls.Add(tc1);
                    Label lblAvailableQuantityValue = new Label();
                    lblAvailableQuantityValue.ID = "lblAvailableQuantityValue_" + _id;
                    lblAvailableQuantityValue.EnableViewState = true;
                    tc2.Controls.Add(lblAvailableQuantityValue);
                    tr.Controls.Add(tc2);
                    TextBox txtQuantity = new TextBox();
                    txtQuantity.ID = "txtQuantity_" + _id;
                    txtQuantity.EnableViewState = true;
                    tc3.Controls.Add(txtQuantity);
                    tr.Controls.Add(tc3);
                    TextBox txtPrice = new TextBox();
                    txtPrice.ID = "txtPrice_" + _id;
                    txtPrice.EnableViewState = true;
                    tc4.Controls.Add(txtPrice);
                    tr.Controls.Add(tc4);
                    tblSales.Controls.AddAt(4+j, tr);
                }
            }
        }


        private int arrViewState = 0;
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            arrViewState += 1;
            string _id = arrViewState.ToString();
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();
            TableCell tc2 = new TableCell();
            TableCell tc3 = new TableCell();
            TableCell tc4 = new TableCell();
            DropDownList ddlProduct = new DropDownList();
            ddlProduct.ID = "ddlProductName_" + _id;
            ddlProduct.SelectedIndexChanged += ddlProductsName_SelectedIndexChanged;
            SalesLib purchaseDetails = new SalesLib();
            ddlProduct.DataSource = purchaseDetails.GetProductNames();
            ddlProduct.DataTextField = "productName";
            ddlProduct.DataValueField = "productID";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("-Please Select Product-", ""));
            ddlProduct.AutoPostBack = true;
            ddlProduct.EnableViewState = true;
            tc1.Controls.Add(ddlProduct);
            tr.Controls.Add(tc1);
            Label lblAvailableQuantityValue = new Label();
            lblAvailableQuantityValue.ID = "lblAvailableQuantityValue_" + _id;
            lblAvailableQuantityValue.EnableViewState = true;
            tc2.Controls.Add(lblAvailableQuantityValue);
            tr.Controls.Add(tc2);
            TextBox txtQuantity = new TextBox();
            txtQuantity.ID = "txtQuantity_" + _id;
            txtQuantity.EnableViewState = true;
            tc3.Controls.Add(txtQuantity);
            tr.Controls.Add(tc3);
            TextBox txtPrice = new TextBox();
            txtPrice.ID = "txtPrice_" + _id;
            txtPrice.EnableViewState = true;
            tc4.Controls.Add(txtPrice);
            tr.Controls.Add(tc4);
            tblSales.Controls.AddAt(4+arrViewState, tr);
            ViewState["Count"] = arrViewState;
        }

        private void ddlProductsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int j = 1; j <= (int)ViewState["Count"]; j++)
            {
                DropDownList ProductName = (DropDownList)tblSales.FindControl("ddlProductName_" + j);
                Label AvailableQuantity = (Label)tblSales.FindControl("lblAvailableQuantityValue_" + j);
                if (ProductName.SelectedValue == string.Empty)
                    AvailableQuantity.Text = string.Empty;
                else
                {
                    SalesLib salesDetails = new SalesLib();
                    salesDetails.productId = Convert.ToInt32(ProductName.SelectedValue);
                    AvailableQuantity.Text = salesDetails.GetAvailableQuantity().ToString();
                }
            }
        }

        private void FillGridView()
        {
            SalesLib salesDetails = new SalesLib();
            gvSalesData.DataSource = salesDetails.GetSalesDetails();
            gvSalesData.DataBind();
        }

        private void BindProductName()
        {
            SalesLib purchaseDetails = new SalesLib();
            ddlProductName_0.DataSource = purchaseDetails.GetProductNames();
            ddlProductName_0.DataTextField = "productName";
            ddlProductName_0.DataValueField = "productID";
            ddlProductName_0.DataBind();
            ddlProductName_0.Items.Insert(0, new ListItem("-Please Select Product-", ""));
        }

        

        protected void btnAddUpdateOrder_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == string.Empty)
            {
                lblError.Text = "Please select Customer Name.";
                return;
            }
            if (txtDate.Text == string.Empty)
            {
                lblError.Text = "Please enter Date.";
                return;
            }

            for (int j = 0; j <= arrViewState; j++)
            {
                DropDownList ProductName = (DropDownList)tblSales.FindControl("ddlProductName_" + j);
                Label AvailableQuantity = (Label)tblSales.FindControl("lblAvailableQuantityValue_" + j);
                TextBox Quantity = (TextBox)tblSales.FindControl("txtQuantity_" + j);
                TextBox Price = (TextBox)tblSales.FindControl("txtPrice_" + j);
                if (ProductName.SelectedValue == string.Empty)
                {
                    lblError.Text = "Please select Product Name.";
                    return;
                }
                if (Quantity.Text == string.Empty)
                {
                    lblError.Text = "Please enter Quantity.";
                    return;
                }
                if (Price.Text == string.Empty)
                {
                    lblError.Text = "Please enter Price.";
                    return;
                }
                if (Convert.ToInt32(Quantity.Text) > Convert.ToInt32(AvailableQuantity.Text))
                {
                    lblError.Text = "Quantity should be less than Available Quantity";
                    return;
                }
            }

            SalesLib salesDetails = new SalesLib();
            salesDetails.orderId = lblOrderIDValue.Text == "" ? 0 : Convert.ToInt32(lblOrderIDValue.Text);
            salesDetails.customerName = txtCustomerName.Text;
            salesDetails.date = Convert.ToDateTime(txtDate.Text);
            salesDetails.saleID = hdnfSaleId.Value == "" ? 0 : Convert.ToInt32(hdnfSaleId.Value);

            DataTable sales = new DataTable();
            sales.Columns.Add(new DataColumn("productId", typeof(int)));
            sales.Columns.Add(new DataColumn("quantity", typeof(int)));
            sales.Columns.Add(new DataColumn("price", typeof(decimal)));

            for (int j = 0; j <= arrViewState; j++)
            {
                DropDownList ProductName = (DropDownList)tblSales.FindControl("ddlProductName_" + j);
                Label AvailableQuantity = (Label)tblSales.FindControl("lblAvailableQuantityValue_" + j);
                TextBox Quantity = (TextBox)tblSales.FindControl("txtQuantity_" + j);
                TextBox Price = (TextBox)tblSales.FindControl("txtPrice_" + j);

                sales.Rows.Add(Convert.ToInt32(ProductName.SelectedValue), Convert.ToInt32(Quantity.Text), Convert.ToDecimal(Price.Text));
            }

            lblOrderIDValue.Text = salesDetails.AddUpdateSales(sales).ToString();
            FillGridView();
            lblError.Text = string.Empty;
        }

        
        protected void gvSalesData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvSalesData, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void gvSalesData_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvSalesData.Rows)
            {
                if (row.RowIndex == gvSalesData.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    EditSalesDetails(row);
                }
                else
                {
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        private void EditSalesDetails(GridViewRow row)
        {
            for (int j = 1; j <= arrViewState; j++)
                tblSales.Controls.RemoveAt(5);
            ViewState["Count"] = null;
            arrViewState = 0;
            hdnfSaleId.Value = row.Cells[0].Text;
            lblOrderIDValue.Text = row.Cells[1].Text;
            txtDate.Text = row.Cells[2].Text;
            ddlProductName_0.SelectedValue = row.Cells[3].Text;
            txtCustomerName.Text = row.Cells[4].Text;
            txtQuantity_0.Text = row.Cells[6].Text;
            txtPrice_0.Text = row.Cells[7].Text;
            lblError.Text = string.Empty;
            SalesLib purchaseDetails = new SalesLib();
            purchaseDetails.productId = Convert.ToInt32(ddlProductName_0.SelectedValue);
            lblAvailableQuantityValue_0.Text = purchaseDetails.GetAvailableQuantity().ToString();
        }

        protected void btnNewOrder_Click(object sender, EventArgs e)
        {
            lblOrderIDValue.Text = string.Empty;
            txtDate.Text = string.Empty;
            ddlProductName_0.SelectedValue = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtQuantity_0.Text = string.Empty;
            txtPrice_0.Text = string.Empty;
            lblAvailableQuantityValue_0.Text = string.Empty;
            for (int j = 1; j <= arrViewState; j++)
                tblSales.Controls.RemoveAt(5);
            ViewState["Count"] = null;
            arrViewState = 0;
            lblError.Text = string.Empty;
        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProductName_0.SelectedValue == string.Empty)
                lblAvailableQuantityValue_0.Text = string.Empty;
            else
            {
                SalesLib salesDetails = new SalesLib();
                salesDetails.productId = Convert.ToInt32(ddlProductName_0.SelectedValue);
                lblAvailableQuantityValue_0.Text = salesDetails.GetAvailableQuantity().ToString();
            }
        }
    }
}