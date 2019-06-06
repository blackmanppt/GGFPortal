<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance016.aspx.cs" Inherits="GGFPortal.Finance.Finance016" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>海關匯率</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
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
                        <h3 class="text-info text-left">海關三巡匯入</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>公司別</h4>
                            <asp:DropDownList ID="公司別DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="site" DataValueField="site">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [site] FROM [bas_customs_rate]"></asp:SqlDataSource>
                            <h4>匯入檔案</h4>
                            
                            <asp:FileUpload ID="文件上傳FU" runat="server" />
                            <div class="form-group">
                                <%--<asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />--%>
                                <asp:Button ID="DataCheckBT" runat="server" Text="CheckData" CssClass="btn btn-danger" OnClick="DataCheckBT_Click" />
                                <asp:Button ID="UpLoadBT" runat="server" Text="UpLoadData" CssClass="btn btn-group" OnClick="UpLoadBT_Click" />
                            </div>
                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="TitleLB1" runat="server" Text="匯入年份：" CssClass=" h2" Visible="false"></asp:Label><asp:Label ID="YearLB" runat="server" Text="" CssClass=" h2" Visible="false"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="TitleLB2" runat="server" Text="匯入月份：" CssClass=" h2" Visible="false"></asp:Label><asp:Label ID="MonthLB" runat="server" Text="" CssClass=" h2" Visible="false"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:Label ID="TitleLB3" runat="server" Text="匯入三巡：" CssClass=" h2" Visible="false"></asp:Label><asp:Label ID="三巡LB" runat="server" Text="" CssClass=" h2" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="row">

                        <asp:GridView ID="ErrorGV" CssClass="table table-hover table-condensed" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#FFFFCC" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:GridView ID="DataGV" CssClass="table table-hover table-striped" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Button ID="show3" runat="server" Text="show3" Style=" display:none" OnClick="show3_Click" />
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
