<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance005.aspx.cs" Inherits="GGFPortal.Finance.Finance005" uiCulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AP1會計科目搜尋</title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 93px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
            <asp:Label ID="TitleLB" runat="server" Text="AP1資料蒐尋" style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
    <div>
    
        <table style="width:600px;">
            <tr>
                <td class="auto-style1">
    
        <asp:Label ID="Label1" runat="server" Text="傳票號碼："></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="ACCTB" runat="server"></asp:TextBox>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
        <asp:Button ID="SearchBT" runat="server" OnClick="SearchBT_Click" Text="Search" />
    
                </td>
            </tr>
        </table>
        
    
    </div>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%" Visible="False">
            <LocalReport ReportPath="ReportSource\ReportFinance005.rdlc">

            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>

</body>
</html>
