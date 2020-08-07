<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample012.aspx.cs" Inherits="GGFPortal.Sales.Sample012" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打版完成查詢</title>
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
                        <h3 class="text-info text-left">打版完成查詢</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <%--
                                
                                <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <h4>年度</h4>
                                <div class="form-group">
                                <asp:DropDownList ID="年度DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2" DataTextField="season_y" DataValueField="season_y"  CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>

                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [season_y] FROM [ordc_bah1] ORDER BY [season_y] DESC"></asp:SqlDataSource>
                                    </div>
                            <h4>季節</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="季節DDL" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="season" DataValueField="season"  CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT DISTINCT [season] FROM [ordc_bah1] ORDER BY [season]"></asp:SqlDataSource>
                            </div>

                            --%>
                            <h4>狀態</h4>
                            <div class="form-group">
                                <asp:CheckBox ID="打樣未收單CB" runat="server" Checked="true"  CssClass="form-control" Text="打樣未收單"/>
                                <%--<asp:CheckBox ID="入庫CB" runat="server" Checked="true"   CssClass="form-control" Text="顯示入庫資料"/>--%>
                            </div>
                            <h4>客戶</h4>
                            <div class="form-group">
                                <asp:TextBox ID="代理商TB" runat="server"  CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="代理商TB_AutoCompleteExtender" TargetControlID="代理商TB" ID="代理商TB_AutoCompleteExtender" ServiceMethod="Search樣品客戶" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>

                            </div>
                              <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="款號TB_AutoCompleteExtender" TargetControlID="款號TB" ID="款號TB_AutoCompleteExtender" ServiceMethod="SearchSampleStyleNo" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                <asp:TextBox ID="品牌TB" runat="server" CssClass="form-control" ></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="品牌TB_AutoCompleteExtender" TargetControlID="品牌TB" ID="品牌TB_AutoCompleteExtender" ServiceMethod="Search打樣單品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">

                    <asp:GridView ID="SamGV" runat="server" CssClass="table table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" PageSize="30" OnPageIndexChanging="SamGV_PageIndexChanging" OnRowCommand="SamGV_RowCommand">
                        <Columns>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="145px" >
                                <ItemTemplate>
                                    <asp:Button ID="上傳到料日BT" runat="server" CausesValidation="false" CommandName="上傳" Text="到料" CssClass="btn btn-default"/>
                                    <asp:Button ID="刪除到料日BT" runat="server" CausesValidation="false" CommandName="刪除" Text="刪除" CssClass="btn btn-danger"  OnClientClick="return confirm('是否主副料到期日刪除')" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Position="Top" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>

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
