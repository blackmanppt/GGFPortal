<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegexTest.aspx.cs" Inherits="GGFPortal.test.RegexTest" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>
    Input:
    <asp:TextBox ID="txtInput" runat="server" />
</p>
<p>
    Pattern:
    <asp:TextBox ID="txtPattern" runat="server" />
</p>
<p>
    <asp:Button ID="Button2" runat="server" Text="Button" />
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
</p>
<p>
    <asp:Label ID="lb" runat="server"></asp:Label>
</p>
    </div>
    </form>
</body>
</html>
