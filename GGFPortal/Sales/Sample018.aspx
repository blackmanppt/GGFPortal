<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sample018.aspx.cs" Inherits="GGFPortal.Sales.Sample018" %>

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
<h3 class=" d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>打樣單號</span>

                                </h3>
                                <asp:TextBox ID="打樣單號TB" runat="server" CssClass="form-control h-50" TextMode="MultiLine" ></asp:TextBox>
                                                        
                                                <div class=" float-right btn-group btn m-2 right">
                            <asp:Button ID="UpDateBT" runat="server" Text="上傳" CssClass="btn btn-outline-dark" OnClick="UpDateBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" CssClass="btn btn-success" OnClick="ClearBT_Click" />
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


                    <asp:GridView ID="ErrorGV" runat="server" CssClass="table table-striped table-sm table-danger" />

                        <asp:GridView ID="SamGV" runat="server" CssClass="table table-striped table-sm table-dark" >
<%--                            <Columns>
                                <asp:BoundField DataField="主副料到料日" HeaderText="主副料到料日" SortExpression="主副料到料日"  DataFormatString="{0:d}"  />
                                <asp:BoundField DataField="打版完成日" HeaderText="打版完成日" SortExpression="打版完成日"  DataFormatString="{0:d}"  />
                                <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
                                <asp:BoundField DataField="款號" HeaderText="款號" SortExpression="款號" />
                                <asp:BoundField DataField="打樣單號" HeaderText="打樣單號" SortExpression="打樣單號" />
                                <asp:BoundField DataField="需求日" HeaderText="需求日" SortExpression="需求日"  DataFormatString="{0:d}" NullDisplayText="沒有資料"  />
                            </Columns>--%>
                        </asp:GridView>
        </div>
    </main>
</asp:Content>
