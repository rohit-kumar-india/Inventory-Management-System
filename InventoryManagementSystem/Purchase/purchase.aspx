<%@ Page Title="" Language="C#" MasterPageFile="~/Inventory.Master" AutoEventWireup="true" CodeBehind="purchase.aspx.cs" EnableEventValidation="false" Inherits="InventoryManagementSystem.Purchase.purchase" %>

<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(function() {

            $("#txtDate").datepicker();

        });  

    </script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" ForeColor="Blue"><h2>Purchase Details</h2></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblPurchaseID" runat="server" Text="PurchaseID: "></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblPurchaseIDValue" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddlProductName" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblAvailableQuantity" runat="server" Text="Available Quantity:"></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblAvailableQuantityValue" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblCompanyName" runat="server" Text="Company Name:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="ddlCompanyName" runat="server"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtDate" TextMode="DateTime" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <br />
                <asp:Button ID="btnAddUpdatePurchase" Font-Bold="true" ForeColor="Green" runat="server" Text="Save" OnClick="btnAddUpdatePurchase_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNewPurchase" runat="server" Text="New Purchase" OnClick="btnNewPurchase_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <br />
    <div style="height:20px">
        <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
    </div>
        <div style="color:blue;">
            <h2>Purchase List</h2>
        </div>
        <div class="gridview1">
            <asp:GridView ID="gvPurchaseData" runat="server" HeaderStyle-BackColor="RoyalBlue" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" OnRowDataBound="gvPurchaseData_RowDataBound" OnSelectedIndexChanged="gvPurchaseData_SelectedIndexChanged" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="productId" HeaderText="Product Id" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                    <asp:BoundField DataField="supplierId" HeaderText="Supplier Id" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="purchaseID" HeaderText="Purchase ID" />
                    <asp:BoundField DataField="productName" HeaderText="Product Name" />
                    <asp:BoundField DataField="companyName" HeaderText="Company Name" />
                    <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
