<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales022.aspx.cs" Inherits="GGFPortal.Sales.Sales022" %>

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
                    "format": "YYYY-MM-DD",
                    "separator": " ~ ",
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
                //Updates value of date
                $('input[id="ContentPlaceHolder1_DateRangeTB"]').val(start.format('YYYY-MM-DD') + ' ~ ' + end.format('YYYY-MM-DD'));
                //Add the value to hidden field
                $('input[id="ContentPlaceHolder1_HiddenField1"]').val(start.format('YYYY-MM-DD') + ' ~ ' + end.format('YYYY-MM-DD'));
                $('input[id="ContentPlaceHolder1_DateRangeTB"]').trigger('change');
                //確認資料
                var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
                console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' ~ ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + xxxx + ')');
            });
        });
        //postback後將資料塞回欄位
        $(document).ready(function () {
            //Assign the value from hidden field to textbox
            var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
            console.log(xxxx.length);
            if (xxxx.length > 0) {

                onLoad: $('input[id="ContentPlaceHolder1_DateRangeTB"]').val($('input[id="ContentPlaceHolder1_HiddenField1"]').val());
            }

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>訂單出貨日期</span>

            </h3>
            <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>工廠</span>
            </h3>
            <asp:DropDownList ID="工廠DDL" runat="server" CssClass="form-control"></asp:DropDownList>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>客戶</span>
            </h3>
            <asp:TextBox ID="客戶TB" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:AutoCompleteExtender runat="server"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" MinimumPrefixLength="1" ServiceMethod="Search訂單客戶" BehaviorID="客戶TB_AutoCompleteExtender" TargetControlID="客戶TB" ID="客戶TB_AutoCompleteExtender"></ajaxToolkit:AutoCompleteExtender>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>款號</span>
            </h3>
            <asp:TextBox ID="款號TB" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:AutoCompleteExtender runat="server"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" MinimumPrefixLength="1" ServiceMethod="SearchOrdStyle" BehaviorID="款號TB_AutoCompleteExtender" TargetControlID="款號TB" ID="款號TB_AutoCompleteExtender"></ajaxToolkit:AutoCompleteExtender>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>多款號</span>
            </h3>
            <asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-25" TextMode="MultiLine"></asp:TextBox>
                            <div class="form-group btn-group mr-3">
                                <asp:Button ID="SearchBT" runat="server" Text="搜尋" OnClick="SearchBT_Click" />
                </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <h1 class="h2">
                <asp:Label ID="標題LB" runat="server" Text=""></asp:Label></h1>
            <div class="btn-toolbar mb-2 mb-md-0">
                <div class="btn-group mr-2">
                    <asp:Button ID="ExportBT" runat="server" Text="資料匯出" CssClass="btn btn-sm btn-outline-secondary" Visible="false" />
                </div>
                <%--                <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
                    <span data-feather="calendar"></span>
                    This week
                </button>--%>
            </div>
        </div>


        <h3>
            <asp:Label ID="副標LB" runat="server" Text=""></asp:Label></h3>

        <div class="table-responsive">
            <table class="table table-striped table-sm">
            </table>
            <asp:GridView ID="GV" runat="server" CssClass="table table-striped table-sm table-dark" OnRowCommand="GV_RowCommand">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="GVEditBT" runat="server" CausesValidation="False" CommandName="EditData" Text="編輯" />
                        </ItemTemplate>
                        <ControlStyle CssClass="btn btn-primary" />
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="GVDeleteBT" runat="server" CausesValidation="False" CommandName="DeleteData" Text="刪除" OnClientClick="return confirm('是否刪除')" CssClass="btn btn-danger " />
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="GVSelectBT" runat="server" CausesValidation="False" CommandName="SelectData" Text="選擇" CssClass="btn btn-outline-info" />
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
