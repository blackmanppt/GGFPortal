<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample016.aspx.cs" Inherits="GGFPortal.Sales.Sample016" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打樣收單查詢(河內)</title>
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
                        <h3 class="text-info text-left">打樣收單查詢(河內)</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>
                                <asp:Label ID="Label1" runat="server" Text="收單日期"></asp:Label></h4>
                            <asp:TextBox ID="收單起TB" runat="server" AutoPostBack="true" CssClass=" form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" BehaviorID="收單起TB_CalendarExtender" TargetControlID="收單起TB" ID="收單起TB_CalendarExtender" Format="yyyy/MM/dd" ></ajaxToolkit:CalendarExtender>
                            <asp:TextBox ID="收單迄TB" runat="server" AutoPostBack="true" CssClass=" form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender runat="server" BehaviorID="收單迄TB_CalendarExtender" TargetControlID="收單迄TB" ID="收單迄TB_CalendarExtender" Format="yyyy/MM/dd" ></ajaxToolkit:CalendarExtender>
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass=" form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="款號TB_AutoCompleteExtender" TargetControlID="款號TB" ID="款號TB_AutoCompleteExtender" ServiceMethod="SearchSampleStyleNo" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                                        <asp:TextBox ID="BrandTB" runat="server" CssClass=" form-control"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="BrandTB_AutoCompleteExtender" runat="server" TargetControlID="BrandTB" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="Search打樣單品牌"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc">
                        </ajaxToolkit:AutoCompleteExtender>

                            </div>
                            <h4>樣品種類</h4>
                            <div class=" ">
                                                        <asp:DropDownList ID="SamcTypeDDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSourceSamcType" DataTextField="type_desc" DataValueField="type_id"  CssClass=" form-control dropdown ">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSourceSamcType" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [type_id], [type_desc] FROM [samc_type] ORDER BY [type_id]"></asp:SqlDataSource>
                            </div>
                            <h4>樣品單處理狀態</h4>
                            <div class="">
                                 <asp:DropDownList ID="NewOldDDL" runat="server" CssClass=" form-control dropdown ">
                            <asp:ListItem Value="2">業務完成</asp:ListItem>
                            <asp:ListItem Value="3">打樣完成</asp:ListItem>
                            <asp:ListItem Value="4">全部</asp:ListItem>
                        </asp:DropDownList>
                            </div>
                            <h4>打樣單狀態</h4>
                            <div class=" ">
                                <asp:DropDownList ID="StatusDDL" runat="server" AutoPostBack="True"  CssClass=" form-control dropdown ">
                            <asp:ListItem Value="A">新增</asp:ListItem>
                            <asp:ListItem Value="CL">結案</asp:ListItem>
                            <asp:ListItem Value="CA">刪除</asp:ListItem>
                            <asp:ListItem Value="ALL">全部</asp:ListItem>
                        </asp:DropDownList>
                            </div>
                           <div class="form-group">
                               <h4>樣衣發單地區</h4>
                               <asp:CheckBox ID="AreaCB" runat="server" Text="河內" Checked="true" />
                            </div>

                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="800px" Width="100%" Visible="False">
                        <LocalReport ReportPath="ReportSource\Sales\ReportSALEV6.rdlc" DisplayName="樣品單資料" EnableExternalImages="True">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Button ID="show3" runat="server" Text="show3" Style="display: none" />
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
