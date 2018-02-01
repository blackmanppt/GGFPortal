using GGFPortal.DataSetSource;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Secretary
{

    public partial class Secretary007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            //CusTB.Text = "";
            //提單TB.Text = "";
            StartDay.Text = "";
            EndDay.Text = "";
            //快遞廠商DDL.SelectedValue = "";
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
                ReportDataSource source = new ReportDataSource("工時資料", dt);
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
            StringBuilder strsql = new StringBuilder();
            strsql.AppendFormat(@"select a.*,b.[actual_ie],b.[image_path] from [dbo].[View工時資料] a left join [dbo].[View訂單資料2] b on a.款號=b.[cus_item_no]
                                    where    工作時間 between '{0}' and '{1}'"
                                    , (string.IsNullOrEmpty(StartDay.Text))?"20000101": StartDay.Text, (string.IsNullOrEmpty(EndDay.Text)) ? "20991231" : EndDay.Text);
            //if (!string.IsNullOrEmpty(提單TB.Text.Trim()))
            //{
            //    strsql.AppendFormat(" and UPPER(b.[提單號碼]) = '{0}'", 提單TB.Text.Trim().ToUpper());
            //}
            //if (快遞廠商DDL.SelectedValue!="")
            //{
            //    strsql.AppendFormat(" and UPPER(b.[快遞廠商]) = '{0}'", 快遞廠商DDL.SelectedValue);
            //}
            return strsql;
        }
        
    }
}