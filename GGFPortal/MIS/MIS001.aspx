<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIS001.aspx.cs" Inherits="GGFPortal.MIS.MIS001" uiCulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
            <asp:Label ID="TitleLB" runat="server" Text="訂單未簽核查詢" style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="起始日期："></asp:Label>
        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd"  />
        <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />
    
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%">
            <LocalReport ReportPath="ReportSource\ReportMIS001.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="MISObjectDataSource" Name="MIS001" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="MISObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.MIS001TableAdapters.OrderCheckTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="StartLast" SessionField="StartDay" Type="DateTime" />
                <asp:SessionParameter Name="EndLast" SessionField="EndDay" Type="DateTime" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>

</body>
</html>
