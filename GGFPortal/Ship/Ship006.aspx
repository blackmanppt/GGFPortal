<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ship006.aspx.cs" Inherits="GGFPortal.Ship.Ship006" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>入庫應付、入庫暫估比較表</title>
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
                    <asp:Button ID="SearchBT" CssClass="btn btn-default" runat="server" Text="搜尋" OnClick="SearchBT_Click" />
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
            <div class="row">
                <div class="col-lg-12">

                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"  Visible="False" Height="363px" Width="890px">
                        <LocalReport DisplayName="入庫資料表" ReportPath="ReportSource\Ship\ReportShip006.rdlc">
                        </LocalReport>
                    </rsweb:ReportViewer>

                </div>
                
        </div>
            </div>
    </form>
</body>
</html>
