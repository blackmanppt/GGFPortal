using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{

    public partial class Sample012 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DbInit();
            }
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //品牌TB.Text = "";
            //款號TB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (!SearchCheck())
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
                SamGV.DataSource = dt;
                SamGV.DataBind();
                //ReportViewer1.Visible = true;
                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportDataSource source = new ReportDataSource("採購單料號訂單資料", dt);
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(source);
                //ReportViewer1.DataBind();
                //ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {
            string strselect = "";
            StringBuilder strwhere = new StringBuilder();
            if (打樣未收單CB.Checked)
            {
                strwhere.AppendFormat(@" and dbo.F_DateToNull(sam_in_date) is null and samc_fin_date > '2019-06-10'");
            }
            else
            {
                strselect = @",convert(varchar(20),dbo.F_DateToNull(td_fin_date),111) TD完成日
	                          ,convert(varchar(20),dbo.F_DateToNull(sam_in_date),111) 樣衣收單日
	                          ,convert(varchar(20),dbo.F_DateToNull(sam_out_date),111) 樣衣完成日";
            }
            if (!string.IsNullOrEmpty(代理商TB.Text))
                strwhere.AppendFormat(" and upper([cus_id])  = '{0}' ", 代理商TB.Text.ToUpper());
            StringBuilder strsql = new StringBuilder(string.Format(@" SELECT TOP 1000 a.site,
                                              [sam_nbr] 打樣單號
                                              ,[cus_id] 客戶
                                              ,cus_style_no 款號
                                              ,case when left(a.[dept_no],3) like 'S01%' then '業一' when left(a.[dept_no],3) like'S02%' then '業二' when left(a.[dept_no],3) like 'S03%' then '業三' when left(a.[dept_no],3) like 'S04%' then '業四' else b.dept_name end 部門
                                              ,e.type_desc 樣衣總類
                                                ,c.employee_name+'('+employee_name_eng+')' 業務
                                              ,convert(varchar(20),dbo.F_DateToNull([sam_date]),111) 打樣日期
	                                          ,convert(varchar(20),dbo.F_DateToNull(samc_fin_date),111) 打版完成日
                                               ,convert(varchar(20),dbo.F_DateToNull(s_real_arrival_date),111) 到料日
                                                {0}
                                          FROM [samc_reqm] a
                                              left join bas_dept b on a.site=b.site and a.dept_no=b.dept_no
                                              left join bas_employee c on a.site=c.site and   a.salesman=c.employee_no
                                              left join bas_item_statistic d on a.site=d.site and a.item_statistic=d.item_statistic
                                              left join samc_type e on a.site=e.site and a.type_id=e.type_id
                                          where samc_fin_date is not null  
                                                {1}
                                          order by samc_fin_date desc ", strselect, strwhere));





            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節年度])  = '{0}' ", 年度DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節])  = '{0}' ", 季節DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    strsql.AppendFormat(" and upper([Style])  like '%{0}%' ", 款號TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    strsql.AppendFormat(" and upper([品牌])  = '{0}' ", 品牌TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    strsql.AppendFormat(" and upper([代理商])  = '{0}' ", 代理商TB.Text.ToUpper());
            //if(主料CB.Checked)
            //    strsql.Append(" and upper([主副料])  = 'M' ");
            //if (入庫CB.Checked)
            //    strsql.Append(" and upper([採購單狀態])  = 'IN' ");
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    bCheck = true;
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        protected void SamGV_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            SamGV.PageIndex = e.NewPageIndex;
            DbInit();
        }

        protected void SamGV_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "上傳"|| e.CommandName == "刪除")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string StrSite = "", StrSam_nbr = "" ,StrUpdateData="";
                //StringBuilder sb = new StringBuilder();

                StrSite = SamGV.Rows[row.RowIndex].Cells[1].Text;
                StrSam_nbr = SamGV.Rows[row.RowIndex].Cells[2].Text;
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("UpdateSam");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        StrUpdateData = (e.CommandName == "上傳") ?"'" + DateTime.Now.ToString("yyyy-MM-dd") +"'": "null";


                        command1.CommandText = string.Format(@"
                                        update samc_reqm
                                            set s_real_arrival_date= {0}
                                        where 
                                        sam_nbr = '{1}' and 
                                        site = '{2}'
                                        ", StrUpdateData, StrSam_nbr, StrSite);
                        command1.ExecuteNonQuery();

                        transaction1.Commit();
                        //DBBind();
                        DbInit();
                        MessageLB.Text = "主副料到期日上傳完畢";
                        AlertPanel_ModalPopupExtender.Show();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "主副料到期日上傳失敗 :", "Sample012.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "主副料到期日上傳 Error:", "Sample012.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            MessageLB.Text = "主副料到期日上傳失敗請連絡MIS";
                            AlertPanel_ModalPopupExtender.Show();
                            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('核准失敗請連絡MIS');</script>");
                        }
                    }
                    finally
                    {
                        conn1.Close();
                        conn1.Dispose();
                        command1.Dispose();
                        //Session.RemoveAll();
                    }
                }

            }

        }
    }
}