<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SALE.aspx.cs" Inherits="GGFPortal.Sales.SALE" UICulture="Auto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 81px;
            background-color: #33CCCC;
        }
        .auto-style2 {
            width: 317px;
        }
        .auto-style3 {
            text-align: right;
            width: 83px;
            background-color: #33CCCC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label ID="TitleLB" runat="server" Text="出口大表查詢" Style="color: #6600FF; background-color: #00CC99"></asp:Label>
            </h1>
        </div>
        <div>

            <table style="border-style: ridge; width: 800px;">
                <tr>
                    <td class="auto-style1" style="border-style: solid">

                        <asp:Label ID="Label1" runat="server" Text="起迄日期："></asp:Label>
                    </td>
                    <td class="auto-style2" style="border-style: solid">
                        <asp:TextBox ID="StartDayTB" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="StartDayTB_CalendarExtender" runat="server" TargetControlID="StartDayTB" Format="yyyyMMdd" />
                        ~
            <asp:TextBox ID="EndDay" runat="server" AutoPostBack="True"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="EndDay_CalendarExtender" runat="server" TargetControlID="EndDay" Format="yyyyMMdd" />
                    </td>
                    <td class="auto-style3" style="border-style: solid">
                        <asp:Label ID="Label3" runat="server" Text="開單人員："></asp:Label>
                    </td>
                    <td style="border-style: solid">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" style="border-style: solid">
                        <asp:Label ID="Label2" runat="server" Text="樣品種類："></asp:Label>
                    </td>
                    <td class="auto-style2" style="border-style: solid">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>

                    </td>
                    <td class="auto-style3" style="border-style: solid">
                        <asp:Label ID="Label4" runat="server" Text="品牌："></asp:Label>
                    </td>
                    <td style="border-style: solid">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" style="border-style: solid">
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style2" style="border-style: solid"></td>
                    <td class="auto-style3" style="border-style: solid">
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="border-style: solid"></td>
                </tr>
                <tr>
                    <td class="auto-style1" style="border-style: solid"></td>
                    <td class="auto-style2" style="border-style: solid"></td>
                    <td class="auto-style3" style="border-style: solid"></td>
                    <td style="border-style: ridge"></td>
                </tr>
                <tr>
                    <td class="auto-style1" style="border-style: solid">&nbsp;</td>
                    <td class="auto-style2" style="border-style: solid">&nbsp;</td>
                    <td class="auto-style3" style="border-style: solid">&nbsp;</td>
                    <td style="border-style: solid">
                        <asp:Button ID="SearchBT" runat="server" OnClick="Search_Click" Text="Search" />

                    </td>
                </tr>
            </table>

            <br />

        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%">
                <LocalReport ReportPath="ReportSource\ReportSALE.rdlc" EnableExternalImages="true">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.SalesTempDSTableAdapters.samc_reqmTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_site" Type="String" />
                    <asp:Parameter Name="Original_sam_nbr" Type="String" />
                    <asp:Parameter Name="Original_sam_times" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="site" Type="String" />
                    <asp:Parameter Name="sam_nbr" Type="String" />
                    <asp:Parameter Name="sam_times" Type="String" />
                    <asp:Parameter Name="sam_no" Type="String" />
                    <asp:Parameter Name="version" Type="String" />
                    <asp:Parameter Name="sam_date" Type="DateTime" />
                    <asp:Parameter Name="cus_id" Type="String" />
                    <asp:Parameter Name="dept_no" Type="String" />
                    <asp:Parameter Name="item_no" Type="String" />
                    <asp:Parameter Name="type_id" Type="String" />
                    <asp:Parameter Name="salesman" Type="String" />
                    <asp:Parameter Name="sam_size" Type="String" />
                    <asp:Parameter Name="assign_qty" Type="Decimal" />
                    <asp:Parameter Name="plan_fin_date" Type="DateTime" />
                    <asp:Parameter Name="emb" Type="String" />
                    <asp:Parameter Name="washing" Type="String" />
                    <asp:Parameter Name="oth_extra" Type="String" />
                    <asp:Parameter Name="finish_date" Type="DateTime" />
                    <asp:Parameter Name="finish_qty" Type="Decimal" />
                    <asp:Parameter Name="place_origin" Type="String" />
                    <asp:Parameter Name="currency_id" Type="String" />
                    <asp:Parameter Name="unit_price" Type="Decimal" />
                    <asp:Parameter Name="amount" Type="Decimal" />
                    <asp:Parameter Name="sam_qty" Type="Decimal" />
                    <asp:Parameter Name="sam_cus_qty" Type="Decimal" />
                    <asp:Parameter Name="sam_taipei_qty" Type="Decimal" />
                    <asp:Parameter Name="image_path" Type="String" />
                    <asp:Parameter Name="remark60" Type="String" />
                    <asp:Parameter Name="status" Type="String" />
                    <asp:Parameter Name="close_date" Type="DateTime" />
                    <asp:Parameter Name="reason" Type="String" />
                    <asp:Parameter Name="online_date" Type="DateTime" />
                    <asp:Parameter Name="confirm_yn" Type="String" />
                    <asp:Parameter Name="progress_rate" Type="String" />
                    <asp:Parameter Name="sam_class" Type="String" />
                    <asp:Parameter Name="p1" Type="String" />
                    <asp:Parameter Name="p4" Type="String" />
                    <asp:Parameter Name="p7" Type="String" />
                    <asp:Parameter Name="ratio_size" Type="String" />
                    <asp:Parameter Name="sample_complete_1" Type="String" />
                    <asp:Parameter Name="sample_complete_2" Type="String" />
                    <asp:Parameter Name="cus_express_corp" Type="String" />
                    <asp:Parameter Name="cus_assign_account" Type="String" />
                    <asp:Parameter Name="cus_address_id" Type="String" />
                    <asp:Parameter Name="cus_addressee" Type="String" />
                    <asp:Parameter Name="cus_address" Type="String" />
                    <asp:Parameter Name="cus_style_no" Type="String" />
                    <asp:Parameter Name="brand_name" Type="String" />
                    <asp:Parameter Name="sam_type" Type="String" />
                    <asp:Parameter Name="proofing_factory" Type="String" />
                    <asp:Parameter Name="filter_creator" Type="String" />
                    <asp:Parameter Name="filter_dept" Type="String" />
                    <asp:Parameter Name="creator" Type="String" />
                    <asp:Parameter Name="create_date" Type="DateTime" />
                    <asp:Parameter Name="modifier" Type="String" />
                    <asp:Parameter Name="modify_date" Type="DateTime" />
                    <asp:Parameter Name="printing" Type="String" />
                    <asp:Parameter Name="sewing" Type="String" />
                    <asp:Parameter Name="samc_remark60" Type="String" />
                    <asp:Parameter Name="mark" Type="String" />
                    <asp:Parameter Name="crp_yn" Type="String" />
                    <asp:Parameter Name="crp_date" Type="DateTime" />
                    <asp:Parameter Name="item_statistic" Type="String" />
                    <asp:Parameter Name="remark_1" Type="String" />
                    <asp:Parameter Name="final" Type="String" />
                    <asp:Parameter Name="last_date" Type="DateTime" />
                    <asp:Parameter Name="samc_fin_date" Type="DateTime" />
                    <asp:Parameter Name="sam_type_A" Type="String" />
                    <asp:Parameter Name="sam_type_B" Type="String" />
                    <asp:Parameter Name="sam_type_C" Type="String" />
                    <asp:Parameter Name="sam_type_D" Type="String" />
                    <asp:Parameter Name="sam_type_E" Type="String" />
                    <asp:Parameter Name="sam_type_F" Type="String" />
                    <asp:Parameter Name="hotfix" Type="String" />
                    <asp:Parameter Name="s_plan_arrival_date" Type="DateTime" />
                    <asp:Parameter Name="s_real_arrival_date" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sam_no" Type="String" />
                    <asp:Parameter Name="version" Type="String" />
                    <asp:Parameter Name="sam_date" Type="DateTime" />
                    <asp:Parameter Name="cus_id" Type="String" />
                    <asp:Parameter Name="dept_no" Type="String" />
                    <asp:Parameter Name="item_no" Type="String" />
                    <asp:Parameter Name="type_id" Type="String" />
                    <asp:Parameter Name="salesman" Type="String" />
                    <asp:Parameter Name="sam_size" Type="String" />
                    <asp:Parameter Name="assign_qty" Type="Decimal" />
                    <asp:Parameter Name="plan_fin_date" Type="DateTime" />
                    <asp:Parameter Name="emb" Type="String" />
                    <asp:Parameter Name="washing" Type="String" />
                    <asp:Parameter Name="oth_extra" Type="String" />
                    <asp:Parameter Name="finish_date" Type="DateTime" />
                    <asp:Parameter Name="finish_qty" Type="Decimal" />
                    <asp:Parameter Name="place_origin" Type="String" />
                    <asp:Parameter Name="currency_id" Type="String" />
                    <asp:Parameter Name="unit_price" Type="Decimal" />
                    <asp:Parameter Name="amount" Type="Decimal" />
                    <asp:Parameter Name="sam_qty" Type="Decimal" />
                    <asp:Parameter Name="sam_cus_qty" Type="Decimal" />
                    <asp:Parameter Name="sam_taipei_qty" Type="Decimal" />
                    <asp:Parameter Name="image_path" Type="String" />
                    <asp:Parameter Name="remark60" Type="String" />
                    <asp:Parameter Name="status" Type="String" />
                    <asp:Parameter Name="close_date" Type="DateTime" />
                    <asp:Parameter Name="reason" Type="String" />
                    <asp:Parameter Name="online_date" Type="DateTime" />
                    <asp:Parameter Name="confirm_yn" Type="String" />
                    <asp:Parameter Name="progress_rate" Type="String" />
                    <asp:Parameter Name="sam_class" Type="String" />
                    <asp:Parameter Name="p1" Type="String" />
                    <asp:Parameter Name="p4" Type="String" />
                    <asp:Parameter Name="p7" Type="String" />
                    <asp:Parameter Name="ratio_size" Type="String" />
                    <asp:Parameter Name="sample_complete_1" Type="String" />
                    <asp:Parameter Name="sample_complete_2" Type="String" />
                    <asp:Parameter Name="cus_express_corp" Type="String" />
                    <asp:Parameter Name="cus_assign_account" Type="String" />
                    <asp:Parameter Name="cus_address_id" Type="String" />
                    <asp:Parameter Name="cus_addressee" Type="String" />
                    <asp:Parameter Name="cus_address" Type="String" />
                    <asp:Parameter Name="cus_style_no" Type="String" />
                    <asp:Parameter Name="brand_name" Type="String" />
                    <asp:Parameter Name="sam_type" Type="String" />
                    <asp:Parameter Name="proofing_factory" Type="String" />
                    <asp:Parameter Name="filter_creator" Type="String" />
                    <asp:Parameter Name="filter_dept" Type="String" />
                    <asp:Parameter Name="creator" Type="String" />
                    <asp:Parameter Name="create_date" Type="DateTime" />
                    <asp:Parameter Name="modifier" Type="String" />
                    <asp:Parameter Name="modify_date" Type="DateTime" />
                    <asp:Parameter Name="printing" Type="String" />
                    <asp:Parameter Name="sewing" Type="String" />
                    <asp:Parameter Name="samc_remark60" Type="String" />
                    <asp:Parameter Name="mark" Type="String" />
                    <asp:Parameter Name="crp_yn" Type="String" />
                    <asp:Parameter Name="crp_date" Type="DateTime" />
                    <asp:Parameter Name="item_statistic" Type="String" />
                    <asp:Parameter Name="remark_1" Type="String" />
                    <asp:Parameter Name="final" Type="String" />
                    <asp:Parameter Name="last_date" Type="DateTime" />
                    <asp:Parameter Name="samc_fin_date" Type="DateTime" />
                    <asp:Parameter Name="sam_type_A" Type="String" />
                    <asp:Parameter Name="sam_type_B" Type="String" />
                    <asp:Parameter Name="sam_type_C" Type="String" />
                    <asp:Parameter Name="sam_type_D" Type="String" />
                    <asp:Parameter Name="sam_type_E" Type="String" />
                    <asp:Parameter Name="sam_type_F" Type="String" />
                    <asp:Parameter Name="hotfix" Type="String" />
                    <asp:Parameter Name="s_plan_arrival_date" Type="DateTime" />
                    <asp:Parameter Name="s_real_arrival_date" Type="DateTime" />
                    <asp:Parameter Name="Original_site" Type="String" />
                    <asp:Parameter Name="Original_sam_nbr" Type="String" />
                    <asp:Parameter Name="Original_sam_times" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="FinaceObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="GGFPortal.DataSetSource.FinanceD001TableAdapters.ViewShpcTableAdapter">
                <SelectParameters>
                    <asp:SessionParameter Name="StartDay" SessionField="F001StartDay" Type="String" />
                    <asp:SessionParameter Name="EndDay" SessionField="F001EndDay" Type="String" />
                    <asp:SessionParameter DefaultValue="" Name="site" SessionField="F001Site" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>

</body>
</html>
