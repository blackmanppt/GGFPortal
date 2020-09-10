using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Secretary
{
    public partial class Secretary009 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "產區產量總表";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            ((Label)Master.FindControl("BrandLB")).Text = StrPageName;
            Page.Title = StrPageName;
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";

            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DbInit()
        {
            DataTable dt = new DataTable(),dt2=new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                SqlDataAdapter myAdapter2 = new SqlDataAdapter(selectsql("明細").ToString(), Conn);
                myAdapter2.Fill(dt2);
            }
            #region query 使用 In
            //using (SqlConnection conn1 = new SqlConnection(strConnectString))
            //{
            //    SqlCommand command1 = conn1.CreateCommand();
            //    SqlTransaction transaction1;
            //    conn1.Open();
            //    transaction1 = conn1.BeginTransaction("createExcelImport");
            //    try
            //    {
            //        command1.Connection = conn1;
            //        command1.Transaction = transaction1;

            //        #region 查詢
            //        string Str搜尋參數 = "";
            //        string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
            //        string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
            //        //string[] ParaFromDatatable = 
            //        command1.CommandText = string.Format(@"SELECT d* from 
            //                     where {1} in ( {0} ) and a.site='GGF'
            //                     ", string.Join(",", parameters), Str搜尋參數);
            //        command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
            //        for (int i = 0; i < StrArrary.Length; i++)
            //            command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
            //        command1.ExecuteNonQuery();
            //        SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
            //        dt.Load(dr);
            //        #endregion
            //        //transaction1.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        Log.ErrorLog(ex, "Error", StrProgram);
            //        transaction1.Rollback();
            //        throw;
            //    }
            //    finally
            //    {
            //        conn1.Close();
            //        transaction1.Dispose();
            //    }
            //}
            #endregion

            if (dt.Rows.Count > 0&& dt2.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("訂單秒數", dt);
                ReportDataSource source2 = new ReportDataSource("訂單秒數明細", dt2);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Clear();
                if (預告單CB.Checked == true)
                {
                    ReportViewer1.LocalReport.ReportPath = @"ReportSource\Secretary\ReportSecretary009V3.rdlc";
                }
                else
                {
                    ReportViewer1.LocalReport.ReportPath = @"ReportSource\Secretary\ReportSecretary009V4.rdlc";
                }
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.LocalReport.DataSources.Add(source2);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql(string StrType="")
        {

            StringBuilder strsql = new StringBuilder();
            string strUnion = @" UNION ALL 
                                    SELECT 訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, 
                                    case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF', salesman, employee_name,OrderBy,'預告單' as '訂單種類' , 0 as 秒數   FROM ViewPreOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
                                                                       ";
            if (StrType=="明細")
            {
                strsql.AppendFormat(@"select left(訂單月份,4) 訂單年度,RIGHT(訂單月份,2)訂單月, * from (
                                                    SELECT 訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, 
                                                    case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF', salesman, employee_name,OrderBy, case when 訂單類別 = 'A' then '訂單' else '?' end as '訂單種類',實際IE as 秒數 FROM ViewOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
                                                    {2} ) a  where 訂單日期 between '{0}' and '{1}' ", DateRangeTB.Text.Substring(0, 8), DateRangeTB.Text.Substring(11, 8),(預告單CB.Checked==true)? strUnion:"");
            }
            else
            {
                strsql.AppendFormat(@"select left(訂單月份,4) 訂單年度,RIGHT(訂單月份,2)訂單月, * from (
                                                    SELECT 訂單號碼, 代理商代號, 代理商名稱, 客戶名稱, 訂單日期, 訂單月份, 工廠代號, 工廠名稱, 地區, 訂單數量, 
                                                    case when [代理商代號] ='MGF' then 'MGF' else cus_name_brief end  as 'ForMGF', salesman, employee_name,OrderBy,case when 訂單類別 = 'A' then '訂單' else '?' end as '訂單種類',實際IE*訂單數量 as 秒數  FROM ViewOrderQty   x left join bas_cus_master b on x.ForMGF=b.cus_id and b.site='GGF'
                                                    {2} ) a  where 訂單日期 between '{0}' and '{1}'   ", DateRangeTB.Text.Substring(0, 8), DateRangeTB.Text.Substring(11, 8), (預告單CB.Checked == true) ? strUnion : "");
            }
            //TimeSpan ts月份;
            //DateTime dt開始月份 = DateTime.Now, dt結束月份;
            //int i月數 = 6;

            //dt開始月份 = Convert.ToDateTime(DateRangeTB.Text.Substring(0, 10)) ;
            //dt結束月份 = Convert.ToDateTime(DateRangeTB.Text.Substring(13, 10));
            //ts月份 = dt結束月份 - dt開始月份;
            //i月數 = 12 * (dt結束月份.Year - dt開始月份.Year) + (dt結束月份.Month - dt開始月份.Month);

            ////新增月份自動填入
            //strsql.AppendFormat(@" union all
            //                        select '' 訂單年度,'' 訂單月,'' 訂單號碼,'' 代理商代號,'' 代理商名稱,'' 客戶名稱,'' 訂單日期,
            //                        LEFT( CONVERT(varchar(8), dateadd(M,rows-1,'{0}'),112),6) AS 訂單月份
            //                        ,'預設月份' 工廠代號,'預設月份' 工廠名稱,'' 地區,0 訂單數量
            //                        ,'預設月份' ForMGF,'' salesman,'' employee_name,'' OrderBy,'訂單' as '訂單種類'
            //                        from 
            //                            ( 
            //                            select id,row_number()over(order by id) rows  from sysobjects
            //                            )
            //                        Tmp where Tmp.rows <= {1}
            //                        ", dt開始月份.ToString("yyyy/MM/dd")
            //                    , i月數
            //                    );

            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    bCheck = true;
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    bCheck = true;
            return bCheck;

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}