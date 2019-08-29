<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales016.aspx.cs" Inherits="GGFPortal.Sales.Sales016" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../scripts/jquery-3.4.1.min.js"></script>
    <script src="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.js"></script>
    <link href="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />



    <script type="text/javascript" src="../scripts/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../scripts/daterangepicker/daterangepicker.min.js"></script>
    <link href="../scripts/daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        $(function () {
            $('input[name="DateRangeTB"]').daterangepicker({
                "showDropdowns": true,
                "autoApply": true,
                "locale": {
                    "format": "YYYY/MM/DD",
                    "separator": " - ",
                    "applyLabel": "Apply",
                    "cancelLabel": "Cancel",
                    "fromLabel": "From",
                    "toLabel": "To",
                    "customRangeLabel": "Custom",
                    "weekLabel": "W",
                    "daysOfWeek": [
                        "Su",
                        "Mo",
                        "Tu",
                        "We",
                        "Th",
                        "Fr",
                        "Sa"
                    ],
                    "monthNames": [
                        "January",
                        "February",
                        "March",
                        "April",
                        "May",
                        "June",
                        "July",
                        "August",
                        "September",
                        "October",
                        "November",
                        "December"
                    ],
                    "firstDay": 1
                },
                "showCustomRangeLabel": false,
                "alwaysShowCalendars": true,
                "autoUpdateInput": true
            }, function (start, end, label) {
                console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
            });
        });
    </script>
    <script type="text/javascript">
        function vendor_Populated(sender, e) {
            var vendor = sender.get_completionList().childNodes;
            var div = "<table class='table table-dark'>";
            div += "<tr><th>供應商代號</th><th>供應商簡稱</th></tr>";
            for (var i = 0; i < vendor.length; i++) {

                div += "<tr><td>" + vendor[i].innerHTML.split(',')[0] + "</td><td>" + vendor[i].innerHTML.split(',')[1] + "</td></tr>";
            }
            div += "</table>";
            sender._completionListElement.innerHTML = div;
        }
    </script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar ">

            <asp:Label ID="TitleLB" runat="server" Text="" CssClass="btn btn-info navbar-brand  "></asp:Label>

            <%--         <asp:Button ID="IndexBT" runat="server" Text="返回搜尋畫面" OnClick="IndexBT_Click" CssClass="btn btn-outline-success" />--%>
        </nav>
        <div class=" container-fluid">

            <div class="row table-bordered table-dark  mb-2">
                <div class="col-md-1 text-right">
                    <asp:Label ID="成分BL" runat="server" Text="成分：" CssClass="h3"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="成分DDL" runat="server" CssClass=" dropdown form-control" DataSourceID="SqlDataSource1" DataTextField="說明" DataValueField="代號"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [說明], [代號] FROM [View布種成分]"></asp:SqlDataSource>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="布種LB" runat="server" Text="布種：" CssClass="h3"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="布種DDL" runat="server" CssClass=" form-control dropdown" DataSourceID="SqlDataSource2" DataTextField="說明" DataValueField="代號"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [代號], [說明] FROM [View布種] ORDER BY [說明]"></asp:SqlDataSource>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="布種規格LB" runat="server" Text="布種規格：" CssClass="h3"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="布種規格TB" runat="server" CssClass="form-control"></asp:TextBox><asp:LinkButton ID="RemarkLinkB" runat="server" OnClick="Remark_Click">LinkButton</asp:LinkButton>
                </div>
            </div>
            <div class="row  table-bordered  table-dark  mb-2">
                <div class="col-md-1 text-right">
                    <asp:Label ID="供應商LB" runat="server" Text="供應商：" CssClass="h3"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="供應商TB" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="供應商TB_AutoCompleteExtender" TargetControlID="供應商TB" ID="供應商TB_AutoCompleteExtender" ServiceMethod="Search採購單供應商" MinimumPrefixLength="1" UseContextKey="True" CompletionListItemCssClass="dropdown-item dropdown" OnClientPopulated="vendor_Populated"></ajaxToolkit:AutoCompleteExtender>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="客戶代號LB" runat="server" Text="客戶代號：" CssClass="h3"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="客戶代號TB" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="客戶代號TB_AutoCompleteExtender" TargetControlID="客戶代號TB" ID="客戶代號TB_AutoCompleteExtender" ServiceMethod="Search訂單客戶" MinimumPrefixLength="1" UseContextKey="True" CompletionListItemCssClass="dropdown-item dropdown"></ajaxToolkit:AutoCompleteExtender>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="採購日期LB" runat="server" Text="採購日期：" CssClass="h3"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="採購日期TB" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3 text-center">
                    <asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBT_Click" />
                </div>
            </div>
            <%--           <div class="row table-dark mb-2">
                <div class="col-10"></div>
                
            </div>--%>
            <div>
                <rsweb:ReportViewer ID="TempRV" runat="server" CssClass="table col-12"></rsweb:ReportViewer>
            </div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="show3" runat="server" Text="show3" Style="" />
                <asp:Panel ID="AlertPanel" runat="server" align="center" CssClass="alert-danger w-25 h-25 ali" Style="">
                    <div class=" text-center">
                        <h3>
                            <asp:Label ID="MessageLB" runat="server" Text="" CssClass="h3"></asp:Label>

                        </h3>
                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-danger" />
                    </div>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                </ajaxToolkit:ModalPopupExtender>
                                <asp:Panel ID="RemarkPanel" runat="server" align="center" CssClass=" alert-light w-75 h-75 ali" Style="">
                    <div class=" ">
                        <h3>
                            <asp:Label ID="RemarkMSGLB" runat="server" Text="" CssClass="h3"></asp:Label>

                        </h3>
                        <table class="table table-info">
                            <tr>
                                <td></td>
                            </tr>
<tr>
                                <td></td>
                            </tr>
<tr>
                                <td></td>
                            </tr>

                        </table>
                        <p class="text-center">
                            <asp:Button ID="RemarkBT" runat="server" Text="確定" CssClass="btn btn-danger " />
                        </p>
                    </div>
                </asp:Panel>
                <asp:Button ID="show" runat="server" Text="show" />
                <ajaxToolkit:PopupControlExtender runat="server" ExtenderControlID="" PopupControlID="RemarkPanel" BehaviorID="RemarkPanel_PopupControlExtender" TargetControlID="show" ID="RemarkPanel_PopupControlExtender"></ajaxToolkit:PopupControlExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </form>
    <script src="../scripts/bootstrap-4.3.1/js/dist/util.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/dropdown.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/collapse.js"></script>
</body>
</html>
