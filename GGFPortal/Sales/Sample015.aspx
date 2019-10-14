<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample015.aspx.cs" Inherits="GGFPortal.Sales.Sample015" %>

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
                "singleDatePicker": true,
                "showDropdowns": true,
                "locale": {
                    "format": "YYYY-MM-DD",
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
                "alwaysShowCalendars": true
            }, function (start, end, label) {
                console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-dark fixed-top bg-dark flex-md-nowrap p-0 shadow">

            <asp:Label ID="BrandLB" runat="server" Text="" CssClass="navbar-brand col-sm-3 col-md-2 mr-0"></asp:Label>
            <%--        <a class="navbar-brand col-sm-3 col-md-2 mr-0" href="#">Company name</a>
    <input class="form-control form-control-dark w-100" type="text" placeholder="Search" aria-label="Search">
        <ul class="navbar-nav px-3">
            <li class="nav-item text-nowrap">
                <a class="nav-link" href="#">Sign out</a>
            </li>
        </ul>--%>
        </nav>
        <div class="container-fluid">
            <div class="row">
                <nav class="col-md-2 d-none d-md-block bg-light sidebar">
                    <div class="sidebar-sticky">

                         
                         <h3 class=" d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-danger">
                                    <span>日期</span>

                                </h3>
                                <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
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


                    <asp:GridView ID="ErrorGV" runat="server" CssClass="table table-striped table-sm table-danger"  AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="打樣單號" HeaderText="打樣單號" SortExpression="打樣單號" />
                            <asp:BoundField DataField="款號" HeaderText="款號" SortExpression="款號" />
                            <asp:BoundField DataField="客戶代號" HeaderText="客戶代號" SortExpression="客戶代號" />
                            <asp:BoundField DataField="打樣單狀態" HeaderText="打樣單狀態" SortExpression="打樣單狀態" />
                            <asp:BoundField DataField="打樣處理" HeaderText="打樣處理" SortExpression="打樣處理" />
                        </Columns>
                    </asp:GridView>
                                        <asp:GridView ID="TESTGV" runat="server" CssClass="table table-striped table-sm table-danger"  AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Search" HeaderText="Search" SortExpression="Search" />
                            <asp:BoundField DataField="打樣單狀態" HeaderText="打樣單狀態" SortExpression="打樣單狀態" />
                            <asp:BoundField DataField="打樣處理" HeaderText="打樣處理" SortExpression="打樣處理" />
                        </Columns>
                    </asp:GridView>
                        <asp:GridView ID="SamGV" runat="server" CssClass="table table-striped table-sm table-dark" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="發版日期" HeaderText="發版日期" SortExpression="發版日期"  DataFormatString="{0:d}"  />
                                <asp:BoundField DataField="打版完成日" HeaderText="打版完成日" SortExpression="打版完成日"  DataFormatString="{0:d}"  />
                                <asp:BoundField DataField="客戶名稱" HeaderText="客戶名稱" SortExpression="客戶名稱" />
                                <asp:BoundField DataField="款號" HeaderText="款號" SortExpression="款號" />
                                <asp:BoundField DataField="打樣單號" HeaderText="打樣單號" SortExpression="打樣單號" />
                                <asp:BoundField DataField="需求日" HeaderText="需求日" SortExpression="需求日"  DataFormatString="{0:d}" NullDisplayText="沒有資料"  />
                            </Columns>
                        </asp:GridView>
                    
                </main>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="show3" runat="server" Text="show3" Style="" />
                <asp:Panel ID="AlertPanel" runat="server" align="center"  CssClass="alert-danger w-75" Style="display: none">
                    <div class=" text-center">
                        <h3>
                            <asp:Label ID="MessageLB" runat="server" Text="" CssClass="h3"></asp:Label>

                        </h3>
                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-danger" />
                    </div>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                </ajaxToolkit:ModalPopupExtender>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
