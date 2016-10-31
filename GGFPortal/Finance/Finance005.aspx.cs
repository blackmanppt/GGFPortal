using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GGFPortal.Finance
{
    public partial class Finance005 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AP1ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("AP1"))
                    Ds.Tables.Remove("AP1");
                string sqlstr = selectsql(), strSearch;
                strSearch = ACCTB.Text.Trim()+"%";
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.SelectCommand.Parameters.AddWithValue("Search", strSearch);
                //myAdapter.SelectCommand.Parameters.AddWithValue("Search1", strSearch);
                myAdapter.Fill(Ds, "AP1");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (Ds.Tables["AP1"].Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("Finance005", Ds.Tables["AP1"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
                //ACPGV.DataSource = Ds.Tables["ACP"];
                //ACPGV.DataBind();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
        }
        private void DbInit()
        {
            string sqlstr = selectsql();

            //this.SqlDataSource1.SelectCommand = sqlstr;
            //this.SqlDataSource1.DataBind();
            //ACPGV.DataBind();
        }
        private string selectsql()
        {
            string sqlstr = @"
                            select ACC_ID as '會計科目',case when DB_AMT is null then 0 else DB_AMT end as  '借方', case when CR_AMT is null then 0 else CR_AMT end as  '貸方',CODE as '用途',REMARK as '備註',ACC_NO as '傳票號碼' from [dbo].[SLIP]
                            where ACC_NO like'105%' and ACC_NO in ( select  ACC_NO from [dbo].[SLIP] where ACC_ID='1112') and ACC_NO like @Search
                            ";
            return sqlstr;
        }


        
    }

    
        
        
        
}
