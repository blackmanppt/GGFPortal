<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sample021.aspx.cs" Inherits="GGFPortal.Sales.Sample021" %>

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

                        <h3 class=" justify-content-between align-items-center  text-muted">
                <span>打樣單號</span>

            </h3>
            <asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-50" TextMode="MultiLine"></asp:TextBox>
            <div class="form-group justify-content-end text-right m-2">
            
                <asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBT_Click"/>
            <asp:Button ID="CancelBT" runat="server" Text="Cancel" CssClass="btn btn-outline-primary" OnClick="CancelBT_Click"/>
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

        <div class="table-responsive">
                <asp:Button ID="UpDateBT" runat="server" Text="還回樣品室" CssClass="btn btn-danger m-1" Visible="false" OnClick="UpDateBT_Click"/>
            <asp:GridView ID="UpdateGV" runat="server" CssClass="table table-striped table-sm table-dark"></asp:GridView>
            <asp:Button ID="CloseBT" runat="server" Text="強制結案"  CssClass="btn btn-outline-danger m-1" Visible="false" OnClick="CloseBT_Click" />
                <asp:Button ID="DeleteBT" runat="server" Text="作廢" CssClass="btn btn-danger m-1" Visible="false" OnClick="DeleteBT_Click" />
                <br />
            <asp:Label ID="ErrorContinueLB" runat="server" Text="未歸還資料" Visible="false" CssClass="text-danger "></asp:Label>
            <asp:GridView ID="ErrorContinueGV" runat="server" CssClass="table table-striped table-sm table-secondary"></asp:GridView>
            <asp:Label ID="ErrorLB" runat="server" Text="異常資料" Visible="false" CssClass="text-danger "></asp:Label>
            <asp:GridView ID="ErrorGV" runat="server" CssClass="table table-striped table-sm table-danger"></asp:GridView>


        </div>
    </main>
</asp:Content>
