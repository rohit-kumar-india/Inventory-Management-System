<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventoryManagementSystem.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginHeader" class="headerBottomBorder">
            <h1><i>Inventory Management system</i></h1>
        </div>
        <div style="height:50px;"></div>
        <div id="loginContent">
        
        <asp:Table runat="server" HorizontalAlign="Center">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2" ForeColor="Blue"><h1>Login</h1></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblEmailId" runat="server" Text="Email Id:"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left"><asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <br />
                    <asp:Button ID="btnReset" runat="server" Font-Bold="true" ForeColor="darkred" Text="Reset" OnClick="btnReset_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLogin" runat="server" Font-Bold="true" ForeColor="#006600" Text="Login" OnClick="btnLogin_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
            <br />
            <div style="height:30px;">
            <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
        </div>
        </div>
        <div id="loginFooter">
            <h3>CopyRight@Rohit</h3>
        </div>
   </form>
</body>
</html>
 
