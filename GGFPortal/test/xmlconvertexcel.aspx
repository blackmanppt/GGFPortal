<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xmlconvertexcel.aspx.cs" Inherits="GGFPortal.test.xmlconvertexcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
                <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
        <asp:GridView ID="GridView4" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
