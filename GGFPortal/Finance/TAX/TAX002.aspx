<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX002.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX002" %>

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
        .auto-style3 {
            width: 80px;
            text-align: right;
            height: 20px;
        }
        .auto-style4 {
            width: 89px;
            height: 20px;
        }
        .auto-style5 {
            height: 20px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
    
        <table style="width:800px; height: 600px;">
            <tr style=" height: 20px">
                <td colspan="4" style="text-align: center;" >
    
        <asp:Label ID="TitleLB0" runat="server" BackColor="#00CCFF" Font-Size="XX-Large" Text="包裝底稿結轉"></asp:Label>
    
                </td>
            </tr>
            <tr style=" height: 20px">
                <td style="text-align: right" >
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
            <tr>
                <td class="auto-style3">
                </td>
                <td class="auto-style4"></td>
                <td class="auto-style5">
                    <asp:Button ID="ConvertBT" runat="server" Text="結轉" OnClick="ConvertBT_Click" />
                </td>
                <td class="auto-style5"></td>
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
                                    <asp:BoundField DataField="site" HeaderText="公司別" />
                                    <asp:BoundField DataField="pak_nbr" HeaderText="包裝單號" />
                                    <asp:BoundField DataField="cabinet_no" HeaderText="櫃號" />
                                    <asp:BoundField DataField="dta_date" HeaderText="ETA" />
                                    <asp:BoundField DataField="etd_date" HeaderText="ETD" />
                                    <asp:BoundField DataField="decl_no" HeaderText="報關號碼" />
                                    <asp:BoundField DataField="bol_no" HeaderText="提單" />
                                    <asp:BoundField DataField="vendor_name" HeaderText="代工廠" />
                                    <asp:BoundField DataField="PkdSelect" HeaderText="已被挑選" />
                                    
                                    
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
                            <asp:Label ID="PackageLB" runat="server" BackColor="#00CCFF" Font-Size="X-Large" Text="未結轉資料" Visible="False"></asp:Label>
                            <asp:GridView ID="PackageGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="PackageGV_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="site" HeaderText="公司別" />
                                    <asp:BoundField DataField="pak_nbr" HeaderText="包裝單號" />
                                    <asp:BoundField DataField="cabinet_no" HeaderText="櫃號" />
                                    <asp:BoundField DataField="dta_date" HeaderText="ETA" />
                                    <asp:BoundField DataField="etd_date" HeaderText="ETD" />
                                    <asp:BoundField DataField="decl_no" HeaderText="報關號碼" />
                                    <asp:BoundField DataField="bol_no" HeaderText="提單" />
                                    <asp:BoundField DataField="vendor_name" HeaderText="代工廠" />
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

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:ModalPopupExtender ID="POPPanel_ModalPopupExtender" runat="server" TargetControlID="Show" PopupControlID="POPPanel"  CancelControlID="hide" >
                                    </ajaxToolkit:ModalPopupExtender>
                    <asp:Button ID="Show" runat="server" Text="Show" Visible="False" />


                    <asp:Panel ID="POPPanel" runat="server" style="display:none" >
                        <table style="width: 600px; height: 400px; background-color: #00FFFF;">
                            <tr>
                                <td colspan="3">


                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


                                </td>

                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="purc_pkd_acrGV" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                                        <Columns>
                                    <asp:BoundField DataField="site" HeaderText="公司別" />
                                    <asp:BoundField DataField="pak_nbr" HeaderText="包裝單號" />
                                    <asp:BoundField DataField="cabinet_no" HeaderText="櫃號" />
                                    <asp:BoundField DataField="dta_date" HeaderText="ETA" />
                                    <asp:BoundField DataField="etd_date" HeaderText="ETD" />
                                    <asp:BoundField DataField="vendor_name" HeaderText="代工廠" />
                                    <asp:BoundField DataField="PkdSelect" HeaderText="已被挑選" />
                                    
                                    
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
                                </td>

                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="hide" runat="server" Text="hide" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
