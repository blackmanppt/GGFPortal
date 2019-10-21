<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F003.aspx.cs" Inherits="GGFPortal.FactoryMG.F003" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <nav class="navbar navbar-dark fixed-top bg-dark flex-md-nowrap p-0 shadow">

            <asp:Label ID="BrandLB" runat="server" Text="" CssClass="navbar-brand col-sm-3 col-md-2 mr-0"></asp:Label>
           
   
        </nav>
        <div class="container-fluid">
            <div class="row">
                <nav class="col-md-2 d-none d-md-block bg-light sidebar">
                    <div class="sidebar-sticky">
                         <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span><asp:Label ID="Label2" runat="server" Text="起迄日期："></asp:Label></span>

                                </h3>
                                <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
                         <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>說明2</span>

                                </h3>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                         <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                                    <span>日期</span>

                                </h3>
                              
                    <asp:Label ID="Label3" runat="server" Text="款號："></asp:Label>

                        <asp:TextBox ID="StyleNoTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo" TargetControlID="StyleNoTB">
                        </ajaxToolkit:AutoCompleteExtender>
                        <asp:Button ID="SearchBT" runat="server" Text="搜尋" CssClass="btn-dark" OnClick="SearchBT_Click" />   
                    </div>
                </nav>
                <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
                    <div class="table-responsive">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT * FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine)">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="Productivity" Name="UsingDefine" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px" Visible="False" Width="90%">
                <LocalReport ReportPath="ReportSource\VN\ReportVN001.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
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
            </ContentTemplate>
        </asp:UpdatePanel>
<%--        <div>
            
            <asp:Label ID="TitleLB" runat="server" Text="工時資料餵入查詢" style="font-size: xx-large; font-weight: 700; color: #990099; background-color: #0099FF;"></asp:Label>
        </div>--%>
    <div>
        
    <table style="width: 600px;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" Format="yyyyMMdd" TargetControlID="StartDayTB" />
                        ~<asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" Format="yyyyMMdd" TargetControlID="EndDay" />
                    </td>
                    <td>
                       
                    </td>
                </tr>
                <tr>

                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="組別"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList ID="TeamCB" runat="server" DataSourceID="SqlDataSource1" DataTextField="MappingData" DataValueField="Data" RepeatDirection="Horizontal" AppendDataBoundItems="True">
                            <asp:ListItem>ALL</asp:ListItem>
                        </asp:CheckBoxList>
                        
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
    </div>
        <div>
            
        </div>
    </form>
</body>
</html>
