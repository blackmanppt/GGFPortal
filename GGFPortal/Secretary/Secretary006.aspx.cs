using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Secretary
{

    public partial class Secretary006 : System.Web.UI.Page
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
            //StyleTB.Text = "";
            //StartDay.Text = "";
            //EndDay.Text = "";
            //VendorDDL.SelectedValue = "";
            //訂單交期TB.Text = "";
            //款號TB.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
                DbInit();

        }
        protected void DbInit()
        {
            if(DateDDL.SelectedValue.Length>0)
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
                    ReportDataSource source = new ReportDataSource("CubeOrderQty", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(source);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
            }
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(@" SELECT 訂單號碼,	代理商代號,	代理商名稱,	客戶名稱,	訂單日期
                                        ,	訂單月份,	工廠代號,	工廠名稱	,地區	,訂單數量,	ForMGF	,salesman
                                        ,	employee_name	,客戶月份	,地區分類
                                        FROM [GGFCubeDB].[dbo].[CubeOrderQty] where  ");
            strsql.AppendFormat("  id  like '{0}%'",DateDDL.SelectedValue);
            return strsql;
        }
        
    }
}