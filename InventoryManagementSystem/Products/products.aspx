<%@ Page Language="C#" MasterPageFile="~/Inventory.master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="InventoryManagementSystem.Products.products" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" ForeColor="Blue"><h2>AddProduct</h2></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblProductID" runat="server" Text="ProductID: "></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblProductIDValue" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblBrandName" runat="server" Text="Brand Name:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtBrandName" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <br />
                <asp:Button ID="btnAddUpdateProduct" Font-Bold="true" ForeColor="Green" runat="server" Text="Add Product" OnClick="btnAddUpdateProduct_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNewProduct" runat="server" Font-Bold="true" ForeColor="Green" Text="New Product" OnClick="btnNewProduct_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
        <div style="height:20px">
        <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
    </div>
        <div style="color:blue;">
            <h2>Products List</h2>
        </div>
        <div class="gridview1">
            <asp:GridView ID="gvProductsData" runat="server" HeaderStyle-BackColor="RoyalBlue" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" OnRowDataBound="gvProductsData_RowDataBound" OnSelectedIndexChanged="gvProductsData_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="productID" HeaderText="Product ID" />
                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                    <asp:BoundField DataField="brandName" HeaderText="Brand Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                    <asp:BoundField DataField="description" HeaderText="Description" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>