<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VN006.aspx.cs" Inherits="GGFPortal.VN.VN006" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>工時匯入狀況查詢</title>
    <style type="text/css">
        
        .auto-style3 {
            text-align: left;
            height: 23px;
        }

        .auto-style4 {
            text-align: left;
            height: 23px;
            width: 348px;
        }

        .auto-style6 {
            text-align: right;
            height: 23px;
            width: 112px;
        }

        .auto-style8 {
            width: 348px;
        }
        .auto-style9 {
            width: 112px;
            text-align: right;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../../themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../demo.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.easyui-1.4.5.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="工時匯入狀況查詢" Font-Bold="True" Font-Size="X-Large" Style="color: #66FF66; background-color: #339966"></asp:Label>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

        </div>
        <div>
            <table style="width: 600px;">
                <tr>
                    <th class="auto-style6">
                        <asp:Label ID="Label2" runat="server" Text="匯入日期："></asp:Label>
                    </th>
                    <td class="auto-style4">
                        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd" />
                        ~<asp:TextBox ID="EndDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" TargetControlID="EndDayTB" Format="yyyyMMdd" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="Export" runat="server" OnClick="Export_Click" Text="Export" />
                        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
                    </td>
                </tr>
                <tr>
                    <th class="auto-style9">
                        <asp:Label ID="Label3" runat="server" Text="狀態："></asp:Label></th>
                    <td class="auto-style8">
                        <asp:DropDownList ID="FlagDDL" runat="server">
                            <asp:ListItem Value="%">全部</asp:ListItem>
                            <asp:ListItem Value="1">未刪除</asp:ListItem>
                            <asp:ListItem Value="2">刪除</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <th>

                    </th>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" AllowPaging="True" PageSize="20" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="uid">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="uid" HeaderText="uid" SortExpression="uid" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="MappingData" HeaderText="部門" SortExpression="MappingData" />
                    <asp:BoundField DataField="狀態" HeaderText="狀態" SortExpression="狀態" ReadOnly="True" />
                    <asp:BoundField DataField="CreateDate" HeaderText="建立日期" SortExpression="CreateDate" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="ModifyDate" HeaderText="最後修改日期" SortExpression="ModifyDate" DataFormatString="{0:d}" />
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT a.uid,a.Date, b.MappingData, CASE WHEN a.Flag = 1 THEN N'新增' WHEN a.Flag = 2 THEN N'刪除' ELSE '' END AS '狀態', a.CreateDate, a.ModifyDate FROM Productivity_Head AS a LEFT OUTER JOIN Mapping AS b ON a.Team = b.Data AND b.UsingDefine = 'Productivity' WHERE (a.Flag > 0) ORDER BY a.Date" DeleteCommand="UPDATE Productivity_Head SET Flag = 2 WHERE (1 = 2)">

            </asp:SqlDataSource>



        </div>

    </form>
</body>
</html>
