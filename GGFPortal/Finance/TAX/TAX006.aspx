<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX006.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX006" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 115px;
            text-align: right;
        }
        .auto-style5 {
            width: 349px;
        }
        .auto-style6 {
            width: 370px;
        }
        .watermarked {
	height:18px;
	width:150px;
	padding:2px 0 0 2px;
	border:1px solid #BEBEBE;
	background-color:#F0F8FF;
	color:gray;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
    <asp:Label ID="Label1" runat="server" Text="銷貨稅額沖銷調整" style="font-size: xx-large; color: #333300; font-weight: 700; background-color: #3399FF;"></asp:Label>
        </div>
        <table style="width:600px;">
            <tr>
                <td class="auto-style1">
                    
                        <asp:Label ID="Label2" runat="server" Text="月份區間："></asp:Label>
                    
                </td>
                <td class="auto-style5">
                        <asp:TextBox ID="StartDayTB" runat="server" AutoPostBack="True" Width="70px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" Format="yyyyMM" TargetControlID="StartDayTB" />
                        ~
                        <asp:TextBox ID="EndDayTB" runat="server" AutoPostBack="True" Width="70px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" Format="yyyyMM" TargetControlID="EndDayTB" />

                    </td>
                <td class="auto-style6">

                </td>
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
                    <ajaxToolkit:TextBoxWatermarkExtender ID="StyleNoTB_TextBoxWatermarkExtender" runat="server" TargetControlID="StyleNoTB" WatermarkText="可模糊搜尋"  WatermarkCssClass="watermarked" />
                    <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" TargetControlID="StyleNoTB"  CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo" >
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
                <td class="auto-style6">
                    <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" />
                </td>
            </tr>
        </table>
    
    </div>
        <div>
                
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="ACRGV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanging="ACRGV_SelectedIndexChanging" OnRowDeleting="ACRGV_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select" Text="選取" />
                        <asp:Button ID="Button2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" />
                        <ajaxToolkit:ConfirmButtonExtender ID="Button2_ConfirmButtonExtender" runat="server" TargetControlID="Button2" ConfirmText="確定刪除資料?" />
                    </ItemTemplate>
                </asp:TemplateField>
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
                                    <ajaxToolkit:ModalPopupExtender ID="POPPanel_ModalPopupExtender" runat="server" TargetControlID="Show" PopupControlID="POPPanel"  CancelControlID="CancelBT" >
                                    </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="Show" runat="server" Text="Show" style="display:none"/>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                <asp:Panel ID="POPPanel" runat="server" Height="500px" Width="800px" align="center"  ScrollBars="Horizontal" BackColor="#33CCFF" style="">
                    <table style="width:100%;">

                        <tr>
                            <td>
                                <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="AcrTicketGV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" OnRowDataBound="AcrTicketGV_RowDataBound">
                                    <AlternatingRowStyle BackColor="#DCDCDC" />
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
                                        <asp:BoundField DataField="id" HeaderText="ID" />
                                        <asp:BoundField DataField="style_no" HeaderText="style_no" />
                                        <asp:BoundField DataField="nbr" HeaderText="單據號碼" />
                                        <asp:BoundField DataField="TYPE" HeaderText="類別" />
                                        <asp:BoundField DataField="DATE" HeaderText="建立時間" DataFormatString="{0:yyyy/MM/dd}" />
                                        <asp:BoundField DataField="MONEY" HeaderText="銷貨收入" />
                                        <asp:BoundField DataField="AMT" HeaderText="預收貨款" />
<%--                                    <asp:BoundField DataField="acr_date" HeaderText="應收單據日期" />
                                        <asp:BoundField DataField="CheckFlag" HeaderText="補入狀態" />
                                        <asp:BoundField DataField="acr_status" HeaderText="狀態" />--%>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" BorderStyle="None" />
                                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" BorderStyle="None" />
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#000065" />
                                </asp:GridView>

                            </td>
                        </tr>
       
                              
                        <tr>
              
                            <td style="text-align: right">
                                <asp:Button ID="SaveBT" runat="server" Text="Save" OnClick="SaveBT_Click" />
                                <%--<ajaxToolkit:ConfirmButtonExtender ID="SaveBT_ConfirmButtonExtender" runat="server" TargetControlID="SaveBT" ConfirmText="確定更新?" />--%>
                                <asp:Button ID="CancelBT" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                                                            </ContentTemplate>
                        </asp:UpdatePanel>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
