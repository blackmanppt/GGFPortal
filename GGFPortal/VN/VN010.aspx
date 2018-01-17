<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VN010.aspx.cs" Inherits="GGFPortal.VN.VN010" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>越南款號各組數量查詢</title>
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
                        <h3 class="text-info text-center">越南款號各組數量
                        </h3>
                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                    <h4>處理日期</h4>
                    <div class="form-group">
                        <asp:TextBox ID="StartTB" runat="server" class="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="StartTB_CalendarExtender" runat="server" BehaviorID="StartTB_CalendarExtender" TargetControlID="StartTB" Format="yyyyMMdd"/>
                        <asp:TextBox ID="EndTB" runat="server" class="form-control"></asp:TextBox>
						    <ajaxToolkit:CalendarExtender ID="EndTB_CalendarExtender" runat="server" BehaviorID="EndTB_CalendarExtender" TargetControlID="EndTB" Format="yyyyMMdd" />
						</div> 
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StyleNoTB" runat="server" TextMode="MultiLine" Height="100px" CssClass="text-muted form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>
                            <asp:Literal ID="MessageLT" runat="server"></asp:Literal>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="768px" Width="1024px" Visible="False" >
                        <LocalReport ReportPath="ReportSource\VN\ReportVN005.rdlc" DisplayName="產量統計">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
