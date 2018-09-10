using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sales012 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //品牌TB.Text = "";
            款號TB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (SearchCheck())
            {
                DbInit();
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
                ReportDataSource source = new ReportDataSource("AMZForecast", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(" select a.*,b.日期,b.年度,b.周數,b.數量 from AMZForcastHead a left join AMZForcastLine b on a.uid=b.uid where a.IsDelete=0 and b.IsDelete=0 ");
            if(true)
            {
                string str開始日期 = "", str結束日期 = "";
                str開始日期 = (!string.IsNullOrEmpty(開始年度TB.Text) && !string.IsNullOrEmpty(開始年度周數TB.Text)) 
                    ? Convert.ToDateTime(開始年度TB.Text + "-01-01").AddDays(7 * Convert.ToInt16(開始年度周數TB.Text)).ToString("yyyy-MM-dd") 
                    : (!string.IsNullOrEmpty(開始年度TB.Text)&&string.IsNullOrEmpty(開始年度周數TB.Text))?
                        開始年度TB.Text+"-01-01" 
                        :"2000-01-01";
                str結束日期 = (!string.IsNullOrEmpty(結束年度TB.Text) && !string.IsNullOrEmpty(結束年度周數TB.Text))
                    ? Convert.ToDateTime(結束年度TB.Text + "-01-01").AddDays(7 * Convert.ToInt16(結束年度周數TB.Text)).ToString("yyyy-MM-dd")
                    : (!string.IsNullOrEmpty(結束年度TB.Text) && string.IsNullOrEmpty(結束年度周數TB.Text)) ?
                        結束年度TB.Text + "-12-31"
                        : "2099-12-31";
                strsql.AppendFormat(" and b.日期 between '{0}' and '{1}' ", str開始日期, str結束日期 );
                //計算函式 F計算 = new 計算函式();
                //int x = F計算.當年第幾週(dt);
                //if (!string.IsNullOrEmpty(開始年度周數TB.Text))
                //    x = F計算.當年第幾週(dt.AddDays(7 * Convert.ToInt16(開始年度周數TB.Text)));
            }
            if (!string.IsNullOrEmpty(款號TB.Text))
                strsql.AppendFormat(" and upper([款號])  like '%{0}%' ", 款號TB.Text.ToUpper());
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = true;
            string strError = "";
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    bCheck = true;
            if((!string.IsNullOrEmpty(開始年度TB.Text)&& string.IsNullOrEmpty(開始年度周數TB.Text))||(string.IsNullOrEmpty(開始年度TB.Text) && !string.IsNullOrEmpty(開始年度周數TB.Text)))
            {
                if(strError.Length>0)
                    strError += ",";
                strError += "年周都要填寫";
            }
            if(strError.Length>0)
            {
                F_ErrorShow(strError+"。");
                bCheck = false;
            }
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            dt = Convert.ToDateTime(開始年度TB.Text + "-01-01");
            計算函式 F計算 = new 計算函式();
            int x = F計算.當年第幾週(dt);
            int y = 0;
            if (!string.IsNullOrEmpty(開始年度周數TB.Text))
                x = F計算.當年第幾週(dt.AddDays(7 * Convert.ToInt16(開始年度周數TB.Text)));
            F_ErrorShow(dt.AddDays(7 * Convert.ToInt16(開始年度周數TB.Text)).ToString("yyyyMMdd"));
        }
    }
}