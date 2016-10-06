<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX001.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX001" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80px;
        }
        .auto-style2 {
            width: 89px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:800px; height: 600px;">
            <tr style=" height: 20px">
                <td colspan="4" style="text-align: center;" >
    
        <asp:Label ID="TitleLB" runat="server" BackColor="#00CCFF" Font-Size="XX-Large" Text="應收結轉"></asp:Label>
    
                </td>
            </tr>
            <tr style=" height: 20px">
                <td class="auto-style1">
                    <asp:Label ID="MonthLB" runat="server" Text="結轉月份："></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DateDDL" runat="server" style="margin-left: 0px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr style=" height: 20px">
                <td class="auto-style1">
                    <asp:Button ID="ConvertBT" runat="server" OnClick="ConvertBT_Click" Text="結轉" Visible="False" />
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                                    <tr style=" height: 20px">
                <td class="auto-style1">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                                        </td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                            <td>&nbsp;</td>
            </tr>

                        <tr>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="ConvertLB" runat="server" BackColor="#00CC99" BorderColor="#CC33FF" Font-Size="X-Large" Text="已結轉資料" Visible="False"></asp:Label>
                            <br />
                            <asp:Button ID="DeleteBT" runat="server" OnClick="DeleteBT_Click" Text="刪除" Visible="False" />
                            <asp:GridView ID="ConvertGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" OnPageIndexChanging="ConvertGV_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="style_no" HeaderText="Style No" />
                                    <asp:BoundField DataField="cust_po_nbr" HeaderText="客戶PO" />
                                    <asp:BoundField DataField="exchange_rate" HeaderText="匯率" />
                                    <asp:BoundField DataField="foreign_amt" HeaderText="原幣金額" />
                                    <asp:BoundField DataField="NTDPrice" HeaderText="本幣金額" />
                                    <asp:BoundField DataField="acr_nbr" HeaderText="acr_nbr" />
                                    <asp:BoundField DataField="reference_no" HeaderText="出貨單號" />
                                    <asp:BoundField DataField="CheckFlag" HeaderText="CheckFlag" />
                                    
                                </Columns>
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#33276A" />
                            </asp:GridView>
                            <asp:Label ID="AcrLB" runat="server" BackColor="#00CCFF" Font-Size="X-Large" Text="未結轉資料" Visible="False"></asp:Label>
                            <asp:GridView ID="AcrGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="AcrGV_PageIndexChanging" OnSelectedIndexChanging="AcrGV_SelectedIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="style_no" HeaderText="Style No" />
                                    <asp:BoundField DataField="cust_po_nbr" HeaderText="客戶PO" />
                                    <asp:BoundField DataField="exchange_rate" HeaderText="匯率" />
                                    <asp:BoundField DataField="foreign_amt" HeaderText="原幣金額" />
                                    <asp:BoundField DataField="NTDPrice" HeaderText="本幣金額" />
                                    <asp:BoundField DataField="acr_nbr" HeaderText="acr_nbr" />
                                    <asp:BoundField DataField="reference_no" HeaderText="出貨單號" />
                                    <asp:BoundField DataField="CheckFlag" HeaderText="CheckFlag" />
                                </Columns>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                            </td>
            </tr>
        </table>
    
    </div>
        <div>
        </div>
    </form>
</body>
</html>
