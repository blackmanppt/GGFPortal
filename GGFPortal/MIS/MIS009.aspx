<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIS009.aspx.cs" Inherits="GGFPortal.MIS.MIS009" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>廠商交易資料查詢</title>
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
                        <h3 class="text-info text-center">廠商交易資料查詢
                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">

                            <div class="form-group center-block">
                                <h4>廠商名稱</h4>
                                <asp:TextBox ID="廠商名稱TB" runat="server" CssClass="form-control"></asp:TextBox>

                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" ServiceMethod="Search廠商名稱" MinimumPrefixLength="1" UseContextKey="True" TargetControlID="廠商名稱TB" ID="廠商名稱TB_AutoCompleteExtender"></ajaxToolkit:AutoCompleteExtender>
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
                        <LocalReport ReportPath="ReportSource\MIS\ReportMIS009.rdlc" DisplayName="廠商交易資料">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
