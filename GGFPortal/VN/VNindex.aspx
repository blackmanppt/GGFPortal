<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VNindex.aspx.cs" Inherits="GGFPortal.VN.VNindex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 85px;
            background-color: #00CCFF;
        }
table, td, th {
    border: 1px solid black;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
        <table style="width:400px;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="資料查詢："></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/VN/VN001.aspx">Style No 查詢</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="資料匯入："></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Cut">裁剪</asp:LinkButton><br/>
                    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Stitch">車縫</asp:LinkButton><br/>
                    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=QC">品檢</asp:LinkButton><br/>
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Iron">整燙</asp:LinkButton><br/>
                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/VN/VN002.aspx?AREA=VGG&TYPE=Package">包裝</asp:LinkButton>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
            <td class="auto-style2">
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
   
    </div>
    </form>
</body>
</html>
