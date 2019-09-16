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
    public partial class Sample015 : System.Web.UI.Page
    {
        字串處理 切字串 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        string StrPageName = "打樣完成日上傳", StrProgram =  "Sample015.aspx";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            BrandLB.Text = StrPageName;
            Page.Title = StrPageName;
            //DateRangeTB.Attributes["readonly"] = "readonly";
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DbInit()
        {
            DataTable dt = new DataTable(), dt2 = new DataTable();
            try
            {
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("CheckData").ToString(), Conn);
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                }
                #region query 使用 In
        //        using (SqlConnection conn1 = new SqlConnection(strConnectString))
        //        {
        //            SqlCommand command1 = conn1.CreateCommand();
        //            SqlTransaction transaction1;
        //            conn1.Open();
        //            transaction1 = conn1.BeginTransaction("createExcelImport");
        //            try
        //            {
        //                command1.Connection = conn1;
        //                command1.Transaction = transaction1;

        //                #region 匯入
        //                string[] parameters = SamArray.Select((s, i) => "@sam_nbr" + i.ToString()).ToArray();
        //                command1.CommandText = string.Format(@"SELECT          a.receipt_date AS 發版日期, 
        //                    b.cus_name AS 客戶名稱, a.cus_style_no AS 款號, 
        //                    a.sam_nbr AS 打樣單號, dbo.F_DateToNull(a.samc_fin_date) AS 打版完成日期, 
        //                    a.samc_remark60 AS 備註, a.plan_fin_date AS 預計完成日, 
        //                    a.online_date AS 上線日期, a.samc_plan_fin_date AS 打版預計完成日, 
        //                    a.plan_fin_date AS 預計完日, dbo.F_DateToNull(a.last_date) AS 需求日
        //                    ,dbo.F_DateToNull(a.samc_fin_date) 打版完成日
							 //from samc_reqm a left join bas_cus_master b on a.site=b.site and a.cus_id=b.cus_id
        //                     where sam_nbr in ( {0} ) and a.site='GGF'
        //                     ", string.Join(",", parameters));
        //                command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
        //                for (int i = 0; i < SamArray.Length; i++)
        //                    command1.Parameters.AddWithValue(parameters[i], SamArray[i]);
        //                //command1.Parameters.Add("@sam_nbr", SqlDbType.DateTime).Value = DateRangeTB.Text;
        //                command1.ExecuteNonQuery();
        //                SqlDataReader dr = command1.ExecuteReader(CommandBehavior.CloseConnection);
        //                dt.Load(dr);
        //                #endregion
        //                //transaction1.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                Log.ErrorLog(ex, "上傳失敗", StrProgram);
        //                transaction1.Rollback();
        //                throw;
        //            }
        //            finally
        //            {
        //                conn1.Close();
        //                transaction1.Dispose();
        //            }
        //        }
                #endregion
                if (dt.Rows.Count > 0)
                {
                    DataView dv = new DataView(dt);
                    dv.RowFilter = " 打樣單狀態 <> '有打樣單' or 打樣處理 <> '有資料'";
                    ErrorGV.DataSource = dv.ToTable();
                    ErrorGV.DataBind();
                    dv.RowFilter = String.Empty;
                    dv.RowFilter = " 打樣單狀態 = '有打樣單' and 打樣處理 = '有資料'";

                    dt2 = dv.ToTable();
                    if (dt2.Rows.Count>0)
                    {
                        if(UpDate(dt2))
                        {
                            using (SqlConnection Conn = new SqlConnection(strConnectString))
                            {
                                DataTable dt3 = new DataTable();
                                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("Search").ToString(), Conn);
                                myAdapter.Fill(dt3);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                                SamGV.DataSource = dt3;
                                SamGV.DataBind();
                            }

                        }
                    }
                    //TESTGV.DataBind();
                }
                else
                    F_ErrorShow("搜尋不到資料");
            }
            catch (Exception ex)
            {
                Log.ErrorLog(ex, "資料搜尋異常", StrProgram);
                F_ErrorShow("資料搜尋異常");
                throw;
            }

        }

        private StringBuilder selectsql(string SelectPam ="")
        {
            StringBuilder strsql = new StringBuilder();

            //Regex.Replace(被處理字串, @"[^\w\.@!]", "")

            switch (SelectPam)
            {
                case "Search":
                    strsql.Append(@" SELECT          a.receipt_date AS 發版日期, 
                            b.cus_name AS 客戶名稱, a.cus_style_no AS 款號, 
                            a.sam_nbr AS 打樣單號, dbo.F_DateToNull(a.samc_fin_date) AS 打版完成日期, 
                            a.samc_remark60 AS 備註, a.plan_fin_date AS 預計完成日, 
                            a.online_date AS 上線日期, a.samc_plan_fin_date AS 打版預計完成日, 
                            a.plan_fin_date AS 預計完日, a.last_date AS 需求日
                            ,dbo.F_DateToNull(a.samc_fin_date) 打版完成日
							 from samc_reqm a left join bas_cus_master b on a.site=b.site and a.cus_id=b.cus_id  ");
                    strsql.Append(" where a.samc_fin_date is not null and a.sam_nbr in " + 切字串.字串多筆資料搜尋(打樣單號TB.Text));
                    break;
                case "CheckData":
                    string strUnion = "";
                    if(SamArray.Length>0)
                        foreach (var item in SamArray)
                        {
                            strUnion += (strUnion.Length > 0)?
                                " union select '" + item.ToString() + "' as 'Search' ": strUnion = " select '" + item.ToString() + "' as 'Search' ";
                        }
                    strsql.AppendFormat(@" select distinct Search
                                            ,case when b.create_date is NULL then '打樣無資料' else '有打樣單' end as '打樣單狀態' 
                                            , case when c.sam_nbr  is NULL then '無資料' else '有資料' end as '打樣處理'  from ( {0} )
            							 a left join samc_reqm b on a.Search=b.sam_nbr left join GGFRequestSam c on a.Search=c.sam_nbr 
                                        ", strUnion);
                    //strsql.Append(" and a.sam_nbr in " + 切字串.字串多筆資料搜尋(打樣單號TB.Text));
                    break;

                default:
                    break;
            }

            return strsql;
        }
        public bool SearchCheck()
        {
            bool bCheck = false;
            return bCheck;

        }
        public string[] SamArray { get; set; }
        protected void UpDateBT_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(打樣單號TB.Text.Trim()))
            {
                string[] stringSeparators = new string[] { "\r\n" };
                SamArray = 打樣單號TB.Text.Trim().Split(stringSeparators, StringSplitOptions.None);
                //UpDate();
                DbInit();
            }
            else
                F_ErrorShow("未輸入上傳單號");
        }

        private bool UpDate(DataTable dt)
        {
            bool BCheck = true;
            using (SqlConnection conn1 = new SqlConnection(strConnectString))
            {
                SqlCommand command1 = conn1.CreateCommand();
                SqlTransaction transaction1;
                conn1.Open();
                transaction1 = conn1.BeginTransaction("Update_Samc_fin_date");
                try
                {
                    command1.Connection = conn1;
                    command1.Transaction = transaction1;

                    #region 匯入
                    string[] parameters = SamArray.Select((s, i) => "@sam_nbr" + i.ToString()).ToArray();
                    command1.CommandText = string.Format(@"UPDATE samc_reqm
                                                                    set samc_fin_date=@samc_fin_date
                                                               where sam_nbr in ( {0} ) and site='GGF'
                                                               ", string.Join(",", parameters));
                    command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = DateRangeTB.Text;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        command1.Parameters.AddWithValue(parameters[i], dt.Rows[i][""]);
                    //command1.Parameters.Add("@sam_nbr", SqlDbType.DateTime).Value = DateRangeTB.Text;
                    command1.ExecuteNonQuery();
                    #endregion
                    transaction1.Commit();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "上傳失敗", StrProgram);
                    transaction1.Rollback();
                    BCheck = false;
                    throw;
                }
                finally
                {
                    conn1.Close();
                    transaction1.Dispose();
                    
                }

            }
            return BCheck;
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            SamGV.DataSource = null;
            SamGV.DataBind();
            DateRangeTB.Text = DateTime.Now.ToString("yyyy-MM-dd");
            打樣單號TB.Text = "";
            SamArray = null;
        }

        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }
    }
}