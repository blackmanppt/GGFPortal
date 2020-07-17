<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales023.aspx.cs" Inherits="GGFPortal.Sales.Sales023" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
<h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>轉出款號</span>
            </h3>
            <asp:TextBox ID="款號TB" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:AutoCompleteExtender runat="server"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" MinimumPrefixLength="1" ServiceMethod="SearchOrdStyle" BehaviorID="款號TB_AutoCompleteExtender" TargetControlID="款號TB" ID="款號TB_AutoCompleteExtender"></ajaxToolkit:AutoCompleteExtender>
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>轉入款號</span>
            </h3>
            <asp:TextBox ID="轉入款號TB" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:AutoCompleteExtender runat="server"  ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" MinimumPrefixLength="1" ServiceMethod="SearchOrdStyle" BehaviorID="轉入款號TB_AutoCompleteExtender" TargetControlID="轉入款號TB" ID="轉入款號TB_AutoCompleteExtender"></ajaxToolkit:AutoCompleteExtender>

                            <div class="form-group btn-group mr-3">
                                <asp:Button ID="SearchBT" runat="server" Text="搜尋" CssClass="btn btn-outline-dark" OnClick="SearchBT_Click" />
                                <asp:Button ID="ClearBT" runat="server" Text="清除搜尋資料" CssClass="btn btn-secondary" OnClick="ClearBT_Click" />
                </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <h1 class="h2">
                <asp:Label ID="標題LB" runat="server" Text=""></asp:Label></h1>
            <div class="btn-toolbar mb-2 mb-md-0">
                <div class=" form-group btn-group mr-2">
                    <asp:Button ID="ExportBT" runat="server" Text="資料匯出" CssClass="btn btn-sm btn-outline-secondary" Visible="false" OnClick="ExportBT_Click" />
                </div>
                <%--                <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
                    <span data-feather="calendar"></span>
                    This week
                </button>--%>
            </div>
        </div>


        <h3>
            <asp:Label ID="副標LB" runat="server" Text=""></asp:Label></h3>

        <div class="table-responsive">
            <table class="table table-striped table-sm">
            </table>
            <asp:GridView ID="GV" runat="server" CssClass="table table-striped table-sm table-dark" OnRowCommand="GV_RowCommand" AutoGenerateColumns="False">
                <Columns>
<%--                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="GVEditBT" runat="server" CausesValidation="False" CommandName="EditData" Text="編輯" />
                        </ItemTemplate>
                        <ControlStyle CssClass="btn btn-primary" />
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="GVDeleteBT" runat="server" CausesValidation="False" CommandName="DeleteData" Text="刪除" OnClientClick="return confirm('是否刪除')" CssClass="btn btn-danger " />
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="GVSelectBT" runat="server" CausesValidation="False" CommandName="SelectData" Text="入庫明細" CssClass="btn btn-outline-info" />
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="庫存調撥單" HeaderText="庫存調撥單" SortExpression="庫存調撥單" />
                    <asp:BoundField DataField="庫存調撥序號" HeaderText="庫存調撥序號" SortExpression="庫存調撥序號" />
                    <asp:BoundField DataField="料號" HeaderText="料號" SortExpression="料號" />
                    <asp:BoundField DataField="料號規格" HeaderText="料號規格" SortExpression="料號規格" />
                    <asp:BoundField DataField="轉出號碼" HeaderText="轉出號碼" SortExpression="轉出號碼" />
                    <asp:BoundField DataField="轉出款號" HeaderText="轉出款號" SortExpression="轉出款號" />
                    <asp:BoundField DataField="轉入號碼" HeaderText="轉入號碼" SortExpression="轉入號碼" />
                    <asp:BoundField DataField="轉入款號" HeaderText="轉入款號" SortExpression="轉入款號" />
                    <asp:BoundField DataField="調撥數量" HeaderText="調撥數量" SortExpression="調撥數量" />
                    <asp:BoundField DataField="調撥單位" HeaderText="調撥單位" SortExpression="調撥單位" />
                    <asp:BoundField DataField="採購單價" HeaderText="採購單價" SortExpression="採購單價" />
                    <asp:BoundField DataField="採購單位" HeaderText="採購單位" SortExpression="採購單位" />
                </Columns>

            </asp:GridView>
        </div>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
