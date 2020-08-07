<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SALE_V4.aspx.cs" Inherits="GGFPortal.Sales.SALE_V4" UICulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
                #titletable {
            border-collapse: collapse;
            border: 1px solid black;
        }
        .auto-style1 {
            text-align: right;
            width: 113px;
            background-color: #33CCCC;
            border-collapse: collapse;
            border: 1px solid black;
        }

        .auto-style2 {
            border-collapse: collapse;
            border: 1px solid black;
            width: 342px;
        }
        .auto-style3 {

            font-weight: bold;
            text-align: right;
        }
        .auto-style5 {
            border-collapse: collapse;
            border: 1px solid black;
            width: 389px;
        }
        .auto-style6 {
            border-collapse: collapse;
            border: 1px solid black;
            width: 342px;
        }
        .auto-style7 {
            border-collapse: collapse;
            border: 1px solid black;
            width: 103px;
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
                <asp:Label ID="TitleLB" runat="server" Text="打樣單查詢" Style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
        <div>

            <table style="width: 800px;" id="titletable">
                <tr>
                    <td class="auto-style1" style="border-style: solid">

                        <asp:Label ID="Label1" runat="server" Text="修改日期：" CssClass="auto-style3"></asp:Label>
                    </td>
                    <td class="auto-style2" style="border-style: solid">
                        <asp:TextBox ID="StartDayTB" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyy/MM/dd" />
                        ~
            <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay" Format="yyyy/MM/dd" />
                    </td>
                    <td class="auto-style7">
                        <asp:Label ID="Label5" runat="server" Text="打樣狀態："></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="StatusDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="StatusDDL_SelectedIndexChanged">
                            <asp:ListItem Value="A">新增</asp:ListItem>
                            <asp:ListItem Value="CL">結案</asp:ListItem>
                            <asp:ListItem Value="CA">刪除</asp:ListItem>
                            <asp:ListItem Value="ALL">全部</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                   
                </tr>
                <tr>
                    <td  class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="品牌：" CssClass="auto-style3"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="BrandTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="BrandTB_AutoCompleteExtender" runat="server" TargetControlID="BrandTB" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchBrand" >
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                                        <td class="auto-style7">
                                            <asp:Label ID="Label6" runat="server" Text="結案日期：" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="StartDayTB0" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB0_CalendarExtender" runat="server" TargetControlID="StartDayTB0" Format="yyyy/MM/dd" />
                        <asp:Label ID="Label7" runat="server" Text="~" Visible="False"></asp:Label>
            <asp:TextBox ID="EndDay0" runat="server" AutoPostBack="True" Visible="False"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDay0_CalendarExtender" runat="server" TargetControlID="EndDay0" Format="yyyy/MM/dd" />
                    </td>
                </tr>
                                <tr>
                    <td  class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="樣品種類：" CssClass="auto-style3"></asp:Label>
                                    </td>
                    <td class="auto-style6">
                        <asp:DropDownList ID="SamcTypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceSamcType" DataTextField="type_desc" DataValueField="type_id">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceSamcType" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [type_id], [type_desc] FROM [samc_type] ORDER BY [type_id]"></asp:SqlDataSource>
                                    </td>
                                                        <td class="auto-style7"></td>
                    <td class="auto-style5"></td>
                </tr>
                                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="處理狀態：" CssClass="auto-style3"></asp:Label>
                                    </td>
                    <td style="text-align: left" class="auto-style6">
                        <asp:DropDownList ID="NewOldDDL" runat="server">
                            <asp:ListItem Value="2">業務完成</asp:ListItem>
                            <asp:ListItem Value="3">打樣完成</asp:ListItem>
                            <asp:ListItem Value="4">全部</asp:ListItem>
                        </asp:DropDownList>

                                    </td>
                    <td class="auto-style7"></td>
                    <td class="auto-style5">
                        <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />

                        <asp:Button ID="ClearBT" runat="server" Text="Clear" OnClick="ClearBT_Click" />
                                    </td>
                </tr>
            </table>


            <br />

        </div>
        <div>
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%">
                        <ServerReport ReportPath="samc" ReportServerUrl="http://192.168.0.131/reportserver" />
                        <LocalReport ReportPath="ReportSource\ReportSALE_V4.rdlc" EnableExternalImages="true" DisplayName="Sample">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="SamcV4" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.SalesTempDSTableAdapters.samc_reqm4TableAdapter">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="2" Name="progress_rate" SessionField="Progress_rate" Type="String" />
                    <asp:SessionParameter DefaultValue="2" Name="progress_rate1" SessionField="Prgress_rate1" Type="String" />
                    <asp:SessionParameter Name="modify_date1" SessionField="StartDay" Type="DateTime" DefaultValue="1900/01/01"/>
                    <asp:SessionParameter Name="modify_date2" SessionField="EndDay" Type="DateTime" DefaultValue="2900/01/01"/>
                    <asp:SessionParameter DefaultValue="%" Name="brand_name" SessionField="Brand" Type="String" />
                    <asp:SessionParameter DefaultValue="%" Name="type_id" SessionField="SamcType" Type="String" />
                    <asp:SessionParameter DefaultValue="A" Name="status" SessionField="status" Type="String" />
                    <asp:SessionParameter DefaultValue="2000/01/01" Name="samc_fin_date1" SessionField="samc_fin_date1" Type="DateTime" />
                    <asp:SessionParameter DefaultValue="2999/01/01" Name="samc_fin_date2" SessionField="samc_fin_date2" Type="DateTime" />
                    <asp:SessionParameter DefaultValue="1" Name="flag1" SessionField="flag1" Type="Decimal" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>

</body>
</html>
