<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales029.aspx.cs" Inherits="GGFPortal.Sales.Sales029" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>資料匯出</span>

            </h3>
            <div class="form-group">
                <asp:Button ID="AMZ成衣資料匯出BT" runat="server" Text="成衣資料匯出" CssClass="btn btn-block btn-info" OnClick="AMZ成衣資料匯出BT_Click" />
            </div>
            
                <div class="form-group">
                    
                    <asp:Button ID="AMZ主料庫存匯出BT" runat="server" Text="主料庫存匯出" CssClass="btn btn-block btn-primary" OnClick="AMZ主料庫存匯出BT_Click" />
                    </div>
                    <div class="form-group">
                    <asp:Button ID="AMZ越南主料庫存匯出含儲位BT" runat="server" Text="越南主料庫存匯出含儲位" CssClass="btn btn-block btn-dark" OnClick="AMZ越南主料庫存匯出含儲位BT_Click"  />
                
            </div>
        </div>
    </nav>
  <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <!--<div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
                    <h1 class="h2">Dashboard</h1>
                    <div class="btn-toolbar mb-2 mb-md-0">
                        <div class="btn-group mr-2">
                            <button type="button" class="btn btn-sm btn-outline-secondary">Share</button>
                            <button type="button" class="btn btn-sm btn-outline-secondary">Export</button>
                        </div>
                        <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
                            <span data-feather="calendar"></span>
                            This week
                        </button>
                    </div>
                </div>


                <h2>Section title</h2>

        <div class="table-responsive">
            <table class="table table-striped table-sm">
            </table>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-sm table-dark"></asp:GridView>
        </div>-->
    </main>
    
</asp:Content>
