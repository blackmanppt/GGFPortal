using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Ship
{

    public partial class Ship001 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        字串處理 字串處理 = new 字串處理();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            //CusTB.Text = "";
            StyleTB.Text = "";
            //StartDay.Text = "";
            供應商TB.Text = "";
            主料CB.Checked = true;
            副料CB.Checked = true;
            PurTB.Text = "";
            款號TB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {
            if(F_Check())
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
                    ReportDataSource source = new ReportDataSource("Ship001", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(source);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                    F_ErrorShow("搜尋不到資料");
            }
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(" select * from [View採購單] where 三角出 <>'Y' ");

            string 款號 ,採購單;
            採購單 = 字串處理.字串多筆資料搜尋(PurTB.Text).ToString();
            款號 = 字串處理.字串多筆資料搜尋(款號TB.Text).ToString();
            if (款號.Length > 0)
                strsql.AppendFormat(" and 款號 in {0} ", 款號);
            if (採購單.Length>0)
                strsql.AppendFormat(" and 採購單 in {0} ", 採購單);
            if (主料CB.Checked == false || 副料CB.Checked == false)
                strsql.AppendFormat(" and 主副料 = '{0}'", (主料CB.Checked == true) ? "M" : "S");
            if (!string.IsNullOrEmpty(供應商TB.Text))
                strsql.AppendFormat("and  (供應商簡稱 ='{0}' or  供應商代號 = '{0}')", 供應商TB.Text);
            if (!string.IsNullOrEmpty(StyleTB.Text))
                strsql.AppendFormat(" and 款號 = '{0}' ", StyleTB.Text);
            return strsql;
        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
        public bool F_Check()
        {
            bool bChk = true;
            string strError="";
            if (主料CB.Checked == false && 副料CB.Checked == false)
            { 
                strError = "主副料最少要選擇一項";
                bChk = false;
                
            }
            if(!bChk)
                F_ErrorShow(strError);
            return bChk;
        }
    }
}