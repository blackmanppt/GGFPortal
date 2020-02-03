<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="MIS012.aspx.cs" Inherits="GGFPortal.MIS.MIS012" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            var start = moment().subtract(29, 'days');
            var end = moment();
            $('input[id="ContentPlaceHolder1_DateRangeTB"]').daterangepicker({
                "startDate": start,
                "endDate": end,
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
<%--            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>
            <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>--%>

                        <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>出貨單號</span>

            </h3>
            <asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-75" TextMode="MultiLine"></asp:TextBox>
            <asp:TextBox ID="佣金TB" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:TextBoxWatermarkExtender runat="server" BehaviorID="佣金TB_TextBoxWatermarkExtender" TargetControlID="佣金TB" ID="佣金TB_TextBoxWatermarkExtender" WatermarkText="填入佣金，Example：3.2"></ajaxToolkit:TextBoxWatermarkExtender>
            <div class="form-group align-items-end">
                <asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-outline-secondary" OnClick="SearchBT_Click"/>
                <asp:Button ID="ClearBT" runat="server" Text="Clear" CssClass="btn btn-dark" />
            </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <!--<div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
                    <h1 class="h2">Dashboard</h1>
                    <div class="btn-toolbar mb-2 mb-md-0">
                        <div class="btn-group mr-2">
                            <button type="button" class="btn btn-sm btn-outline-secondary">Share</button>
                            <button type="button" class="btn btn-sm btn-outline-secondary">Export</button>
                        </div>
                        <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
                            <span data-feather="calendar"></span>
                            This week
                        </button>
                    </div>
                </div>


                <h2>Section title</h2>-->
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-sm table-dark"></asp:GridView>
    </main>
</asp:Content>
