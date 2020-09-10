<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance002V2.aspx.cs" Inherits="GGFPortal.Finance.Finance002V2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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



    <script type="text/javascript" src="../scripts/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../scripts/daterangepicker/daterangepicker.min.js"></script>
    <link href="../scripts/daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        $(function () {
            $('input[name="DateRangeTB"]').daterangepicker({
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
                console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
            });
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 16.666667%;
            flex: 0 0 16.666667%;
            max-width: 16.666667%;
            left: 0px;
            top: -662px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar ">

            <asp:Label ID="TitleLB" runat="server" Text="" CssClass="btn btn-info navbar-brand  "></asp:Label>

            <%--         <asp:Button ID="IndexBT" runat="server" Text="返回搜尋畫面" OnClick="IndexBT_Click" CssClass="btn btn-outline-success" />--%>
        </nav>
        <div class=" container-fluid">

            <div class="row table-bordered table-dark  mb-2">
                <div class="col-sm-1 text-right">
                    <asp:Label ID="SiteLB" runat="server" Text="公司別："></asp:Label>
                </div>
                <div class="col-sm-2">

                    <asp:DropDownList ID="SiteDDL" runat="server" CssClass="form-control dropdown">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>GGF</asp:ListItem>
                        <asp:ListItem>TCL</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-1 text-right">
                    <asp:Label ID="ETAETDLB" runat="server" Text="ETA/ETD為0："></asp:Label>

                </div>
                <div class="col-sm-1">
                    <asp:RadioButtonList ID="ETARBL" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>ETA</asp:ListItem>
                        <asp:ListItem>ETD</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-sm-1 text-right">

                    <asp:Label ID="RecDateLB" runat="server" Text="入庫日期："></asp:Label>

                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="DateRangeTB" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-1 text-right">
                    <asp:Label ID="ItemLB" runat="server" Text="主/副料："></asp:Label>
                </div>
                <div class="col-sm-2">
                    <asp:RadioButtonList ID="ItemRBL" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>主料</asp:ListItem>
                        <asp:ListItem>副料</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row  table-bordered  table-dark  mb-2">
                <div class="col-sm-1 text-right">
                    <asp:Label ID="NationLB" runat="server" Text="產區："></asp:Label>
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="NationDDL" runat="server" CssClass="form-control dropdown">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-1 text-right">
                    <asp:Label ID="AcpStatusLB" runat="server" Text="付款狀態："></asp:Label>
                </div>
                <div class="col-sm-2">
                    <asp:RadioButtonList ID="ACPRBL" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>已付</asp:ListItem>
                        <asp:ListItem>未付</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-sm-1 text-right">
                    <asp:Label ID="FactoryLB" runat="server" Text="代工廠："></asp:Label>
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="FactoryDDL" runat="server" CssClass="form-control dropdown">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-1 text-right">
                    <asp:Label ID="PurLB" runat="server" Text="採購單號："></asp:Label>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="PurTB" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="PurTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchPurID" TargetControlID="PurTB">
                    </ajaxToolkit:AutoCompleteExtender>
                </div>
            </div>
            <div class="row  table-bordered  table-dark  mb-2">
                <div class="col-sm-1 text-right">
                    <asp:Label ID="Label2" runat="server" Text="款號："></asp:Label>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="StyleNoTB" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo" TargetControlID="StyleNoTB">
                    </ajaxToolkit:AutoCompleteExtender>
                </div>
                <div class="col-sm-1 text-right">
                    <asp:Label ID="Label3" runat="server" Text="訂單單號："></asp:Label>
                </div>
                <div class="col-sm-2">

                    <asp:TextBox ID="OrdNbrTB" runat="server" CssClass="form-control"></asp:TextBox>

                    <ajaxToolkit:AutoCompleteExtender ID="OrdNbrTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchOrdNbr" TargetControlID="OrdNbrTB">
                    </ajaxToolkit:AutoCompleteExtender>

                </div>
                <div class="col-sm-1 text-right">
                    <asp:Label ID="VendorLB" runat="server" Text="供應商代號："></asp:Label>
                </div>
                <div class="col-sm-2">
                    <div class=" btn-group">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:TextBox ID="VendorTB" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="VendorTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="2" ServiceMethod="SearchVendorID" TargetControlID="VendorTB">
                                </ajaxToolkit:AutoCompleteExtender>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:ImageButton ID="SearchVendorIDBT" runat="server" Height="25px" ImageUrl="~/IMG/images.png" OnClick="SearchVendorIDBT_Click" Width="31px" />

                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="SearchVendorIDPanel" TargetControlID="SearchVendorIDBT" CancelControlID="SearchCancel"></ajaxToolkit:ModalPopupExtender>
                    </div>
                </div>
                <div class="col-sm-1 text-right">

                    <asp:Label ID="Label4" runat="server" Text="入庫單號："></asp:Label>

                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="RecTB" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row table-dark mb-2">
                <div class="col-10"></div>
                <div class="col-2 align-items-end">
                    
                                        <asp:Button ID="ClearBT" runat="server" Text="清空資料" OnClick="ClearBT_Click" CssClass="btn btn-outline-secondary" />
                    <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <div>



                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="False"  CssClass="bg-dark" Width="100%" >
                    <LocalReport ReportPath="ReportSource\ReportFinance002.rdlc">
                    </LocalReport>
                </rsweb:ReportViewer>



            </div>
        </div>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="SearchVendorIDPanel" TargetControlID="SearchVendorIDBT" CancelControlID="SearchCancel"></ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="SearchVendorIDPanel" runat="server" align="center" Height="400px" Width="600px" ScrollBars="Horizontal" BackColor="#33CCFF" Style="display: none">
            <asp:Button ID="ShowBT" runat="server" Text="Button" Visible="false" />
            <table style="width: 400px;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="廠商名稱或代號："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="SearchVendorID2TB" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="SearchVendorID2" runat="server" OnClick="SearchVendorID2_Click" Text="Search" />
                        <asp:Button ID="SearchCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="VendorGV" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="vendor_id" OnSelectedIndexChanging="VendorGV_SelectedIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="vendor_id" HeaderText="vendor_id" />
                                        <asp:BoundField DataField="vendor_name" HeaderText="vendor_name" />
                                    </Columns>
                                </asp:GridView>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
                <asp:Panel ID="AlertPanel" runat="server" align="center" CssClass="alert-danger w-75" Style="display: none">
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
        <asp:HiddenField ID="hfCustomerId" runat="server" />
    </form>
    <script src="../scripts/bootstrap-4.3.1/js/dist/util.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/dropdown.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/collapse.js"></script>
</body>
</html>
