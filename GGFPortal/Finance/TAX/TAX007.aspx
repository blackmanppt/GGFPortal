<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TAX007.aspx.cs" Inherits="GGFPortal.Finance.TAX.TAX007" uiCulture="Auto" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
            <asp:Label ID="TitleLB" runat="server" Text="發貨沖銷" style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
    <div>
    
        <table style="width:600px;">
            <tr>
                <td class="auto-style1">
    
        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd"  />
                    ~<asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay"  Format="yyyyMMdd"  />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                        <asp:Label ID="Label11" runat="server" Text="月份："></asp:Label>
                </td>
                <td>
                        <asp:DropDownList ID="MonthDDL" runat="server">
                        </asp:DropDownList>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="款號："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="StyleNoTB" runat="server"></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="StyleNoTB_TextBoxWatermarkExtender" runat="server" TargetControlID="StyleNoTB" WatermarkText="輸入要搜尋款號" />
                    <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo"  TargetControlID="StyleNoTB">
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
                <td>
        <asp:Button ID="SearchBT" runat="server" OnClick="SearchBT_Click" Text="Search" />
    
                </td>
            </tr>
        </table>
        
    
    </div>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%" Visible="False">
            <LocalReport ReportPath="ReportSource\ReportTAX.rdlc">

            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>

</body>
</html>
