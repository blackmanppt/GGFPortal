﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX003.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX003" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>應收發票補入</title>
    <style type="text/css">
        .auto-style2 {
            text-align: right;
            width: 57px;
        }
        .auto-style3 {
            font-size: larger;
            color: #660066;
            background-color: #00CC66;
        }
        .auto-style4 {
            width: 176px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <h1>
            <asp:Label ID="Label1" runat="server" Text="應收發票補入：" CssClass="auto-style3"></asp:Label>
            </h1>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="月份："></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="MonthDDL" runat="server">
                        </asp:DropDownList>

                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="款號："></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="StyleNoTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo"  TargetControlID="StyleNoTB">
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
                <tr>
                    
                    <td colspan="3">
                        <asp:GridView ID="AcrTicketGV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Button ID="SelectAllBT" runat="server" Text="全選" OnClick="SelectAllBT_Click" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
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
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
