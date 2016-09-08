<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search002.aspx.cs" Inherits="GGFPortal.Ship.Search.Search002" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Search ACP</title>
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
            
            <asp:Label ID="Label1" runat="server" Text="搜尋應付資料(含以應負)" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            
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
                    <td class="auto-style3"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="應付單號："></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="ACPTB" runat="server" Height="69px" TextMode="MultiLine" Width="209px"></asp:TextBox>
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
                        <asp:Button ID="Search" runat="server" Text="Search" />
                    </td>
                </tr>
            </table>
        </div>
        <div >

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="50" BorderStyle="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="style_no" HeaderText="style_no" SortExpression="style_no" />
                    <asp:BoundField DataField="數量" HeaderText="數量" SortExpression="數量" />
                    <asp:BoundField DataField="單價" HeaderText="單價" SortExpression="單價" />
                    <asp:BoundField DataField="明細金額" HeaderText="明細金額" SortExpression="明細金額" />
                    <asp:BoundField DataField="pur_nbr" HeaderText="pur_nbr" ReadOnly="True" SortExpression="pur_nbr" />
                    <asp:BoundField DataField="acp_nbr" HeaderText="acp_nbr" SortExpression="acp_nbr" />
                    <asp:BoundField DataField="acp_seq" HeaderText="acp_seq" SortExpression="acp_seq" />
                    <asp:BoundField DataField="料品代號" HeaderText="料品代號" SortExpression="料品代號" />
                    <asp:BoundField DataField="立帳幣別" HeaderText="立帳幣別" SortExpression="立帳幣別" />
                    <asp:BoundField DataField="unit" HeaderText="unit" SortExpression="unit" />
                    <asp:BoundField DataField="remark40" HeaderText="remark40" SortExpression="remark40" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" 
                SelectCommand="select style_no, acp_qty AS 數量, unit_price AS 單價, detail_amt AS 明細金額, CASE WHEN pur_nbr IS NULL THEN '' ELSE pur_nbr END AS pur_nbr, acp_nbr, acp_seq, item_no AS 料品代號, offset_currency AS 立帳幣別 ,unit,remark40 FROM dbo.acp_trn WHERE      ( ( (kind = 'AP18') AND (transaction_class = 15)) OR ((kind = 'AP01') AND (transaction_class = 01))) ORDER BY [acp_nbr]">

            </asp:SqlDataSource>



        </div>

    </form>
</body>
</html>