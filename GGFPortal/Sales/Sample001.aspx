<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample001.aspx.cs" Inherits="GGFPortal.Sales.Sample001" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>樣品進度登記</title>
    
        <%--<link href="scripts/bootstrap.min.css" rel="stylesheet"/>--%>
    <style type="text/css">
        .auto-style1 {
            width: 72px;
        }
    </style>
    <style type="text/css">
            .hiddencol
            {
                display:none;
            }
                .viscol
    {
        display:block;
    }
        </style>
</head>
<body>
    <form id="form1" runat="server">

    <div>
    
        <table style="width:800px;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="樣品進度登記" style="font-size: xx-large; font-weight: 700; background-color: #00CC99;"></asp:Label>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

                    </td>
                
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="StyleNoLB" runat="server" Text="Style No："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="StyleNoTB" runat="server"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="StyleNoTB_AutoCompleteExtender" runat="server" CompletionInterval="100" CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" ServiceMethod="SearchStyleNo"  TargetControlID="StyleNoTB">
                    </ajaxToolkit:AutoCompleteExtender>
                    <asp:Button ID="Button1" runat="server" Text="Search" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <div>

            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="site,sam_nbr,sam_times" DataSourceID="SqlDataSource1" AllowPaging="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" PageSize="20" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="編輯" SelectText="編輯" ShowSelectButton="True" />
                    <asp:BoundField DataField="site" HeaderText="公司別" ReadOnly="True" SortExpression="site" />
                    <asp:BoundField DataField="sam_nbr" HeaderText="樣品單號" ReadOnly="True" SortExpression="sam_nbr" />
                    <asp:BoundField DataField="cus_style_no" HeaderText="款號" SortExpression="cus_style_no" />
                    <asp:BoundField DataField="image_path" HeaderText="小圖路徑" SortExpression="image_path"  HeaderStyle-CssClass="hiddencol"   ItemStyle-cssclass="hiddencol" >
                    
<HeaderStyle CssClass="hiddencol"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
                    </asp:BoundField>
                    
                    <%--
                    
                    <asp:BoundField DataField="sam_no" HeaderText="sam_no" SortExpression="sam_no" />
                    <asp:BoundField DataField="version" HeaderText="version" SortExpression="version" />
                    
                    <asp:BoundField DataField="cus_id" HeaderText="cus_id" SortExpression="cus_id" />
                    <asp:BoundField DataField="dept_no" HeaderText="dept_no" SortExpression="dept_no" />
                    <asp:BoundField DataField="item_no" HeaderText="item_no" SortExpression="item_no" />
                    <asp:BoundField DataField="type_id" HeaderText="type_id" SortExpression="type_id" />
                    <asp:BoundField DataField="salesman" HeaderText="salesman" SortExpression="salesman" />
                    <asp:BoundField DataField="sam_size" HeaderText="sam_size" SortExpression="sam_size" />
                    <asp:BoundField DataField="assign_qty" HeaderText="assign_qty" SortExpression="assign_qty" />
                    <asp:BoundField DataField="plan_fin_date" HeaderText="plan_fin_date" SortExpression="plan_fin_date" />
                    <asp:BoundField DataField="emb" HeaderText="emb" SortExpression="emb" />
                    <asp:BoundField DataField="washing" HeaderText="washing" SortExpression="washing" />
                    <asp:BoundField DataField="oth_extra" HeaderText="oth_extra" SortExpression="oth_extra" />
                    <asp:BoundField DataField="finish_date" HeaderText="finish_date" SortExpression="finish_date" />
                    <asp:BoundField DataField="finish_qty" HeaderText="finish_qty" SortExpression="finish_qty" />
                    <asp:BoundField DataField="place_origin" HeaderText="place_origin" SortExpression="place_origin" />
                    <asp:BoundField DataField="currency_id" HeaderText="currency_id" SortExpression="currency_id" />
                    <asp:BoundField DataField="unit_price" HeaderText="unit_price" SortExpression="unit_price" />
                    <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                    
                    <asp:BoundField DataField="sam_cus_qty" HeaderText="sam_cus_qty" SortExpression="sam_cus_qty" />
                    <asp:BoundField DataField="sam_taipei_qty" HeaderText="sam_taipei_qty" SortExpression="sam_taipei_qty" />
                    
                    <asp:BoundField DataField="remark60" HeaderText="remark60" SortExpression="remark60" />
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    <asp:BoundField DataField="close_date" HeaderText="close_date" SortExpression="close_date" />
                    <asp:BoundField DataField="reason" HeaderText="reason" SortExpression="reason" />
                    <asp:BoundField DataField="online_date" HeaderText="online_date" SortExpression="online_date" />
                    <asp:BoundField DataField="confirm_yn" HeaderText="confirm_yn" SortExpression="confirm_yn" />
                    <asp:BoundField DataField="progress_rate" HeaderText="progress_rate" SortExpression="progress_rate" />
                    <asp:BoundField DataField="sam_class" HeaderText="sam_class" SortExpression="sam_class" />
                    <asp:BoundField DataField="original_sampleo_yn" HeaderText="original_sampleo_yn" SortExpression="original_sampleo_yn" />
                    <asp:BoundField DataField="original_edition_yn" HeaderText="original_edition_yn" SortExpression="original_edition_yn" />
                    <asp:BoundField DataField="original_edition_size" HeaderText="original_edition_size" SortExpression="original_edition_size" />
                    <asp:BoundField DataField="ratio_size" HeaderText="ratio_size" SortExpression="ratio_size" />
                    <asp:BoundField DataField="sample_complete_1" HeaderText="sample_complete_1" SortExpression="sample_complete_1" />
                    <asp:BoundField DataField="sample_complete_2" HeaderText="sample_complete_2" SortExpression="sample_complete_2" />
                    <asp:BoundField DataField="cus_express_corp" HeaderText="cus_express_corp" SortExpression="cus_express_corp" />
                    <asp:BoundField DataField="cus_assign_account" HeaderText="cus_assign_account" SortExpression="cus_assign_account" />
                    <asp:BoundField DataField="cus_address_id" HeaderText="cus_address_id" SortExpression="cus_address_id" />
                    <asp:BoundField DataField="cus_addressee" HeaderText="cus_addressee" SortExpression="cus_addressee" />
                    <asp:BoundField DataField="cus_address" HeaderText="cus_address" SortExpression="cus_address" />
                    
                    <asp:BoundField DataField="brand_name" HeaderText="brand_name" SortExpression="brand_name" />
                    <asp:BoundField DataField="sam_type" HeaderText="sam_type" SortExpression="sam_type" />
                    <asp:BoundField DataField="proofing_factory" HeaderText="proofing_factory" SortExpression="proofing_factory" />
                    <asp:BoundField DataField="filter_creator" HeaderText="filter_creator" SortExpression="filter_creator" />
                    <asp:BoundField DataField="filter_dept" HeaderText="filter_dept" SortExpression="filter_dept" />
                    <asp:BoundField DataField="creator" HeaderText="creator" SortExpression="creator" />
                    <asp:BoundField DataField="create_date" HeaderText="create_date" SortExpression="create_date" />
                    <asp:BoundField DataField="modifier" HeaderText="modifier" SortExpression="modifier" />
                    <asp:BoundField DataField="modify_date" HeaderText="modify_date" SortExpression="modify_date" />
                    <asp:BoundField DataField="printing" HeaderText="printing" SortExpression="printing" />
                    <asp:BoundField DataField="sewing" HeaderText="sewing" SortExpression="sewing" />
                    <asp:BoundField DataField="samc_remark60" HeaderText="samc_remark60" SortExpression="samc_remark60" />
                    <asp:BoundField DataField="mark" HeaderText="mark" SortExpression="mark" />
                    <asp:BoundField DataField="crp_yn" HeaderText="crp_yn" SortExpression="crp_yn" />
                    <asp:BoundField DataField="crp_date" HeaderText="crp_date" SortExpression="crp_date" />
                    <asp:BoundField DataField="item_statistic" HeaderText="item_statistic" SortExpression="item_statistic" />
                    <asp:BoundField DataField="remark_1" HeaderText="remark_1" SortExpression="remark_1" />
                    <asp:BoundField DataField="final" HeaderText="final" SortExpression="final" />
                    <asp:BoundField DataField="last_date" HeaderText="last_date" SortExpression="last_date" />
                    <asp:BoundField DataField="samc_fin_date" HeaderText="samc_fin_date" SortExpression="samc_fin_date" />
                    <asp:BoundField DataField="sam_type_A" HeaderText="sam_type_A" SortExpression="sam_type_A" />
                    <asp:BoundField DataField="sam_type_B" HeaderText="sam_type_B" SortExpression="sam_type_B" />
                    <asp:BoundField DataField="sam_type_C" HeaderText="sam_type_C" SortExpression="sam_type_C" />
                    <asp:BoundField DataField="sam_type_D" HeaderText="sam_type_D" SortExpression="sam_type_D" />
                    <asp:BoundField DataField="sam_type_E" HeaderText="sam_type_E" SortExpression="sam_type_E" />
                    <asp:BoundField DataField="sam_type_F" HeaderText="sam_type_F" SortExpression="sam_type_F" />
                    <asp:BoundField DataField="hotfix" HeaderText="hotfix" SortExpression="hotfix" />
                    <asp:BoundField DataField="s_plan_arrival_date" HeaderText="s_plan_arrival_date" SortExpression="s_plan_arrival_date" />
                    <asp:BoundField DataField="s_real_arrival_date" HeaderText="s_real_arrival_date" SortExpression="s_real_arrival_date" />
                    <asp:BoundField DataField="sam_type_G" HeaderText="sam_type_G" SortExpression="sam_type_G" />
                    
                    <asp:BoundField DataField="original_edition" HeaderText="original_edition" SortExpression="original_edition" />--%>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            小圖
                        </HeaderTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("image_path") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="90px" ImageUrl='<%# Eval("image_path") %>' Width="90px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="type_desc" HeaderText="種類" ReadOnly="True" SortExpression="type_desc" />
                    <asp:BoundField DataField="samc_fin_date" HeaderText="打版完成日" SortExpression="samc_fin_date" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="sam_qty" HeaderText="需求件數" SortExpression="sam_qty" />
                    <asp:BoundField DataField="sam_date" HeaderText="打樣日期" SortExpression="sam_date" DataFormatString="{0:d}"/>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GGFConnectionString %>" SelectCommand="SELECT a.site, a.sam_nbr, a.sam_times, a.sam_no, a.version, a.sam_date, a.cus_id, a.dept_no, a.item_no, a.type_id, a.salesman, a.sam_size, a.assign_qty, a.plan_fin_date, a.emb, a.washing, a.oth_extra, a.finish_date, a.finish_qty, a.place_origin, a.currency_id, a.unit_price, a.amount, a.sam_qty, a.sam_cus_qty, a.sam_taipei_qty, a.image_path, a.remark60, a.status, a.close_date, a.reason, a.online_date, a.confirm_yn, a.progress_rate, a.sam_class, a.original_sampleo_yn, a.original_edition_yn, a.original_edition_size, a.ratio_size, a.sample_complete_1, a.sample_complete_2, a.cus_express_corp, a.cus_assign_account, a.cus_address_id, a.cus_addressee, a.cus_address, a.cus_style_no, a.brand_name, a.sam_type, a.proofing_factory, a.filter_creator, a.filter_dept, a.creator, a.create_date, a.modifier, a.modify_date, a.printing, a.sewing, a.samc_remark60, a.mark, a.crp_yn, a.crp_date, a.item_statistic, a.remark_1, a.final, a.last_date, a.samc_fin_date, a.sam_type_A, a.sam_type_B, a.sam_type_C, a.sam_type_D, a.sam_type_E, a.sam_type_F, a.hotfix, a.s_plan_arrival_date, a.s_real_arrival_date, a.sam_type_G, a.samc_plan_fin_date, a.original_edition, a.reason_remark, a.sale_finish_date, a.receipt_yn, a.receipt_date, b.type_desc FROM samc_reqm AS a LEFT OUTER JOIN samc_type AS b ON a.site = b.site AND a.type_id = b.type_id WHERE (a.cus_style_no LIKE '%' + LTRIM(RTRIM(@sam_nbr)) + '%') AND (a.status &lt;&gt; @status) ORDER BY a.modify_date DESC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="StyleNoTB" DefaultValue="%" Name="sam_nbr" PropertyName="Text" Type="String" />
                    <asp:Parameter DefaultValue="CL" Name="status" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
