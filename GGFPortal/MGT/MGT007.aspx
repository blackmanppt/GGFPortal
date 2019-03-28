<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT007.aspx.cs" Inherits="GGFPortal.MGT.MGT007" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單明細表-每日查詢</title>
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
                        <h3 class="text-info text-left">快遞單明細表-查詢
			 

                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">


                            <h4>快遞日期</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyy-MM-dd" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="EndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" BehaviorID="EndDay_CalendarExtender" TargetControlID="EndDay" Format="yyyy-MM-dd" />
                            </div>
                            <h4>快遞廠商</h4>
                            <div class="form-group">                                
                                    <asp:DropDownList ID="快遞廠商DDL" runat="server" CssClass="form-control" >
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>譽得</asp:ListItem>
                                        <asp:ListItem>峻越</asp:ListItem>
                                        <asp:ListItem>捷麟</asp:ListItem>
                                        <asp:ListItem>順豐</asp:ListItem>
                                        <asp:ListItem>船務-馬島-DHL</asp:ListItem>
                                        <asp:ListItem>DHL</asp:ListItem>
                                        <asp:ListItem>FedEx</asp:ListItem>
                                        <asp:ListItem>VGG</asp:ListItem>
                                        <asp:ListItem>越新</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            <h4>快遞單號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="提單TB" runat="server" class="form-control"></asp:TextBox>
                                <%--                                <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="StyleTB"  ServiceMethod="快遞單號" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>--%>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False">
                        <LocalReport ReportPath="ReportSource\MGT\ReportMGT007.rdlc" DisplayName="快遞單明細">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
