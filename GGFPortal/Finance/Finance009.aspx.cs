using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Finance
{
    public partial class Finance009 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {

            }
            else
            {
                Session["F001StartDay"] = DateTime.Now.ToString("yyyyMMdd");
                Session["F001EndDay"] = "29990101";
                Session["F001Site"] = "%";
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //int x = 1;
            //Session["F001StartDay"] = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "20000101";
            //Session["F001EndDay"] = (EndDay.Text.Length > 0) ? EndDay.Text : "29990101";
            //switch (SiteDDL.SelectedIndex)
            //{
            //    case 1:
            //        Session["F001Site"] = "GGF";
            //        break;
            //    case 2:
            //        Session["F001Site"] = "TCL";
            //        break;
            //    default:
            //        Session["F001Site"] = "%";
            //        break;

            //}
            //ReportViewer1.LocalReport.Refresh();
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
                ReportDataSource source = new ReportDataSource("Finance001", dt);
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
            strsql.AppendFormat(@"SELECT  site, shp_nbr, 開航日, 客戶, S_O, style_no, PO_NUMBER, vendor_name_brief, SUM(出貨數量) AS '出貨數量', 
出貨單價, SUM(出貨金額) AS '出貨金額', 幣別, 匯率, 加減項, 代理商, open_date, sum(外幣佣金) as '外幣佣金', sum(本幣佣金) as '本幣佣金'
FROM              ViewShpc
WHERE          (開航日 BETWEEN '{0}' AND '{1}') AND (site LIKE '{2}')
GROUP BY   site, shp_nbr, 開航日, 客戶, S_O, style_no, PO_NUMBER, vendor_name_brief, 出貨單價, 幣別, 匯率, 加減項, 代理商, 
                            open_date
ORDER BY   開航日, 客戶, vendor_name_brief "
                                    , (string.IsNullOrEmpty(StartDayTB.Text)) ? "2000-01-01" : StartDayTB.Text, (string.IsNullOrEmpty(EndDay.Text)) ? "2099-12-31" : EndDay.Text,(SiteDDL.SelectedValue=="全部")?"%": SiteDDL.SelectedValue);
            //if (!string.IsNullOrEmpty(提單TB.Text.Trim()))
            //{
            //    strsql.AppendFormat(" and UPPER(b.[提單號碼]) = '{0}'", 提單TB.Text.Trim().ToUpper());
            //}
            //if (快遞廠商DDL.SelectedValue != "")
            //{
            //    strsql.AppendFormat(" and UPPER(b.[快遞廠商]) = '{0}'", 快遞廠商DDL.SelectedValue);
            //}
            return strsql;
        }
    }
}