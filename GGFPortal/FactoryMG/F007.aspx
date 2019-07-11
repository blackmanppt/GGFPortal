<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F007.aspx.cs" Inherits="GGFPortal.FactoryMG.F007" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>工時資料餵入查詢表</title>
    <style type="text/css">
        #titletable {
            border-collapse: collapse;
            border: 1px solid black;
        }
        .auto-style2 {
            text-align: left;
            border: 1px solid black;
        }
        .auto-style3 {
            text-align: left;
            height: 23px;
            border: 1px solid black;
        }
    </style>
        <link rel="stylesheet" type="text/css" href="../../themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../../themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../demo.css"/>
    <script type="text/javascript" src="../Scripts/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.easyui-1.4.5.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div  >
            
            <asp:Label ID="Label1" runat="server" Text="工時資料餵入查詢表" Font-Bold="True" Font-Size="X-Large" style="color: #FFCC66; background-color: #3333FF"></asp:Label>
            
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
        </div>
        <div  >
            <table style="width:600px;"  id="titletable">
                <tr>
                    <th class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Text="匯入日期："></asp:Label>
                    </th>
                    <td class="auto-style3">
                        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB"  Format="yyyyMMdd"/>
                        ~<asp:TextBox ID="EndDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" TargetControlID="EndDayTB"  Format="yyyyMMdd"/>
                    </td>
                    <td class="auto-style3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <th class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Style no："></asp:Label>
                    </th>
                    <td class="auto-style2">
                        <asp:TextBox ID="StyleNoSeachTB" runat="server" ></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="StyleNoSeachTB_AutoCompleteExtender" runat="server" TargetControlID="StyleNoSeachTB" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
                    </td>
                </tr>

            </table>
        </div>
        <div >

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataSourceID="SqlDataSource2" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="Team" HeaderText="Team" SortExpression="Team" />
                    <asp:BoundField DataField="SumTime" HeaderText="SumTime" ReadOnly="True" SortExpression="SumTime" DataFormatString="{0:N2}" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="select Team,sum(b.Person* b.Time) as SumTime from  Productivity_Head a left join Productivity_Line b on a.uid=b.uid
where Flag=1 and Date between @Date1 and @Date2

group by Team">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="19000101" Name="Date1" SessionField="Date1" />
                    <asp:SessionParameter DefaultValue="29991231" Name="Date2" SessionField="Date2" />
                </SelectParameters>
            </asp:SqlDataSource>

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="500px" Width="1001px">
                <LocalReport ReportPath="ReportSource\VN\ReportVN003.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.VNDSTempTableAdapters.VNReportTableAdapter">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="Flag" Type="Int32" />
                    <asp:SessionParameter DefaultValue="19000101" Name="Date1" SessionField="Date1" Type="String" />
                    <asp:SessionParameter DefaultValue="29991231" Name="Date2" SessionField="Date2" Type="String" />
                    <asp:SessionParameter DefaultValue="%" Name="StyleNo" SessionField="StyleNo" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>

    </form>
</body>
</html>