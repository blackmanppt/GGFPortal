<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance009.aspx.cs" Inherits="GGFPortal.Finance.Finance009" UICulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>出口大表</title>
    <script src="../scripts/jquery-3.4.1.min.js"></script>
    <script src="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.js"></script>
    <link href="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label ID="TitleLB" runat="server" Text="出口大表查詢" Style="color: #6600FF; background-color: #00CC99"></asp:Label>
                &nbsp;</h1>
        </div>
        <div>
            <div class="row m-1">
                <div class="row col-6">
                    <div class="col-2">
                        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
                    </div>
                    <div class="col-4">
                        
                                        
                <asp:TextBox ID="StartDayTB" runat="server" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd" />
                    </div>
                    <div class="col-4">
                                    <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay" Format="yyyyMMdd" />
                
                    </div>
                    

                </div>
                <div class="col-6 align-items-baseline">
                    <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" CssClass="btn btn-primary" />
                </div>

            </div>

            <div class="row m-1">
                <div class="row col-6">
                                            <div class="col-2">
                         <asp:Label ID="Label2" runat="server" Text="公司別："></asp:Label>
                    </div>
                    <div class="col-4">
                         <asp:DropDownList ID="SiteDDL" runat="server" CssClass="form-control dropdown">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>GGF</asp:ListItem>
                    <asp:ListItem>TCL</asp:ListItem>
                </asp:DropDownList>
                    </div>

            </div>
            <div class="col-9">

            </div>
            </div>
            

        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%" Visible="False" Height="720px">
                <LocalReport ReportPath="ReportSource\Finance\ReportFinance001_V5.rdlc" DisplayName="出口大表">
                    <%--                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="FinaceObjectDataSource" Name="Finance001" />
                </DataSources>--%>
                </LocalReport>
            </rsweb:ReportViewer>
            <%--        <asp:ObjectDataSource ID="FinaceObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.FinanceD001TableAdapters.ViewShpcArielTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="StartDay" SessionField="F001StartDay" Type="String" DefaultValue="%" />
                <asp:SessionParameter Name="EndDay" SessionField="F001EndDay" Type="String" />
                <asp:SessionParameter DefaultValue="" Name="site" SessionField="F001Site" Type="String" />

            </SelectParameters>
        </asp:ObjectDataSource>--%>
        </div>
    </form>

</body>
</html>
