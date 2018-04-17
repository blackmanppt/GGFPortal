<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevExtreme.aspx.cs" Inherits="GGFPortal.test.DevExtreme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>test</title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
    <script src="../scripts/dx.viz-web.js"></script>
    <script type="text/javascript">

        var data = [
    { type: 'Oranges', brazil: 18279309, china: 2865000, usa: 7357000 },
    { type: 'Grapefruit', brazil: 72000, china: 547000, usa: 1580000 },
    { type: 'Lemons and limes', brazil: 1060000, china: 745100, usa: 722000 },
    { type: 'Tangerines, etc.', brazil: 1271000, china: 14152000, usa: 328000 }
        ];

        $(function () {
            $("#chartContainer").dxChart({
                dataSource: data,
                commonSeriesSettings: {
                    argumentField: 'type',
                    type: 'bar',
                    point: {
                        label: {
                            visible: true,
                            format: 'largeNumber'
                        }
                    }
                },
                series: [
                    { valueField: 'brazil', name: 'Brazil' },
                    { valueField: 'china', name: 'China' },
                    { valueField: 'usa', name: 'USA' }
                ],
                valueAxis: {
                    title: "Produced",
                    label: { format: 'largeNumber' }
                },
                adaptiveLayout: {
                    width: 400,
                    keepLabels: false
                }
            });
        });

    </script>
    <style>
        #chartContainer {
    max-width: 800px;
    margin: 0 auto;
}
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="buttonContainer"></div>
    </div>
    </form>
</body>
</html>
