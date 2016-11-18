<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX003.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX003" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>銷貨發票補入</title>
    <style type="text/css">
        .auto-style2 {
            text-align: right;
            width: 82px;
        }

        .auto-style3 {
            font-size: larger;
            color: #660066;
            background-color: #00CC66;
        }

        .auto-style4 {
            width: 173px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <h1>
                <asp:Label ID="Label1" runat="server" Text="銷貨發票補入：" CssClass="auto-style3"></asp:Label>
            </h1>
            <table style="width: 600px;">
                 <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="自選月份："></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="StartDayTB" runat="server" AutoPostBack="True" Width="70px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" Format="yyyy-MM-dd" TargetControlID="StartDayTB" />
                        ~
                        <asp:TextBox ID="EndDayTB" runat="server" AutoPostBack="True" Width="70px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" Format="yyyy-MM-dd" TargetControlID="EndDayTB" />

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="月份："></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="MonthDDL" runat="server">
                        </asp:DropDownList>

                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="款號："></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="StyleNoTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo" TargetControlID="StyleNoTB">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td>
                        <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click1" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label12" runat="server" Text="發票："></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TicketBT" runat="server"></asp:TextBox>

                    </td>
                    <td>
                        <asp:Button ID="SaveBT2" runat="server" Text="Save" OnClick="SaveBT2_Click" />
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="AcrTicketGV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Button ID="SelectAllBT" runat="server" OnClick="SelectAllBT_Click" Text="全選" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="uid" HeaderText="Key" />
                                        <asp:BoundField DataField="CheckFlag" HeaderText="補入狀態" />
                                        <asp:BoundField DataField="CheckCreateDate" HeaderText="補入時間" />
                                        <asp:BoundField DataField="ticket" HeaderText="發票號碼" />
                                        <asp:BoundField DataField="site" HeaderText="公司別" />
                                        <asp:BoundField DataField="acr_nbr" HeaderText="應收單據號碼" />
                                        <asp:BoundField DataField="acr_seq" HeaderText="應收單據流水號" />
                                        <asp:BoundField DataField="acr_date" HeaderText="應收單據日期" />
                                        <asp:BoundField DataField="style_no" HeaderText="style_no" />
                                        <asp:BoundField DataField="acr_status" HeaderText="狀態" />
                                        <asp:BoundField DataField="reference_no" HeaderText="參考號碼" />
                                        <asp:BoundField DataField="reason" HeaderText="原因碼" />
                                    </Columns>
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
        </div>
    </form>
</body>
</html>
