<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="PrimePay2.Edit" %>

<!DOCTYPE html>

<link rel="stylesheet" type="text/css" href="addCSS.css" />  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" >First Name</asp:Label>
        <asp:TextBox runat="server" ID="first_name"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server" >Last Name</asp:Label>
        <asp:TextBox runat="server" ID="last_name"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server" >Email</asp:Label>
        <asp:TextBox runat="server" ID="email"></asp:TextBox>
        <br />
        <br />
        <asp:Label runat="server" >Phone Number</asp:Label>
        <asp:TextBox runat="server" ID="phone"></asp:TextBox>
        <br />
        <br />
        <asp:Button runat="server" Text="Change" ID="addButton" OnClick="submitEventMethod" />
        <asp:Button runat="server" Text="Cancel" ID="cancelButton" OnClick="cancelEventMethod" />
        <div runat="server" id="errorDiv">
        </div>
    </form>
</body>
</html>
