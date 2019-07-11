using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.FactoryMG
{

    public partial class F011 : System.Web.UI.Page
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
                ReportDataSource source = new ReportDataSource("VNReport", dt);
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
            
            StringBuilder strsql = new StringBuilder(@"SELECT a.*,(a.[今日產量]/12)*a.[工繳收入] as 今日工繳收入,b.estimate_ie as 訂單工繳
                                                        FROM [dbo].[View工時資料]  a 
                                                        LEFT JOIN ordc_bah1 b on a.款號=b.cus_item_no and b.chn_turn_out='N' ");
            strsql.AppendFormat(" where [工作時間]  between '{0}' and '{1}'  and [地區] ='VGG' ", (!String.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text : "20000101", (!String.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : "29990101");
            if(!string.IsNullOrEmpty(StyleTB.Text))
                strsql.AppendFormat(" and [款號]  = '{0}'", StyleTB.Text);
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