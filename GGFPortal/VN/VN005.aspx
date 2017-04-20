<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VN005.aspx.cs" Inherits="GGFPortal.VN.VN005" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Kiểm tra tình trạng nhập giờ làm việc</title>
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

            <asp:Label ID="Label1" runat="server" Text="Kiểm tra tình trạng nhập giờ làm việc" Font-Bold="True" Font-Size="X-Large" Style="color: #66FF66; background-color: #339966"></asp:Label>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

        </div>
        <div>
            <table style="width: 600px;">
                <tr>
                    <th class="auto-style6">
                        <asp:Label ID="Label2" runat="server" Text="Ngày nhập："></asp:Label>
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
                        <asp:Label ID="Label3" runat="server" Text="Trạng thái："></asp:Label></th>
                    <td class="auto-style8">
                        <asp:DropDownList ID="FlagDDL" runat="server">
                            <asp:ListItem Value="%">Toàn bộ</asp:ListItem>
                            <asp:ListItem Value="1">Không loại bỏ</asp:ListItem>
                            <asp:ListItem Value="2">Loại bỏ</asp:ListItem>
                        </asp:DropDownList></td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" AllowPaging="True" PageSize="20">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Ngày tháng" SortExpression="Date" />
                    <asp:BoundField DataField="Remark" HeaderText="Bộ phận" SortExpression="Remark" />
                    <asp:BoundField DataField="狀態" HeaderText="Tình trạng" SortExpression="狀態" ReadOnly="True" />
                    <asp:BoundField DataField="CreateDate" DataFormatString="{0:d}" HeaderText="Ngày lập" SortExpression="CreateDate" />
                    <asp:BoundField DataField="ModifyDate" DataFormatString="{0:d}" HeaderText="Ngày thay đổi" SortExpression="ModifyDate" />
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT a.Date, b.Remark, CASE WHEN a.Flag = 1 THEN N'Thêm mới' WHEN a.Flag = 2 THEN N'Loại bỏ' ELSE '' END AS '狀態', a.CreateDate, a.ModifyDate FROM Productivity_Head AS a LEFT OUTER JOIN Mapping AS b ON a.Team = b.Data AND b.UsingDefine = 'Productivity' WHERE (a.Flag > 0) ORDER BY a.Date">

            </asp:SqlDataSource>



        </div>

    </form>
</body>
</html>
