<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secretary003.aspx.cs" Inherits="GGFPortal.Secretary.Secretary003" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
        .auto-style2 {
            height: 20px;
        }
        .auto-style3 {
            width: 97px;
            text-align: right;
        }
        .auto-style4 {
            height: 20px;
            width: 97px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style1" Text="分機表查詢"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="請輸入相關資訊："></asp:Label>
        <asp:TextBox ID="SearchTB" runat="server"></asp:TextBox>
        <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" />
        <asp:GridView ID="PhoneGV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanging="PhoneGV_SelectedIndexChanging">
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
                <asp:Panel ID="POPPanel" runat="server" Height="500px" Width="400px"  ScrollBars="Horizontal" BackColor="#33CCFF" style="display:none">
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
                                <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Label ID="Label6" runat="server" Text="員工編號："></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="NumberBT" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style2"></td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label7" runat="server" Text="英文姓名："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EngName" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label8" runat="server" Text="Email："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label9" runat="server" Text="Skype："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="SkypeBT" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label10" runat="server" Text="位置："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="LocationDDL" runat="server">
                                    <asp:ListItem>4樓</asp:ListItem>
                                    <asp:ListItem>5樓</asp:ListItem>
                                    <asp:ListItem>7樓</asp:ListItem>
                                    <asp:ListItem>TD</asp:ListItem>
                                    <asp:ListItem>事務</asp:ListItem>
                                    <asp:ListItem>司機</asp:ListItem>
                                    <asp:ListItem>會計</asp:ListItem>
                                    <asp:ListItem>樣品室</asp:ListItem>                                    
                                    <asp:ListItem>總機</asp:ListItem>
                                    <asp:ListItem>船務</asp:ListItem>
                                    <asp:ListItem>行政總務</asp:ListItem>
                                    <asp:ListItem>資訊</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="SaveBT" runat="server" Text="Save" OnClick="SaveBT_Click" />
                                <asp:Button ID="CancelBT" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

    
    </div>
    </form>
</body>
</html>
