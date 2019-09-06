<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MIS011.aspx.cs" Inherits="GGFPortal.MIS.MIS011" %>

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
    <style type="text/css">
    .hiddencol
    {
        display:none;
    }
    .viscol
    {
        display:block;
    }
</style>
    
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
                         <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>說明1</span>

                                </h3>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                         <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>說明2</span>

                                </h3>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                         <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>日期</span>

                                </h3>
                                <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
                       <%-- <ul class="nav flex-column">
                            <li class="nav-item">
                                                            <a class="nav-link active" href="#">
                                <span data-feather="home"></span>
                                Dashboard <span class="sr-only">(current)</span>
                            </a>
                                <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>說明</span>

                                </h3>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            </li>
                            <li class="nav-item">
                                <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>說明</span>

                                </h3>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                            </li>
                             <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="file"></span>
                                Orders
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="shopping-cart"></span>
                                Products
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="users"></span>
                                Customers
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="bar-chart-2"></span>
                                Reports
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="layers"></span>
                                Integrations
                            </a>
                        </li>
                        </ul>--%>

                        <%--                    <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                        <span>Saved reports</span>
                        <a class="d-flex align-items-center text-muted" href="#">
                            <span data-feather="plus-circle"></span>
                        </a>
                    </h6>
                    <ul class="nav flex-column mb-2">
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="file-text"></span>
                                Current month
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="file-text"></span>
                                Last quarter
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="file-text"></span>
                                Social engagement
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <span data-feather="file-text"></span>
                                Year-end sale
                            </a>
                        </li>
                    </ul>--%>
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
                        <table class="table table-striped table-sm">
                        </table>
                        <asp:GridView ID="LanguageGV" runat="server" CssClass="table table-striped table-sm table-dark" AutoGenerateColumns="False" DataKeyNames="id,程式,資料代號" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:TemplateField HeaderText="編輯"   >
                                    <ItemTemplate>
                                        <div class="  text-center">
                                        <div class="btn-group">
                                        <asp:Button ID="AddBT" runat="server" Text="新增" CssClass="btn btn-primary" CommandName="Add" />
                                        <asp:Button ID="DeleteBT" runat="server" Text="刪除"  CssClass="btn btn-danger" CommandName="Delete" OnClientClick="return confirm('是否刪除')" />
                                        </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"   ItemStyle-cssclass="hiddencol" HeaderStyle-CssClass="hiddencol"  >

                                </asp:BoundField>
                                <asp:BoundField DataField="程式" HeaderText="程式" ReadOnly="True" SortExpression="程式" ItemStyle-CssClass="align-items-center" />
                                <asp:BoundField DataField="資料代號" HeaderText="資料代號" ReadOnly="True" SortExpression="資料代號" />
                                <asp:BoundField DataField="中文" HeaderText="中文" SortExpression="中文" />
                                <asp:BoundField DataField="英文" HeaderText="英文" SortExpression="英文" />
                                <asp:BoundField DataField="越文" HeaderText="越文" SortExpression="越文" />
                                <asp:BoundField DataField="說明" HeaderText="說明" SortExpression="說明" />
                                <asp:BoundField DataField="建立時間" HeaderText="建立時間" SortExpression="建立時間" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="異動時間" HeaderText="異動時間" SortExpression="異動時間" DataFormatString="{0:d}" />
                            </Columns>
                            <RowStyle CssClass="align-items-center" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT * FROM [GGF多語對照表]"></asp:SqlDataSource>
                    </div>
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
