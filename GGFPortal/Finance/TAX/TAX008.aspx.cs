using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using GGFPortal.DataSetSource;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;

namespace GGFPortal.Finance.TAX
{

    public partial class TAX008 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestGroupConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (YearDDL.Items.Count == 0)
            {
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (DateTime.Now.Year - 2015) * 12 + (DateTime.Now.Month - 12);
                string[] strMonth = new string[] { };
                List<string> sMonth = new List<string>();
                List<DateTime> dMonth = new List<DateTime>();
                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        YearDDL.Items.Add("");
                    }
                    YearDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                    sMonth.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                }
                GGFPortal.DataSetSource.TestGroupEntities xx = new TestGroupEntities();
                var value = (from x in xx.acr_trn
                             where x.acr_date != null
                             select  x.acr_date)
                            .Distinct().ToList()
                            
                            ;
                //List<string> lp = value.Select(date=>string.Format("yyyyMM",date));
                
                var value2 = from y in value
                             from z in sMonth
                             where  !y.ToString().Contains(z)
                             select y;

                List<string> strings = new List<string>() { "2014-01-14" };

                List<DateTime> dates = strings.Select(date => DateTime.Parse(date)).ToList();

            }
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected string convertdate(DateTime dt)
        {
            return dt.ToString("yyyyMM");
        }
        protected void ClearBT_Click(object sender, EventArgs e)
        {
            YearDDL.SelectedValue = "";
            //MonthDDL.SelectedValue = "";
            //AreaDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        protected void DbInit()
        {
            if ( String.IsNullOrEmpty(YearDDL.SelectedValue))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('未選擇年度');</script>");
            else
            {
                DataTable dt = new DataTable();
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter("select * from [ExportTaxRebate] where Flag =1 and RebateDate = @RebateDate ", Conn);
                    myAdapter.SelectCommand.Parameters.Add("@RebateDate",SqlDbType.NVarChar).Value=YearDDL.SelectedValue;
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                }
                if (dt.Rows.Count > 0)
                {
                    DeleteBT.Visible = true;
                    CloseBT.Visible = false;
                    //var x = from z in dt.AsEnumerable()
                    //        group z by z.Field<string>("") into g
                    //                             //where z.Field<DateTime>("OrderDate") > new DateTime(2001, 8, 1)
                    //                         select new
                    //                         {
                    //                             xx =g.Key,
                    //                         };
                    
                    using (SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        SqlDataAdapter myAdapter = new SqlDataAdapter("select * from [ExportTaxRebate] where Flag =1 and RebateDate = @RebateDate ", Conn);
                        myAdapter.SelectCommand.Parameters.Add("@RebateDate", SqlDbType.NVarChar).Value = YearDDL.SelectedValue;
                        myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                    }
                    MonthLB.Text = YearDDL.SelectedValue;
                    //StyleCountLB.Text = x.Count().ToString();
                     //= x.GroupBy(w=>w.Field<string>("")).ToList().Count<int>();
                    //ReportViewer1.Visible = true;
                    //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    //ReportDataSource source = new ReportDataSource("Sample006", dt);
                    //ReportViewer1.LocalReport.DataSources.Clear();
                    //ReportViewer1.LocalReport.DataSources.Add(source);
                    //ReportViewer1.DataBind();
                    //ReportViewer1.LocalReport.Refresh();

                }
                else
                {
                    DeleteBT.Visible = false;
                    CloseBT.Visible = true;

                }
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
            }
        }

        private StringBuilder selectsql()
        {
            
            StringBuilder strsql = new StringBuilder(" select * from [ExportTaxRebate] where Flag =1 and RebateDate = @RebateDate");
            return strsql;
        }

        protected void CloseBT_Click(object sender, EventArgs e)
        {

        }
        private int GetTaxIndex()
        {
            Int32 TAXId = 0;
            string sql =
                @"INSERT INTO [dbo].[ExportTaxRebate]
                           ([RebateDate])
                     VALUES
                           (@RebateDate); 
                    SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@RebateDate", SqlDbType.NVarChar);
                cmd.Parameters["@RebateDate"].Value = YearDDL.SelectedValue;
                try
                {
                    conn.Open();
                    TAXId = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Get ExportTaxRebate uid Error:", "TAX008.aspx");
                }
            }
            return (int)TAXId;
        }
    }
}