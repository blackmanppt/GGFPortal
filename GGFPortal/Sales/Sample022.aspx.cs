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
    public partial class Sample022 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "租借報表", StrProgram = "TempCode.aspx";
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
            //using (SqlConnection Conn = new SqlConnection(strConnectString))
            //{
            //    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql().ToString(), Conn);
            //    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            //}
            #region query 使用 In
            using (SqlConnection conn1 = new SqlConnection(strConnectString))
            {
                SqlCommand command1 = conn1.CreateCommand();
                SqlTransaction transaction1;
                conn1.Open();
                transaction1 = conn1.BeginTransaction("createExcelImport");
                try
                {
                    command1.Connection = conn1;
                    command1.Transaction = transaction1;

                    #region 查詢
                    string Str搜尋參數 = "sam_nbr",Str搜尋日期="";

                    //switch (StatusDDL.SelectedItem.Text)
                    //{
                    //    case "打版室借出":
                    //        Str搜尋日期 = "打版室借出時間";
                    //        break;
                    //    case "樣品室收到":
                    //        Str搜尋日期 = "樣品室收到時間";
                    //        break;
                    //    case "樣品室還回":
                    //        Str搜尋日期 = "樣品室還回時間";
                    //        break;
                    //    case "轉借TD":
                    //        Str搜尋日期 = "轉借TD時間";
                    //        break;
                    //    case "打版室收回":
                    //        Str搜尋日期 = "打版室收回時間";
                    //        break;

                    //    default:
                    //        break;
                    //}
                    string[] StrArrary = 字串處理.SplitEnter(MutiTB.Text);
                    string[] parameters = 字串處理.QueryParameter(MutiTB.Text, Str搜尋參數);
                    //string[] ParaFromDatatable = 
                    command1.CommandText = string.Format(@" select a.[sam_nbr],b.cus_style_no
                                      ,[SamCreateDate]
                                      ,[RentCreateDate]
                                      ,[RentModifyDate]
                                      ,[IsDelete]
                                      ,[IsClose]
                                      ,[借出狀態]
                                      ,[打版室借出時間]
                                      ,[樣品室收到時間]
                                      ,[樣品室還回時間]
                                      ,[轉借TD時間]
                                      ,[打版室收回時間]
                                      ,MappingData AS 狀態
                                  FROM [dbo].[GGFSampleRent] a left join samc_reqm b on a.sam_nbr=b.sam_nbr 
                                        LEFT  JOIN
                            dbo.Mapping AS d ON d.UsingDefine = 'GGFSampleRent' AND a.借出狀態 = d.Data
                                 where   convert(nvarchar(10),[RentCreateDate],120) between '{1}' and '{2}' {3} {0} "
                                , (string.IsNullOrEmpty(MutiTB.Text)) ? "" : string.Format(" and a.[sam_nbr] in ({0})", string.Join(",", parameters))
                                , DateRangeTB.Text.Substring(0, 10)
                                , DateRangeTB.Text.Substring(13, 10)
                                , (未歸還CB.Checked) ? " and IsDelete =0 and IsClose=0 and [打版室收回時間] is null " : "");
                    if(!string.IsNullOrEmpty(MutiTB.Text))
                        for (int i = 0; i < StrArrary.Length; i++)
                            command1.Parameters.AddWithValue(parameters[i], StrArrary[i]);
                    command1.ExecuteNonQuery();
                    SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
                    dt.Load(dr);
                    #endregion
                    //transaction1.Commit();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Error", StrProgram);
                    transaction1.Rollback();
                    throw;
                }
                finally
                {
                    conn1.Close();
                    transaction1.Dispose();
                }
            }
            #endregion

            if (dt.Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("View版套借出表", dt);
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

            StringBuilder strsql = new StringBuilder(" select * from [View採購單料號訂單資料] where 1=1 ");
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