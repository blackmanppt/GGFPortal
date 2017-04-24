<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance010.aspx.cs" Inherits="GGFPortal.Finance.Finance010" uiCulture="Auto" %>

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
            <asp:Label ID="TitleLB" runat="server" Text="出口大表查詢" style="color: #6600FF; background-color: #00CC99"></asp:Label>
            &nbsp;</h1>
        </div>
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd"  />
~
            <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay"  Format="yyyyMMdd"  />
        <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />
    
        <br />
        <asp:Label ID="Label2" runat="server" Text="公司別："></asp:Label>
        <asp:DropDownList ID="SiteDDL" runat="server">
            <asp:ListItem Value="%">全部</asp:ListItem>
            <asp:ListItem>GGF</asp:ListItem>
            <asp:ListItem>TCL</asp:ListItem>
        </asp:DropDownList>
    
        <br />
        <asp:Label ID="Label3" runat="server" Text="工廠："></asp:Label>
    
        <asp:DropDownList ID="VendorDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="vendor_name_brief" DataValueField="vendor_id">
            <asp:ListItem Value="%">全部</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT ordc_bah1.vendor_id, bas_vendor_master.vendor_name_brief FROM ordc_bah1 LEFT OUTER JOIN bas_vendor_master ON ordc_bah1.site = bas_vendor_master.site AND ordc_bah1.vendor_id = bas_vendor_master.vendor_id WHERE (ordc_bah1.bah_status &lt;&gt; N'CA')
order by bas_vendor_master.vendor_name_brief "></asp:SqlDataSource>
    
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%">
            <LocalReport ReportPath="ReportSource\ReportFinance010.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="FinaceObjectDataSource" Name="Finace010" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="FinaceObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.FinanceTempDSTableAdapters.ShipMappingPoTableAdapter">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="%" Name="site" SessionField="site" Type="String" />

                <asp:SessionParameter Name="Date1" SessionField="Date1" Type="Object" DefaultValue="19000101" />
<asp:SessionParameter SessionField="Date2" DefaultValue="29991231" Name="Date2" Type="Object"></asp:SessionParameter>
                <asp:SessionParameter Name="vendor_id" SessionField="vendor_id" Type="String" DefaultValue="%" />

            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>

</body>
</html>
