<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample005.aspx.cs" Inherits="GGFPortal.Sales.Sample005" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>樣品室產量月總表-客戶</title>
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
                        <h3 class="text-info text-left">樣品室產量月總表-客戶
                        </h3>
                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <div class="form-group">
                            <h4>年</h4>
<asp:DropDownList ID="YearDDL" runat="server" class="form-control"></asp:DropDownList>
						</div> 
                    <h4>月</h4>
                    <div class="form-group">
							<asp:DropDownList ID="MonthDDL" runat="server" class="form-control">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
						</div> 
                            <h4>地區</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="AreaDDL" runat="server" class="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>台北</asp:ListItem>
                                    <asp:ListItem>宜蘭</asp:ListItem>
                                    <asp:ListItem>上海</asp:ListItem>
                                    <asp:ListItem>廣州</asp:ListItem>
                                </asp:DropDownList>
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
                        <LocalReport ReportPath="ReportSource\ReportSample005.rdlc" DisplayName="樣品室產量月總表-客戶">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
