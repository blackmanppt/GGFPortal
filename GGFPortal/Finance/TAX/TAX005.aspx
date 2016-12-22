<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX005.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX005" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>進項稅額折抵</title>
    <style type="text/css">
        .auto-style1 {
            width: 82px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="銷貨稅額沖銷批次作業" style="font-size: xx-large; background-color: #00CCFF"></asp:Label>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
        <table style="width:800px;">
            <tr>
                <td class="auto-style1" style="text-align: right">
                    <asp:Label ID="Label1" runat="server" Text="結轉月份："></asp:Label>
                </td>
                <td>                        <asp:DropDownList ID="MonthDDL" runat="server">
                        </asp:DropDownList>

                    </td>
                <td>
                    <asp:Button ID="SearchBT" runat="server" Text="搜尋" OnClick="SearchBT_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="SettlementBT" runat="server" Text="結轉" OnClick="SettlementBT_Click" Enabled="False" />
                </td>
            </tr>
        </table>
    
    </div>
    <div>
    
        <asp:GridView ID="SearchGV" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Button ID="SelectAllBT" runat="server" OnClick="SelectAllBT_Click" Text="全選" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
