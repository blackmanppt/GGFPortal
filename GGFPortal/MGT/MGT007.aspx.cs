using GGFPortal.DataSetSource;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace GGFPortal.MGT
{

    public partial class MGT007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //SiteDDL.SelectedValue = "";
            //CusTB.Text = "";
            提單TB.Text = "";
            StartDay.Text = "";
            EndDay.Text = "";
            快遞廠商DDL.SelectedValue = "";
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
                ReportDataSource source = new ReportDataSource("MGT007", dt);
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
            strsql.AppendFormat(@"SELECT b.提單號碼,b.提單日期,b.快遞廠商, case when b.送件地點='其他' then b.送件地點+'：' + b.地點備註 else b.送件地點 end as '送件地點'     ,[寄件人]
                                          ,[寄件人工號]
                                          ,[寄件人分機]
                                          ,[寄件人部門]
                                          ,[收件人]
                                          ,[客戶名稱]
                                          ,[明細]
                                          ,[重量]
                                          ,[責任歸屬]
                                          ,[付款方式]
                                          ,[備註二] as 備註
                                          ,送件部門
                                          ,原因歸屬
                                          ,[email]
                                          ,c.dept_name as 寄件人部門2
                                          ,[結案時間]
                                          ,[檢貨時間]
                                          ,case when a.[修改日期] is null then a.[建立日期] else a.[修改日期] end as 最後修改時間
                                          ,寄件地點
                                            ,[地點備註]
                                    FROM [dbo].[快遞單明細] a left join [快遞單] b on a.id=b.id  left join bas_dept c on c.site='GGF' and a.寄件人部門=c.dept_no
                                    where    b.IsDeleted = 0  and a.IsDeleted = 0 and  b.提單日期 between '{0}' and '{1}'"
                                    , (string.IsNullOrEmpty(StartDay.Text))?"2000-01-01": StartDay.Text, (string.IsNullOrEmpty(EndDay.Text)) ? "2099-12-31" : EndDay.Text);
            if (!string.IsNullOrEmpty(提單TB.Text.Trim()))
            {
                strsql.AppendFormat(" and UPPER(b.[提單號碼]) = '{0}'", 提單TB.Text.Trim().ToUpper());
            }
            if (快遞廠商DDL.SelectedValue!="")
            {
                strsql.AppendFormat(" and UPPER(b.[快遞廠商]) = '{0}'", 快遞廠商DDL.SelectedValue.ToUpper());
            }
            return strsql;
        }
        
    }
}