<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VNTimeDelete.aspx.cs" Inherits="GGFPortal.VN.VNTimeDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>工時資料刪除</title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div>
        <table>
            <tr>
                <th><asp:Label ID="Label1" runat="server" Text="工時資料刪除"></asp:Label></th>
            </tr>
            <tr>
                <th></th>
                <td></td>
            </tr>
        </table>
    
    </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1">
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>

        </div>
    </form>
</body>
</html>
