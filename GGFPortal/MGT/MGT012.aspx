<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="MGT012.aspx.cs" Inherits="GGFPortal.MGT.MGT012" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <script type="text/javascript">
        $(function () {
            var start = moment().subtract(29, 'days');
            var end = moment();
            $('input[id="ContentPlaceHolder1_DateRangeTB"]').daterangepicker({
                singleDatePicker: true,
                showDropdowns: true,
                "locale": {
                    "format": "YYYY-MM-DD",
                    "applyLabel": "Apply",
                    cancelLabel: "Cancel",
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
                    "firstDay": 0
                }
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
<%--            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>
            
            <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender runat="server" BehaviorID="DateRangeTB_CalendarExtender" TargetControlID="DateRangeTB" ID="DateRangeTB_CalendarExtender" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>快遞單號</span>

            </h3>
        
            <asp:TextBox ID="提單TB" runat="server" class="form-control"></asp:TextBox>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>寄件部門</span>

            </h3>
            

            <div class="form-group m-3">

            </div>--%>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" Visible="false" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="ReportSource\MGT\ReportMGT011V2.rdlc" DisplayName="快遞核准單"></LocalReport>
        </rsweb:ReportViewer>
    </main>
                                                   
</asp:Content>
