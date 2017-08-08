using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.VN
{

    public partial class VN013 : System.Web.UI.Page
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
            //CusTB.Text = "";
            StyleTB.Text = "";
            StartDay.Text = "";
            EndDay.Text = "";
            //VendorDDL.SelectedValue = "";
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
                ReportDataSource source = new ReportDataSource("VN013", dt);
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
            
            StringBuilder strsql = new StringBuilder(@"SELECT [款號],[部門],  sum([今日目標產量]) as 今日目標產量 ,sum([今日產量]) as 今日產量 ,sum([工時]*[實際工作人數]) as [總時數] 
                                                        FROM [dbo].[View工時資料]  a 
                                                         ");
            strsql.AppendFormat(" where [工作時間]  between '{0}' and '{1}'  and a.Team= 'Stitch' ", (!String.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text : "20000101", (!String.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : "29990101");
            if(!string.IsNullOrEmpty(StyleTB.Text))
                strsql.AppendFormat(" and [款號]  = '{0}'", StyleTB.Text);
            strsql.AppendFormat(" group by [款號],[部門]  ", StyleTB.Text);
            //if (!String.IsNullOrEmpty(SiteDDL.SelectedValue) || !String.IsNullOrEmpty(CusTB.Text) || !String.IsNullOrEmpty(StyleTB.Text) || !String.IsNullOrEmpty(VendorDDL.SelectedValue) || !String.IsNullOrEmpty(StartDay.Text) || !String.IsNullOrEmpty(EndDay.Text))
            //{
            //    strsql.Append(" where 1=1 ");
            //    if (!String.IsNullOrEmpty(SiteDDL.SelectedValue))
            //        strsql.AppendFormat(" and [site]  = '{0}' ", SiteDDL.SelectedValue);
            //    if (!String.IsNullOrEmpty(CusTB.Text))
            //        strsql.AppendFormat(" and [客戶]  = '{0}'",CusTB.Text);
            //    if (!String.IsNullOrEmpty(StyleTB.Text))
            //        strsql.AppendFormat(" and [style_no]  = '{0}'", StyleTB.Text);
            //    if (!String.IsNullOrEmpty(VendorDDL.SelectedValue))
            //        strsql.AppendFormat(" and [工廠代號]  = '{0}'", VendorDDL.SelectedValue);
            //    if (!String.IsNullOrEmpty(StartDay.Text) || !String.IsNullOrEmpty(EndDay.Text))
            //    {
            //        strsql.AppendFormat(" and [開航日]  between '{0}' and '{1}' ", (!String.IsNullOrEmpty(StartDay.Text))? StartDay.Text:"20000101", (!String.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : "29990101");
            //    }
            //}
            return strsql;
        }
        
    }
}