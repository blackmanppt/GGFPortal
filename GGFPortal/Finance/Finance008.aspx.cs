using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance
{
    public partial class Finance008 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "出口大表";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            ((Label)Master.FindControl("BrandLB")).Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";

            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {

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
                ReportDataSource source = new ReportDataSource("出口大表", dt);
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
            string StrAgent = string.IsNullOrEmpty(AgentSearchTB.Text) ? "" : $" and 客戶 like '{AgentSearchTB.Text.Trim()}%'";
            StringBuilder strsql = new StringBuilder($@"SELECT [site]
                                      ,[shp_nbr]
                                      ,[開航日]
                                      ,[客戶]
                                      ,[S_O]
                                      ,[style_no]
                                      ,[PO_NUMBER]
                                      ,[vendor_name_brief]
                                      ,sum([出貨數量]) AS '出貨數量'
                                      ,[出貨單價]
                                      ,SUM([出貨金額]) AS  '出貨金額'
                                      ,[幣別]
                                      ,[匯率]
                                      ,[加減項]
                                ,[品牌]
                                  FROM [dbo].[ViewShpc]
                                where [開航日] between '{DateRangeTB.Text.Substring(0,8)}' and '{DateRangeTB.Text.Substring(11, 8)}' { StrAgent }
                                  GROUP BY
                                [site]
                                      ,[shp_nbr]
                                      ,[開航日]
                                      ,[客戶]
                                      ,[S_O]
                                      ,[style_no]
                                      ,[PO_NUMBER]
                                      ,[vendor_name_brief]
                                      ,[品牌]
                                      ,[出貨單價]
                                      ,[幣別]
                                      ,[匯率]
                                      ,[加減項]
                                order by [開航日]");
            return strsql;
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}