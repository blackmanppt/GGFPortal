<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VN003.aspx.cs" Inherits="GGFPortal.VN.VN003" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Label ID="TitleLB" runat="server" Text="工時資料餵入查詢" style="font-size: xx-large; font-weight: 700; color: #990099; background-color: #0099FF;"></asp:Label>
        </div>
    <div>
        
    <table style="width: 600px;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" Format="yyyyMMdd" TargetControlID="StartDayTB" />
                        ~<asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" Format="yyyyMMdd" TargetControlID="EndDay" />
                    </td>
                    <td>
                        <asp:Button ID="SearchBT" runat="server" Text="搜尋" OnClick="SearchBT_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:Label ID="Label3" runat="server" Text="款號："></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="StyleNoTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo" TargetControlID="StyleNoTB">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
    </div>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px" Visible="False" Width="90%">
                <LocalReport ReportPath="ReportSource\VN\ReportVN001.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
