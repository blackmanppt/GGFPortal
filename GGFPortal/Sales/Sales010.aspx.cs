using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sales010 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            品牌TB.Text = "";
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請輸入搜尋資料');</script>");
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
                ReportDataSource source = new ReportDataSource("採購單料號訂單資料", dt);
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
            
            StringBuilder strsql = new StringBuilder(" select * from [View採購單料號訂單資料] where 1=1 ");
            if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
                strsql.AppendFormat(" and upper([季節年度])  = '{0}' ", 年度DDL.SelectedValue.ToUpper());
            if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
                strsql.AppendFormat(" and upper([季節])  = '{0}' ", 季節DDL.SelectedValue.ToUpper());
            if (!string.IsNullOrEmpty(款號TB.Text))
                strsql.AppendFormat(" and upper([Style])  like '%{0}%' ", 款號TB.Text.ToUpper());
            if (!string.IsNullOrEmpty(品牌TB.Text))
                strsql.AppendFormat(" and upper([品牌])  = '{0}' ", 品牌TB.Text.ToUpper());
            if (!string.IsNullOrEmpty(代理商TB.Text))
                strsql.AppendFormat(" and upper([代理商])  = '{0}' ", 代理商TB.Text.ToUpper());
            if(主料CB.Checked)
                strsql.Append(" and upper([主副料])  = 'M' ");
            if (入庫CB.Checked)
                strsql.Append(" and upper([採購單狀態])  = 'IN' ");
            if (!string.IsNullOrEmpty(供應商TB.Text))
                strsql.AppendFormat(" and (upper([供應商代號]) = '{0}' or upper(供應商名稱) = '{0}' )", 供應商TB.Text.ToUpper());
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
                bCheck = true;
            if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
                bCheck = true;
            if (!string.IsNullOrEmpty(款號TB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(品牌TB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(代理商TB.Text))
                bCheck = true;
            if (!string.IsNullOrEmpty(供應商TB.Text))
                bCheck = true;
            return bCheck;

        }
    }
}