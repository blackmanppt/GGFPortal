<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales007.aspx.cs" Inherits="GGFPortal.Sales.Sales007" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>訂單預估毛利成本(Sales)</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-left">訂單預估毛利成本(Sales)</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">

                            <h4>季節</h4>
<%--                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyy-MM-dd" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="EndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" BehaviorID="EndDay_CalendarExtender" TargetControlID="EndDay"  Format="yyyy-MM-dd" />
                            </div>--%>
                            <div class="form-group">
                                <asp:DropDownList ID="YearDDL" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="season_y" DataValueField="season_y"></asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DBConnectionString %>' SelectCommand="SELECT DISTINCT [season_y] FROM [ordc_bah1] ORDER BY [season_y] DESC"></asp:SqlDataSource>
                                <asp:DropDownList ID="SeasonDDL" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="season" DataValueField="season">
                                    <%--                                    <asp:ListItem>FW</asp:ListItem>
                                    <asp:ListItem>REPLENISH</asp:ListItem>
                                    <asp:ListItem>BTS</asp:ListItem>
                                    <asp:ListItem>WINTER</asp:ListItem>
                                    <asp:ListItem>SUMMER</asp:ListItem>
                                    <asp:ListItem>HOLIDAY</asp:ListItem>
                                    <asp:ListItem>FALL</asp:ListItem>
                                    <asp:ListItem>SS</asp:ListItem>
                                    <asp:ListItem>SPRING</asp:ListItem>
                                    <asp:ListItem>TRANS</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DBConnectionString %>' SelectCommand="SELECT DISTINCT [season] FROM [ordc_bah1] ORDER BY [season]"></asp:SqlDataSource>
                            </div>
                            <h4>客戶</h4>
                            <div class="form-group">
                                <asp:TextBox ID="客戶TB" runat="server" CssClass="form-control" ></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="客戶TB_AutoCompleteExtender" TargetControlID="客戶TB" ID="客戶TB_AutoCompleteExtender" ServiceMethod="Search訂單客戶品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>

                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Visible="False" >
                        <LocalReport ReportPath="ReportSource\Sales\ReportSales007.rdlc" DisplayName="訂單資料">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
