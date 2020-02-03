using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS
{
    public partial class MIS012 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "佣金比率上傳", StrProgram = "MIS012.aspx";
        
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
        protected void DbInit(string 查詢條件)
        {
            DataTable dt = new DataTable();
            //using (SqlConnection Conn = new SqlConnection(strConnectString))
            //{
            //    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
            //    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            //}
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
                //ReportViewer1.Visible = true;
                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportDataSource source = new ReportDataSource("採購單料號訂單資料", dt);
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(source);
                //ReportViewer1.DataBind();
                //ReportViewer1.LocalReport.Refresh();
            }
            else
                F_ErrorShow("搜尋不到資料");
        }

        private StringBuilder selectsql(string 查詢條件)
        {

            StringBuilder strsql = new StringBuilder();
            switch (查詢條件)
            {
                case "訂單資料查詢":
                    //strsql.Append()
                    break;
                default:
                    break;
            }
            //if (!string.IsNullOrEmpty(年度DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節年度])  = '{0}' ", 年度DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(季節DDL.SelectedValue))
            //    strsql.AppendFormat(" and upper([季節])  = '{0}' ", 季節DDL.SelectedValue.ToUpper());
            //if (!string.IsNullOrEmpty(款號TB.Text))
            //    strsql.AppendFormat(" and upper([Style])  like '%{0}%' ", 款號TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(品牌TB.Text))
            //    strsql.AppendFormat(" and upper([品牌])  = '{0}' ", 品牌TB.Text.ToUpper());
            //if (!string.IsNullOrEmpty(代理商TB.Text))
            //    strsql.AppendFormat(" and upper([代理商])  = '{0}' ", 代理商TB.Text.ToUpper());
            //if (主料CB.Checked)
            //    strsql.Append(" and upper([主副料])  = 'M' ");
            //if (入庫CB.Checked)
            //    strsql.Append(" and upper([採購單狀態])  = 'IN' ");
            return strsql;
        }
        public string SearchCheck()
        {
            string sCheck = "";
            if (!string.IsNullOrEmpty(MutiTB.Text))
                sCheck = "未填出貨單號";
            if (!string.IsNullOrEmpty(佣金TB.Text))
                sCheck = (string.IsNullOrEmpty(sCheck))?"未填出貨單號": sCheck + "<br/>未填出貨單號";
            return sCheck;

        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {

            Session.Remove("佣金比");
            Session.Remove("佣金比");
            string sCheck = SearchCheck();
            if (!string.IsNullOrEmpty(sCheck))
            {
                #region 查詢訂單佣金比率

                #endregion
            }
            else
            {
                F_ErrorShow(sCheck);
            }

        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}