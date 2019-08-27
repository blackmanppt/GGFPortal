<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales018.aspx.cs" Inherits="GGFPortal.Sales.Sales018" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.js"></script>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.4.1.min.js"></script>
    
    
    <script type="text/javascript"  src="../scripts/daterangepicker/moment.min.js"></script>
    <script type="text/javascript"  src="../scripts/daterangepicker/daterangepicker.min.js"></script>
    <link href="../scripts/daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
<%--    <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />--%>

    <script type="text/javascript">
        $(function () {
            $('input[name="DateRangeTB"]').daterangepicker({
                "showDropdowns": true,
                "autoApply": true,
                "locale": {
                    "format": "YYYY/MM",
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
<body class=" bg-dark" >
    <form id="form1" runat="server">
        <nav class="navbar navbar-dark fixed-top flex-md-nowrap p-0 shadow">

            <asp:Label ID="BrandLB" runat="server" Text="" CssClass="navbar-brand bg-dark col-sm-3 col-md-2 mr-0"></asp:Label>

        </nav>
        <div class="container-fluid ">
            <div class="row">
                <nav class="col-md-2 d-none d-md-block  sidebar bg-secondary">
                    <div class="sidebar-sticky ">
                        <h3 class=" d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-light">
                            <span>需求月份</span>

                        </h3>
                        <asp:TextBox ID="DateRangeTB" name="daterange" runat="server" class="form-control"></asp:TextBox>
                        <h3 class=" d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-light">
                            <span>代工廠</span>

                        </h3>
                        <asp:DropDownList ID="代工廠DDL" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="vendor_name_brief" DataValueField="vendor_id">
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GGFConnectionString %>' SelectCommand="SELECT DISTINCT bas_vendor_master.vendor_name, bas_vendor_master.vendor_id, bas_vendor_master.vendor_name_brief FROM ordc_bah1 INNER JOIN bas_vendor_master ON ordc_bah1.site = bas_vendor_master.site AND ordc_bah1.vendor_id = bas_vendor_master.vendor_id WHERE (ordc_bah1.bah_status <> 'CA')"></asp:SqlDataSource>
                        <h3 class=" d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-light">
                            <span>款號</span>

                        </h3>
                        <asp:TextBox ID="款號TB" runat="server" CssClass="form-control h-25" TextMode="MultiLine"></asp:TextBox>
                        <div class="nav justify-content-end ">
                            <div class=" btn-group nav-item m-1">
                                <asp:Button ID="SearchBT" runat="server" CssClass="btn btn-dark" Text="Search" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" CssClass="btn btn-outline-dark" Text="Clear" OnClick="ClearBT_Click" />
                            </div>

                        </div>


                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GGFConnectionString %>' SelectCommand="select distinct [doc_item] from ordc_sample"></asp:SqlDataSource>
                    </div>
                </nav>

                <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">


                    <div class=" bg-light">

                        <asp:GridView ID="MaterialGV" runat="server" CssClass="table table-striped table-sm table-active" AutoGenerateColumns="False" DataKeyNames="site,ord_nbr,color_id" OnRowCommand="MaterialGV_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="結案BT" runat="server" Text="結案" CssClass="btn btn-light" CommandName="結案" />
                                    </ItemTemplate>
                                    <ItemStyle CssClass=" text-sm-center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="site" HeaderText="公司別" ReadOnly="True" SortExpression="site">
                                    <ItemStyle CssClass="text-sm-center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ord_nbr" HeaderText="訂單號碼" ReadOnly="True" SortExpression="ord_nbr" />
                                <asp:BoundField DataField="cus_item_no" HeaderText="款號" ReadOnly="True" SortExpression="cus_item_no" />
                                <asp:BoundField DataField="doc_item" HeaderText="樣" SortExpression="doc_item" />
                                <asp:BoundField DataField="color_id" HeaderText="color_id" SortExpression="color_id" />
                                <asp:BoundField DataField="color_cname" HeaderText="顏色" SortExpression="color_cname" />
                                <asp:BoundField DataField="color_ename" HeaderText="顏色(英)" SortExpression="color_ename" />
                                <asp:BoundField DataField="req_date" HeaderText="需求日" SortExpression="req_date" DataFormatString="{0:d}" />
                            </Columns>
                            <HeaderStyle CssClass=" text-center text-secondary h5" />
                        </asp:GridView>

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </div>
                </main>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none;" />
                <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" CssClass="alert-danger" Style="display: none">
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
</body>
</html>
