using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sample011 : System.Web.UI.Page
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
            AreaDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {
            if (!String.IsNullOrEmpty(StartDayTB.Text) && String.IsNullOrEmpty(EndDayTB.Text))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('未選擇起迄時間');</script>");
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
                    ReportDataSource source = new ReportDataSource("打樣單明細表", dt);
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
            
            StringBuilder strsql = new StringBuilder(" select * from [View打樣室處理作業明細] where ");

            if (!String.IsNullOrEmpty(StartDayTB.Text) || !String.IsNullOrEmpty(EndDayTB.Text)  || !String.IsNullOrEmpty(AreaDDL.SelectedValue) )
            {

                if(人員DDL.SelectedValue=="全部")
                {
                    strsql.AppendFormat(" ( 處理人員 like '%車縫%' or  處理人員 like '%裁剪人%')");
                }
                else
                {
                    strsql.AppendFormat("  處理人員 like '%{0}%' ",人員DDL.SelectedValue);
                }
                strsql.AppendFormat(" and ( 打樣處理日期 between '{0}' and '{1}')",
                    (!string.IsNullOrEmpty(StartDayTB.Text))? StartDayTB.Text:"20000101",
                    (!string.IsNullOrEmpty(EndDayTB.Text)) ? EndDayTB.Text : "20999999"
                    );

                //if (!String.IsNullOrEmpty(StartDayTB.Text))
                //{
                //    strsql.AppendFormat(" and YEAR([發版日期])  = '{0}' ", YearDDL.SelectedValue);
                //    if (!String.IsNullOrEmpty(MonthDDL.SelectedValue))
                //        strsql.AppendFormat(" and MONTH([發版日期])  = '{0}'", MonthDDL.SelectedValue);
                //}

                if (!String.IsNullOrEmpty(AreaDDL.SelectedValue))
                    strsql.AppendFormat(" and [地區]  = '{0}'", AreaDDL.SelectedValue);
            }
            return strsql;
        }
        
    }
}