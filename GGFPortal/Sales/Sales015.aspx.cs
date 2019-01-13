using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sales015 : System.Web.UI.Page
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
                string strerror = "";
                if (StartDayTB.Text.Length != 6 && !string.IsNullOrEmpty(StartDayTB.Text))
                    strerror += "\\n需求年月(起)日期格式錯誤";
                if (EndDayTB.Text.Length != 6 && !string.IsNullOrEmpty(EndDayTB.Text))
                    strerror = "\\n需求年月(迄)日期格式錯誤";
                F_ErrorShow("請輸入搜尋資料");
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
                ReportDataSource source = new ReportDataSource("訂單工廠樣品單", dt);
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
            
            StringBuilder strsql = new StringBuilder(" select * from [View訂單工廠樣品單] where 需求日 is not null ");
            if (!string.IsNullOrEmpty(this.工廠DDL.SelectedValue))
                strsql.AppendFormat(" and upper([工廠])  = '{0}' ", this.工廠DDL.SelectedValue.ToUpper());
            strsql.AppendFormat(" and upper([需求月份])  between '{0}' and '{1}' "
                , (!string.IsNullOrEmpty(StartDayTB.Text))? StartDayTB.Text:"201601"
                , (!string.IsNullOrEmpty(EndDayTB.Text)) ? EndDayTB.Text : "2999");
            if (!string.IsNullOrEmpty(this.種類DDL.SelectedValue))
                strsql.AppendFormat(" and upper([種類])  = '{0}' ", this.種類DDL.SelectedValue.ToUpper());
            if (!string.IsNullOrEmpty(this.品牌TB.Text))
                strsql.AppendFormat(" and upper([品牌])  = '{0}' ", this.品牌TB.Text.ToUpper());
            if (!string.IsNullOrEmpty(this.款號TB.Text))
                strsql.AppendFormat(" and upper([款號])  = '{0}' ", this.款號TB.Text.ToUpper());
            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = true;
            //if (!string.IsNullOrEmpty(工廠DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(種類DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    bCheck = true;
            if ((StartDayTB.Text.Length != 6 && !string.IsNullOrEmpty(StartDayTB.Text)) || (EndDayTB.Text.Length != 6 && !string.IsNullOrEmpty(EndDayTB.Text)))
            {
                bCheck = false;
            }
            return bCheck;

        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
    }
}