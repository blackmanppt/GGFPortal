using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Finance
{

    public partial class Finance015 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            UploadDateTB.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {

            //StyleTB.Text = "";
            StartDay.Text = "";
            EndDay.Text = "";
            StyleTB.Text = "";
            UploadDateTB.Text = "";
            文件上傳CB.Checked = false;

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {


            if (搜尋確認())
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
                    ReportDataSource source = new ReportDataSource("文件日上傳", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(source);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
            }
        }

        private bool 搜尋確認()
        {
            bool bcheck=true;
            if (!string.IsNullOrEmpty(UploadDateTB.Text) && 文件上傳CB.Checked)
            {
                bcheck = false;
            }

            return bcheck;
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(@" SELECT [客戶代號]
                                                          ,[品牌]
                                                          ,[出貨單號]
                                                          ,[出貨日]
                                                          ,[款號]
                                                          ,[預計上傳日]
                                                          ,[實際上傳日]
                                                          ,[提前天數]
                                                          ,[預計收款日]
                                                          ,[出貨金額]
                                                      FROM [dbo].[View出貨單帳務對應天數] ");

            strsql.AppendFormat(" where [出貨日]  between '{0}' and '{1}' ", 
                (!String.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text : (!string.IsNullOrEmpty(StyleTB.Text)|| !string.IsNullOrEmpty(UploadDateTB.Text)) ?"2000-01-01":DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd"), 
                (!String.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : "2099-12-31");
            if(!string.IsNullOrEmpty(StyleTB.Text))
                strsql.AppendFormat(" and [款號]  = '{0}'", StyleTB.Text);
            
            if(文件上傳CB.Checked==true)
            {
                strsql.Append(" and [實際上傳日]  is null ");
            }
            else
            {
                if (!string.IsNullOrEmpty(UploadDateTB.Text))
                    strsql.AppendFormat(" and [實際上傳日]  = '{0}'", UploadDateTB.Text);
            }
            return strsql;
        }

        protected void 文件上傳CB_CheckedChanged(object sender, EventArgs e)
        {
            if(文件上傳CB.Checked==true)
            {
                UploadDateTB.Text = "";
            }
            
        }
    }
}