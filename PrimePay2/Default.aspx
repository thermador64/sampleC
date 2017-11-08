<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimePay2.Default" %>

<!DOCTYPE html>
<link rel="stylesheet" type="text/css" href="pageCSS.css" />  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button runat="server" Text="Add Contact" ID="addButton" OnClick="addEventMethod" />
        <asp:Table runat="server" ID="contactList"></asp:Table>
        <div id="myDiv" runat="server">
        </div>
    </form>
</body>
</html>
