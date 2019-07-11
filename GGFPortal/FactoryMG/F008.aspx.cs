using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;

namespace GGFPortal.FactoryMG
{

    public partial class F008 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //StartTB.Attributes["readonly"] = "readonly";
            //EndTB.Attributes["readonly"] = "readonly";
            if (YearDDL.Items.Count == 0)
            {
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (DateTime.Now.Year - 2017)*12+DateTime.Now.Month;


                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        YearDDL.Items.Add("");
                    }
                    YearDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                }
            }
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //YearDDL.SelectedValue = "";
            //MonthDDL.SelectedValue = "";
            //AreaDDL.SelectedValue = "";
            //StartTB.Text = "";
            //EndTB.Text = "";
            //for (int i = 0; i < DeptCBL.Items.Count; i++)
            //{
            //    DeptCBL.Items[i].Selected = false;
            //}
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
           MessageLT.Text = "";
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
                ReportDataSource source = new ReportDataSource("工時成本", dt);
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
            }
                

        }

        private StringBuilder selectsql()
        {
            string strAccount="";
            StringBuilder strsql = new StringBuilder();
            if (!string.IsNullOrEmpty( YearDDL.SelectedValue))
            {
                
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = @"select dbo.F_總工時(@SearchText , 'VGG' ) as Search ";
                        cmd.Parameters.AddWithValue("@SearchText", YearDDL.SelectedValue);
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                strAccount = sdr["Search"].ToString();
                            }
                        }
                        conn.Close();
                    }
                }
                strsql.AppendFormat(@" 
                                        select x.*,(投入工時/{0}) * b.Cost as 金額 from (
                                            SELECT 地區,
                                                left(工作時間,6) as 成本年月
                                                ,LEFT(工作時間,4) as 年
                                                ,SUBSTRING(工作時間  ,5,2) as 月
                                                ,sum([工時]*[實際工作人數]) as 投入工時,[dbo].[F_StyleFindOrd_nbr](款號)as 訂單號碼 ,sum([今日產量]) as 總數量
                                            FROM [dbo].[View工時資料]
                                            where Team ='Stitch'  and [地區] ='VGG' 
                                            and 工作時間 like '{1}%'
                                            group by 地區,left(工作時間,6),款號,LEFT(工作時間,4) 	  ,SUBSTRING(工作時間  ,5,2)
                                        ) x left join ProductivityCost b on x.地區=b.VendorId and  x.年= b.Year and x.月 = b.Month
                                         ", strAccount, YearDDL.SelectedValue);
            }
            return strsql;
        }
        
    }
}