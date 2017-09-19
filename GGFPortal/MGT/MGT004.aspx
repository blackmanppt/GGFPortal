<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MGT005.aspx.cs" Inherits="GGFPortal.MGT.MGT005" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>快遞單明細表</title>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-left">快遞單明細表
			 

                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">


<%--                            <h4>快遞日期</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyy-MM-dd" />
                            </div>--%>
                            <h4>快遞單號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StyleTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="StyleTB"  ServiceMethod="快遞單號" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False" >
                        <LocalReport ReportPath="ReportSource\MGT\ReportMGT005.rdlc" DisplayName="快遞單明細">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
