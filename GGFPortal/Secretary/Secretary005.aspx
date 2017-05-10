<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secretary005.aspx.cs" Inherits="GGFPortal.Secretary.Secretary005" uiCulture="Auto" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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
            <asp:Label ID="TitleLB" runat="server" Text="訂單出貨查詢(無預估)" style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
        <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"  EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
            <asp:Label ID="StartLB" runat="server" Text="起始日期："></asp:Label>
            <asp:TextBox ID="StartDay" runat="server" AutoPostBack="True"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" TargetControlID="StartDay"  Format="yyyyMMdd"  />
            <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />
            <br />
            <asp:Label ID="EndLB" runat="server" Text="結束日期："></asp:Label>
            <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay"  Format="yyyyMMdd"  />
        </div>
    <div>
    
        
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="700px" Width="90%">
            <LocalReport ReportPath="ReportSource\ReportS002.rdlc" DisplayName="產區表無預估">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="Sercetary001ObjectDataSource" Name="Sercretary001" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="Sercetary001ObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.SercetaryTableAdapters.OrderTableAdapter" OnDataBinding="Sercetary001ObjectDataSource_DataBinding">
            <SelectParameters>
                <asp:ControlParameter ControlID="StartDay" Name="StartDay" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="EndDay" Name="EndDay" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
