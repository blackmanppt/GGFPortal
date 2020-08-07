<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F015.aspx.cs" Inherits="GGFPortal.FactoryMG.F015" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


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
            var start = moment().subtract(29, 'days');
            var end = moment();
            $('input[name="DateRangeTB"]').daterangepicker({
                "startDate": start,
                "endDate": end,
                "showDropdowns": true,
                "autoApply": true,
                "locale": {
                    "format": "YYYYMMDD",
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">   </asp:ScriptManager>
                 <nav class="navbar navbar-dark fixed-top bg-dark flex-md-nowrap p-0 shadow">

            <asp:Label ID="BrandLB" runat="server" Text="" CssClass="navbar-brand col-sm-3 col-md-2 mr-0"></asp:Label>
           
   
        </nav>
        <div class="container-fluid">
            <div class="row">
                <nav class="col-md-2 d-none d-md-block bg-light sidebar">
                    <div class="sidebar-sticky">
                                                    <h3>
                                <asp:Label ID="AreaLB" runat="server" Text="地區" Visible="false"></asp:Label></h3>
                            <asp:DropDownList ID="AreaDDL" runat="server" CssClass="dropdown form-control" Visible="false">
                                <asp:ListItem>VGG</asp:ListItem>
                                <asp:ListItem>GAMA</asp:ListItem>
                            </asp:DropDownList>
                         <h3 >
                                    <asp:Label ID="Label3" runat="server" Text="起迄日期："></asp:Label>

                                </h3>
                                <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>

                            <h2><asp:Label ID="StyleNoLB" runat="server" Text="Style No："></asp:Label></h2>
                    

                        <asp:TextBox ID="StyleNoSeachTB" runat="server" CssClass="form-control" ></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="StyleNoSeachTB_AutoCompleteExtender" runat="server" TargetControlID="StyleNoSeachTB" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo">
                        </ajaxToolkit:AutoCompleteExtender>
                        <h2><asp:Label ID="StyleNoMutiLB" runat="server" Text="Muti Style No："></asp:Label></h2>
                        <asp:TextBox ID="StyleNoSearchMutiTB" runat="server" CssClass="form-control h-25" TextMode="MultiLine"></asp:TextBox>
                        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" CssClass="btn-dark"/>
                    
                    </div>
                </nav>
                <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="false" Width="100%" Height="60%" >
                        <LocalReport ReportPath="ReportSource\Factory\ReportF015.rdlc"></LocalReport>
                    </rsweb:ReportViewer>
                </main>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="show3" runat="server" Text="show3" Style="display:none" />
                <asp:Panel ID="AlertPanel" runat="server" align="center"  CssClass="alert-danger w-75" Style="display: none">
                    <div class=" text-center">
                        <h3>
                            <asp:Label ID="MessageLB" runat="server" Text="" CssClass="h3"></asp:Label>

                        </h3>
                        <asp:Button ID="AlertBT" runat="server" Text="OK" CssClass="btn btn-danger" />
                    </div>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                </ajaxToolkit:ModalPopupExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
      

      

    </form>
</body>
</html>