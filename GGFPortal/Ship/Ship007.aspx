<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ship007.aspx.cs" Inherits="GGFPortal.Ship.Ship007" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>採購入庫狀況查詢</title>
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
                        <h3 class="text-info text-left">採購入庫狀況查詢</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass="form-control" Height="100px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <h4>採購單</h4>
                                <div class="form-group">
                                <asp:TextBox ID="採購單TB" runat="server" CssClass="form-control" Height="100px" TextMode="MultiLine"></asp:TextBox>
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
                        <LocalReport ReportPath="ReportSource\Ship\ReportShip007.rdlc" DisplayName="採購入庫狀況" EnableExternalImages="True">
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
