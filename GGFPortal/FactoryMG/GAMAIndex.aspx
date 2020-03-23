<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GAMAIndex.aspx.cs" Inherits="GGFPortal.FactoryMG.GAMAIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script src="../scripts/jquery-3.4.1.min.js"></script>
    <script src="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.js"></script>
    <link href="../scripts/bootstrap-4.3.1/site/docs/4.3/examples/dashboard/dashboard.css" rel="stylesheet" />
    <script src="../scripts/bootstrap-4.3.1/dist/js/bootstrap.min.js"></script>
    <link href="../scripts/bootstrap-4.3.1/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container align-content-center">
            <table>
                <tr>
                    <th>
                        <h3>
                            Stitch Update:
                        </h3>
                    </th>
                    <td>
                                                <asp:Button ID="StitchBT" runat="server" Text="Stitch" CssClass="btn btn-primary" OnClick="StitchBT_Click" />
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
