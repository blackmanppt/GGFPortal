using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Ship
{

    public partial class Ship002 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        字串處理 字串處理 = new 字串處理();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartDay.Attributes["readonly"] = "readonly";
            //訂單交期TB.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            //CusTB.Text = "";
            StyleTB.Text = "";
            //StartDay.Text = "";
            //EndDay.Text = "";
            //VendorDDL.SelectedValue = "";
            //訂單交期TB.Text = "";
            //款號TB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StyleTB.Text))
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
                ReportDataSource source = new ReportDataSource("客戶訂單轉Excel", dt);
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
            
            StringBuilder strsql = new StringBuilder(@" select [訂單號碼]
                                                            ,[訂單序號]
                                                            ,[客戶代號]
                                                            ,[品牌]
                                                            ,[出貨日期]
                                                            ,[款號]
                                                            ,[PO號碼]
                                                            ,[HTS]
                                                            ,[預計出貨總量]
                                                            ,sum([出貨數量]) as '出貨數量'
                                                            ,[單價]
                                                            ,[工繳]
                                                            ,[代工廠]
                                                            ,[客戶]
                                                        from [View客戶訂單轉Excel] where  ");
            strsql.AppendFormat("  款號  = '{0}'",StyleTB.Text.Trim());
            strsql.Append(@" group by [訂單號碼]
                                ,[訂單序號]
                                ,[客戶代號]
                                ,[品牌]
                                ,[出貨日期]
                                ,[款號]
                                ,[PO號碼]
                                ,[HTS]
                                ,[預計出貨總量]
                                ,[單價]
                                ,[工繳]
                                ,[代工廠]
                                ,[客戶]");

            return strsql;
        }
        
    }
}