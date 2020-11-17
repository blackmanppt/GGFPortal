<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search001.aspx.cs" Inherits="GGFPortal.Ship.Search.Search001" %>


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
      <script src="~/scripts/jquery-3.4.1.min.js"></script>
    <script src="~/scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.js"></script>
    <link href="~/scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.css" rel="stylesheet" />
    <script src="~/scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>
    <link href="~/scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="h2" >
            
            <asp:Label ID="Label1" runat="server" Text="應付資料搜尋" Font-Bold="True" Font-Size="X-Large" CssClass=""></asp:Label>
            
        </div>
        <div  >
            <table style="width:800px;" class="table table-active" >
                <tr>
                    <td>
                        <div class="row align-items-center">
                            <div class="col-3 text-right h4">
                                <asp:Label ID="Label2" runat="server" Text="採購單號："></asp:Label>
                            </div>
                            <div class="col-3">
                                 <asp:TextBox ID="PurSearchTB" runat="server" TextMode="MultiLine"  CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-3 text-right h4">
                                <asp:Label ID="Label3" runat="server" Text="應付單號："></asp:Label>
                            </div>
                            <div class="col-3">
                                 <asp:TextBox ID="ACPTB" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    

                </tr>
                <tr>
<td>
    <div class="row align-items-center">
        <div class="col-3  text-right h4">
                        <asp:Label ID="Label4" runat="server" Text="Style no："></asp:Label>
        </div>
        <div class="col-3">
            <asp:TextBox ID="StyleNoSeachTB" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-6 text-right align-items-end">
             <div class="form-group btn-group">
                        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click"  CssClass="btn btn-primary"/>
                        <asp:Button ID="Export" runat="server" OnClick="Export_Click" Text="Export" CssClass="btn btn-outline-danger" />
                            </div>
        </div>
    </div>
</td>

                       
                </tr>
                
            </table>
        </div>
        <div >

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" AllowPaging="True" PageSize="20" CssClass="table table-active">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [ViewACP]  ORDER BY [acp_nbr]">

            </asp:SqlDataSource>



        </div>

    </form>
</body>
</html>