<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIS002.aspx.cs" Inherits="GGFPortal.MIS.MIS002" UICulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label ID="TitleLB" runat="server" Text="採購單未簽核查詢" Style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
        <div>

            <asp:Label ID="SearchLB" runat="server" Text="起始日期："></asp:Label>
            <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd" />
            <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />

        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%">
                <LocalReport ReportPath="ReportSource\ReportMIS002.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="MISObjectDataSource" Name="MIS002" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="MISObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.MIS001TableAdapters.PurCheckTableAdapter">
                <SelectParameters>
                    <asp:SessionParameter Name="StartLast" SessionField="StartDay" Type="DateTime" />
                    <asp:SessionParameter Name="EndLast" SessionField="EndDay" Type="DateTime" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>

</body>
</html>
