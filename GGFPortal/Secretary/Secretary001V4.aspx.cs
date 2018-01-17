using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace GGFPortal.Secretary
{
    public partial class Secretary001V4 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDay.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {
                if (StartDay.Text.Length > 0)
                {
                    EndDay_CalendarExtender.StartDate = Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2));
                }
                if (EndDay.Text.Length > 0)
                {
                    StartDay_CalendarExtender.EndDate = Convert.ToDateTime(EndDay.Text.Substring(0, 4) + "/" + EndDay.Text.Substring(4, 2) + "/" + EndDay.Text.Substring(6, 2));
                }
            }
            //else
            //{
            //    Sercetary001ObjectDataSource.SelectParameters["StartDay"].DefaultValue = DateTime.Now.AddMonths(-1).ToString("yyyyMM") + "01";
            //    Sercetary001ObjectDataSource.SelectParameters["EndDay"].DefaultValue = DateTime.Now.AddMonths(6).AddDays(-DateTime.Now.AddMonths(6).Day).ToString("yyyyMMdd");

            //}


        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //if (StartDay.Text.Length > 0 && EndDay.Text.Length > 0)
            //{
            //    ReportViewer1.LocalReport.Refresh();
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇起訖日期');</script>");
            //    //ReportViewer1.Visible = false;
            //}
            DBinit();

        }

        protected void Sercetary001ObjectDataSource_DataBinding(object sender, EventArgs e)
        {

        }
        public void DBinit()
        {
            StringBuilder sbstring = new StringBuilder(@"select left(訂單月份,4) 訂單年度,RIGHT(訂單月份,2)訂單月, * from (
                                                    SELECT 訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, 
                                                    ForMGF, salesman, employee_name,OrderBy FROM ViewOrderQty 
                                                    UNION ALL 
                                                    SELECT 訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, 
                                                    ForMGF, salesman, employee_name,OrderBy FROM ViewPreOrderQty 
                                                                        ) a ");
            StringBuilder sbstr1 = new StringBuilder(sbstring.ToString()), sbstr2= new StringBuilder(sbstring.ToString()), sbstr3 = new StringBuilder(sbstring.ToString());
            sbstr1.AppendFormat(" where 訂單日期 between '{0}' and '{1}'", (!string.IsNullOrEmpty(StartDay.Text)) ? StartDay.Text : DateTime.Now.ToString("yyyyMM") + "00", (!string.IsNullOrEmpty(EndDay.Text)) ? EndDay.Text : DateTime.Now.AddMonths(6).ToString("yyyyMM") + "00");
            //sbstr2.AppendFormat(" where 訂單日期 between '{0}' and '{1}'", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime( StartDay.Text.Substring(0,4)+"/"+ StartDay.Text.Substring(4, 2)+ "/" + StartDay.Text.Substring(6, 2)).AddMonths(-7).ToString("yyyyMMdd") : DateTime.Now.AddMonths(-7).ToString("yyyyMM") + "00", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddMonths(-1).ToString("yyyyMMdd") : DateTime.Now.AddMonths(-1).ToString("yyyyMM") + "00");
            sbstr2.AppendFormat(" where left(訂單日期,4) between '{0}' and '{1}'", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddYears(-1).ToString("yyyy") : DateTime.Now.AddYears(-1).ToString("yyyy"), (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddYears(1).ToString("yyyy") : DateTime.Now.AddYears(1).ToString("yyyy"));
            sbstr3.AppendFormat(" where 訂單日期 like '{0}' ", (!string.IsNullOrEmpty(StartDay.Text)) ? Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2)).AddYears(-1).ToString("yyyy")+"%" : DateTime.Now.AddYears(-1).ToString("yyyy") + "%");
            DataTable dt = new DataTable(), dt2 = new DataTable(), dt3 = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                TimeSpan ts月份;
                DateTime dt開始月份=DateTime.Now, dt結束月份;
                int i月數 = 6;
                if (!string.IsNullOrEmpty(StartDay.Text)&& !string.IsNullOrEmpty(EndDay.Text))
                {
                    dt開始月份 = Convert.ToDateTime(StartDay.Text.Substring(0, 4) + "/" + StartDay.Text.Substring(4, 2) + "/" + StartDay.Text.Substring(6, 2));
                    dt結束月份 = Convert.ToDateTime(EndDay.Text.Substring(0, 4) + "/" + EndDay.Text.Substring(4, 2) + "/" + EndDay.Text.Substring(6, 2));
                    ts月份 = dt結束月份 - dt開始月份;
                    i月數 = 12 * (dt結束月份.Year - dt開始月份.Year) + (dt結束月份.Month - dt開始月份.Month);
                }

                //新增月份自動填入
                sbstr1.AppendFormat(@" union all
                                    select '' 訂單年度,'' 訂單月,'' 訂單號碼,'' 代理商代號,'' 代理商名稱,'' 客戶名稱,'' 訂單日期,
                                    LEFT( CONVERT(varchar(8), dateadd(M,rows-1,'{0}'),112),6) AS 訂單月份
                                    ,'預設月份' 工廠代號,'預設月份' 工廠名稱,'' 地區,0 訂單數量
                                    ,'預設月份' ForMGF,'' salesman,'' employee_name,'' OrderBy
                                    from 
                                        ( 
                                        select id,row_number()over(order by id) rows  from sysobjects
                                        )
                                    Tmp where Tmp.rows <= {1}
                                    ",  dt開始月份.ToString("yyyy/MM/dd")
                                    , i月數
                                    );
                SqlDataAdapter myAdapter = new SqlDataAdapter(sbstr1.ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                
                SqlDataAdapter myAdapter2 = new SqlDataAdapter(sbstr2.ToString(), Conn);
                myAdapter2.Fill(dt2);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                SqlDataAdapter myAdapter3 = new SqlDataAdapter(sbstr3.ToString(), Conn);
                myAdapter3.Fill(dt3);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            }
            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("Sercretary001", dt);
                ReportDataSource source2 = new ReportDataSource("SercretaryOldOrder", dt2);
                ReportDataSource source3 = new ReportDataSource("SercretaryLastYearOrder", dt3);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.LocalReport.DataSources.Add(source2);
                ReportViewer1.LocalReport.DataSources.Add(source3);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
        }
    }
}