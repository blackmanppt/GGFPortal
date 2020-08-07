<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Finance008.aspx.cs" Inherits="GGFPortal.Finance.Finance008" %>

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
                    "format": "YYYYMMDD",
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
                    $('input[id="ContentPlaceHolder1_DateRangeTB"]').val(start.format('YYYYMMDD') + ' ~ ' + end.format('YYYYMMDD'));  
                    //Add the value to hidden field
                    $('input[id="ContentPlaceHolder1_HiddenField1"]').val(start.format('YYYYMMDD') + ' ~ ' + end.format('YYYYMMDD'));
                    $('input[id="ContentPlaceHolder1_DateRangeTB"]').trigger('change');
                    //確認資料
                    var xxxx = $('input[id="ContentPlaceHolder1_HiddenField1"]').val();
                    console.log('New date range selected: ' + start.format('YYYYMMDD') + ' ~ ' + end.format('YYYYMMDD') + ' (predefined range: ' + xxxx + ')');
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
            <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>客戶代號</span>

            </h3>
            <div class="form-group">
    <asp:TextBox ID="AgentSearchTB" runat="server" CssClass="form-control"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="2"  ServiceMethod="Search訂單客戶品牌" TargetControlID="AgentSearchTB" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc">
        </ajaxToolkit:AutoCompleteExtender>
            </div>
            <div class="form-group m-2">
                <asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchBT_Click" />
            </div>
        </div>

    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Height="92%" Width="100%" Visible="False">
            <LocalReport ReportPath="ReportSource\Finance\ReportFinance008V2.rdlc"></LocalReport>
        </rsweb:ReportViewer>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

