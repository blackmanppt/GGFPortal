﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GGFPortal.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="width: 100%;">
                <tr>
                    <td>
                        MIS</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MIS/MIS001.aspx">訂單未簽核查詢</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MIS/MIS002.aspx">採購單未簽核查詢</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/test/test.aspx">test</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>財務</td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Finance/Finace001.aspx">出貨大表</asp:HyperLink>
                        <br />
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Finance/TAX/TAX001.aspx">進項稅額應收結轉</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>秘書</td>
                    <td>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Secretary/Secretary001.aspx">產區表</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
