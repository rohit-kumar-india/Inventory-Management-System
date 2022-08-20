<%@ Page Language="C#" MasterPageFile="~/Inventory.master" AutoEventWireup="true" CodeBehind="suppliers.aspx.cs" EnableEventValidation="false" Inherits="InventoryManagementSystem.Suppliers.suppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" ForeColor="Blue"><h2>AddSuppliers</h2></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblSupplierID" runat="server" Text="SupplierID: "></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblSupplierIDValue" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblCompanyName" runat="server" Text="CompanyName:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblGSTNumber" runat="server" Text="GSTNumber:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtGSTNumber" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblMobileNo" runat="server" Text="MobileNo:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <br />
                <asp:Button ID="btnAddUpdateSupplier" Font-Bold="true" ForeColor="Green" runat="server" Text="AddSupplier" OnClick="btnAddUpdateSupplier_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNewsupplier" runat="server" Font-Bold="true" ForeColor="Green" Text="New Supplier" OnClick="btnNewsupplier_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <br />
    <div style="height:20px">
        <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
    </div>
        <div style="color:blue;">
            <h2>Suppliers List</h2>
        </div>
        <div class="gridview1">
            <asp:GridView ID="gvSuppliersData" OnRowDataBound="gvSuppliersData_RowDataBound" OnSelectedIndexChanged="gvSuppliersData_SelectedIndexChanged" HeaderStyle-BackColor="RoyalBlue" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" runat="server" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="supplierID" HeaderText="Supplier ID" />
                    <asp:BoundField DataField="companyName" HeaderText="Company Name" />
                    <asp:BoundField DataField="gstNumber" HeaderText="Gst Number" />
                    <asp:BoundField DataField="mobileno" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                </Columns>
            </asp:GridView>
        </div>
    
</asp:Content>
