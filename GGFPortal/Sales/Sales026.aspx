<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales026.aspx.cs" Inherits="GGFPortal.Sales.Sales026" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
             <div class="form-group">
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>款號 ( 料號內款號 )</span>
            </h3>
                        <asp:TextBox ID="SearchTB" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
            <div class="form-group">
                            <asp:CheckBox ID="MutiCB" runat="server"  CssClass="form-check" Text="多款號查詢" AutoPostBack="true"/>
            
            </div>

                <asp:TextBox ID="MutiTB" runat="server" CssClass="form-control h-50" TextMode="MultiLine" > </asp:TextBox>

            <div class="form-group text-right m-3">
                <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" CssClass="btn btn-primary" />
                <asp:Button ID="ClearBT" runat="server" Text="Clean" OnClick="ClearBT_Click" CssClass="btn btn-outline-danger" />
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
        <asp:GridView ID="GV" runat="server" CssClass="table table-dark"></asp:GridView>
    </main>
    <!--日期暫存-->
    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>
