<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales001.aspx.cs" Inherits="GGFPortal.Sales.Sales001" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div>
            <h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
            <asp:Label ID="TitleLB" runat="server" Text="訂單量查詢" style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
    <div>
    
        <table style="width:600px;">
            <tr>
                <td class="auto-style1">
    
        <asp:Label ID="Label1" runat="server" Text="客戶名稱："></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox ID="VendorTB" runat="server"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="VendorTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="2" ServiceMethod="SearchVendorID" TargetControlID="VendorTB">
                            </ajaxToolkit:AutoCompleteExtender>
                            <asp:ImageButton ID="SearchVendorIDBT" runat="server" Height="19px" ImageUrl="~/IMG/images.png" OnClick="SearchVendorIDBT_Click" Width="16px" />
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="SearchCancel" PopupControlID="SearchVendorIDPanel" TargetControlID="ShowBT">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Button ID="ShowBT" runat="server" Text="Button" Visible="true" Style="display:none" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="訂單時間："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="StartDay" runat="server" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" TargetControlID="StartDay" Format="yyyyMMdd" />
                    <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay" Format="yyyyMMdd" />
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/IMG/Cancelimages.png" OnClick="ImageButton1_Click" Width="16px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="訂單工廠："></asp:Label>
                </td>
                <td>
        
                    <asp:DropDownList ID="FactoryDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="MappingData" DataValueField="MappingData" AppendDataBoundItems="True">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [MappingData] FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="ViewOrderQty" Name="UsingDefine" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
        
                </td>
                <td>
        <asp:Button ID="SearchBT" runat="server" OnClick="SearchBT_Click" Text="Search" />
    
                </td>
            </tr>
        </table>
        
    
    </div>
    <div>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%" Visible="False">
            <LocalReport ReportPath="ReportSource\ReportSales001.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:Panel ID="SearchVendorIDPanel" runat="server" align="center" Height="400px" Width="600px" ScrollBars="Horizontal" BackColor="#33CCFF" style="display:none">
                    <table style="width:600px;">
                        <tr>
                            <td class="auto-style3">
                                <asp:Label ID="Label4" runat="server" Text="客戶名稱或代號："></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="auto-style1">
                                            <asp:TextBox ID="SearchVendorID2TB" runat="server"></asp:TextBox>
                                            <br />
                                            <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Button ID="SearchVendorID2" runat="server" OnClick="SearchVendorID2_Click" Text="Search" />
                                <asp:Button ID="SearchCancel" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style2">       
                                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="VendorGV" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="cus_id" OnSelectedIndexChanging="VendorGV_SelectedIndexChanging" Width="360px">
                                    <Columns>
                                        <asp:BoundField DataField="cus_id" HeaderText="客戶代號" />
                                        <asp:BoundField DataField="cus_name_brief" HeaderText="客戶簡稱" />
                                        <asp:BoundField DataField="cus_name" HeaderText="客戶名稱" />
                                    </Columns>
                                </asp:GridView>
                
                                                    </ContentTemplate>
        </asp:UpdatePanel>
                                
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style2">
                                &nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
    

        </div>
    </form>
</body>
</html>
