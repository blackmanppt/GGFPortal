<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales021.aspx.cs" Inherits="GGFPortal.Sales.Sales021" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">

            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>款號</span>

            </h3>
            <div class="form-group">
                <asp:TextBox ID="StyleNoTB" runat="server" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="StyleNoTB_AutoCompleteExtender" TargetControlID="StyleNoTB" ID="StyleNoTB_AutoCompleteExtender" ServiceMethod="SearchOrdStyle"></ajaxToolkit:AutoCompleteExtender>
            </div>
            <div class="form-group align-items-end">
                <asp:Button ID="SearchBT" runat="server" Text="搜尋" CssClass="btn btn-primary" OnClick="SearchBT_Click" />

            </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
            <h1 class="h2">
                <asp:Label ID="款號LB" runat="server" Text=""></asp:Label></h1>
        </div>
        <div class="form-group">
        <div class="form-row">
            <div class="col-2 text-lg-left">
                <asp:Label ID="客戶品牌LB" runat="server" Text="" CssClass="form-text font-weight-bold"></asp:Label>
            </div>
            <div class="col-2 text-lg-left">
                <asp:Label ID="訂單狀態LB" runat="server" Text="" CssClass="form-text font-weight-bold"></asp:Label>
            </div>
            <div class="col-2 text-lg-right">
                                <asp:Button ID="ExportBT" runat="server" Text="匯出" CssClass="btn btn-outline-dark" OnClick="ExportBT_Click" Visible="false" />
            </div>
        </div>
        <div class="form-row">
            <div class="col-2 text-lg-left">
                <asp:Label ID="業務人員LB" runat="server" Text="" CssClass="form-text font-weight-bold"></asp:Label>
            </div>
            <div class="col-2 text-lg-left">
                <asp:Label ID="訂單數量LB" runat="server" Text="" CssClass="form-text font-weight-bold"></asp:Label>
            </div>
        </div>
        <div class="form-row">
            <div class="col-2 text-lg-left">
                <asp:Label ID="代工廠LB" runat="server" Text="" CssClass="form-text font-weight-bold"></asp:Label>
            </div>
        </div>
            </div>
        <asp:GridView ID="採購單GV" runat="server" CssClass="table table-dark"></asp:GridView>
    </main>
</asp:Content>
