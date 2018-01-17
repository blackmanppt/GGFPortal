<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VN013.aspx.cs" Inherits="GGFPortal.VN.VN013" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>越南工時資料</title>
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
                        <h3 class="text-info text-left">越南工時資料
			 

                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">

<%--                            <div class="form-group center-block">
                                <h4>公司別</h4>
                                <asp:DropDownList ID="SiteDDL" runat="server" class="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>GGF</asp:ListItem>
                                    <asp:ListItem>TCL</asp:ListItem>
                                </asp:DropDownList>

                            </div>--%>
                            <h4>日期</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyyMMdd" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="EndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" BehaviorID="EndDay_CalendarExtender" TargetControlID="EndDay"  Format="yyyyMMdd" />
                            </div>
<%--                            <h4>客戶</h4>
                            <div class="form-group">
                                <asp:TextBox ID="CusTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="CusTB_AutoCompleteExtender" runat="server"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="CusTB" ServiceMethod="SearchShipCus" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>--%>
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StyleTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="StyleTB"  ServiceMethod="SearchVNExcelStyle" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>
<%--                            <h4>工廠</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="VendorDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="vendor_name_brief" DataValueField="vendor_id" class="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select distinct a.vendor_id,b.vendor_name_brief from  ordc_bah1 a left join bas_vendor_master b on a.site=b.site and a.vendor_id=b.vendor_id
where a.bah_status&lt;&gt;'CA' 
order by vendor_id"></asp:SqlDataSource>
                            </div>--%>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False" >
                        <LocalReport ReportPath="ReportSource\VN\ReportVN013V2.rdlc" DisplayName="越南工時資料">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
