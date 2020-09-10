<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales013.aspx.cs" Inherits="GGFPortal.Sales.Sales013" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRP排程表</title>
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
                        <h3 class="text-info text-left">CRP排程表</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>預計上線日</h4>
                            <div class="form-group">
                                <asp:TextBox ID="下線日StartTB" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="下線日StartTB_CalendarExtender" TargetControlID="下線日StartTB" ID="下線日StartTB_CalendarExtender" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="下線日EndTB" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="下線日EndTB_CalendarExtender" TargetControlID="下線日EndTB" ID="下線日EndTB_CalendarExtender" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>
                            </div>
                            <h4>車縫組</h4>
                            <div class="from-group">
                                <asp:DropDownList ID="車縫DDL" runat="server" CssClass=" form-control dropdown-menu-left">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>A組</asp:ListItem>
                                    <asp:ListItem>C組</asp:ListItem>
                                    <asp:ListItem>E組</asp:ListItem>
                                    <asp:ListItem>外廠</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <h4>客戶代號</h4>
                            <%--                            <asp:DropDownList ID="客戶DDL" runat="server" AppendDataBoundItems="true" DataSourceID="SqlDataSource1" DataTextField="agents" DataValueField="agents" CssClass=" form-control " SelectMethod="">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>--%>
                            <div class="form-group">
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:GGFConnectionString %>' SelectCommand="SELECT DISTINCT [agents] FROM [ordc_bah1] WHERE ([bah_status] <> @bah_status) order by agents">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="CA" Name="bah_status" Type="String"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <asp:UpdatePanel ID="updatepanel1" runat="server">

                                    <ContentTemplate>

                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>

                                        <ajaxToolkit:PopupControlExtender ID="TextBox1_PopupControlExtender" runat="server"
                                            Enabled="True" ExtenderControlID="" TargetControlID="TextBox1"
                                            PopupControlID="Panel1" OffsetY="22">
                                        </ajaxToolkit:PopupControlExtender>

                                        <asp:Panel ID="Panel1" runat="server" Height="200px" Width="145px"
                                            BorderStyle="Solid" BorderWidth="2px" Direction="LeftToRight"
                                            ScrollBars="Auto" BackColor="#006699" Style="display: none" ForeColor="#66FFFF">

                                            <asp:CheckBoxList ID="CheckBoxList1" runat="server"
                                                DataSourceID="SqlDataSource1" DataTextField="agents"
                                                DataValueField="agents" AutoPostBack="True"
                                                OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                            </asp:CheckBoxList>

                                        </asp:Panel>

                                    </ContentTemplate>

                                </asp:UpdatePanel>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
                            </div>
                        </div>




                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" Visible="False">
                        <LocalReport ReportPath="ReportSource\Sales\ReportSales013.rdlc" DisplayName="CRP排程表" EnableExternalImages="True">
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
