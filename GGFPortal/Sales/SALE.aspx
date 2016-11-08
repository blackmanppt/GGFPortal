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
        .auto-style3 {
            text-align: right;
            width: 83px;
            background-color: #33CCCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
                <asp:Label ID="TitleLB" runat="server" Text="出口大表查詢" Style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
        <div>

            <table style="border:3px #cccccc solid;" border='1' width: 800px;">
                <tr>
                    <td class="auto-style1" style="border-style: solid">

                        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
                    </td>
                    <td class="auto-style2" style="border-style: solid">
                        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyy-MM-dd" />
                        ~
            <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay" Format="yyyy-MM-dd" />
                    </td>
                    <td>
                        <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />

                    </td>
                </tr>

            </table>

            <br />

        </div>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%">
                <LocalReport ReportPath="ReportSource\ReportSALE.rdlc" EnableExternalImages="true">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.SalesTempDSTableAdapters.samc_reqmTableAdapter">
                <SelectParameters>
                    <asp:SessionParameter Name="last_dat1" SessionField="StartDay" Type="DateTime"/>
                    <asp:SessionParameter Name="last_dat2" SessionField="EndDay" Type="DateTime"/>
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="FinaceObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.FinanceD001TableAdapters.ViewShpcTableAdapter">
                <SelectParameters>
                    <asp:SessionParameter Name="StartDay" SessionField="F001StartDay" Type="String" />
                    <asp:SessionParameter Name="EndDay" SessionField="F001EndDay" Type="String" />
                    <asp:SessionParameter DefaultValue="" Name="site" SessionField="F001Site" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>

</body>
</html>
