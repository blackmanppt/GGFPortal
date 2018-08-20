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
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

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
            //if (Session["Today"]==null)
            //{
            //    Session["Today"] = DateTime.Now.ToString("yyyy-MM-dd");
            //}
        }


        /// <summary>
        /// 確認資料正確性
        /// </summary>
        /// <param name="D_table">正常資料</param>
        /// <param name="D_errortable">回傳Error</param>
        /// <param name="str頁簽名稱">Sheetname</param>
        /// <param name="row">列資料</param>
        private void F_資料確認(DataTable D_table, DataTable D_errortable, string str頁簽名稱, IRow row)
        {
            StringBuilder sbError = new StringBuilder();
            //Regex資料驗證規則
            //string strRegex工號 = "V[0-9]{4}", strRegex工段 = "[0-9]{3}", strRegex數量 = "[0-9]{4}";
            //string strRegex日期 = "\\b(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})\\b";
            #region old code驗證區

            //if (!string.IsNullOrEmpty(row.GetCell(0).ToString()))
            //{
            //    if (row.GetCell(0).ToString().ToUpper() == "NULL")
            //    {
            //        berror = 錯誤訊息(sbError, "閱卷序號資料為NULL");
            //    }
            //    else
            //    {
            //        str閱卷序號 = row.GetCell(0).ToString().ToUpper();
            //        sbError.AppendFormat("閱卷序號：{0}", str閱卷序號);
            //    }
            //}
            //if (!string.IsNullOrEmpty(row.GetCell(1).ToString()))
            //{
            //    if (row.GetCell(1).ToString().ToUpper() == "NULL")
            //    {
            //        berror = 錯誤訊息(sbError, "款號資料為NULL");
            //    }
            //    else
            //    {
            //        str款號 = row.GetCell(1).ToString().ToUpper();
            //        using (SqlConnection conn = new SqlConnection(strConnectString))
            //        {
            //            try
            //            {
            //                SqlCommand command = new SqlCommand();
            //                command.Connection = conn;
            //                command.CommandText = @"SELECT top 1
            //                                    *
            //                                FROM [dbo].[ordc_bah1]
            //                                where [cus_item_no] = @cus_item_no";
            //                command.CommandType = CommandType.Text;
            //                command.Parameters.Add("@cus_item_no", SqlDbType.NVarChar).Value = str款號;
            //                conn.Open();
            //                SqlDataReader reader = command.ExecuteReader();

            //                if (!reader.HasRows)
            //                {
            //                    berror = 錯誤訊息(sbError, "無訂單款號資料");
            //                }
            //                reader.Close();
            //            }
            //            catch (Exception ex)
            //            {
            //                berror = 錯誤訊息(sbError, "搜尋訂單款號資料異常" + ex.ToString());
            //            }
            //        }
            //    }

            //}
            //else
            //    berror = 錯誤訊息(sbError, "沒有款號、");

            //if (!string.IsNullOrEmpty(row.GetCell(2).ToString()))
            //{
            //    if (row.GetCell(2).ToString().ToUpper() == "NULL")
            //    {
            //        berror = 錯誤訊息(sbError, "組別資料為NULL");
            //    }
            //    else
            //        str組別 = row.GetCell(2).ToString().ToUpper();
            //}
            //else
            //    berror = 錯誤訊息(sbError, "沒有組別、");
            //
            #endregion
            //z為第幾行開始讀取資料
            for (int z = 3; z < 24; z = z + 7)
            {
                //string str工號 = "";
                ////工號V9999 工段99 數量9999

                #region regex用法
                //bool b工號Error = false;
                //if (!string.IsNullOrEmpty(row.GetCell(z).ToString()))
                //{
                //    str工號 = row.GetCell(z).ToString().Trim().ToUpper();
                //    Regex reg = new Regex(strRegex工號);
                //    b工號Error = (!reg.IsMatch(str工號) && str工號.Length != 5) ? true : false;
                //}
                //else
                //    b工號Error = true;
                #endregion
                #region 同列明細迴圈
                //檢查1~3工段數量
                for (int zz = 0; zz < 5; zz = zz + 2)
                {
                    //string str工段 = "", str數量 = "", str工段轉換 = "";
                    //bool b工段Error = false, b數量Error = false, b工段轉換Error = false;
                    //匯入資料
                    DataRow D_dataRow = D_table.NewRow();
                    //錯誤資料
                    DataRow D_erroraRow = D_errortable.NewRow();
                    D_dataRow[0] = str頁簽名稱;
                    ////D_dataRow[1] = SearchTB.Text;
                    //if (!string.IsNullOrEmpty(row.GetCell(z + zz + 1).ToString()))
                    //{
                    //    //永琦工段要三碼，補0
                    //    str工段 = "0" + row.GetCell(z + zz + 1).ToString();
                    //    Regex reg = new Regex(strRegex工段);
                    //    b工段Error = (!reg.IsMatch(str工段) || str工段.Length != 3) ? true : false;
                    //}
                    //else
                    //    b工段Error = true;
                    
                    
                   
                    #region 沒有資料跳過不塞明細

                    ////工段2，3沒資料跳過
                    //if (str數量 == "" && str工段 == "" && zz > 0)
                    //    continue;
                    //if (str數量 == "" && str工段 == "" && str工號 == "")
                    //    continue;
                    #endregion
                    #region 匯入資料或ErrorLog
                    //if (b工段Error || b數量Error || berror || b工號Error || b工段轉換Error)
                    if (true)
                    {
                        //if (b工號Error)
                        //    錯誤訊息(sbError, string.Format(" 工號錯誤：{0}", (str工號 == "") ? "沒有工號" : str工號));
                        //if (b工段Error)
                        //    錯誤訊息(sbError, string.Format(" 工段錯誤：{0}", (str工段 == "") ? "沒有工段" : str工段));
                        //if (b數量Error)
                        //    錯誤訊息(sbError, string.Format(" 數量錯誤：{0}", (str數量 == "") ? "數量為0" : str數量));
                        //if (b工段轉換Error)
                        //    錯誤訊息(sbError, str工段轉換);
                        ////str閱卷序號 = "", str款號 = "", str組別 = "", str日期 = "";
                        ////D_erroraRow[0] = str頁簽名稱;
                        //D_erroraRow[0] = str閱卷序號;
                        //D_erroraRow[1] = str款號;
                        //D_erroraRow[2] = str組別;
                        ////D_erroraRow[3] = SearchTB.Text;
                        //D_erroraRow[4] = str工號;
                        //D_erroraRow[5] = "錯誤資料：" + sbError;
                        //D_errortable.Rows.Add(D_erroraRow);
                    }
                    else
                    {
                        ////D_dataRow[0] = str頁簽名稱;
                        //D_dataRow[0] = str閱卷序號;
                        //D_dataRow[1] = str款號;
                        //D_dataRow[2] = str組別;
                        ////D_dataRow[3] = SearchTB.Text;
                        //D_dataRow[4] = str工號;
                        //D_dataRow[5] = str工段;
                        //D_dataRow[6] = str數量;
                        //D_table.Rows.Add(D_dataRow);
                    }
                    #endregion
                }
                #endregion
            }
        }

        /// <summary>
        /// 將Session的資料上傳到資料庫
        /// </summary>
        public void F_UpLoad()
        {
            //有錯誤資料不給匯入
            //if (SearchTB.Text.Trim() != "" && F_CheckData() && Session["ExcelError"] == null)
            if(Session["ExcelError"] == null)
            {
                if (Session["Excel"] != null)
                {
                    DataTable dt = (DataTable)Session["Excel"];
                    int iIndex = 0;
                    //取得塞入資料流水號(TableName,程式)
                    

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
                                #region 匯入單頭
                                //iIndex = addid.GetExcelIdex("AMZForcastHead", "TempExcelImport.aspx");
                                //command1.CommandText = string.Format(@"INSERT INTO [dbo].[工段總表明細]
                                //                      ([uid]
                                //                      ,[閱卷序號]
                                //                      ,[款號]
                                //                      ,[組別]
                                //                      ,[日期]
                                //                      ,[工號]
                                //                      ,[工段]
                                //                      ,[數量])
                                //                 VALUES
                                //                       ({0}
                                //                       ,@閱卷序號
                                //                       ,@款號
                                //                       ,@組別
                                //                       ,@日期
                                //                       ,@工號
                                //                       ,@工段
                                //                       ,@數量
                                //                        )
                                //                       ", iIndex);
                                //command1.Parameters.Add("@閱卷序號", SqlDbType.NVarChar).Value = dt.Rows[i]["閱卷序號"].ToString();
                                //command1.Parameters.Add("@款號", SqlDbType.NVarChar).Value = dt.Rows[i]["款號"].ToString();
                                //command1.Parameters.Add("@組別", SqlDbType.NVarChar).Value = dt.Rows[i]["組別"].ToString();
                                //command1.Parameters.Add("@日期", SqlDbType.NVarChar).Value = dt.Rows[i]["日期"].ToString();
                                //command1.Parameters.Add("@工號", SqlDbType.NVarChar).Value = dt.Rows[i]["工號"].ToString();
                                //command1.Parameters.Add("@工段", SqlDbType.NVarChar).Value = dt.Rows[i]["工段"].ToString();
                                //command1.Parameters.Add("@數量", SqlDbType.NVarChar).Value = dt.Rows[i]["數量"].ToString();

                                //command1.ExecuteNonQuery();
                                #endregion
                                #region 匯入明細
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    //command1.CommandText = string.Format(@"INSERT INTO [dbo].[工段總表明細]
                                    //                  ([uid]
                                    //                  ,[閱卷序號]
                                    //                  ,[款號]
                                    //                  ,[組別]
                                    //                  ,[日期]
                                    //                  ,[工號]
                                    //                  ,[工段]
                                    //                  ,[數量])
                                    //             VALUES
                                    //                   ({0}
                                    //                   ,@閱卷序號
                                    //                   ,@款號
                                    //                   ,@組別
                                    //                   ,@日期
                                    //                   ,@工號
                                    //                   ,@工段
                                    //                   ,@數量
                                    //                    )
                                    //                   ", iIndex);
                                    //command1.Parameters.Add("@閱卷序號", SqlDbType.NVarChar).Value = dt.Rows[i]["閱卷序號"].ToString();
                                    //command1.Parameters.Add("@款號", SqlDbType.NVarChar).Value = dt.Rows[i]["款號"].ToString();
                                    //command1.Parameters.Add("@組別", SqlDbType.NVarChar).Value = dt.Rows[i]["組別"].ToString();
                                    //command1.Parameters.Add("@日期", SqlDbType.NVarChar).Value = dt.Rows[i]["日期"].ToString();
                                    //command1.Parameters.Add("@工號", SqlDbType.NVarChar).Value = dt.Rows[i]["工號"].ToString();
                                    //command1.Parameters.Add("@工段", SqlDbType.NVarChar).Value = dt.Rows[i]["工段"].ToString();
                                    //command1.Parameters.Add("@數量", SqlDbType.NVarChar).Value = dt.Rows[i]["數量"].ToString();

                                    //command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();
                                }
                                ////上傳成功更新Head狀態
                                //command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 1 ,[Date] = @Date WHERE uid = {0} ", iIndex);
                                //command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Session["Date"].ToString();
                                //command1.ExecuteNonQuery();
                                #endregion
                                transaction1.Commit();
                            }
                            #region 匯入ErrorLog
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
                            #endregion
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

        /// <summary>
        /// 顯示匯入異常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void show3_Click(object sender, EventArgs e)
        {
            F_ErrorShow("");
        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        protected void DataCheckBT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(文件上傳FU.FileName))
                F_LoadExcel();
            else
                F_ErrorShow("未夾檔案");
        }
        public void F_LoadExcel()
        {
            //引用//ReferenceCode/ExcelColumn.cs的類別
            AMZForcast GetExcelDefine = new AMZForcast();
            //導入匯入table
            GetExcelDefine.ForcastDT();
            //上傳路徑
            String savePath = Server.MapPath(@"~\ExcelUpLoad\Sales\AMZForcast");

            DataTable D_table = new DataTable("Excel");
            //建立Excel欄位
            D_table = GetExcelDefine.ForcastDataTable.Copy();
            DataTable D_errortable = new DataTable("Error");
            //實際顯示欄位
            int Excel欄位數 = D_table.Columns.Count - 2;
            if (F_CheckData())
            {
                if (文件上傳FU.HasFile)
                {
                    String fileName = 文件上傳FU.FileName;
                    Session["FileName"] = fileName;
                    savePath = savePath + fileName;
                    文件上傳FU.SaveAs(savePath);
                    string str頁簽名稱 = "";
                    //Label1.Text = "Kiểm tra tệp tin dữ liệu thành công, tên tệp tin---- " + fileName;
                    //--------------------------------------------------
                    //---- （以上是）上傳 FileUpload的部分，成功運作！
                    //--------------------------------------------------

                    #region D_table
                    //D_table.Columns.Add("SheetName");
                    //D_table.Columns.Add("閱卷序號");
                    //D_table.Columns.Add("款號");
                    //D_table.Columns.Add("組別");
                    //D_table.Columns.Add("日期");
                    //D_table.Columns.Add("工號");
                    //D_table.Columns.Add("工段");
                    //D_table.Columns.Add("數量");

                    #endregion


                    #region ErrorTable
                    //                    D_errortable.Columns.Add("SheetName");
                    D_errortable.Columns.Add("款號");
                    //D_errortable.Columns.Add("尺寸");
                    //D_errortable.Columns.Add("顏色");
                    //D_errortable.Columns.Add("訂單數量");
                    //D_errortable.Columns.Add("可用庫存量");
                    D_errortable.Columns.Add("Error");
                    #endregion


                    if (fileName.Substring(fileName.Length - 4, 4).ToUpper() == "XLSX")
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(文件上傳FU.FileContent);  //==只能讀取 System.IO.Stream

                        for (int x = 0; x < workbook.NumberOfSheets; x++)
                        {
                            XSSFSheet u_sheet = (XSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                            XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(3);  //-- Excel 表頭列
                            IRow DateRow = (IRow)u_sheet.GetRow(2);             //-- v.1.2.4版修改
                            //Session["Date"] = SearchTB.Text;
                            str頁簽名稱 = u_sheet.SheetName.ToString();

                            //-- for迴圈的「啟始值」要加一，表示不包含 Excel表頭列
                            // for (int i = (u_sheet.FirstRowNum + 1); i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                            //i=1第二列開始
                            for (int i = 1; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);
                                F_資料確認(D_table, D_errortable, str頁簽名稱, row);
                            }
                            //-- 釋放 NPOI的資源
                            u_sheet = null;
                        }
                        //-- 釋放 NPOI的資源
                        workbook = null;
                        ////--Excel資料顯示             
                        //DataView D_View2 = new DataView(D_table);
                        //ExcelGV.DataSource = D_View2;
                        //ExcelGV.DataBind();


                        //--錯誤資料顯示
                        if (D_errortable.Rows.Count > 0)
                        {
                            DataView D_View3 = new DataView(D_errortable);
                            ErrorGV.DataSource = D_View3;
                            ErrorGV.DataBind();
                        }

                        //--------------------------------------------------
                        //---- （以下是）上傳 FileUpload的部分！
                        //--------------------------------------------------
                    }
                    else
                    {

                        HSSFWorkbook workbook = new HSSFWorkbook(文件上傳FU.FileContent);  //==只能讀取 System.IO.Stream
                        for (int x = 0; x < workbook.NumberOfSheets; x++)
                        {
                            HSSFSheet u_sheet = (HSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                            HSSFRow headerRow = (HSSFRow)u_sheet.GetRow(3);  //-- Excel 表頭列
                            IRow DateRow = (IRow)u_sheet.GetRow(2);             //-- v.1.2.4版修改
                            //Session["Date"] = SearchTB.Text;
                            str頁簽名稱 = u_sheet.SheetName.ToString();

                            for (int i = 1; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                            {

                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);
                                F_資料確認(D_table, D_errortable, str頁簽名稱, row);
                            }
                            //-- 釋放 NPOI的資源
                            u_sheet = null;
                        }
                        //-- 釋放 NPOI的資源
                        workbook = null;
                        ////--Excel資料顯示             
                        //DataView D_View2 = new DataView(D_table);
                        //ExcelGV.DataSource = D_View2;
                        //ExcelGV.DataBind();
                        //--錯誤資料顯示
                        if (D_errortable.Rows.Count > 0)
                        {
                            DataView D_View3 = new DataView(D_errortable);
                            ErrorGV.DataSource = D_View3;
                            ErrorGV.DataBind();
                        }

                        //--------------------------------------------------
                        //---- （以下是）上傳 FileUpload的部分！
                        //--------------------------------------------------

                    }
                }
                else
                {
                    F_ErrorShow("????  ...... 請先挑選檔案之後，再來上傳");
                }   // FileUpload使用的第一個 if判別式

                if (D_table.Rows.Count > 0)
                    Session["Excel"] = D_table;
                else
                {
                    Session["Excel"] = null;
                }

                if (D_errortable.Rows.Count > 0)
                    Session["ExcelError"] = D_errortable;
                else
                {
                    Session["ExcelError"] = null;
                    ErrorGV.DataSource = null;
                    ErrorGV.DataBind();
                }
            }
            else
            {
                //if (F_CheckData() == false)
                //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('當日已有匯入資料');</script>");
                //else
                //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇匯入日期');</script>");
            }
        }
        /// <summary>
        /// 資料鎖定驗證
        /// </summary>
        /// <returns></returns>
        private bool F_CheckData()
        {
            //bool bcheck = true;

            //using (SqlConnection conn = new SqlConnection(strConnectString1))
            //{
            //    SqlCommand command = new SqlCommand();
            //    command.Connection = conn;
            //    command.CommandText = @"SELECT top 1 [uid]
            //                                  ,[filename]
            //                                  ,[日期]
            //                                  ,[CREATEDATE]
            //                                  ,[MODIFYDATE]
            //                                  ,[IsDelete]
            //                                FROM [dbo].[工段總表單頭]
            //                                where [日期] = @Date and [IsDelete] = 0";
            //    command.CommandType = CommandType.Text;
            //    command.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SearchTB.Text;
            //    conn.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        bcheck = false;
            //    }
            //    reader.Close();
            //}
            return true;
        }
    }
}