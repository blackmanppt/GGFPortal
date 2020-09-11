<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales012.aspx.cs" Inherits="GGFPortal.Sales.Sales012" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>AMZForecast</title>
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
                        <h3 class="text-info text-left">AMZForecast</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <h4>年度~周數</h4>
                                <div class="form-group">
<%--                                <asp:DropDownList ID="年度DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="season_y" DataValueField="season_y"  CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>

                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [season_y] FROM [ordc_bah1] ORDER BY [season_y] DESC"></asp:SqlDataSource>
    --%>
                                    <div class="form-group">
                                        起始：2018~1<br />
                                        結束：2018~26
                                        </div>
                                    <asp:TextBox ID="開始年度TB" Width="60px" runat="server"></asp:TextBox>~<asp:TextBox ID="開始年度周數TB" Width="60px" runat="server"></asp:TextBox>
                                    </div>
                            <div class="form-group">
                                <asp:TextBox ID="結束年度TB" CssClass="" Width="60px" runat="server" TextMode="Number"></asp:TextBox>~<asp:TextBox ID="結束年度周數TB" CssClass="" Width="60px" runat="server"></asp:TextBox>
                            </div>
                            <%--<h4>季節</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="季節DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="season" DataValueField="season"  CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [season] FROM [ordc_bah1] ORDER BY [season]"></asp:SqlDataSource>
                            </div>
                            <h4>代理商</h4>
                            <div class="form-group">
                                <asp:TextBox ID="代理商TB" runat="server"  CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="代理商TB_AutoCompleteExtender" TargetControlID="代理商TB" ID="代理商TB_AutoCompleteExtender" ServiceMethod="Search訂單客戶品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                <asp:TextBox ID="品牌TB" runat="server" CssClass="form-control" ></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="品牌TB_AutoCompleteExtender" TargetControlID="品牌TB" ID="品牌TB_AutoCompleteExtender" ServiceMethod="Search訂單品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>狀態</h4>
                            <div class="form-group">
                                <asp:CheckBox ID="主料CB" runat="server" Checked="true"  CssClass="form-control" Text="顯示主料資料"/>
                                <asp:CheckBox ID="入庫CB" runat="server" Checked="true"   CssClass="form-control" Text="顯示入庫資料"/>
                            </div>--%>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
                            </div>

                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"  Width="100%" Visible="False" >
                        <LocalReport ReportPath="ReportSource\Sales\ReportSales012.rdlc" DisplayName="AMZ" EnableExternalImages="True">
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
