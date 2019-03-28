<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="easyui.aspx.cs" Inherits="GGFPortal.test.easyui" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../ReferenceCode/easyui/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../ReferenceCode/easyui/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="../demo.css"/>
    <script type="text/javascript" src="../ReferenceCode/easyui/jquery.min.js"></script>
    <script type="text/javascript" src="../ReferenceCode/easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function ()
        {
 
            $('#tdd').datagrid({
                title: '统计 报表',
                iconCls: 'icon-save',
                width: 1000,
                height: 550,
                url: "Handler2.ashx",//接收一般处理程序返回来的json数据
                columns: [[
                    { title: '統計', colspan: 6 },
                    { field: 'OID', title: '標題', width: 100, align: 'center', rowspan: 2,
                        formatter: function (value, rec)
                        {
                            return '<span style="color:red">Edit Delete</span>';
                        }
                    }
                ], [
                { field: '員工代號', title: '員工代號', width: 100 },//field后面就改为你自己的数据表字段，然后可以调整宽度什么的
                { field: '名字', title: '名字', width: 100, align: 'right' },
                { field: '英文名字', title: '英文名字', width: 100, align: 'left' },
                { field: '部門名稱', title: '部門名稱', width: 100 },
                { field: 'Email', title: 'Email', width: 100 },
                { field: '分機', title: '分機', width: 100 }
            ]],
                pagination: true,
                rownumbers: true,
                method: 'get',
                remoteSort: false,
                multiSort: true
            });
        }
);
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table id="tdd" align="center">
    </table>

    </div>
    </form>
</body>
</html>
