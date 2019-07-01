using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sample014 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDayTB.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            StartDayTB.Text = "";
            EndDayTB.Text = "";
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
            DataTable dt = new DataTable(), dt2 = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("打版完成日").ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執c行SQL指令。取出資料，放進 DataSet。
                //SqlDataAdapter myAdapter2 = new SqlDataAdapter(selectsql("收單日").ToString(), Conn);
                //myAdapter2.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("View1", dt);
                //ReportDataSource source1 = new ReportDataSource("View2", dt2);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                //ReportViewer1.LocalReport.DataSources.Add(source1);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql(string Str日期類別)
        {
            Str日期類別 = "打版完成日";
            StringBuilder strsql = new StringBuilder(@" SELECT distinct [site]
                                                              ,[sam_nbr]
                                                              ,[款號]
                                                              ,[item_statistic_name]
                                                              ,[type_desc]
                                                              ,客戶代號
                                                              ,SampleUser
                                                              ,[打版完成日]
                                                          FROM [dbo].[View樣品室處理作業總表]
                                                          where SampleUser like '%打版%' ");
            if (Str日期類別 == "打版完成日")
            {
                strsql.AppendFormat(" and [打版完成日]   between '{0}' and '{1}' "
                    ,(string.IsNullOrEmpty(StartDayTB.Text))?DateTime.Now.ToString("yyyy-MM-dd"):StartDayTB.Text
                    , (string.IsNullOrEmpty(EndDayTB.Text)) ? (string.IsNullOrEmpty(StartDayTB.Text))?DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"): Convert.ToDateTime(StartDayTB.Text).AddDays(7).ToString("yyyy-MM-dd")
                                                                : EndDayTB.Text
                    );
            }
            else
            {
                //strsql.Append(" and [打樣處理建立日期]  between '{0}' and '{1}' ");
                strsql.AppendFormat(" and [打樣處理建立日期]   between '{0}' and '{1}' "
                    , (string.IsNullOrEmpty(StartDayTB.Text)) ? DateTime.Now.ToString("yyyy-MM-dd") : StartDayTB.Text
                    , (string.IsNullOrEmpty(EndDayTB.Text)) ? (string.IsNullOrEmpty(StartDayTB.Text)) ? DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") : Convert.ToDateTime(StartDayTB.Text).AddDays(7).ToString("yyyy-MM-dd")
                                                                : EndDayTB.Text
                    );
            }
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
            if (!string.IsNullOrEmpty(StartDayTB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(EndDayTB.Text))
                bCheck = true;
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
    }
}