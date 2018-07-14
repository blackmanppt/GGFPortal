<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance015.aspx.cs" Inherits="GGFPortal.Finance.Finance015" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文件上傳日-查詢</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-left">文件上傳日-查詢</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">

                            <h4>出貨日</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyy-MM-dd" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="EndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" BehaviorID="EndDay_CalendarExtender" TargetControlID="EndDay"  Format="yyyy-MM-dd" />
                            </div>

                            <h4>文件實際上傳日</h4>
                            <div class="form-group">
                                <asp:TextBox ID="UploadDateTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" TargetControlID="UploadDateTB" ID="UploadDateTB_CalendarExtender"   Format="yyyy-MM-dd"  ></ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="UploadEndDateTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="UploadEndDateTB_CalendarExtender" TargetControlID="UploadEndDateTB" ID="UploadEndDateTB_CalendarExtender"  Format="yyyy-MM-dd" ></ajaxToolkit:CalendarExtender>
                                <asp:CheckBox ID="文件上傳CB" runat="server" CssClass="form-control" AutoPostBack="True" OnCheckedChanged="文件上傳CB_CheckedChanged" Text="文件未上傳" />
                            </div>
                            <h4>預計收款日</h4>
                            <div class="form-group">
                                <asp:TextBox ID="AcrStartDateTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="AcrStartDateTB_CalendarExtender" TargetControlID="AcrStartDateTB" ID="AcrStartDateTB_CalendarExtender" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="AcrEndDateTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="AcrEndDateTB_CalendarExtender" TargetControlID="AcrEndDateTB" ID="AcrEndDateTB_CalendarExtender" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                            </div>
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StyleTB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="StyleTB"  ServiceMethod="SearchOrdStyle" MinimumPrefixLength="1" UseContextKey="True" >
                                </ajaxToolkit:AutoCompleteExtender>
                            </div>

                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False" >
                        <LocalReport ReportPath="ReportSource\Finance\ReportFinance015.rdlc" DisplayName="文件上傳">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
