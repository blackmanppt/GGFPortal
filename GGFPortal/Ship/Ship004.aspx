<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ship004.aspx.cs" Inherits="GGFPortal.Ship.Ship004" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>櫃號相關資料-查詢</title>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2">
                    <nav class="navbar navbar-default" role="navigation">
                        <h3 class="text-info text-left">櫃號相關資料-查詢</h3>

                        <div class="collapse navbar-collapse " id="bs-example-navbar-collapse-1">

                            <h4>ETA</h4>
                            <div class="form-group">
                                <asp:TextBox ID="StartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="StartDay_CalendarExtender" runat="server" BehaviorID="StartDay_CalendarExtender" TargetControlID="StartDay" Format="yyyy-MM-dd" />
                                <asp:TextBox ID="EndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" BehaviorID="EndDay_CalendarExtender" TargetControlID="EndDay"  Format="yyyy-MM-dd" />
                            </div>
                            <h4>ETD</h4>
                            <div class="form-group">
                                <asp:TextBox ID="ETDStartDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server"  TargetControlID="ETDStartDay" ID="ETDStartDay_CalendarExtender"  Format="yyyy-MM-dd" ></ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="ETDEndDay" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server"  TargetControlID="ETDEndDay" ID="ETDEndDay_CalendarExtender"  Format="yyyy-MM-dd" ></ajaxToolkit:CalendarExtender>
                            </div>
                            <h4>櫃號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="櫃號TB" TextMode="MultiLine" runat="server" class="form-control" Height="200px"></asp:TextBox>
                                <asp:CheckBox ID="顯示直送CB" runat="server" Text="顯示直送" />
                            </div>
                            <h4>款號</h4>
                            <div class="form-group">
                                <asp:TextBox ID="款號TB" TextMode="MultiLine" runat="server" class="form-control" Height="200px"></asp:TextBox>

                            </div>
                            <div class="form-group">
                            <asp:Button ID="SearchBT" runat="server" Text="Search" class="btn btn-default" OnClick="SearchBT_Click" />
                            <asp:Button ID="ClearBT" runat="server" Text="Clear" class="btn btn-default" OnClick="ClearBT_Click" />

                            </div>


                        </div>

                    </nav>
                </div>
                <div class="col-md-10">
                    <div class="row">
                        <asp:Button ID="搜尋BT" runat="server" Text="搜尋" CssClass="btn btn-default" OnClick="搜尋BT_Click" Visible="False" />
                            <asp:GridView ID="櫃號GV" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="全部搜尋CB" runat="server" Text="全部搜尋" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="搜尋CB" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="櫃號" HeaderText="櫃號" />
                                    <asp:BoundField DataField="ETA" DataFormatString="{0:yyyy-MM-dd}" HeaderText="ETA" />
                                    <asp:BoundField DataField="ETD" HeaderText="ETD" DataFormatString="{0:yyyy-MM-dd}"/>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>

                    </div>
                    <div class="row">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"  Width="100%" Visible="False" >
                            <LocalReport ReportPath="ReportSource\Ship\ReportShip004.rdlc" DisplayName="入庫櫃號">
                            </LocalReport>
                        </rsweb:ReportViewer>
                        </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
