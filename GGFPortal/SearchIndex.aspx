<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchIndex.aspx.cs" Inherits="GGFPortal.SearchIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Ship/Search/Search001.aspx">船務</asp:LinkButton>
    
    </div>
        <div>
            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Ship/Search/Search002.aspx">工讀生</asp:LinkButton>
        </div>
    </form>
</body>
</html>
