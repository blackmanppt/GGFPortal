<%@ Page Title="" Language="C#" MasterPageFile="~/TempCode/GGFSite.Master" AutoEventWireup="true" CodeBehind="Sales027.aspx.cs" Inherits="GGFPortal.Sales.Sales027" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

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

    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4 h-100">


           <%--  <asp:GridView ID="ErrorGV" runat="server" CssClass="table table-striped table-sm table-primary"></asp:GridView>
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-sm table-dark"></asp:GridView>--%>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Height="100%" Width="100%" Visible="False" AsyncRendering="False" SizeToReportContent="True">
                <LocalReport ReportPath="ReportSource\Sales\ReportSales027.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>

    </main>
</asp:Content>
