<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales016.aspx.cs" Inherits="GGFPortal.Sales.Sales016" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>

    <script src="../scripts/jquery-3.4.1.min.js"></script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar ">

            <asp:Label ID="TitleLB" runat="server" Text="" CssClass="btn btn-info navbar-brand  "></asp:Label>

            <%--         <asp:Button ID="IndexBT" runat="server" Text="返回搜尋畫面" OnClick="IndexBT_Click" CssClass="btn btn-outline-success" />--%>
        </nav>
        <div class=" container-fluid">
            <%--        <div class="row mb-2">
            <table class="table  table-bordered  table-dark">
                <tr>
                    <th class=" text-right col-md-2">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></th>
                    <td class=" col-md-4">

                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control dropdown">
                        </asp:DropDownList>

                    </td>
                    <th class=" text-right col-md-2">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></th>
                    <td class=" col-md-4">

                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control dropdown">
                        </asp:DropDownList>

                    </td>
                </tr>

            </table>

        </div>--%>
            <div class="row table-bordered table-dark  mb-2">
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label2" runat="server" Text="Label" CssClass=" "></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:DropDownList ID="成分DDL" runat="server" CssClass=" dropdown form-control" DataSourceID="SqlDataSource1" DataTextField="說明" DataValueField="代號"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [說明], [代號] FROM [View布種成分]"></asp:SqlDataSource>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass=" form-control dropdown" DataSourceID="SqlDataSource2" DataTextField="說明" DataValueField="代號"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [代號], [說明] FROM [View布種] ORDER BY [說明]"></asp:SqlDataSource>
                </div>
            </div>
            <div class="row  table-bordered  table-dark  mb-2">
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-1 text-right">
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row table-dark mb-2">
                <div class="col-10"></div>
                <div class="col-2 text-center">
                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-light" />
                </div>
            </div>
            <div>
                <rsweb:ReportViewer ID="TempRV" runat="server" CssClass="table col-12"></rsweb:ReportViewer>
            </div>
        </div>
    </form>
    <script src="../scripts/bootstrap-4.3.1/js/dist/util.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/dropdown.js"></script>
    <script src="../scripts/bootstrap-4.3.1/js/dist/collapse.js"></script>
</body>
</html>
