<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finance003.aspx.cs" Inherits="GGFPortal.Finance.Finance003" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 20px;
            width: 100px;
            text-align: right;
            background-color: #3399FF;
        }
        .auto-style3 {
            width: 100px;
            text-align: right;
            background-color: #3399FF;
        }
        .auto-style4 {
            height: 20px;
            width: 180px;
        }
        .auto-style5 {
            width: 180px;
        }
        .auto-style6 {
            width: 102px;
            text-align: right;
            background-color: #0099FF;
        }
        .auto-style7 {
            text-align: right;
        }
        .auto-style8 {
            width: 100px;
            text-align: right;
            background-color: #3399FF;
            height: 30px;
        }
        .auto-style9 {
            width: 180px;
            height: 30px;
        }
        .auto-style10 {
            width: 102px;
            text-align: right;
            background-color: #0099FF;
            height: 30px;
        }
        .auto-style11 {
            height: 30px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
            <asp:Label ID="TitleLB" runat="server" Text="報表"></asp:Label>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
            </asp:ScriptManager>
        </h1>
    
    </div>
    <div>
        <table style="width:600px; border-spacing: 1px; border-collapse: inherit;" border="1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="SiteLB" runat="server" Text="公司別："></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:DropDownList ID="SiteDDL" runat="server">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>GGF</asp:ListItem>
                        <asp:ListItem>TCL</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="ETAETDLB" runat="server" Text="ETA/ETD為0："></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:RadioButtonList ID="ETARBL" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>ETA</asp:ListItem>
                        <asp:ListItem>ETD</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="RecDateLB" runat="server" Text="入庫日期："></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="StartDayTB" runat="server" Width="70px" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyy-MM-dd" />
                    ~
                    <asp:TextBox ID="EndDayTB" runat="server" Width="70px" AutoPostBack="True"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="EndDayTB_CalendarExtender" runat="server" TargetControlID="EndDayTB" Format="yyyy-MM-dd"  />
                </td>
                <td class="auto-style6">
                    <asp:Label ID="ItemLB" runat="server" Text="主/副料："></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="ItemRBL" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>主料</asp:ListItem>
                        <asp:ListItem>副料</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="NationLB" runat="server" Text="產區："></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:DropDownList ID="NationDDL" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style10">
                    <asp:Label ID="AcpStatusLB" runat="server" Text="付款狀態："></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:RadioButtonList ID="ACPRBL" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>已付</asp:ListItem>
                        <asp:ListItem>未付</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
             <tr>
                <td class="auto-style3">
                    <asp:Label ID="FactoryLB" runat="server" Text="代工廠："></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:DropDownList ID="FactoryDDL" runat="server">
                    </asp:DropDownList>
                 </td>
                <td class="auto-style6">
                    <asp:Label ID="PurLB" runat="server" Text="採購單號："></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="PurTB" runat="server"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="PurTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchPurID" TargetControlID="PurTB" >
                    </ajaxToolkit:AutoCompleteExtender>
                 </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="VendorLB" runat="server" Text="供應商代號："></asp:Label>
                </td>
                <td class="auto-style5">

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
                                <ContentTemplate>
                                    <asp:TextBox ID="VendorTB" runat="server"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="VendorTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="2" ServiceMethod="SearchVendorID" TargetControlID="VendorTB">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    <asp:ImageButton ID="SearchVendorIDBT" runat="server" Height="19px" ImageUrl="~/IMG/images.png" OnClick="SearchVendorIDBT_Click" Width="16px" />
                 </td>
                <td class="auto-style6">
                                    
                                </td>
                <td class="auto-style7">
                    <asp:Button ID="SearchBT" runat="server" Text="Search" OnClick="SearchBT_Click" />
                </td>
            </tr>
        </table>
    </div>
        <div>

                                

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="False" Width="100%">
                <LocalReport ReportPath="ReportSource\ReportFinance002.rdlc"  >
                </LocalReport>
            </rsweb:ReportViewer>

                                

        </div>
        <asp:HiddenField ID="hfCustomerId" runat="server" />
        
    </form>

</body>
</html>
