<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales010.aspx.cs" Inherits="GGFPortal.Sales.Sales010" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>採購料號查詢</title>
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
                        <h3 class="text-info text-left">採購料號查詢</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
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
                            <h4>代理商</h4>
                            <div class="form-group">
                                <asp:TextBox ID="代理商TB" runat="server"  CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" BehaviorID="代理商TB_AutoCompleteExtender" TargetControlID="代理商TB" ID="代理商TB_AutoCompleteExtender" ServiceMethod="Search訂單客戶品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                            <h4>品牌</h4>
                            <div class="form-group">
                                <asp:TextBox ID="品牌TB" runat="server" CssClass="form-control" ></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="品牌TB_AutoCompleteExtender" TargetControlID="品牌TB" ID="品牌TB_AutoCompleteExtender" ServiceMethod="Search訂單品牌" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                                                        <h4>供應商</h4>
                                <asp:TextBox ID="供應商TB" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc" TargetControlID="供應商TB" ID="供應商TB_AutoCompleteExtender" ServiceMethod="Search供應商代號"  MinimumPrefixLength="1"
        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" OnClientPopulated="Employees_Populated" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                            <div>
                                    <script type="text/javascript">
                                        function Employees_Populated(sender, e) {
                                            var employees = sender.get_completionList().childNodes;
                                            var div = "<table>";
                                            div += "<tr><th>Search</th><th>SearchName</th></tr>";
                                            for (var i = 0; i < employees.length; i++) {
 
                                                div += "<tr><td>" + employees[i].innerHTML.split(',')[0] + "</td><td>" + employees[i].innerHTML.split(',')[1]  + "</td></tr>";
                                            }
                                            div += "</table>";
                                            sender._completionListElement.innerHTML = div;
                                        }
                                    </script>
                                </div>
                            <h4>狀態</h4>
                            <div class="form-group">
                                <asp:CheckBox ID="主料CB" runat="server" Checked="true"  CssClass="form-control" Text="顯示主料資料"/>
                                <asp:CheckBox ID="入庫CB" runat="server" Checked="true"   CssClass="form-control" Text="顯示入庫資料"/>
                            </div>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />
                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"  Width="100%" Visible="False" >
                        <LocalReport ReportPath="ReportSource\Sales\ReportSales010.rdlc" DisplayName="採購單資料" EnableExternalImages="True">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
