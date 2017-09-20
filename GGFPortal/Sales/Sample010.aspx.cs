using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{

    public partial class Sample010 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            StyleTB.Text = "";
            //StartDay.Text = "";
            //EndDay.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            }
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("打樣收單", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
            
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(@" SELECT c.type_desc, a.site, a.sam_nbr, a.sam_times, a.sam_no, a.version, a.sam_date, a.cus_id, a.dept_no, a.item_no, 
                                    a.type_id, a.salesman, a.sam_size, a.assign_qty, [dbo].[F_DateToNull](a.plan_fin_date) as 'plan_fin_date', a.emb, a.washing, a.oth_extra,[dbo].[F_DateToNull](finish_date) as  'finish_date',
                                    a.finish_qty, a.place_origin, a.currency_id, a.unit_price, a.amount, a.sam_qty, a.sam_cus_qty, a.sam_taipei_qty, 
                                    a.image_path, a.remark60, a.status, [dbo].[F_DateToNull](close_date) as 'close_date', a.reason,[dbo].[F_DateToNull](online_date) as 'online_date', a.confirm_yn, a.progress_rate, 
                                    a.sam_class, a.original_sampleo_yn, a.original_edition_yn, a.original_edition_size, a.ratio_size, 
                                    a.sample_complete_1, a.sample_complete_2, a.cus_express_corp, a.cus_assign_account, a.cus_address_id, 
                                    a.cus_addressee, a.cus_address, a.cus_style_no, a.brand_name, a.sam_type, a.proofing_factory, a.filter_creator, 
                                    a.filter_dept, a.creator, a.create_date, a.modifier, a.modify_date, a.printing, a.sewing, a.samc_remark60, a.mark, 
                                    a.crp_yn, a.crp_date, a.item_statistic, a.remark_1, a.final,[dbo].[F_DateToNull](last_date) as 'last_date',[dbo].[F_DateToNull](samc_fin_date) as 'samc_fin_date', a.sam_type_A, 
                                    a.sam_type_B, a.sam_type_C, a.sam_type_D, a.sam_type_E, a.sam_type_F, a.hotfix,[dbo].[F_DateToNull](s_plan_arrival_date) as 's_plan_arrival_date', 
                                    [dbo].[F_DateToNull](s_real_arrival_date) 's_real_arrival_date', b.tel_nbr,d.dept_name,e.item_statistic_name,a.reason_remark,a.original_edition,
                                    (SELECT distinct cast((n.MappingData +'_'+ z.SampleUser )  AS NVARCHAR ) + ',' from  [GGFRequestSam]  z left join Mapping n on z.Flag=n.Data and n.UsingDefine='GGFRequestSam'
                                    where sam_nbr=a.sam_nbr 
                                    FOR XML PATH('')) as SampleName,f.reason_name,[dbo].[F_DateToNull](samc_plan_fin_date) as 'samc_plan_fin_date', [dbo].[F_DateToNull](receipt_date) as 'receipt_date'
                                    FROM              samc_reqm AS a LEFT OUTER JOIN
                                    bas_employee AS b ON a.site = b.site AND a.creator = b.employee_no LEFT OUTER JOIN
                                    samc_type AS c ON a.site = c.site AND a.type_id = c.type_id left join bas_dept d on a.site=d.site and a.dept_no=d.dept_no
                                    left join bas_item_statistic e on a.site=e.site and a.item_statistic=e.item_statistic
                                    left join bas_reason f on a.site=f.site and a.reason=f.reason and f.sys_id='SAMC'
                                    WHERE  
                                ");
            
            string str處理狀態 = "";
            strsql.Append((處理狀態DDL.SelectedValue == "4") ? " a.progress_rate in ('2','3')" : " a.progress_rate ='" + 處理狀態DDL.SelectedValue + "'");
            foreach (ListItem item in 打樣單狀態CB.Items)
            {
                if (item.Selected)
                {
                    if (str處理狀態.Length > 0)
                        str處理狀態 += ",";
                    str處理狀態 += "'" + item.Value + "'";
                }
            }
            if (str處理狀態.Length > 0)
                strsql.AppendFormat(" and a.status in ({0})", str處理狀態);
            if (StyleTB.Text.Trim().Length>0)
                strsql.AppendFormat(" and cus_style_no = '{0}'", StyleTB.Text);
            strsql.Append("order by receipt_date desc");
            
            return strsql;
        }
        
    }
}