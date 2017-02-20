<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VN002.aspx.cs" Inherits="GGFPortal.VN.VN002" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>組別查詢</title>
    <style type="text/css">
        .line{
            border: 2px solid black;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="border: 2px solid #000000; width:500px; border-collapse: collapse;border: 2px solid black;"  >
            <tr class="line">
                <td colspan="3">
                    <asp:Label ID="Label2" runat="server" Text="Package"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="line">

                    <asp:Label ID="Label1" runat="server" Text="UpDate："></asp:Label>
                </td>
                <td class="line">

                    <asp:TextBox ID="SearchTB" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="SearchTB_CalendarExtender" runat="server" Format="yyyyMMdd" TargetControlID="SearchTB" />
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </td>
                <td class="line">

                    &nbsp;</td>
            </tr>
            <tr>
                <td  class="line">                   
                    <asp:Label ID="Label3" runat="server" Text="File Update"></asp:Label>
                </td>
                <td class="line">          
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:Button ID="CheckBT" runat="server" Text="Check" OnClick="CheckBT_Click" />
                </td>
            </tr>
            <tr>
                <td class="line"></td>
                <td class="line">

                    <asp:Button ID="TeamCodeBT" runat="server" Text="TeamCode" OnClick="TeamCodeBT_Click" />

                    <asp:Button ID="TempExcel" runat="server" Text="TempExcel" />
                </td>
                <td class="line">
                    <asp:Button ID="UpLoadBT" runat="server" Text="UpLoad" OnClick="UpLoadBT_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3" class="line">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
        <div>
            <asp:GridView ID="ErrorGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SheetName" HeaderText="SheetName" />
                    <asp:BoundField DataField="Dept" HeaderText="部門" />
                    <asp:BoundField DataField="Error" HeaderText="Error" />
                </Columns>
            </asp:GridView>
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
