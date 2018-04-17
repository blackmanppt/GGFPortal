<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WEBapitest.aspx.cs" Inherits="GGFPortal.test.WEBapitest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../scripts/jquery-3.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="Text1" type="text" />
        <div id="test"></div>
    </form>
    <script type="text/javascript">
    function getProducts() {
        $.getJSON("api/APITest",
            function (data) {
                $('#test').empty(); // Clear the table body.

                // Loop through the list of products.
                $.each(data, function (key, val) {
                    // Add a table row for the product.
                    var row = '<td>' + val.Name + '</td><td>' + val.Price + '</td>';
                    $('<tr/>', { html: row })  // Append the name.
                        .appendTo($('#test'));
                });
            });
        }

        $(document).ready(getProducts);
</script>
</body>
</html>
