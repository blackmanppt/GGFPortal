<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales027.aspx.cs" Inherits="GGFPortal.Sales.Sales027" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
           <%-- <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>日期</span>

            </h3>--%>
            <div class="row m-3">
            
            <label class="btn btn-info">

                <img src="../Pic/Icon/svg/file.svg" />
<input id="upload_file" style="display:none;" type="file" runat="server" accept="application/vnd.ms-excel , application/vnd.openxmlformats-officedocument.spreadsheetml.sheet">
<i class="fa fa-photo"></i> 上傳檔案
</label>
                </div>
            <div class="row m-3">
            <asp:Button ID="CheckBT" runat="server" Text="Check" CssClass="btn btn-outline-dark" OnClick="CheckBT_Click" />
            <asp:Button ID="UpLoadBT" runat="server" Text="UpLoad" CssClass="btn btn-dark" OnClick="UpLoadBT_Click"/>
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
        <div class="table-responsive">
            <asp:GridView ID="ErrorGV" runat="server" CssClass="table table-striped table-sm table-primary"></asp:GridView>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-sm table-dark"></asp:GridView>
        </div>
    </main>
</asp:Content>
