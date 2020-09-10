<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample011.aspx.cs" Inherits="GGFPortal.Sales.Sample011" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>樣品室產量月總表-處理人員(打版日期)</title>
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
                        <h3 class="text-info text-left">樣品室產量月總表-處理人員(打版日期)
                        </h3>
                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">
                            <h4>日期</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDayTB" runat="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="StartDayTB_CalendarExtender" TargetControlID="StartDayTB" ID="StartDayTB_CalendarExtender" Format="yyyyMMdd"></ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="EndDayTB" runat="server" CssClass="form-control"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="EndDayTB_CalendarExtender" TargetControlID="EndDayTB" ID="EndDayTB_CalendarExtender" Format="yyyyMMdd"></ajaxToolkit:CalendarExtender>
                            </div> 
                    <div class="form-group">

						</div> 
                            <h4>地區</h4>
                            <div class="form-group">
                                <asp:DropDownList ID="AreaDDL" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="Data" DataValueField="Data" AppendDataBoundItems="True">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT [Data] FROM [Mapping] WHERE ([UsingDefine] = @UsingDefine) ORDER BY [Remark]">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="樣品室地區" Name="UsingDefine" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <h4>處理人員</h4>
                            <asp:DropDownList ID="人員DDL" runat="server" CssClass="form-control">
                                <asp:ListItem>全部</asp:ListItem>
                                <asp:ListItem>車縫</asp:ListItem>
                                <asp:ListItem>裁剪人</asp:ListItem>
                            </asp:DropDownList>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="100%" Width="100%" Visible="False" >
                        <LocalReport ReportPath="ReportSource\Sample\ReportSample011V2.rdlc" DisplayName="樣品室產量月總表-處理人員">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
