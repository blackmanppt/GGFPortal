<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="easyui2.aspx.cs" Inherits="GGFPortal.test.easyui2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../ReferenceCode/easyui/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="../ReferenceCode/easyui/themes/icon.css"/>
    
    <script type="text/javascript" src="../ReferenceCode/easyui/jquery.min.js"></script>
    <script type="text/javascript" src="../ReferenceCode/easyui/jquery.easyui.min.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Add sorting to DataGrid</h2>
    <div style="margin-bottom:10px">
        <p>Click on column header to sort but the 'Attribute' and 'Status' column can't be sorted because their sortable feature is not assigned yet.</p>
    </div>
    
    <table id="tt" class="easyui-datagrid" style="width:700px;height:250px"
            url="Handler2.ashx"
            title="Load Data" iconCls="icon-save"
            sortName="員工代號" sortOrder="asc"
            rownumbers="true" pagination="true">
        <thead>
            <tr>
                <th field="員工代號" width="80" sortable="true">員工代號</th>
                <th field="名字" width="100" sortable="true">名字</th>
                <th field="英文名字" width="80" align="right" sortable="true">英文名字</th>
                <th field="部門名稱" width="80" align="right" sortable="true">部門名稱</th>
                <th field="Email" width="220">Email</th>
                <th field="分機" width="60" align="center">分機</th>
            </tr>
        </thead>
    </table>
    </div>
    </form>
</body>
</html>
