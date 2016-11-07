<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales001.aspx.cs" Inherits="GGFPortal.Sales.Sales001" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="90%">
            <LocalReport ReportPath="ReportSource\ReportSales001.rdlc">

                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Sales001" />
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
    </div>
    </form>
</body>
</html>
