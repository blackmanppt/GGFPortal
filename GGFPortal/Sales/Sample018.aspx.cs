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

namespace GGFPortal.Sales
{
    public partial class Sample018 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "主副料到料日上傳", StrProgram = "Sample018.aspx";
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
            DataTable dt = new DataTable(), dt2 = new DataTable();
            ErrorGV.DataSource = null;
            ErrorGV.DataBind();
            SamGV.DataSource = null;
            SamGV.DataBind();
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
                    dv.RowFilter = " 打樣單狀態 = '無資料' or 打版完成日 = '無打版完成日'";
                    ErrorGV.DataSource = dv.ToTable();
                    ErrorGV.DataBind();
                    dv.RowFilter = String.Empty;
                    dv.RowFilter = " 打樣單狀態 = '有打樣單' and 打版完成日 <> '無打版完成日' ";

                    dt2 = dv.ToTable();
                    dv.RowFilter = String.Empty;
                    DataTable dt4 = new DataTable();
                    dv.RowFilter = "打版完成日 = '無打版完成日' and 打樣單狀態 = '有打樣單' ";
                    dt4 = dv.ToTable();
                    if (dt4.Rows.Count > 0)
                    {
                        SystemFunction systemFunction = new SystemFunction();
                        StringBuilder sb = new StringBuilder();
                        sb.Append(@"<h1><strong>樣品主副料到齊，未收到版套</strong></h1>
                                                <table style='width: 498px; height: 180px;' border='1'>
                                                <tbody>
                                                <tr style='height: 52px;'>
                                                <td style='width: 136px; height: 52px; text-align: center;'>
                                                <h1><strong>打樣單號</strong></h1>
                                                </td>
                                                <td style='width: 143px; height: 52px; text-align: center;'>
                                                <h1><strong>款號</strong></h1>
                                                </td>
                                                <td style='width: 130px; height: 52px;'>
                                                <h1 style='text-align: center;'><strong>客戶代號</strong></h1>
                                                </td>
                                                </tr>");
                        foreach (DataRow item in dt4.Rows)
                        {
                            sb.AppendFormat(@"<tr style='height: 53.4688px;'>
                                                        <td style='width: 136px; height: 53.4688px; text-align: center;'><strong>{0}</strong></td>
                                                        <td style='width: 143px; height: 53.4688px; text-align: center;'><strong>{1}</strong></td>
                                                        <td style='width: 130px; height: 53.4688px; text-align: center;'><strong>{2}</strong></td>
                                                        </tr>",item["打樣單號"].ToString(), item["款號"].ToString(), item["客戶代號"].ToString());
                        }
                        sb.Append("</tbody></ table > ");
                        systemFunction.SendMail("linda.shieh@greatg.com.tw;natalie.lu@greatg.com.tw;", "樣品主副料到期，未收到版套", sb.ToString());
                    }
                    if (dt2.Rows.Count > 0)
                    {
                        if (UpDate(dt2))
                        {
                            using (SqlConnection Conn = new SqlConnection(strConnectString))
                            {
                                DataTable dt3 = new DataTable();
                                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql("Search",dt2).ToString(), Conn);
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
                //throw;
            }
        }

        private StringBuilder selectsql(string SelectPam,DataTable dt=null)
        {
            StringBuilder strsql = new StringBuilder();

            //Regex.Replace(被處理字串, @"[^\w\.@!]", "")

            switch (SelectPam)
            {
                case "Search":
                    string[] parameters = dt.Rows.OfType<DataRow>().Select(p => "'" + p.Field<string>("打樣單號") + "'").ToArray() ;

                    strsql.Append(@" SELECT          convert(varchar(10),a.s_real_arrival_date,120) AS 主副料到料日, 
                            b.cus_name AS 客戶名稱, a.cus_style_no AS 款號, 
                            a.sam_nbr AS 打樣單號,
                            convert(varchar(10),dbo.F_DateToNull(a.samc_fin_date),120) 打版完成日, 
                            a.samc_remark60 AS 備註, 
                            convert(varchar(10),a.online_date,120) AS 上線日期, 
                            convert(varchar(10),a.plan_fin_date,120) AS 預計完日, convert(varchar(10),a.last_date,120) AS 需求日
                            
							 from samc_reqm a left join bas_cus_master b on a.site=b.site and a.cus_id=b.cus_id  ");
                    //strsql.Append(" where  a.sam_nbr in " + 字串處理.字串多筆資料搜尋(打樣單號TB.Text));
                    strsql.AppendFormat(" where  a.sam_nbr in ({0})" , string.Join(",", parameters));
                    break;
                case "CheckData":
                    string strUnion = "";
                    if (SamArray.Length > 0)
                        foreach (var item in SamArray)
                        {
                            strUnion += (strUnion.Length > 0) ?
                                " union select '" + item.ToString() + "' as '打樣單號' " : strUnion = " select '" + item.ToString() + "' as '打樣單號' ";
                        }
                    strsql.AppendFormat(@" select distinct b.cus_style_no as 款號,b.cus_id as 客戶代號, 打樣單號
                                            ,case when b.create_date is NULL then '打樣無資料' else '有打樣單' end as '打樣單狀態' 
                                            , case when c.sam_nbr  is NULL then '無資料' else '有資料' end as '打樣處理' ,case when dbo.F_DateToNull(b.samc_fin_date) is null then '無打版完成日' else convert(varchar(10),[samc_fin_date],120) end 打版完成日  from ( {0} )
            							 a left join samc_reqm b on a.打樣單號=b.sam_nbr left join GGFRequestSam c on a.打樣單號=c.sam_nbr 
                                        ", strUnion);
                    //strsql.Append(" and a.sam_nbr in " + 切字串.字串多筆資料搜尋(打樣單號TB.Text));
                    break;

                default:
                    break;
            }

            return strsql;
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
                transaction1 = conn1.BeginTransaction("Update_s_real_arrival_date");
                try
                {
                    command1.Connection = conn1;
                    command1.Transaction = transaction1;

                    #region 匯入
                    string[] parameters = dt.Rows.OfType<DataRow>().Select((s, i) => "@sam_nbr" + i.ToString()).ToArray();
                    //string[] parameters = SamArray.Select((s, i) => "@sam_nbr" + i.ToString()).ToArray();
                    command1.CommandText = string.Format(@"UPDATE samc_reqm
                                                                    set s_real_arrival_date=@s_real_arrival_date
                                                               where sam_nbr in ( {0} ) and site='GGF'
                                                               ", string.Join(",", parameters));
                    command1.Parameters.Add("@s_real_arrival_date", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd");
                    for (int i = 0; i < dt.Rows.Count; i++)
                        command1.Parameters.AddWithValue(parameters[i], dt.Rows[i]["打樣單號"]);
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
                    //throw;
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
            打樣單號TB.Text = "";
            SamArray = null;
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
    }
}