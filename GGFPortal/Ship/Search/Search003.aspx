<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search003.aspx.cs" Inherits="GGFPortal.Ship.Search.Search003" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>採購入庫狀況查詢</title>
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
            
            <asp:Label ID="Label1" runat="server" Text="採購入庫狀況查詢" Font-Bold="True" Font-Size="X-Large" style="color: #FFCC66; background-color: #3333FF"></asp:Label>
            
        </div>
        <div  >
            <table style="width:400px;" >
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="採購單號："></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="PurSearchTB" runat="server" Height="86px" TextMode="MultiLine" Width="209px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
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
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="公司別"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="SiteDDL" runat="server">
                            <asp:ListItem>ALL</asp:ListItem>
                            <asp:ListItem>GGF</asp:ListItem>
                            <asp:ListItem>TCL</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div >

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" AllowPaging="True" PageSize="20">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="site" HeaderText="site" SortExpression="site" />
                    <asp:BoundField DataField="cus_item_no" HeaderText="cus_item_no" SortExpression="cus_item_no" />
                    <asp:BoundField DataField="pur_nbr" HeaderText="pur_nbr" SortExpression="pur_nbr" />
                    <asp:BoundField DataField="exchange_rate" HeaderText="exchange_rate" SortExpression="exchange_rate" />
                    <asp:BoundField DataField="org_item_no" HeaderText="org_item_no" SortExpression="org_item_no" />
                    <asp:BoundField DataField="item_name" HeaderText="item_name" SortExpression="item_name" />
                    <asp:BoundField DataField="pur_unit" HeaderText="pur_unit" SortExpression="pur_unit" />
                    <asp:BoundField DataField="pur_price" HeaderText="pur_price" SortExpression="pur_price" />
                    <asp:BoundField DataField="採購數量" HeaderText="採購數量" ReadOnly="True" SortExpression="採購數量" />
                    <asp:BoundField DataField="入庫數量" HeaderText="入庫數量" ReadOnly="True" SortExpression="入庫數量" />
                    <asp:BoundField DataField="是否轉三角" HeaderText="是否轉三角" ReadOnly="True" SortExpression="是否轉三角" />
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select x.site,x.cus_item_no,x.pur_nbr,x.exchange_rate,x.org_item_no,y.item_name,x.pur_unit,x.pur_price,sum(x.pur_qty) as 採購數量,sum(x.rqty) as 入庫數量,case when x.chn_yn='Y' then '是' else '否' end as 是否轉三角  from ( select a.site, a.cus_item_no,b.pur_nbr,c.pur_seq,b.exchange_rate,c.org_item_no, c.pur_qty ,c.pur_unit,c.pur_price , sum(d.rec_qty) as rqty,b.chn_yn from ordc_bah1 a left join purc_purchase_master b on a.site=b.site and a.ord_nbr=b.ord_nbr left join purc_purchase_detail c on b.site=c.site and b.pur_nbr=c.pur_nbr left join purc_receive_detail d on c.site=d.site and c.pur_nbr=d.pur_nbr and c.pur_seq=d.pur_seq where a.bah_status<>'CA' and b.pur_head_status<>'CA' and c.org_item_no is not null and b.chn_yn<>'Y' and c.pur_detail_status<>'CA' and d.rec_detail_status<>'CA' group by  a.cus_item_no,b.pur_nbr,c.pur_seq,b.exchange_rate,c.org_item_no ,c.site,c.pur_unit,c.pur_price,a.site,c.pur_qty,b.chn_yn ) as x left join bas_item_master y on x.site=y.site and x.org_item_no=y.item_no group by x.site,cus_item_no,pur_nbr,exchange_rate,org_item_no,pur_unit,pur_price,y.item_name,chn_yn">
            </asp:SqlDataSource>
        </div>

    </form>
</body>
</html>