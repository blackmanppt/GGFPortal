using GGFPortal.DataSetSource;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Secretary
{

    public partial class Secretary008 : System.Web.UI.Page
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
            CusTB.Text = "";
            StyleTB.Text = "";
            StartDay.Text = "";
            EndDay.Text = "";
            VendorDDL.SelectedValue = "";

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
                ReportDataSource source = new ReportDataSource("訂單明細", dt);
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
            StringBuilder strsql = new StringBuilder(@"select * from [dbo].[View訂單明細表] where   1=1");
            strsql.AppendFormat(@" and 出貨日期 between '{0}' and '{1}'",(string.IsNullOrEmpty(StartDay.Text))?"2000-01-01":StartDay.Text, (string.IsNullOrEmpty(EndDay.Text)) ? "2099-01-01" : EndDay.Text);
            strsql.AppendFormat(@" and 客戶代號 like '{0}'",(string.IsNullOrEmpty(CusTB.Text))?"%":CusTB.Text);
            strsql.AppendFormat(@" and 款號 like '{0}'", (string.IsNullOrEmpty(StyleTB.Text)) ? "%" : StyleTB.Text);
            strsql.AppendFormat(@" and [代工廠] like '{0}' ", (string.IsNullOrEmpty(VendorDDL.SelectedValue)) ? "%" : VendorDDL.SelectedValue);

            return strsql;
        }
        
    }
}