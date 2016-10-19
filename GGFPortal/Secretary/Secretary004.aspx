<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secretary004.aspx.cs" Inherits="GGFPortal.Secretary.Secretary004" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>出口資料查詢</title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }

        .auto-style2 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="產區資料查詢"></asp:Label>
            <table style="width: 400px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="輸入客戶資訊："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="SearchTB" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="搜尋月份："></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DateDDL" runat="server" Style="margin-left: 0px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="PhoneGV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
