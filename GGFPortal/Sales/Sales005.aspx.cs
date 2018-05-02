using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace GGFPortal.Sales
{

    public partial class Sales005 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartTB.Attributes["readonly"] = "readonly";
            //EndTB.Attributes["readonly"] = "readonly";
            DateTime dtNow = DateTime.Now;
            int icount = (dtNow.Year- 2017)*12+dtNow.Month;
            if (StartDDL.Items.Count == 0)
            {
                for (int i = 0; i < icount; i++)
                {
                    if (i == 0)
                    {
                        StartDDL.Items.Add("");
                    }
                    StartDDL.Items.Add(dtNow.AddMonths(-i).ToString("yyyyMM"));
                }
            }
            if (EndDDL.Items.Count == 0)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (i == 0)
                    {
                        EndDDL.Items.Add("");
                    }
                    EndDDL.Items.Add(dtNow.AddMonths(i).ToString("yyyyMM"));
                }
            }
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //StartTB.Text = "";
            //EndTB.Text = "";
            StartDDL.Text = "";
            EndDDL.Text = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
           MessageLT.Text = "";
           DbInit();
        }
        protected void DbInit()
        {
            bool chk = true;
            if(!string.IsNullOrEmpty( StartDDL.SelectedValue)&& !string.IsNullOrEmpty(EndDDL.SelectedValue))
            {
                if ( Convert.ToInt32( StartDDL.SelectedValue ) > Convert.ToInt32( EndDDL.SelectedValue))
                    chk = false;
            }
            if (chk)
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
                    ReportDataSource source = new ReportDataSource("營收統計", dt);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(source);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                {
                    MessageLT.Text = @"                            
                                    <div class='form-group'>
                                        <h3 class='text-info text-center'>沒有資料 </ h3 >
                                    </div>";
                    ReportViewer1.Visible = false;
                }
            }
            else
            {
                MessageLT.Text = @"                            
                                    <div class='form-group'>
                                        <h3 class='text-info text-center'> 起始日期大於結束日期 </ h3 >
                                    </div>";
                ReportViewer1.Visible = false;
            }
            
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(@" SELECT  * FROM [dbo].[View營收資料] ");
            strsql.AppendFormat(" where 交期年月 between '{0}' and '{1}' ", (!String.IsNullOrEmpty(StartDDL.SelectedValue))? StartDDL.SelectedValue : DateTime.Now.ToString("yyyyMM"), (!String.IsNullOrEmpty(EndDDL.SelectedValue)) ? EndDDL.SelectedValue : DateTime.Now.AddMonths(3).ToString("yyyyMM"));
            return strsql;
        }
        
    }
}