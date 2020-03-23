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

namespace GGFPortal.Sales
{
    public partial class Sales019 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "訂單DDP查詢";
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
            DataTable dt = new DataTable();
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
                myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

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

            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("View訂單明細表", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql()
        {

            StringBuilder strsql = new StringBuilder(@"SELECT  *,(select top 1 sale_price from ordc_material where ord_nbr=訂單號碼 and item_no like 'OH%') as 印花費
                                        FROM [dbo].[View訂單明細表]  ");
            strsql.AppendFormat(" where convert(varchar(10),出貨日期,120) between '{0}' and '{1}' and 交易條件 = 'DDP' and nation_no like 'VN%'",DateRangeTB.Text.Substring(0,10),DateRangeTB.Text.Substring(13,10));
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