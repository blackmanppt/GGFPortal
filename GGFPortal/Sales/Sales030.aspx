<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales030.aspx.cs" Inherits="GGFPortal.Sales.Sales030" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
                    "format": "YYYYMM",
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
                    $('input[id="ContentPlaceHolder1_DateRangeTB"]').val(start.format('YYYYMM') + ' ~ ' + end.format('YYYYMM'));  
                    //Add the value to hidden field
                    $('input[id="ContentPlaceHolder1_HiddenField1"]').val(start.format('YYYYMM') + ' ~ ' + end.format('YYYYMM'));
                    $('input[id="ContentPlaceHolder1_DateRangeTB"]').trigger('change');
                    //確認資料
                    var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
                    console.log('New date range selected: ' + start.format('YYYYMM') + ' ~ ' + end.format('YYYYMM') + ' (predefined range: ' + xxxx + ')');
            });
        });
        //postback後將資料塞回欄位
        $(document).ready(function () {
            //Assign the value from hidden field to textbox
            var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
            console.log(xxxx.length);
            if (xxxx.length>0) {

                onLoad: $('input[id="ContentPlaceHolder1_DateRangeTB"]').val($('input[id="ContentPlaceHolder1_HiddenField1"]').val());
            }
            
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>
            <div class="form-group">
                <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
                        <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>客戶代號</span>
                            </h3>
            <div class="m-2 form-group">
                <asp:TextBox ID="客戶搜尋TB" runat="server" CssClass="form-control"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="客戶搜尋TB_AutoCompleteExtender" TargetControlID="客戶搜尋TB" ID="客戶搜尋TB_AutoCompleteExtender" ServiceMethod="SearchShipCus" MinimumPrefixLength="1"></ajaxToolkit:AutoCompleteExtender>
                        
            </div>
            <div class="form-group">
                
            </div>
            <div class="form-group ">
                <div class=" text-right">
                    <asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBT_Click" />
                </div>
                
            </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="True" Visible="False" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
            <LocalReport ReportPath="ReportSource\Sales\ReportSales030.rdlc">
            </LocalReport>
    </rsweb:ReportViewer>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
