
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HighChart.aspx.cs" Inherits="GGFPortal.test.HighChart" %>
<%@ Register TagPrefix="hc" TagName="Chart" Src="~/Controls/HighchartsControl.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script src="http://code.highcharts.com/stock/highstock.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
</head>
<body>ql3
    <form id="form1" runat="server">

        <hc:Chart runat="server"/>



	
    </form>
</body>
</html>
