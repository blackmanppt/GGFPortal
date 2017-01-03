<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelUpload.aspx.cs" Inherits="GGFPortal.test.ExcelUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button ID="UploadBT" runat="server" OnClick="UploadBT_Click" Text="Upload" />
            <asp:Button ID="SaveBT" runat="server" OnClick="SaveBT_Click" Text="Button" />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:GridView ID="ErrorGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SheetName" HeaderText="SheetName" />
                    <asp:BoundField DataField="Dept" HeaderText="部門" />
                    <asp:BoundField DataField="Error" HeaderText="Error" />
                </Columns>
            </asp:GridView>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:GridView ID="ExcelGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SheetName" HeaderText="SheetName" />
                    <asp:BoundField DataField="Dept" HeaderText="部門" />
                    <asp:BoundField DataField="Customer" HeaderText="客戶" />
                    <asp:BoundField DataField="StyleNo" HeaderText="款號" />
                    <asp:BoundField DataField="OrderQty" HeaderText="訂單數量" />
                    <asp:BoundField DataField="OrderShipDate" HeaderText="訂單交期" />
                    <asp:BoundField DataField="OnlineDate" HeaderText="上線日期" />
                    <asp:BoundField DataField="StandardProductivity" HeaderText="1/人8H標準產量" />
                    <asp:BoundField DataField="Person" HeaderText="實際工作人數" />
                    <asp:BoundField DataField="Time" HeaderText="工時" />
                    <asp:BoundField DataField="Percent" HeaderText="百分比" />
                    <asp:BoundField DataField="GoalProductivity" HeaderText="今日目標產量" />
                    <asp:BoundField DataField="DayProductivity" HeaderText="今日產量" />
                    <asp:BoundField DataField="TotalEfficiency" HeaderText="效率" />
                    <asp:BoundField DataField="Rmark1" HeaderText="責任歸屬及上線天數" />
                    <asp:BoundField DataField="DayCost1" HeaderText="今日各組成本" />
                    <asp:BoundField DataField="DayCost2" HeaderText="今日生產成本" />
                    <asp:BoundField DataField="DayCost3" HeaderText="工繳收入" />
                    <asp:BoundField DataField="DayCost4" HeaderText="今日工繳收入" />
                    <asp:BoundField DataField="DayCost5" HeaderText="今日生產損益" />
                    <asp:BoundField DataField="DayCost6" HeaderText="CM損益" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
