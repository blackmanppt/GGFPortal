<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secretary006.aspx.cs" Inherits="GGFPortal.Secretary.Secretary006" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客戶訂單轉Excel</title>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-center">產區資料查詢
                        </h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                        <h4>選擇日期</h4>
                            <div class="form-group">

                                <asp:DropDownList ID="DateDDL" runat="server" DataSourceID="SqlDataSource1" AppendDataBoundItems="True" DataMember="DefaultView" DataTextField="時間" DataValueField="時間" CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFCubeDBConnectionString %>" SelectCommand="SELECT DISTINCT  top 10 SUBSTRING(id,0,17) as [時間] FROM [CubeOrderQty] WHERE ([IsDelete] = @IsDelete) order by [時間] desc">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="false" Name="IsDelete" Type="Boolean" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False" >
                        <LocalReport ReportPath="ReportSource\Secretary\ReportSecretary006.rdlc" DisplayName="資料庫">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
