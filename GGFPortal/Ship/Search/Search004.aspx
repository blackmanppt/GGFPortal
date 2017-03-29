<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search004.aspx.cs" Inherits="GGFPortal.Ship.Search.Search004" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>包裝底稿狀況查詢</title>
    <style type="text/css">
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            text-align: left;
            height: 23px;
        }
    </style>
        <link rel="stylesheet" type="text/css" href="../../themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../../themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../demo.css"/>
    <script type="text/javascript" src="../Scripts/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.easyui-1.4.5.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div  >
            
            <asp:Label ID="Label1" runat="server" Text="包裝底稿狀況查詢" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            
        </div>
        <div  >
            <table style="width:400px;" >
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="包裝底稿號碼："></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="PakSearchTB" runat="server" Height="86px" TextMode="MultiLine" Width="209px"></asp:TextBox>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="入庫單號："></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="RecTB" runat="server" Height="69px" TextMode="MultiLine" Width="209px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="Export" runat="server" OnClick="Export_Click" Text="Export" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Style no："></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="StyleNoSeachTB" runat="server" Height="60px" TextMode="MultiLine" Width="209px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div >

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" AllowPaging="True" PageSize="20">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="pak_nbr" HeaderText="pak_nbr" SortExpression="pak_nbr" />
                    <asp:BoundField DataField="cus_item_no" HeaderText="cus_item_no" SortExpression="cus_item_no" />
                    <asp:BoundField DataField="rec_nbr" HeaderText="rec_nbr" SortExpression="rec_nbr" />
                    <asp:BoundField DataField="eta" HeaderText="eta" SortExpression="eta" />
                    <asp:BoundField DataField="etc_date" HeaderText="etc_date" SortExpression="etc_date" />
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select a.pak_nbr,a.cus_item_no,a.rec_nbr,b.dta_date as eta,b.etc_date from purc_pkd a left join purc_pkm b on a.site=b.site and a.pak_nbr=b.pak_nbr ">

            </asp:SqlDataSource>



        </div>

    </form>
</body>
</html>