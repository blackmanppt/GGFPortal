using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sales006 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            CusTB.Text = "";
            //StyleTB.Text = "";
            StartDay.Text = "";
            EndDay.Text = "";
            VendorDDL.SelectedValue = "";
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
                ReportDataSource source = new ReportDataSource("業務出口資料", dt);
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
            
            StringBuilder strsql = new StringBuilder(" select[客戶] ,[工廠名稱], YEAR(open_date) as'出貨年', MONTH(open_date) as'出貨月份', sum([出貨金額]) as '出貨總金額',sum([出貨數量]) as '出貨總數量' from View出口大表 ");

            if ( !String.IsNullOrEmpty(CusTB.Text) || !String.IsNullOrEmpty(VendorDDL.SelectedValue) || !String.IsNullOrEmpty(StartDay.Text) || !String.IsNullOrEmpty(EndDay.Text))
            {
                strsql.Append(" where 1=1 ");
                //if (!String.IsNullOrEmpty(SiteDDL.SelectedValue))
                //    strsql.AppendFormat(" and [site]  = '{0}' ", SiteDDL.SelectedValue);
                if (!String.IsNullOrEmpty(CusTB.Text))
                    strsql.AppendFormat(" and [客戶]  = '{0}'",CusTB.Text);
                //if (!String.IsNullOrEmpty(StyleTB.Text))
                //    strsql.AppendFormat(" and [style_no]  = '{0}'", StyleTB.Text);
                if (!String.IsNullOrEmpty(VendorDDL.SelectedValue))
                    strsql.AppendFormat(" and [工廠代號]  = '{0}'", VendorDDL.SelectedValue);
                if (!String.IsNullOrEmpty(StartDay.Text) || !String.IsNullOrEmpty(EndDay.Text))
                {
                    strsql.AppendFormat(" and [開航日]  between '{0}' and '{1}' ", (!String.IsNullOrEmpty(StartDay.Text))? StartDay.Text:"20000101", (!String.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : "29990101");
                }
            }
            strsql.Append(@" group by [客戶] ,[工廠名稱], YEAR(open_date) , MONTH(open_date)  
                             order by [工廠名稱], YEAR(open_date) , MONTH(open_date) ");
            return strsql;
        }
        
    }
}