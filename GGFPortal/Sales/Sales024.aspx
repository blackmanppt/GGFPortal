<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales024.aspx.cs" Inherits="GGFPortal.Sales.Sales024" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="col-md-2 d-none d-md-block bg-light sidebar">
        <div class="sidebar-sticky">
            <h3 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>上傳月份</span>

            </h3>

                        <div class="row m-3 form-group">
                <asp:TextBox ID="DateTB" runat="server" CssClass="form-control"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="DateTB_CalendarExtender" TargetControlID="DateTB" ID="DateTB_CalendarExtender" Format="yyyyMM"></ajaxToolkit:CalendarExtender>
            </div>
            <div class="row m-3">
            
            <label class="btn btn-info">

                <img src="../Pic/Icon/svg/file.svg" />
<input id="upload_file" style="display:none;" type="file" runat="server" accept="application/vnd.ms-excel , application/vnd.openxmlformats-officedocument.spreadsheetml.sheet">
<i class="fa fa-photo"></i> 上傳檔案
</label>
                </div>

            <div class="form-group">
                <asp:Button ID="DeleteBT" runat="server" Text="刪除" Visible="false" CssClass="btn btn-outline-danger btn-block" OnClick="DeleteBT_Click" />
            </div>
            <div class="row m-3 form-group">
            <asp:Button ID="CheckBT" runat="server" Text="Check" CssClass="btn btn-outline-dark" OnClick="CheckBT_Click" />
            <asp:Button ID="UpLoadBT" runat="server" Text="UpLoad" CssClass="btn btn-dark" OnClick="UpLoadBT_Click"/>
                </div>
        </div>
    </nav>

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
        <div class="table-responsive">
            <asp:GridView ID="GuidanceErrorGV" runat="server" CssClass="table table-striped table-sm table-primary"></asp:GridView>
            <asp:GridView ID="CapacityErrorGV" runat="server" CssClass="table table-striped table-sm table-danger"></asp:GridView>
        </div>
    </main>
</asp:Content>
