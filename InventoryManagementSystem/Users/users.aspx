<%@ Page Language="C#" MasterPageFile="~/Inventory.master" AutoEventWireup="true" CodeBehind="users.aspx.cs" EnableEventValidation="false" Inherits="InventoryManagementSystem.Users.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="2" ForeColor="Blue"><h2>User Registration</h2></asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblUserID" runat="server" Text="UserID: "></asp:Label></asp:TableCell>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblUserIDValue" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblFirstName" runat="server" Text="FirstName:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblLastName" runat="server" Text="LastName:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblEmailId" runat="server" Text="EmailId:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblMobileNumber" runat="server" Text="MobileNumber:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblAddress1" runat="server" Text="Address1:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblAddress2" runat="server" Text="Address2:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblPinCode" runat="server" Text="PinCode:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="txtPinCode" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <br />
                <asp:Button ID="btnAddUser" Font-Bold="true" ForeColor="Green" runat="server" Text="Add User" OnClick="btnAddUser_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNewUser" runat="server" Font-Bold="true" ForeColor="Green" Text="New User" OnClick="btnNewUser_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <br />
    <div style="height:20px">
        <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
    </div>
        <div style="color:blue;">
            <h2>Users List</h2>
        </div>
        <div class="gridview1">
            <asp:GridView ID="gvUsersData" OnRowDataBound="gvUsersData_RowDataBound" OnSelectedIndexChanged="gvUsersData_SelectedIndexChanged" HeaderStyle-BackColor="RoyalBlue" HeaderStyle-ForeColor="White" AutoGenerateColumns="false" runat="server" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="userID" HeaderText="User ID" />
                    <asp:BoundField DataField="firstName" HeaderText="First Name" />
                    <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="emailId" HeaderText="Email ID" />
                    <asp:BoundField DataField="mobileNumber" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="password" HeaderText="Password" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                    <asp:BoundField DataField="address1" HeaderText="Address1" />
                    <asp:BoundField DataField="address2" HeaderText="Address2" />
                    <asp:BoundField DataField="pincode" HeaderText="Pincode" />
                </Columns>
            </asp:GridView>
        </div>
    
</asp:Content>
