<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory.Master" AutoEventWireup="true" CodeBehind="sales.aspx.cs" EnableEventValidation="false" Inherits="InventoryManagementSystem.Sales.sales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="tblSales" runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="4" ForeColor="Blue"><h2>Sales Details</h2></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell><asp:HiddenField ID="hdnfSaleId" runat="server" Value=""></asp:HiddenField></asp:TableCell>
            <asp:TableHeaderCell HorizontalAlign="right"><asp:Label ID="lblOrderID" runat="server" Text="Order ID: "></asp:Label></asp:TableHeaderCell>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblOrderIDValue" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell><asp:Label ID="lblCustomerName" runat="server" Text="Customer Name:"></asp:Label></asp:TableHeaderCell>
            <asp:TableCell><asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableHeaderCell><asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label></asp:TableHeaderCell>
            <asp:TableCell><asp:TextBox ID="txtDate" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableHeaderCell><asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label></asp:TableHeaderCell>
            <asp:TableHeaderCell><asp:Label ID="lblAvailableQuantity" runat="server" Text="Available Quantity"></asp:Label></asp:TableHeaderCell>
            <asp:TableHeaderCell><asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label></asp:TableHeaderCell>
            <asp:TableHeaderCell><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell><asp:DropDownList ID="ddlProductName_0" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged"></asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:Label ID="lblAvailableQuantityValue_0" runat="server" Text=""></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtQuantity_0" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtPrice_0" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"></asp:TableCell>
            
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4">
                <br />
                <asp:Button ID="btnAddUpdateOrder" Font-Bold="true" ForeColor="Green" runat="server" Text="Save" OnClick="btnAddUpdateOrder_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNewOrder" runat="server" Font-Bold="true" ForeColor="Green" Text="New Order" OnClick="btnNewOrder_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAddProduct" runat="server" Font-Bold="true" ForeColor="Green" Text="Add Product" OnClick="btnAddProduct_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <div style="height:20px">
        <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
    </div>
        <div style="color:blue;">
            <h2>Sales List</h2>
        </div>
        <div class="gridview1">
            <asp:GridView ID="gvSalesData" runat="server" HeaderStyle-BackColor="RoyalBlue" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" OnRowDataBound="gvSalesData_RowDataBound" OnSelectedIndexChanged="gvSalesData_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="saleID" HeaderText="Sale Id" />
                    <asp:BoundField DataField="orderID" HeaderText="Order Id" />
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="productID" HeaderText="Product ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                    <asp:BoundField DataField="customerName" HeaderText="Customer Name" />
                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
