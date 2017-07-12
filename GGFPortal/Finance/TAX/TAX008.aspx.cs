using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using GGFPortal.DataSetSource;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;

namespace GGFPortal.Finance.TAX
{

    public partial class TAX008 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (YearDDL.Items.Count == 0)
            {
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (DateTime.Now.Year - 2015) * 12 + (DateTime.Now.Month - 12);
                string[] strMonth = new string[] { };
                List<string> sMonth = new List<string>();
                List<DateTime> dMonth = new List<DateTime>();
                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        YearDDL.Items.Add("");
                    }
                    YearDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                    sMonth.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                }
                GGFPortal.DataSetSource.TestGroupEntities xx = new TestGroupEntities();
                var value = (from x in xx.acr_trn
                             where x.acr_date != null
                             select  x.acr_date)
                            .Distinct().ToList()
                            
                            ;
                //List<string> lp = value.Select(date=>string.Format("yyyyMM",date));
                
                var value2 = from y in value
                             from z in sMonth
                             where  !y.ToString().Contains(z)
                             select y;

                List<string> strings = new List<string>() { "2014-01-14" };

                List<DateTime> dates = strings.Select(date => DateTime.Parse(date)).ToList();

            }
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected string convertdate(DateTime dt)
        {
            return dt.ToString("yyyyMM");
        }
        protected void ClearBT_Click(object sender, EventArgs e)
        {
            YearDDL.SelectedValue = "";
            //MonthDDL.SelectedValue = "";
            //AreaDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {
            if ( String.IsNullOrEmpty(YearDDL.SelectedValue))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('未選擇年度');</script>");
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                }
                if (dt.Rows.Count > 0)
                {
                    //ReportViewer1.Visible = true;
                    //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    //ReportDataSource source = new ReportDataSource("Sample006", dt);
                    //ReportViewer1.LocalReport.DataSources.Clear();
                    //ReportViewer1.LocalReport.DataSources.Add(source);
                    //ReportViewer1.DataBind();
                    //ReportViewer1.LocalReport.Refresh();
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
            }
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(" select * from [View打樣室處理作業] ");

            //if (!String.IsNullOrEmpty(YearDDL.SelectedValue) || !String.IsNullOrEmpty(MonthDDL.Text)  || !String.IsNullOrEmpty(AreaDDL.SelectedValue) )
            //{
            //    strsql.Append(" where 1=1 ");
            //    if (!String.IsNullOrEmpty(YearDDL.SelectedValue))
            //    {
            //        strsql.AppendFormat(" and YEAR([發版日期])  = '{0}' ", YearDDL.SelectedValue);
            //        if (!String.IsNullOrEmpty(MonthDDL.SelectedValue))
            //            strsql.AppendFormat(" and MONTH([發版日期])  = '{0}'", MonthDDL.SelectedValue);
            //    }

            //    if (!String.IsNullOrEmpty(AreaDDL.SelectedValue))
            //        strsql.AppendFormat(" and [地區]  = '{0}'", AreaDDL.SelectedValue);
            //}
            return strsql;
        }
        
    }
}