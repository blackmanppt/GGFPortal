using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class SALE_V5 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
            收單起TB.Attributes["readonly"] = "readonly";
            收單迄TB.Attributes["readonly"] = "readonly";
            //StartDayTB0.Attributes["readonly"] = "readonly";
            //EndDay0.Attributes["readonly"] = "readonly";

            if (IsPostBack)
            {
                if (收單起TB.Text.Length > 0)
                    收單迄TB_CalendarExtender.StartDate = Convert.ToDateTime(收單起TB.Text);
                if (收單迄TB.Text.Length > 0)
                    收單起TB_CalendarExtender.EndDate = Convert.ToDateTime(收單迄TB.Text);
                //if (StartDayTB0.Text.Length > 0)
                //    EndDay0_CalendarExtender.StartDate = Convert.ToDateTime(StartDayTB0.Text);
                //if (EndDay0.Text.Length > 0)
                //    StartDayTB0_CalendarExtender.EndDate = Convert.ToDateTime(EndDay0.Text);
                if (ReceiptCB.Checked == false)
                    Label1.Text = "收單日期";
                else
                    Label1.Text = "業務完成日期";
            }
            else
            {
            }
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            收單起TB.Text = "";
            收單迄TB.Text = "";
            SamcTypeDDL.SelectedValue = "";
            BrandTB.Text = "";
            NewOldDDL.SelectedValue = "2";
            StatusDDL.SelectedValue = "A";
            結案起TB.Text = "";
            結案迄TB.Text = "";
            //FinalDateShow(false);
            ReceiptCB.Checked = false;
            款號TB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (SearchCheck())
            {
                DbInit();
            }
            else
            {
                F_ErrorShow("請輸入搜尋資料");
            }
            
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
                ReportDataSource source = new ReportDataSource("View1", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(string.Format(@" 
                                                        SELECT   {0}
                                                        [receipt_date] 收單日期
                                                        ,[sam_nbr] 樣品單號
                                                        ,image_path 小圖
                                                        ,[brand_name] 品牌
                                                        ,[cus_style_no] 款號
                                                        ,[item_statistic_name] 款式類別
                                                        ,[type_desc] 樣品種類
                                                        ,[dbo].[F_DateToNull]([last_date]) 需求日期
                                                        ,[sam_size] 需求尺寸
                                                        ,[sam_qty] 需求件數
                                                        ,[dbo].[F_DateToNull]([online_date]) 上線日期
                                                        ,[dbo].[F_DateToNull]([samc_fin_date]) 打版完成日
                                                        ,[dbo].[F_DateToNull]([s_real_arrival_date]) 主副料到達日
                                                        ,[dbo].[F_DateToNull]([plan_fin_date]) 預計完成日
                                                        ,[dbo].[F_DateToNull]([finish_date]) 打樣完成日
                                                        , case when [dbo].[F_DateToNull]([finish_date]) is null then null  when DATEPART(WEEKDAY, finish_date-1) =5 then [finish_date] + 4  else [finish_date]+2 end TD預計完成日
                                                        ,[dbo].[F_DateToNull](td_fin_date) TD完成日
                                                        ,b.employee_name_eng +'('+b.tel_nbr+')' as 開單人員
                                                        ,[remark60] 備註

                                                         ,((SELECT distinct cast((n.MappingData +'_'+ z.SampleUser )  AS NVARCHAR ) + ',' from  [GGFRequestSam]  z left join Mapping n on z.SampleType=n.Data and n.UsingDefine='GGFRequestSam' and z.Flag=0
                                                        where sam_nbr=a.sam_nbr 
                                                        FOR XML PATH(''))) as 打樣人員
														,(SELECT distinct cast((zz.處理時間+'_'+ zz.修改人員 )  AS NVARCHAR ) + ',' from  [GGFRequestSam]  z  left join [GGFRequestMark] zz on z.uid=zz.uid and z.Flag=0 and zz.狀態=0
                                                        where sam_nbr=a.sam_nbr 
                                                        FOR XML PATH('')) as 馬克處理
                                                        FROM              samc_reqm AS a LEFT OUTER JOIN
                                                        bas_employee AS b ON a.site = b.site AND a.creator = b.employee_no LEFT OUTER JOIN
                                                        samc_type AS c ON a.site = c.site AND a.type_id = c.type_id left join bas_dept d on a.site=d.site and a.dept_no=d.dept_no
                                                        left join bas_item_statistic e on a.site=e.site and a.item_statistic=e.item_statistic
                                                        where 1=1 
                                                ", (收單起TB.Text.Length>0&&收單迄TB.Text.Length>0)?"":" top 100 "));
            
            
            if (!string.IsNullOrEmpty(BrandTB.Text))
                strsql.AppendFormat(" and a.brand_name LIKE '{0}%'",BrandTB.Text);
            if(SamcTypeDDL.Text.Length > 0)
            {
                strsql.AppendFormat(" and a.type_id LIKE '{0}'", SamcTypeDDL.SelectedValue); 
            }
            if (StatusDDL.SelectedValue != "ALL")
                strsql.AppendFormat(" and a.status ='{0}'  ", StatusDDL.SelectedValue);
            if (StatusDDL.SelectedValue == "CL")
            {
                strsql.AppendFormat(" and   convert(varchar(10),a.close_date,111)  between '{0}' and '{1}'"
                    , (string.IsNullOrEmpty(結案起TB.Text)) ? DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd") : 結案起TB.Text
                    , (string.IsNullOrEmpty(結案迄TB.Text)) ?
                                    (string.IsNullOrEmpty(結案起TB.Text)) ? DateTime.Now.ToString("yyyy/MM/dd") : Convert.ToDateTime(結案起TB.Text).AddDays(7).ToString("yyyy/MM/dd")
                                    : 結案迄TB.Text);
            }
            
            if(!string.IsNullOrEmpty(款號TB.Text))
                strsql.AppendFormat(" and a.cus_style_no like '{0}%'  ", 款號TB.Text);

            switch (NewOldDDL.SelectedValue)
            {
                //業務完成
                case "2":
                    strsql.Append(" and a.progress_rate ='2' ");
                    break;
                //打樣完成
                case "3":
                    strsql.Append(" and a.progress_rate ='3' ");
                    break;
                default:
                    strsql.Append(" and a.progress_rate  in  ( '2','3') ");
                    break;
            }

            if (string.IsNullOrEmpty(款號TB.Text))
                if (ReceiptCB.Checked == false)
                {
                    if(string.IsNullOrEmpty(款號TB.Text))
                    { 

                    }
                    strsql.AppendFormat(" and   convert(varchar(10),a.receipt_date,111)  between '{0}' and '{1}'"
                        , (string.IsNullOrEmpty(收單起TB.Text)) ? DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd") : 收單起TB.Text
                        , (string.IsNullOrEmpty(收單迄TB.Text)) ?
                                        (string.IsNullOrEmpty(收單起TB.Text)) ? DateTime.Now.ToString("yyyy/MM/dd") : Convert.ToDateTime(收單起TB.Text).AddDays(7).ToString("yyyy/MM/dd")
                                        : 收單迄TB.Text);
                }
                else
                {
                    strsql.Append(" and  a.receipt_date is null  ");
                    //查詢未收單，變更查詢業務完成日
                    strsql.AppendFormat(" and   convert(varchar(10),a.sale_finish_date,111)  between '{0}' and '{1}'"
                        , (string.IsNullOrEmpty(收單起TB.Text)) ? DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd") : 收單起TB.Text
                        , (string.IsNullOrEmpty(收單迄TB.Text)) ?
                                        (string.IsNullOrEmpty(收單起TB.Text)) ? DateTime.Now.ToString("yyyy/MM/dd") : Convert.ToDateTime(收單起TB.Text).AddDays(7).ToString("yyyy/MM/dd")
                                        : 收單迄TB.Text);

                }
            //未收單使用樣品單日期排序
            if (ReceiptCB.Checked == false)
                strsql.Append(" order by receipt_date desc ");
            else
                strsql.Append(" order by sale_finish_date desc ");
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            if (!string.IsNullOrEmpty(結案起TB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(結案迄TB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(款號TB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(BrandTB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(收單起TB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(收單迄TB.Text))
                bCheck = true;
            if(ReceiptCB.Checked==true)
                bCheck = true;
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        protected void StatusDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StatusDDL.SelectedValue == "CL")
            {
                結案起TB.Enabled = true;
                結案迄TB.Enabled = true;
            }
            else
            {
                結案起TB.Enabled = false;
                結案迄TB.Enabled = false;
            }
        }

        protected void ReceiptCB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}