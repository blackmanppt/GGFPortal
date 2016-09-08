<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance002.aspx.cs" Inherits="GGFPortal.Finance.Finance002" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 20px;
            width: 100px;
            text-align: right;
            background-color: #3399FF;
        }
        .auto-style3 {
            width: 100px;
            text-align: right;
            background-color: #3399FF;
        }
        .auto-style4 {
            height: 20px;
            width: 180px;
        }
        .auto-style5 {
            width: 180px;
        }
        .auto-style6 {
            width: 102px;
            text-align: right;
            background-color: #0099FF;
        }
        .auto-style7 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
            <asp:Label ID="TitleLB" runat="server" Text="應付檢查表"></asp:Label>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </h1>
    
    </div>
    <div>
        <table style="width:600px;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="SiteLB" runat="server" Text="公司別："></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="SiteDDL" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>GGF</asp:ListItem>
                        <asp:ListItem>TCL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="ETAETDLB" runat="server" Text="ETA/ETD為0："></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>ETA</asp:ListItem>
                        <asp:ListItem>ETD</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="RecDateLB" runat="server" Text="入庫日期："></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="StartDayTB" runat="server" Width="70px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd" />
                    ~
                    <asp:TextBox ID="EndDayTB" runat="server" Width="70px"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" TargetControlID="EndDayTB" Format="yyyyMMdd"  />
                </td>
                <td class="auto-style6">
                    <asp:Label ID="ItemLB" runat="server" Text="主/副料："></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>主料</asp:ListItem>
                        <asp:ListItem>副料</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="NationLB" runat="server" Text="產區："></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="NationDDL" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="AcpStatusLB" runat="server" Text="付款狀態："></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>已付</asp:ListItem>
                        <asp:ListItem>未付</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td class="auto-style3">
                    <asp:Label ID="FactoryLB" runat="server" Text="代工廠："></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="FactoryDDL" runat="server">
                    </asp:DropDownList>
                 </td>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="VendorLB" runat="server" Text="供應商代號："></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="VendorTB" runat="server"></asp:TextBox>
                 </td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style7">
                    <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" />
                    <asp:Button ID="ExportBT" runat="server" OnClick="ExportBT_Click" Text="Export" />
                </td>
            </tr>
        </table>
    </div>
        <div>

            <asp:GridView ID="ACPGV" runat="server" AllowPaging="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>

        </div>
    </form>

</body>
</html>
