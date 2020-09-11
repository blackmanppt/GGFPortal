<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales014V2.aspx.cs" Inherits="GGFPortal.Sales.Sales014V2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>訂單工廠樣品單產區表</title>
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
                        <h3 class="text-info text-left">訂單工廠樣品單產區表</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>工廠</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="工廠DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="工廠" DataValueField="工廠" CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:GGFConnectionString %>' SelectCommand="SELECT DISTINCT [工廠] FROM [View訂單工廠樣品單]"></asp:SqlDataSource>
                            </div>
                            <div class="form-group">
                                <h5>需求年月(起)</h5>
                                <asp:TextBox ID="StartDayTB" runat="server" CssClass=" form-control" MaxLength="6" TextMode="Number"></asp:TextBox>
                                <ajaxToolkit:TextBoxWatermarkExtender runat="server" BehaviorID="StartDayTB_TextBoxWatermarkExtender" TargetControlID="StartDayTB" ID="StartDayTB_TextBoxWatermarkExtender" WatermarkText="請輸入年月：201601"></ajaxToolkit:TextBoxWatermarkExtender>
                                <h5>需求年月(迄)</h5>
                                <asp:TextBox ID="EndDayTB" runat="server" CssClass=" form-control" MaxLength="6" TextMode="Number"></asp:TextBox>
                                <ajaxToolkit:TextBoxWatermarkExtender runat="server" BehaviorID="EndDayTB_TextBoxWatermarkExtender" TargetControlID="EndDayTB" ID="EndDayTB_TextBoxWatermarkExtender"  WatermarkText="請輸入年月：201612"></ajaxToolkit:TextBoxWatermarkExtender>
                            </div>
                            <h4>種類挑選</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="種類DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="doc_item" DataValueField="doc_item" CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GGFConnectionString %>' SelectCommand="SELECT DISTINCT [doc_item] FROM [ordc_sample]"></asp:SqlDataSource>
                            </div>
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="款號TB_AutoCompleteExtender" TargetControlID="款號TB" ID="款號TB_AutoCompleteExtender" ServiceMethod="SearchOrdStyle" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                <asp:TextBox ID="品牌TB" runat="server" CssClass="form-control" ></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="品牌TB_AutoCompleteExtender" TargetControlID="品牌TB" ID="品牌TB_AutoCompleteExtender" ServiceMethod="Search訂單品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
                            </div>
                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Visible="False" >
                        <LocalReport ReportPath="ReportSource\Sales\ReportSales014V2.rdlc" DisplayName="訂單工廠樣品單" EnableExternalImages="True">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
         <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="show3" runat="server" Text="show3" Style="display: none"/>
                                <%--<asp:Button ID="Button1" runat="server" Text="show3" Style="display: none" />--%>
                                <asp:Panel ID="AlertPanel" runat="server" align="center" Height="100px" Width="600px" BackColor="#009999" Style="display: none">
                                    <div class=" text-center">
                                        <h3>
                                            <asp:Label ID="MessageLB" runat="server" Text=""></asp:Label>
                                           
                                        </h3>
                                        <asp:Button ID="AlertBT" runat="server" Text="確定" CssClass="btn btn-danger" />
                                    </div>
                                </asp:Panel>
                                <ajaxToolkit:ModalPopupExtender ID="AlertPanel_ModalPopupExtender" runat="server" BehaviorID="AlertPanel_ModalPopupExtender" TargetControlID="show3" PopupControlID="AlertPanel" CancelControlID="">
                                </ajaxToolkit:ModalPopupExtender>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
            </div>
    </form>
</body>
</html>
