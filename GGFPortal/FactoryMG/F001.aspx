<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F001.aspx.cs" Inherits="GGFPortal.FactoryMG.F001" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Search Style No</title>
    <style type="text/css">
        .auto-style3 {
            text-align: left;
            height: 23px;
            border: 2px solid black;
        }
        .xx{
            border: 2px solid black;
        }
        
        .auto-style4 {
            text-align: right;
        }
        .auto-style5 {
            text-align: right;
            height: 23px;
            border: 2px solid black;
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
            
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
            <asp:Label ID="Label1" runat="server" Text="Style No Search" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            
        </div>
        <div  >
            <table style="border: 2px solid #000000; width:400px; border-collapse: collapse;border: 2px solid black;"  >
                <tr class="xx">
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text="預計出貨日："></asp:Label>
                    </td>
                    <td class="auto-style3">
                    <asp:TextBox ID="StartDayTB" runat="server" Width="70px" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyy-MM-dd" />
                    ~
                    <asp:TextBox ID="EndDayTB" runat="server" Width="70px" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" TargetControlID="EndDayTB" Format="yyyy-MM-dd"  />
                    </td>
                    <td class="auto-style3">
                       
                    </td>
                </tr>
                <tr class="xx">
                    <td class="auto-style4">
                        <asp:Label ID="Label3" runat="server" Text="Style No："></asp:Label>
                    </td>
                    <td>
 <asp:TextBox ID="StyleNoTB" runat="server"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo"  TargetControlID="StyleNoTB">
                    </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td> 
                        <asp:Button ID="Search" runat="server" Text="Search" />
                        <asp:Button ID="Export" runat="server" OnClick="Export_Click" Text="Export" />

                    </td>
                </tr>
               
            </table>
        </div>
        <div >

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="50" BorderStyle="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="cus_item_no" HeaderText="style_no" SortExpression="style_no" />
                    <asp:BoundField DataField="agents" HeaderText="客戶" SortExpression="客戶" />
                    <asp:BoundField DataField="brand" HeaderText="品牌" SortExpression="品牌" />
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
                SelectCommand="select distinct a.agents,b.cus_name,brand,cus_item_no from ordc_bat x left join ordc_bah1 a on x.site=a.site and x.ord_nbr=a.ord_nbr left join bas_cus_master b on a.agents=b.cus_id where  bah_status<>'CA'">

            </asp:SqlDataSource>



        </div>

    </form>
</body>
</html>