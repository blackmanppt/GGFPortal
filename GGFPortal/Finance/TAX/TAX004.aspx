<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX004.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX004" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 69px;
        }
        .auto-style3 {
            width: 931px;
        }
        .auto-style5 {
            width: 349px;
        }
        .auto-style6 {
            width: 370px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <table style="width:600px;">
            <tr>
                <td class="auto-style1">
                    
                        <asp:Label ID="Label2" runat="server" Text="時間："></asp:Label>
                    
                </td>
                <td class="auto-style5">
                        <asp:TextBox ID="StartDayTB" runat="server" AutoPostBack="True" Width="70px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" Format="yyyy-MM-dd" TargetControlID="StartDayTB" />
                        ~
                        <asp:TextBox ID="EndDayTB" runat="server" AutoPostBack="True" Width="70px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" Format="yyyy-MM-dd" TargetControlID="EndDayTB" />

                    </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                        <asp:Label ID="Label11" runat="server" Text="月份："></asp:Label>
                    </td>
                <td class="auto-style5">
                        <asp:DropDownList ID="MonthDDL" runat="server">
                        </asp:DropDownList>

                    </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                        <asp:Label ID="Label12" runat="server" Text="款號："></asp:Label>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="StyleNoTB" runat="server"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo" TargetControlID="StyleNoTB">
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
                <td class="auto-style6">
                    <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" />
                </td>
            </tr>
        </table>
    
    </div>
        <div>
                <asp:GridView ID="ACRGV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanging="ACRGV_SelectedIndexChanging">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                                    <ajaxToolkit:ModalPopupExtender ID="POPPanel_ModalPopupExtender" runat="server" TargetControlID="Show" PopupControlID="POPPanel"  CancelControlID="CancelBT" >
                                    </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="Show" runat="server" Text="Show" style="display:none"/>
                <asp:Panel ID="POPPanel" runat="server" Height="500px" Width="800px" align="center"  ScrollBars="Horizontal" BackColor="#33CCFF" style="">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label3" runat="server" Text="流水號："></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="UidLB" runat="server" Text=""></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label4" runat="server" Text="分機："></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="PhoneLB" runat="server" Text=""></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label5" runat="server" Text="員工姓名："></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="AcrTicketGV" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
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
                                        <asp:BoundField DataField="style_no" HeaderText="style_no" />
                                        <asp:BoundField DataField="CheckCreateDate" HeaderText="時間" />
                                        <asp:BoundField DataField="acr_seq" HeaderText="類別" />
                                        <asp:BoundField DataField="acr_nbr" HeaderText="單據號碼" />
                                        <asp:BoundField DataField="acr_seq" HeaderText="代工廠" />
                                        <asp:BoundField DataField="acr_date" HeaderText="應收單據日期" />
                                        <asp:BoundField DataField="CheckFlag" HeaderText="補入狀態" />
                                        <asp:BoundField DataField="acr_status" HeaderText="狀態" />
                                    </Columns>
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                            </td>
                        </tr>
       
                              
                        <tr>
              
                            <td colspan="3" style="text-align: right">
                                <asp:Button ID="SaveBT" runat="server" Text="Save" OnClick="SaveBT_Click" />
                                <asp:Button ID="CancelBT" runat="server" Text="Cancel" />
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
