<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales002.aspx.cs" Inherits="GGFPortal.Sales.Sales002" uiCulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>業績表</title>
    <style type="text/css">
        .auto-style1 {
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
            <asp:Label ID="TitleLB" runat="server" Text="業績表" style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
    <div>
    
        <table style="width:600px;">
            <tr>
                <td class="auto-style1">
    
        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd"  />
                    ~<asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay"  Format="yyyyMMdd"  />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
        <asp:Label ID="Label2" runat="server" Text="公司別："></asp:Label>
                </td>
                <td>
        <asp:DropDownList ID="SiteDDL" runat="server">
            <asp:ListItem>全部</asp:ListItem>
            <asp:ListItem>GGF</asp:ListItem>
            <asp:ListItem>TCL</asp:ListItem>
        </asp:DropDownList>
    
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>

                <td colspan="2">                    <asp:Label ID="Label3" runat="server" Text="客戶："></asp:Label>

                    <asp:DropDownList ID="Cus_idDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="cus_name" DataValueField="agents" AutoPostBack="True" OnSelectedIndexChanged="Cus_idDDL_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="Label4" runat="server" Text="品牌："></asp:Label>
                    <asp:DropDownList ID="BrandDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="brand" DataValueField="brand">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT brand FROM ordc_bah1 WHERE (bah_status &lt;&gt; @bah_status) AND (agents = @agents) ORDER BY brand">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="CA" Name="bah_status" Type="String" />
                            <asp:ControlParameter ControlID="Cus_idDDL" Name="agents" PropertyName="SelectedValue" DefaultValue="" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <%--<ajaxToolkit:CascadingDropDown ID="BrandDDL_CascadingDropDown" runat="server" TargetControlID="BrandDDL" />--%>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT bas_cus_master.cus_name, ordc_bah1.agents FROM ordc_bah1 INNER JOIN bas_cus_master ON ordc_bah1.site = bas_cus_master.site AND ordc_bah1.agents = bas_cus_master.cus_id WHERE (ordc_bah1.bah_status &lt;&gt; @bah_status) ORDER BY ordc_bah1.agents">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="CA" Name="bah_status" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <%--<ajaxToolkit:CascadingDropDown ID="Cus_idDDL_CascadingDropDown" runat="server" TargetControlID="Cus_idDDL" LoadingText="讀取中..."   PromptText="請選擇類別" ServicePath="WebService.asmx" ServiceMethod="getType" />--%>
                </td>
                <td>
        <asp:Button ID="SearchBT" runat="server" OnClick="SearchBT_Click" Text="Search" />
    
                </td>
            </tr>
        </table>
        
    
    </div>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%" Visible="False">
            <LocalReport ReportPath="ReportSource\Sales\ReportSales002V2.rdlc">

            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>

</body>
</html>
