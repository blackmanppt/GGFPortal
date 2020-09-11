<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ship003.aspx.cs" Inherits="GGFPortal.Ship.Ship003" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客戶訂單轉Excel</title>
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
                        <h3 class="text-info text-center">客戶訂單轉Excel查詢
                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <div class="form-group center-block">
                                <h4>公司別</h4>
                                <asp:DropDownList ID="公司別DDL" runat="server" class="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>GGF</asp:ListItem>
                                    <asp:ListItem>TCL</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group center-block">
                                <h4>出貨日期</h4>
                                <asp:TextBox ID="StarDayTB" runat="server"  class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StarDayTB_CalendarExtender" runat="server" BehaviorID="StarDayTB_CalendarExtender" TargetControlID="StarDayTB" Format="yyyy-MM-dd"/>
                                <asp:TextBox ID="EndDayTB" runat="server"  class="form-control" ></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" BehaviorID="EndDayTB_CalendarExtender" TargetControlID="EndDayTB"  Format="yyyy-MM-dd"/>
                            </div>
                            <div class="form-group center-block">
                                <h4>代工廠</h4>
                                <asp:DropDownList ID="代工廠DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="vendor_name_brief" DataValueField="vendor_id" class="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT ordc_bah1.vendor_id, bas_vendor_master.vendor_name_brief FROM ordc_bah1 LEFT OUTER JOIN bas_vendor_master ON ordc_bah1.site = bas_vendor_master.site AND ordc_bah1.vendor_id = bas_vendor_master.vendor_id"></asp:SqlDataSource>
                                
                            </div>

                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StyleTB" runat="server"  TextMode="MultiLine"  class="form-control col-lg-5" Height="200px"></asp:TextBox>
    <%--                            <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="StyleTB"  ServiceMethod="SearchOrdStyle" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>--%>
                            </div>
                                                        <h4>客戶</h4>
                            <div class="form-group">
                                <asp:TextBox ID="客戶TB" runat="server" class="form-control"></asp:TextBox>

                                <ajaxToolkit:AutoCompleteExtender ID="客戶TB_AutoCompleteExtender" runat="server"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  ServiceMethod="Search訂單客戶" MinimumPrefixLength="1" UseContextKey="True"  TargetControlID="客戶TB">
                                </ajaxToolkit:AutoCompleteExtender>

                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                <asp:TextBox ID="品牌TB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="品牌TB_AutoCompleteExtender" runat="server" MinimumPrefixLength="1" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" UseContextKey="True"  TargetControlID="品牌TB"  ServiceMethod="Search訂單品牌">
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>
<%--                            
                                

                            --%>
                            <asp:CheckBox ID="衣架資料CB" runat="server"  CssClass="form-control" Text="查詢衣架資料"/>
                            <br />
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Visible="False" >
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
