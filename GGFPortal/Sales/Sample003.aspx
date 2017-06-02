<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample003.aspx.cs" Inherits="GGFPortal.Sales.Sample003" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../scripts/jquery-3.1.1.js"></script>
    <script src="../scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="container">
            <h1><asp:Label ID="Label1" runat="server" Text="打版查詢"></asp:Label>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </h1>
            <table>
                <tr>
                    <th>
                        <asp:Label ID="Label2" runat="server" Text="發版日："></asp:Label>
                    </th>
                    <td><asp:TextBox ID="StartTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartTB_CalendarExtender" runat="server" TargetControlID="StartTB"  Format="yyyy-MM-dd"/>
                        ~<asp:TextBox ID="EndTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndTB_CalendarExtender" runat="server" TargetControlID="EndTB" Format="yyyy-MM-dd"/>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="Label3" runat="server" Text="客戶："></asp:Label></th>
                    <td>
                        <asp:TextBox ID="CusText" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="CusText_AutoCompleteExtender" runat="server" TargetControlID="CusText"  CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchCus">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="Label4" runat="server" Text="款號："></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="StyleTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="StyleTB_AutoCompleteExtender" runat="server" TargetControlID="StyleTB"  CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                    <td><asp:Button ID="SearchBT" runat="server" Text="Search" CssClass="btn btn-primary btn-xs" OnClick="SearchBT_Click" /></td>
                </tr>
            </table>
            <%--<div class="row " style="height: 1.42857143px">
                <div class="col-sm-3" style="background-color: lavender;">
                    
                </div>
                <div class="col-sm-3" style="background-color: lavenderblush;">.col-sm-4</div>
                <div class="col-sm-3" style="background-color: lavender;">.col-sm-4</div>
                <div class="col-sm-3" style="background-color: lavender;">
                    </div>
            </div>--%>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="432px" style="margin-right: 0px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1082px">
                        <LocalReport ReportPath="ReportSource\ReportSample003.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet打版發單" />
                            </DataSources>
                        </LocalReport>
        </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.SalesTempDSTableAdapters.View打版發單表TableAdapter">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="2000-01-01" Name="StarDay" SessionField="StarDay" Type="DateTime" />
                    <asp:SessionParameter DefaultValue="2999-01-01" Name="EndDay" SessionField="EndDay" Type="DateTime" />
                    <asp:SessionParameter DefaultValue="%" Name="cus_id" SessionField="cus_id" Type="String" />
                    <asp:SessionParameter DefaultValue="%" Name="styleno" SessionField="styleno" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>


    </form>
</body>
</html>
