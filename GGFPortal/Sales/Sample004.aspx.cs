using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sample004 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (YearDDL.Items.Count == 0)
            {
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (DateTime.Now.Year - 2015);


                for (int i = 0; i < iCountMonth; i++)
                {
                    if (i == 0)
                    {
                        YearDDL.Items.Add("");
                    }
                    YearDDL.Items.Add(DateTime.Now.AddYears(-i).ToString("yyyy"));
                }
            }
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            YearDDL.SelectedValue = "";
            MonthDDL.SelectedValue = "";
            AreaDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {
            if (!String.IsNullOrEmpty(MonthDDL.SelectedValue) && String.IsNullOrEmpty(YearDDL.SelectedValue))
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
                    ReportViewer1.Visible = true;
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportDataSource source = new ReportDataSource("Sample004", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(source);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
            }
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(" select * from [View打樣室處理作業] ");

            if (!String.IsNullOrEmpty(YearDDL.SelectedValue) || !String.IsNullOrEmpty(MonthDDL.Text)  || !String.IsNullOrEmpty(AreaDDL.SelectedValue) )
            {
                strsql.Append(" where 1=1 ");
                if (!String.IsNullOrEmpty(YearDDL.SelectedValue))
                {
                    strsql.AppendFormat(" and YEAR([發版日期])  = '{0}' ", YearDDL.SelectedValue);
                    if (!String.IsNullOrEmpty(MonthDDL.SelectedValue))
                        strsql.AppendFormat(" and MONTH([發版日期])  = '{0}'", MonthDDL.SelectedValue);
                }

                if (!String.IsNullOrEmpty(AreaDDL.SelectedValue))
                    strsql.AppendFormat(" and [地區]  = '{0}'", AreaDDL.SelectedValue);
                if (!string.IsNullOrEmpty(TypeDDL.SelectedValue))
                {
                    strsql.AppendFormat(" and [打樣處理]  = '{0}'", TypeDDL.SelectedValue);
                    //command1.Parameters.Add("@SampleType", SqlDbType.NVarChar).Value = TypeDDL.SelectedValue;
                }
            }
            return strsql;
        }
        
    }
}