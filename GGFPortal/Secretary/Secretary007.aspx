<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secretary007.aspx.cs" Inherits="GGFPortal.Secretary.Secretary007" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>工時IE對應表</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
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
                        <h3 class="text-info text-left">工時實際IE資料-查詢
			 

                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">


                            <h4>匯入日期</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyyMMdd" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="EndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" BehaviorID="EndDay_CalendarExtender" TargetControlID="EndDay" Format="yyyyMMdd" />
                            </div>
                            <h4>工段</h4>
                            <asp:CheckBox ID="StitchCB" runat="server"  Text="車縫" Checked="true"/>
                            <asp:CheckBox ID="PackageCB" runat="server" Text="包裝" />
                            <asp:CheckBox ID="IronCB" runat="server" Text="整燙" />
                            <asp:CheckBox ID="QCCB" runat="server" Text="QC" />
                            <asp:CheckBox ID="CutCB" runat="server" Text="裁剪" />
<%--                            <h4>快遞廠商</h4>
                            <div class="form-group">                                
                                    <asp:DropDownList ID="快遞廠商DDL" runat="server" CssClass="form-control" >
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>譽得</asp:ListItem>
                                        <asp:ListItem>峻越</asp:ListItem>
                                        <asp:ListItem>捷麟</asp:ListItem>
                                        <asp:ListItem>順豐</asp:ListItem>
                                        <asp:ListItem>馬島-DHL</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            <h4>快遞單號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="提單TB" runat="server" class="form-control"></asp:TextBox>
                            </div>--%>
                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False">
                        <LocalReport ReportPath="ReportSource\Secretary\ReportSecretary007.rdlc" DisplayName="工時IE對應表" EnableExternalImages="True">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
