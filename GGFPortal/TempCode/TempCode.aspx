<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TempCode.aspx.cs" Inherits="GGFPortal.TempCode.TempCode" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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



     <script type="text/javascript"  src="../scripts/daterangepicker/moment.min.js"></script>
    <script type="text/javascript"  src="../scripts/daterangepicker/daterangepicker.min.js"></script>
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
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar ">

            <asp:Label ID="TitleLB" runat="server" Text="" CssClass="btn btn-info navbar-brand  "></asp:Label>

            <%--         <asp:Button ID="IndexBT" runat="server" Text="返回搜尋畫面" OnClick="IndexBT_Click" CssClass="btn btn-outline-success" />--%>
        </nav>
        <div class=" container-fluid">
            <%--        <div class="row mb-2">
            <table class="table  table-bordered  table-dark">
                <tr>
                    <th class=" text-right col-md-2">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></th>
                    <td class=" col-md-4">

                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control dropdown">
                        </asp:DropDownList>

                    </td>
                    <th class=" text-right col-md-2">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></th>
                    <td class=" col-md-4">

                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control dropdown">
                        </asp:DropDownList>

                    </td>
                </tr>

            </table>

        </div>--%>
            <div class="row table-bordered table-dark  mb-2">
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass=" "></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row  table-bordered  table-dark  mb-2">
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row table-dark mb-2">
                <div class="col-10"></div>
                <div class="col-2 text-center">
                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-light" />
                </div>
            </div>
            <div>
                <rsweb:ReportViewer ID="TempRV" runat="server" CssClass="table col-12"></rsweb:ReportViewer>
            </div>
        </div>
         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                <asp:Panel ID="AlertPanel" runat="server" align="center" CssClass="alert-danger w-75" Style="display: none">
                    <div class=" text-center">
                        <h3>
                            <asp:Label ID="MessageLB" runat="server" Text="" CssClass="h3"></asp:Label>

                        </h3>
                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-danger" />
                    </div>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                </ajaxToolkit:ModalPopupExtender>



            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="../scripts/bootstrap-4.3.1/js/dist/util.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/dropdown.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/collapse.js"></script>
</body>
</html>
