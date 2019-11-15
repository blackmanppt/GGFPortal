<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormHR.aspx.cs" Inherits="GGFPortal.test.WebFormHR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem>12/1 加班三小時</asp:ListItem>
<asp:ListItem>12/2 加班一小時</asp:ListItem>
<asp:ListItem>12/5 加班二小時</asp:ListItem>
<asp:ListItem>12/10 加班四小時</asp:ListItem>
<asp:ListItem>12/11 加班四小時</asp:ListItem>
<asp:ListItem>12/20 加班四小時</asp:ListItem>

        </asp:CheckBoxList>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
    </div>
    </form>
</body>
</html>
