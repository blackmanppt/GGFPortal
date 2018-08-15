using GGFPortal.DataSetSource;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using GGFPortal.ReferenceCode;
namespace GGFPortal.TempCode
{

    public partial class TempExcelImport : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        SysLog Log = new SysLog();
        資料庫搜尋條件 addid = new 資料庫搜尋條件();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Today"]==null)
            {
                Session["Today"] = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            //Session["Today"] = StartDay.Text.Trim();
            //Session["Nbr"] = (!string.IsNullOrEmpty(提單TB.Text.Trim()))?提單TB.Text.Trim():"%";
            //Session["快遞商"] = (快遞廠商DDL.SelectedValue != "") ? 快遞廠商DDL.SelectedValue : "%";
            //確認GV.DataBind();
        }

        /// <summary>
        /// 確認資料正確性
        /// </summary>
        /// <param name="D_table"></param>
        /// <param name="D_errortable"></param>
        /// <param name="str頁簽名稱"></param>
        /// <param name="row"></param>
        private void F_資料確認(DataTable D_table, DataTable D_errortable, string str頁簽名稱, IRow row)
        {
            bool berror = false;
            StringBuilder sbError = new StringBuilder();
            string str閱卷序號 = "", str款號 = "", str組別 = "", str日期 = "";
            string strRegex工號 = "V[0-9]{4}", strRegex工段 = "[0-9]{3}", strRegex數量 = "[0-9]{4}";
            //string strRegex日期 = "\\b(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})\\b";

            if (!string.IsNullOrEmpty(row.GetCell(0).ToString()))
            {
                if (row.GetCell(0).ToString().ToUpper() == "NULL")
                {
                    berror = 錯誤訊息(sbError, "閱卷序號資料為NULL");
                }
                else
                {
                    str閱卷序號 = row.GetCell(0).ToString().ToUpper();
                    sbError.AppendFormat("閱卷序號：{0}", str閱卷序號);
                }
            }
            if (!string.IsNullOrEmpty(row.GetCell(1).ToString()))
            {
                if (row.GetCell(1).ToString().ToUpper() == "NULL")
                {
                    berror = 錯誤訊息(sbError, "款號資料為NULL");
                }
                else
                {
                    str款號 = row.GetCell(1).ToString().ToUpper();
                    using (SqlConnection conn = new SqlConnection(strConnectString))
                    {
                        //try
                        //{
                        //    SqlCommand command = new SqlCommand();
                        //    command.Connection = conn;
                        //    command.CommandText = @"SELECT top 1
                        //                        *
                        //                    FROM [dbo].[ordc_bah1]
                        //                    where [cus_item_no] = @cus_item_no";
                        //    command.CommandType = CommandType.Text;
                        //    command.Parameters.Add("@cus_item_no", SqlDbType.NVarChar).Value = str款號;
                        //    conn.Open();
                        //    SqlDataReader reader = command.ExecuteReader();

                        //    if (!reader.HasRows)
                        //    {
                        //        berror = 錯誤訊息(sbError, "無訂單款號資料");
                        //    }
                        //    reader.Close();
                        //}
                        //catch (Exception ex)
                        //{
                        //    berror = 錯誤訊息(sbError, "搜尋訂單款號資料異常"+ex.ToString());
                        //}
                    }
                }

            }
            else
                berror = 錯誤訊息(sbError, "沒有款號、");

            if (!string.IsNullOrEmpty(row.GetCell(2).ToString()))
            {
                if (row.GetCell(2).ToString().ToUpper() == "NULL")
                {
                    berror = 錯誤訊息(sbError, "組別資料為NULL");
                }
                else
                    str組別 = row.GetCell(2).ToString().ToUpper();
            }
            else
                berror = 錯誤訊息(sbError, "沒有組別、");

            for (int z = 3; z < 24; z = z + 7)
            {
                string str工號 = "";
                //工號V9999 工段99 數量9999

                bool b工號Error = false;
                if (!string.IsNullOrEmpty(row.GetCell(z).ToString()))
                {
                    str工號 = row.GetCell(z).ToString().Trim().ToUpper();
                    Regex reg = new Regex(strRegex工號);
                    b工號Error = (!reg.IsMatch(str工號) && str工號.Length != 5) ? true : false;
                }
                else
                    b工號Error = true;

                //檢查1~3工段數量
                for (int zz = 0; zz < 5; zz = zz + 2)
                {
                    string str工段 = "", str數量 = "", str工段轉換 = "";
                    bool b工段Error = false, b數量Error = false, b工段轉換Error = false;
                    DataRow D_dataRow = D_table.NewRow();
                    DataRow D_erroraRow = D_errortable.NewRow();
                    D_dataRow[0] = str頁簽名稱;
                    //D_dataRow[1] = SearchTB.Text;
                    if (!string.IsNullOrEmpty(row.GetCell(z + zz + 1).ToString()))
                    {
                        //永琦工段要三碼，補0
                        str工段 = "0" + row.GetCell(z + zz + 1).ToString();
                        Regex reg = new Regex(strRegex工段);
                        b工段Error = (!reg.IsMatch(str工段) || str工段.Length != 3) ? true : false;
                    }
                    else
                        b工段Error = true;
                    //工段轉換
                    if (!b工段Error && !berror)
                    {
                        using (SqlConnection conn = new SqlConnection(strConnectString))
                        {
                            try
                            {
                                SqlCommand command = new SqlCommand();
                                command.Connection = conn;
                                command.CommandText = @"SELECT top 1
                                                [STP_ID]
                                            FROM [dbo].[FILH01A]
                                            where rtrim(ltrim([SEQ_NO])) = @SEQ_NO and rtrim(ltrim([ORD_NO])) = @ORD_NO";
                                command.CommandType = CommandType.Text;
                                command.Parameters.Add("@SEQ_NO", SqlDbType.NVarChar).Value = str工段.Trim();
                                command.Parameters.Add("@ORD_NO", SqlDbType.NVarChar).Value = str款號.Trim();
                                conn.Open();
                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    str工段 = reader["STP_ID"].ToString();
                                }
                                else
                                {
                                    b工段轉換Error = true;
                                    str工段轉換 = "工段資料轉換失敗,沒有資料";
                                }
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                b工段轉換Error = true;
                                str工段轉換 = " 工段資料轉換失敗,沒有資料," + ex.ToString();
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(row.GetCell(z + zz + 2).ToString()))
                    {
                        str數量 = row.GetCell(z + zz + 2).ToString();
                        Regex reg = new Regex(strRegex數量);
                        b數量Error = (!reg.IsMatch(str數量) || str數量.Length != 4) ? true : false;
                    }
                    else
                        b數量Error = true;

                    //工段2，3沒資料跳過
                    if (str數量 == "" && str工段 == "" && zz > 0)
                        continue;
                    if (str數量 == "" && str工段 == "" && str工號 == "")
                        continue;

                    if (b工段Error || b數量Error || berror || b工號Error || b工段轉換Error)
                    {
                        if (b工號Error)
                            錯誤訊息(sbError, string.Format(" 工號錯誤：{0}", (str工號 == "") ? "沒有工號" : str工號));
                        if (b工段Error)
                            錯誤訊息(sbError, string.Format(" 工段錯誤：{0}", (str工段 == "") ? "沒有工段" : str工段));
                        if (b數量Error)
                            錯誤訊息(sbError, string.Format(" 數量錯誤：{0}", (str數量 == "") ? "數量為0" : str數量));
                        if (b工段轉換Error)
                            錯誤訊息(sbError, str工段轉換);
                        //str閱卷序號 = "", str款號 = "", str組別 = "", str日期 = "";
                        //D_erroraRow[0] = str頁簽名稱;
                        D_erroraRow[0] = str閱卷序號;
                        D_erroraRow[1] = str款號;
                        D_erroraRow[2] = str組別;
                        //D_erroraRow[3] = SearchTB.Text;
                        D_erroraRow[4] = str工號;
                        D_erroraRow[5] = "錯誤資料：" + sbError;
                        D_errortable.Rows.Add(D_erroraRow);
                    }
                    else
                    {
                        //D_dataRow[0] = str頁簽名稱;
                        D_dataRow[0] = str閱卷序號;
                        D_dataRow[1] = str款號;
                        D_dataRow[2] = str組別;
                        //D_dataRow[3] = SearchTB.Text;
                        D_dataRow[4] = str工號;
                        D_dataRow[5] = str工段;
                        D_dataRow[6] = str數量;
                        D_table.Rows.Add(D_dataRow);
                    }
                }
            }
        }
        /// <summary>
        /// 將Session的資料上船到資料庫
        /// </summary>
        public void F_UpLoad()
        {
            //if (SearchTB.Text.Trim() != "" && F_CheckData() && Session["ExcelError"] == null)
            if(Session["ExcelError"] == null)
            {
                if (Session["Excel"] != null)
                {
                    DataTable dt = (DataTable)Session["Excel"];
                    int iIndex = 0;
                    //取得塞入資料流水號(TableName,程式)
                    iIndex = addid.GetExcelIdex("AMZForcastHead","TempExcelImport.aspx");
                    if (iIndex > 0)
                        using (SqlConnection conn1 = new SqlConnection(strConnectString))
                        {
                            SqlCommand command1 = conn1.CreateCommand();
                            SqlTransaction transaction1;
                            conn1.Open();
                            transaction1 = conn1.BeginTransaction("createExcelImport");

                            command1.Connection = conn1;
                            command1.Transaction = transaction1;
                            try
                            {

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //string strInsertColumn="", strInsertData="";
                                    command1.CommandText = string.Format(@"INSERT INTO [dbo].[工段總表明細]
                                                      ([uid]
                                                      ,[閱卷序號]
                                                      ,[款號]
                                                      ,[組別]
                                                      ,[日期]
                                                      ,[工號]
                                                      ,[工段]
                                                      ,[數量])
                                                 VALUES
                                                       ({0}
                                                       ,@閱卷序號
                                                       ,@款號
                                                       ,@組別
                                                       ,@日期
                                                       ,@工號
                                                       ,@工段
                                                       ,@數量
                                                        )
                                                       ", iIndex);
                                    command1.Parameters.Add("@閱卷序號", SqlDbType.NVarChar).Value = dt.Rows[i]["閱卷序號"].ToString();
                                    command1.Parameters.Add("@款號", SqlDbType.NVarChar).Value = dt.Rows[i]["款號"].ToString();
                                    command1.Parameters.Add("@組別", SqlDbType.NVarChar).Value = dt.Rows[i]["組別"].ToString();
                                    command1.Parameters.Add("@日期", SqlDbType.NVarChar).Value = dt.Rows[i]["日期"].ToString();
                                    command1.Parameters.Add("@工號", SqlDbType.NVarChar).Value = dt.Rows[i]["工號"].ToString();
                                    command1.Parameters.Add("@工段", SqlDbType.NVarChar).Value = dt.Rows[i]["工段"].ToString();
                                    command1.Parameters.Add("@數量", SqlDbType.NVarChar).Value = dt.Rows[i]["數量"].ToString();

                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();
                                }
                                ////上傳成功更新Head狀態
                                //command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 1 ,[Date] = @Date WHERE uid = {0} ", iIndex);
                                //command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Session["Date"].ToString();
                                //command1.ExecuteNonQuery();
                                transaction1.Commit();
                            }
                            catch (Exception ex1)
                            {
                                try
                                {
                                    Log.ErrorLog(ex1, "Import Excel Error :" + Session["FileName"].ToString(), "VN002.aspx");
                                }
                                catch (Exception ex2)
                                {
                                    Log.ErrorLog(ex2, "Insert Error Error:" + Session["FileName"].ToString(), "VN002.aspx");
                                }
                                finally
                                {
                                    transaction1.Rollback();
                                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('匯入失敗請連絡MIS');</script>");
                                }
                            }
                            finally
                            {
                                conn1.Close();
                                conn1.Dispose();
                                command1.Dispose();
                                Session.RemoveAll();
                                //Label1.Text = "資料上傳成功";
                            }
                        }
                    else
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('單頭匯入失敗請連絡MIS');</script>");
                }
            }
            else
            {
                if (Session["ExcelError"] != null)
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請修正錯誤資料');</script>");
                //else if (SearchTB.Text.Trim() != "")
                //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('當日已有匯入資料');</script>");
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇匯入日期');</script>");
            }
        }
        /// <summary>
        /// 錯誤訊息紀錄
        /// </summary>
        /// <param name="sbError">錯誤字串</param>
        /// <param name="strerror">欲添加錯誤字串</param>
        /// <returns></returns>
        private static bool 錯誤訊息(StringBuilder sbError, string strerror)
        {
            bool berror = true;
            sbError.Append(strerror);
            return berror;
        }

    }
}