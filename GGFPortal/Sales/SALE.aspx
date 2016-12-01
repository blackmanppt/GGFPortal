<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SALE.aspx.cs" Inherits="GGFPortal.Sales.SALE" UICulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 81px;
            background-color: #33CCCC;
        }
        .auto-style2 {
            width: 317px;
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

            <table style="border:3px #cccccc solid;" border='1' width: 800px;">
                <tr>
                    <td class="auto-style1" style="border-style: solid">

                        <asp:Label ID="Label1" runat="server" Text="修改日期："></asp:Label>
                    </td>
                    <td class="auto-style2" style="border-style: solid">
                        <asp:TextBox ID="StartDayTB" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyy/MM/dd" />
                        ~
            <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay" Format="yyyy/MM/dd" />
                    </td>
                   
                </tr>
                <tr>
                    <td  class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="品牌："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="BrandTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="BrandTB_AutoCompleteExtender" runat="server" TargetControlID="BrandTB" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchBrand" >
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>

                </tr>
                                <tr>
                    <td  class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="樣品種類："></asp:Label>
                                    </td>
                    <td>
                        <asp:DropDownList ID="SamcTypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceSamcType" DataTextField="type_desc" DataValueField="type_id">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceSamcType" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [type_id], [type_desc] FROM [samc_type] ORDER BY [type_id]"></asp:SqlDataSource>
                                    </td>

                </tr>
                                <tr>
                    <td>
                        <asp:DropDownList ID="NewOldDDL" runat="server">
                            <asp:ListItem Value="2">新增</asp:ListItem>
                            <asp:ListItem Value="1">全部</asp:ListItem>
                        </asp:DropDownList>
                                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="CearBT" runat="server" Text="Clear" OnClick="CearBT_Click" />
                        <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />

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
                        <LocalReport ReportPath="ReportSource\ReportSALE.rdlc" EnableExternalImages="true">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.SalesTempDSTableAdapters.samc_reqmTableAdapter">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="2" Name="caicai" SessionField="CaiCai" Type="Decimal" />
                    <asp:SessionParameter Name="modify_date1" SessionField="StartDay" Type="DateTime" DefaultValue="1900/01/01"/>
                    <asp:SessionParameter Name="modify_date2" SessionField="EndDay" Type="DateTime" DefaultValue="2900/01/01"/>
                    <asp:SessionParameter DefaultValue="%" Name="brand_name" SessionField="Brand" Type="String" />
                    <asp:SessionParameter DefaultValue="%" Name="type_id" SessionField="SamcType" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>

</body>
</html>
