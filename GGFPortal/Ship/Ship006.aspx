<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ship006.aspx.cs" Inherits="GGFPortal.Ship.Ship006" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>入庫應付、入庫暫估比較表</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/scripts.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/jQuery.print.min.js"></script>
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row text-center">
                <h2>入庫應付、入庫暫估比較表</h2>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:TextBox ID="StyleTB" CssClass="form-control" runat="server"></asp:TextBox>

                    <ajaxToolkit:AutoCompleteExtender runat="server" ServicePath="~/ReferenceCode/AutoCompleteWCF.svc"  BehaviorID="StyleTB_AutoCompleteExtender" TargetControlID="StyleTB" ID="StyleTB_AutoCompleteExtender"  ServiceMethod="SearchOrdStyle" MinimumPrefixLength="1" UseContextKey="True"></ajaxToolkit:AutoCompleteExtender>
                </div>
                <div class="col-lg-8">
                    <asp:Button ID="SearchBT" CssClass="btn btn-default" runat="server" Text="搜尋" OnClick="SearchBT_Click" />
                </div>

            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:CheckBox ID="搜尋主料CB" Checked="true" runat="server" Text="搜尋主料" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <h3>
                        入庫應付總金額：<asp:Label ID="入庫應付LB" runat="server"></asp:Label>
                    </h3>
                </div>
                <div class="col-lg-6">
                    <h3>
                        入庫暫估總金額：<asp:Label ID="入庫暫估LB" runat="server" Text=""></asp:Label>
                    </h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <asp:GridView ID="GV1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" CssClass=" table table-hover">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>

                </div>
                <div class="col-lg-6">
                    <asp:GridView ID="GV2" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" CssClass=" table table-hover">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
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
        </div>
            </div>
    </form>
</body>
</html>
