<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ship006.aspx.cs" Inherits="GGFPortal.Ship.Ship006" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>入庫應付、入庫暫估比較表</title>
    <script src="../scripts/jquery-3.4.1.min.js"></script>
    <script src="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.js"></script>
    <link href="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row text-center">
                <h2>入庫應付、入庫暫估比較表</h2>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:TextBox ID="StyleTB" CssClass="form-control" runat="server"></asp:TextBox>

                    <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="StyleTB_AutoCompleteExtender" TargetControlID="StyleTB" ID="StyleTB_AutoCompleteExtender"  ServiceMethod="SearchOrdStyle" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                </div>
                <div class="col-lg-8">
                    <asp:Button ID="SearchBT" CssClass="btn btn-outline-primary" runat="server" Text="搜尋" OnClick="SearchBT_Click" />
                </div>

            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:CheckBox ID="搜尋主料CB" Checked="true" runat="server" Text="搜尋主料" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <h3>
                        入庫應付總數量：<asp:Label ID="入庫應付LB" runat="server"></asp:Label>
                    </h3>
                </div>
                <div class="col-lg-6">
                    <h3>
                        入庫暫估總數量：<asp:Label ID="入庫暫估LB" runat="server" Text=""></asp:Label>
                    </h3>
                </div>
            </div>

            </div>
                        <div class="">

                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"  Visible="False" Height="100%" Width="100%" CssClass="table">
                        <LocalReport DisplayName="入庫資料表" ReportPath="ReportSource\Ship\ReportShip006.rdlc">
                        </LocalReport>
                    </rsweb:ReportViewer>

                </div>
    </form>
</body>
</html>
