using GGFPortal.DataSetSource;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using GGFPortal.ReferenceCode;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Globalization;

namespace GGFPortal.Sales
{

    public partial class Sales011 : System.Web.UI.Page
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

            bool berror = false;
            DateTime dtStartDay = Convert.ToDateTime(StartDayTB.Text);
            DataRow D_dataRow = D_table.NewRow();
            //此匯入不驗證資料
            DataRow D_erroraRow = D_errortable.NewRow();

            D_dataRow[0] = (string.IsNullOrEmpty(row.GetCell(0).ToString())) ? null : row.GetCell(0).ToString();
            D_dataRow[1] = (string.IsNullOrEmpty(row.GetCell(1).ToString())) ? null : row.GetCell(1).ToString();
            D_dataRow[2] = (string.IsNullOrEmpty(row.GetCell(2).ToString())) ? null : row.GetCell(2).ToString();
            D_dataRow[3] = (string.IsNullOrEmpty(row.GetCell(3).ToString())) ? null : row.GetCell(3).ToString();
            D_dataRow[4] = (string.IsNullOrEmpty(row.GetCell(4).ToString())) ? null : row.GetCell(4).ToString();
            #region Week Forecast area
            D_dataRow[5] = (string.IsNullOrEmpty(row.GetCell(5).ToString())) ? null : row.GetCell(5).ToString();
            D_dataRow[6] = (string.IsNullOrEmpty(row.GetCell(6).ToString())) ? null : row.GetCell(6).ToString();
            D_dataRow[7] = (string.IsNullOrEmpty(row.GetCell(7).ToString())) ? null : row.GetCell(7).ToString();
            D_dataRow[8] = (string.IsNullOrEmpty(row.GetCell(8).ToString())) ? null : row.GetCell(8).ToString();
            D_dataRow[9] = (string.IsNullOrEmpty(row.GetCell(9).ToString())) ? null : row.GetCell(9).ToString();
            D_dataRow[10] = (string.IsNullOrEmpty(row.GetCell(10).ToString())) ? null : row.GetCell(10).ToString();
            D_dataRow[11] = (string.IsNullOrEmpty(row.GetCell(11).ToString())) ? null : row.GetCell(11).ToString();
            D_dataRow[12] = (string.IsNullOrEmpty(row.GetCell(12).ToString())) ? null : row.GetCell(12).ToString();
            D_dataRow[13] = (string.IsNullOrEmpty(row.GetCell(13).ToString())) ? null : row.GetCell(13).ToString();
            D_dataRow[14] = (string.IsNullOrEmpty(row.GetCell(14).ToString())) ? null : row.GetCell(14).ToString();
            D_dataRow[15] = (string.IsNullOrEmpty(row.GetCell(15).ToString())) ? null : row.GetCell(15).ToString();
            D_dataRow[16] = (string.IsNullOrEmpty(row.GetCell(16).ToString())) ? null : row.GetCell(16).ToString();
            D_dataRow[17] = (string.IsNullOrEmpty(row.GetCell(17).ToString())) ? null : row.GetCell(17).ToString();
            D_dataRow[18] = (string.IsNullOrEmpty(row.GetCell(18).ToString())) ? null : row.GetCell(18).ToString();
            D_dataRow[19] = (string.IsNullOrEmpty(row.GetCell(19).ToString())) ? null : row.GetCell(19).ToString();
            D_dataRow[20] = (string.IsNullOrEmpty(row.GetCell(20).ToString())) ? null : row.GetCell(20).ToString();
            D_dataRow[21] = (string.IsNullOrEmpty(row.GetCell(21).ToString())) ? null : row.GetCell(21).ToString();
            D_dataRow[22] = (string.IsNullOrEmpty(row.GetCell(22).ToString())) ? null : row.GetCell(22).ToString();
            D_dataRow[23] = (string.IsNullOrEmpty(row.GetCell(23).ToString())) ? null : row.GetCell(23).ToString();
            D_dataRow[24] = (string.IsNullOrEmpty(row.GetCell(24).ToString())) ? null : row.GetCell(24).ToString();
            D_dataRow[25] = (string.IsNullOrEmpty(row.GetCell(25).ToString())) ? null : row.GetCell(25).ToString();
            D_dataRow[26] = (string.IsNullOrEmpty(row.GetCell(26).ToString())) ? null : row.GetCell(26).ToString();
            D_dataRow[27] = (string.IsNullOrEmpty(row.GetCell(27).ToString())) ? null : row.GetCell(27).ToString();
            D_dataRow[28] = (string.IsNullOrEmpty(row.GetCell(28).ToString())) ? null : row.GetCell(28).ToString();
            D_dataRow[29] = (string.IsNullOrEmpty(row.GetCell(29).ToString())) ? null : row.GetCell(29).ToString();
            D_dataRow[30] = (string.IsNullOrEmpty(row.GetCell(30).ToString())) ? null : row.GetCell(30).ToString();


            #endregion

            //款號
            berror = (string.IsNullOrEmpty(row.GetCell(2).ToString())) ? true : false;
            錯誤訊息(sbError, string.Format("款號為{0}", (string.IsNullOrEmpty(row.GetCell(2).ToString())) ? "NULL" : row.GetCell(2).ToString()));

            if (string.IsNullOrEmpty(row.GetCell(0).ToString()))
            {
                berror = 錯誤訊息(sbError, "尺寸為NULL");
            }
            if (string.IsNullOrEmpty(row.GetCell(1).ToString()))
            {
                berror = 錯誤訊息(sbError, "顏色為NULL");
            }
            //str閱卷序號 = "", str款號 = "", str組別 = "", str日期 = "";
            //D_erroraRow[0] = str頁簽名稱;
            D_erroraRow[0] = sbError;
            if(berror)
                D_errortable.Rows.Add(D_erroraRow);
            D_table.Rows.Add(D_dataRow);
            #endregion
            
        }

        /// <summary>
        /// 將Session的資料上傳到資料庫
        /// </summary>
        public void F_UpLoad()
        {
            
            if (Session["Excel"] != null)
            {
                DataTable dt = (DataTable)Session["Excel"];
                int iIndex = 0;
                //取得塞入資料流水號(TableName,程式)


                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("createExcelImport");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    int testi=0, testj=0;
                    try
                    {
                        #region 匯入
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            testi = i;
                            DateTime dt匯入時間 = Convert.ToDateTime(StartDayTB.Text);
                            iIndex = addid.GetExcelIdex("AMZForcastHead", "TempExcelImport.aspx");
                            command1.CommandText = string.Format(@"INSERT INTO [dbo].[AMZForcastHead]
                                               ([uid]
                                               ,[款號]
                                               ,[顏色]
                                               ,[尺寸]
                                               ,[匯入起始日期]
                                               ,[匯入結束日期]
                                               ,[訂單單位]
                                               ,[可用庫存])
                                         VALUES
                                               ({0}
                                               ,@款號
                                               ,@顏色
                                               ,@尺寸
                                               ,@匯入起始日期
                                               ,@匯入結束日期
                                               ,@訂單單位
                                               ,@可用庫存)
                                               ", iIndex);
                            command1.Parameters.Add("@款號", SqlDbType.NVarChar).Value = dt.Rows[i]["款號"].ToString();
                            command1.Parameters.Add("@顏色", SqlDbType.NVarChar).Value = dt.Rows[i]["顏色"].ToString();
                            command1.Parameters.Add("@尺寸", SqlDbType.NVarChar).Value = dt.Rows[i]["尺寸"].ToString();
                            command1.Parameters.Add("@匯入起始日期", SqlDbType.VarChar).Value = dt匯入時間.ToString("yyyyMMdd");
                            command1.Parameters.Add("@匯入結束日期", SqlDbType.VarChar).Value = dt匯入時間.AddDays(7*26).ToString("yyyyMMdd");
                            command1.Parameters.Add("@訂單單位", SqlDbType.Int).Value = dt.Rows[i]["訂單單位"].ToString();
                            int i可用庫存量 = 0;
                            if (!string.IsNullOrEmpty(dt.Rows[i]["可用庫存"].ToString()))
                            {
                                int.TryParse(dt.Rows[i]["可用庫存"].ToString(),out i可用庫存量);
                            }
                            command1.Parameters.Add("@可用庫存", SqlDbType.Int).Value = i可用庫存量;
                            command1.ExecuteNonQuery();
                            command1.Parameters.Clear();
                            #region 匯入26週明細
                            
                            for (int j = 1; j < 27; j++)
                            {
                                testj = j;
                                int weekqty = 0;
                                if (!string.IsNullOrEmpty(dt.Rows[i]["Week" + (j).ToString()].ToString()))
                                {
                                    weekqty = Convert.ToInt16(dt.Rows[i]["Week" + (j).ToString()].ToString());
                                }
                                if(weekqty>0)
                                { 
                                    command1.CommandText = string.Format(@"INSERT INTO [dbo].[AMZForcastLine]
                                                           ([uid]
                                                           ,[日期]
                                                           ,[年度]
                                                           ,[周數]
                                                           ,[數量])
                                                     VALUES
                                                           ({0}
                                                           ,@日期
                                                           ,@年度
                                                           ,@周數
                                                           ,@數量)
                                                       ", iIndex);
                                    command1.Parameters.Add("@日期", SqlDbType.DateTime).Value = dt匯入時間.AddDays((j-1)*7);
                                    command1.Parameters.Add("@年度", SqlDbType.Int).Value = dt匯入時間.AddDays((j - 1) * 7).Year;
                                    command1.Parameters.Add("@周數", SqlDbType.Int).Value = GetWeekOfYear(dt匯入時間.AddDays((j - 1) * 7));
                                    //week1~~26

                                    command1.Parameters.Add("@數量", SqlDbType.Int).Value = weekqty;
                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();
                                }
                            }
                            #endregion
                        }

                        #endregion
                        //transaction1.Rollback();
                        transaction1.Commit();
                    }
                    #region 匯入ErrorLog
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Import Excel Error :" + Session["FileName"].ToString()+"testi="+testi.ToString() + ",testj="+testj.ToString(), "Sales011.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Insert Error Error:" + Session["FileName"].ToString(), "Sales011.aspx");
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
            if (!string.IsNullOrEmpty(文件上傳FU.FileName))
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
            //啟始周
            if (文件上傳FU.HasFile)
            {
                String fileName = 文件上傳FU.FileName;
                Session["FileName"] = fileName;
                savePath = savePath + fileName;
                文件上傳FU.SaveAs(savePath);
                string str頁簽名稱 = "";
                //--------------------------------------------------
                //---- （以上是）上傳 FileUpload的部分，成功運作！
                //--------------------------------------------------


                #region ErrorTable
                D_errortable.Columns.Add("Error");
                #endregion


                if (fileName.Substring(fileName.Length - 4, 4).ToUpper() == "XLSX")
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(文件上傳FU.FileContent);  //==只能讀取 System.IO.Stream

                    for (int x = 0; x < workbook.NumberOfSheets; x++)
                    {
                        XSSFSheet u_sheet = (XSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                        XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(0);  //-- Excel 表頭列
                        IRow DateRow = (IRow)u_sheet.GetRow(2);             //-- v.1.2.4版修改
                        str頁簽名稱 = u_sheet.SheetName.ToString();
                        string strtime = headerRow.GetCell(1).ToString();
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

        /// <summary>
        /// 資料鎖定驗證
        /// </summary>
        /// <returns></returns>
        private bool F_CheckData()
        {
            bool bcheck = false;
            string strRegex日期 = "\\b(?<year>\\d{4})-(?<month>\\d{2})-(?<day>\\d{2})\\b";
            string strstartday = StartDayTB.Text;
            Regex reg = new Regex(strRegex日期);
            if(!string.IsNullOrEmpty(strstartday))
                bcheck = (reg.IsMatch(strstartday)) ? true : false;
            if(!bcheck)
                F_ErrorShow("確認日期資料格式正確2018-01-01");
            DateTime dt;
            if (bcheck)
                try
                {
                    dt = Convert.ToDateTime(strstartday);
                }
                catch (Exception ex)
                {
                    bcheck = false;
                    F_ErrorShow("確認日期資料正確2018-01-01");
                }
            return bcheck;
        }

        protected void UpLoadBT_Click(object sender, EventArgs e)
        {

            if (F_CheckData())
            {
                F_UpLoad();
            }

            
        }

        /// <summary>
        /// 當年第幾周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetWeekOfYear(DateTime dt)
        {
            GregorianCalendar gc = new GregorianCalendar();
            return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
}