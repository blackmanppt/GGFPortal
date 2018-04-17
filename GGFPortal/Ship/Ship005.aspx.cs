using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Ship
{

    public partial class Ship005 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        字串處理 字串處理 = new 字串處理();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            //ETDStartDay.Attributes["readonly"] = "readonly";
            //ETDEndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {

            StartDay.Text = "";
            EndDay.Text = "";
            //ETDStartDay.Text = "";
            //ETDEndDay.Text = "";
            //顯示直送CB.Checked = false;
            //櫃號TB.Text = "";
            //款號TB.Text = "";

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            if (UserDDL.SelectedValue == "BOSS")
            { 
                sb.AppendFormat(@"SELECT          
                                    site, 
                                    shp_nbr, 
                                    開航日, 
                                    客戶, 
                                    style_no, 
                                    PO_NUMBER, 
                                    工廠名稱, 
                                    SUM(出貨數量) AS '出貨數量', 
                                    出貨單價, 
                                    SUM(出貨金額) AS '出貨金額', 
                                    open_date
                                FROM              ViewShips
                                WHERE  (開航日 BETWEEN '{0}' AND '{1}') AND (site LIKE '{2}')
                                GROUP BY   site, shp_nbr, 開航日, 客戶, style_no, PO_NUMBER, 工廠名稱, 出貨單價, open_date
                                ORDER BY   開航日, 客戶, 工廠名稱"
                                , (string.IsNullOrEmpty(StartDay.Text))?DateTime.Now.ToString("yyyyMMdd"):StartDay.Text
                                , (string.IsNullOrEmpty(EndDay.Text)) ? DateTime.Now.AddMonths(1).ToString("yyyyMMdd") : EndDay.Text
                                , (SiteDDL.SelectedValue=="")?"%":SiteDDL.SelectedValue);
            }
            else
            {
                sb.AppendFormat(@"SELECT          
                                    site, 
                                    開航日, 
                                    客戶, 
                                    style_no, 
                                    工廠名稱, 
                                    出貨單價, 
                                    open_date
                                FROM              ViewShips
                                WHERE  (開航日 BETWEEN '{0}' AND '{1}') AND (site LIKE '{2}')
                                GROUP BY   site, 開航日, 客戶, style_no,  工廠名稱, 出貨單價, open_date
                                ORDER BY   開航日, 客戶, 工廠名稱"
                , (string.IsNullOrEmpty(StartDay.Text)) ? DateTime.Now.ToString("yyyyMMdd") : StartDay.Text
                , (string.IsNullOrEmpty(EndDay.Text)) ? DateTime.Now.AddMonths(1).ToString("yyyyMMdd") : EndDay.Text
                , (SiteDDL.SelectedValue == "") ? "%" : SiteDDL.SelectedValue);
            }

            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(sb.ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                ReportDataSource source = new ReportDataSource("Ship005", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                if (UserDDL.SelectedValue == "BOSS")
                {
                    ReportViewer1.LocalReport.ReportPath = @"ReportSource\Ship\ReportShip005BOSS.rdlc";
                }
                else
                {
                    ReportViewer1.LocalReport.ReportPath = @"ReportSource\Ship\ReportShip005.rdlc";
                }
                ReportViewer1.LocalReport.DisplayName = "出口大表";
                ReportViewer1.LocalReport.DataSources.Add(source);

                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");


        }
        

     

       
    }
}