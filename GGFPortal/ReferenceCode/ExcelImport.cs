using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace GGFPortal.ReferenceCode
{
    public class ExcelImport
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        static 多語 lang = new 多語();


        static DataCheck datacheck = new DataCheck();
        /// <summary>
        /// 系統地區
        /// </summary>
        public string StrArea { get; set; }
        /// <summary>
        /// 資料路徑
        /// </summary>
        public string Strfile { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string StrErrorShow { get; set; }
        public DataSet Ds { get; set; }
        public string Str副檔名 { get; set; }
        /// <summary>
        /// XLSX定義
        /// </summary>
        public XSSFWorkbook XSSworkbook { get; set; }
        /// <summary>
        /// XLS定義
        /// </summary>
        public HSSFWorkbook HSSworkbook { get; set; }
        public DataTable DTDefine { get; set; }
        /// <summary>
        /// 正確資料可匯入DT
        /// </summary>
        public DataTable DTImportData { get; set; }
        /// <summary>
        /// Excel錯誤資料DT
        /// </summary>
        public DataTable DTError { get; set; }

        public string Str匯入頁簽 { get; set; }

        public class UpDateStatus
        {
            public bool bCheck { get; set; }
            /// <summary>
            /// 資料錯誤的訊息
            /// </summary>
            public String StrErrorData { get; set; }
        }
        /// <summary>
        /// Excel讀取
        /// </summary>
        /// <param name="upload_file"></param>
        /// <param name="Str儲存路徑"></param>
        /// <param name="LsUpLoad"></param>
        protected void F_ExcelLoad(System.Web.UI.HtmlControls.HtmlInputFile upload_file,string Str儲存路徑,List<string> LsUpLoad)
        {
            
            string fileName = Path.GetFileName(upload_file.PostedFile.FileName);

            string LocationFiled = HttpContext.Current.Server.MapPath(Str儲存路徑);

            string Str副檔名 = Path.GetExtension(fileName).ToUpper();
            while (File.Exists(LocationFiled + fileName))
            {
                fileName = fileName.Substring(0, fileName.Length - Str副檔名.Length) + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Str副檔名;
            }
            upload_file.PostedFile.SaveAs(LocationFiled + fileName);

            if (Str副檔名==".XLSX")
            {
                XSSworkbook = new XSSFWorkbook(upload_file.PostedFile.InputStream);
            }
            else
            {
                HSSworkbook = new HSSFWorkbook(upload_file.PostedFile.InputStream);
            }

        }
        /// <summary>
        /// 資料確認
        /// </summary>
        /// <param name="Str匯入資料Table">匯入資料表名稱</param>
        public void F_LoadData(string Str匯入資料Table)
        {
            if(XSSworkbook != null|| HSSworkbook!=null)
            {
                //string str頁簽名稱 = "";
                //int ISheetCheck = 0;//確認Sheet 資料是否正確，每份Sheet只會有一個對應
                try
                {
                    DTDefine = GetDBData("GetDefine", Str匯入資料Table);

                   //指定Import Sheet Name
                    string StrSheetNameCheck = "";
                    Boolean BCheck = false;
                    int I資料起始欄, I資料起始列;

                    DTError.Columns.Add("Error");

                    foreach (DataRow Dr in DTDefine.Rows)
                    {
                        if(Dr["IsUsing"].ToString()=="1")
                            DTImportData.Columns.Add(Dr["欄位名稱"].ToString());
                    }

                    if (DTImportData.Rows.Count > 0)
                    {
                        StrSheetNameCheck = (string.IsNullOrEmpty(DTImportData.Rows[0]["指定頁籤名稱"].ToString())) ? "" : DTImportData.Rows[0]["指定頁籤名稱"].ToString();

                        if (!bool.TryParse(DTImportData.Rows[0]["是否指定頁籤"].ToString(), out BCheck))
                        {
                            BCheck = false;
                        }

                        if (!int.TryParse(DTImportData.Rows[0]["資料起始列"].ToString(), out I資料起始列))
                        {
                            I資料起始列 = 1;
                        }

                        if (!int.TryParse(DTImportData.Rows[0]["資料起始欄"].ToString(), out I資料起始欄))
                        {
                            I資料起始欄 = 0;
                        }

                        if (Str副檔名.ToUpper() == ".XLSX")
                        {
                            for (int x = 0; x < XSSworkbook.NumberOfSheets; x++)
                            {
                                //-- 0表示：第一個 worksheet工作表
                                XSSFSheet u_sheet = (XSSFSheet)XSSworkbook.GetSheetAt(x);
                                Str匯入頁簽 = u_sheet.SheetName.ToString();

                                //檢查是否有要對應資料
                                if (BCheck && StrSheetNameCheck != Str匯入頁簽)
                                {
                                    continue;
                                }
                                //else
                                //{
                                //    ISheetCheck = +1;
                                //}
                                //-- Excel 表頭列
                                XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(I資料起始列);
                                IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);

                                for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    F_資料確認( row, i, I資料起始欄);
                                }
                                //-- 釋放 NPOI的資源
                                u_sheet = null;
                            }
                        }
                        else
                        {
                            for (int x = 0; x < HSSworkbook.NumberOfSheets; x++)
                            {
                                HSSFSheet u_sheet = (HSSFSheet)HSSworkbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                                HSSFRow headerRow = (HSSFRow)u_sheet.GetRow(I資料起始列);  //-- Excel 表頭列
                                IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);             //-- v.1.2.4版修改
                                                                                         //檢查是否有要對應資料
                                if (BCheck && StrSheetNameCheck != Str匯入頁簽)
                                {
                                    continue;
                                }
                                //else
                                //{
                                //    ISheetCheck = +1;
                                //}
                                Str匯入頁簽 = u_sheet.SheetName.ToString();
                                for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    F_資料確認(  row, i, I資料起始欄);
                                }
                                //-- 釋放 NPOI的資源
                                u_sheet = null;
                            }
                        }
                        //--錯誤資料顯示
                        DataView D_View3 = new DataView(DTError);

                        if (DTError.Rows.Count > 0)
                        {

                            //if (str頁簽名稱 == "AMZCapacity")
                            //{
                            //    //CapacityErrorGV.DataSource = D_View3;
                            //    //CapacityErrorGV.DataBind();
                            //}
                            //else
                            //{
                            //    //GuidanceErrorGV.DataSource = D_View3;
                            //    //GuidanceErrorGV.DataBind();
                            //}
                            //if (ISheetCheck != 1)
                            //{
                            //    //F_ErrorShow(str頁簽名稱 + "Sheet 比對失敗");
                            //    StrErrorShow = Str頁簽名稱 + "Sheet 比對失敗";
                            //}
                        }
                        if (this.DTImportData.Rows.Count > 0)
                        {

                            if (DTError.Rows.Count == 0)
                            {
                                //Session[StrExcelSheet] = this.DTImportData;
                            }
                        }
                    }
                    else
                    {
                        StrErrorShow = "Please contact Mis : Import format is not defined";
                    }
                }
                catch (Exception ex)
                {
                    StrErrorShow = $"Error: {ex.Message}";
                }
            }
            else
            {
                StrErrorShow = "Data check fail";
            }
            
        }


        protected DataTable GetDBData(string Str處理狀況,string Str處理Table)
        {
            StringBuilder sb = new StringBuilder();

            switch (Str處理狀況)
            {
                //匯入資料
                case "GetDefine":
                    sb.AppendFormat($@"select 
                        a.指定頁籤名稱,
                        a.是否指定頁籤,
                        a.資料起始欄,
                        a.資料起始列,
                        b.SeqNo,
                        b.欄位名稱,
                        b.資料名稱中文,
                        b.資料名稱英文,
                        b.資料名稱越文,
                        b.資料格式,
                        b.是否為必要欄位,
                        b.IsUsing
                        from [GGF資料匯入定義表Head] a left join [GGF資料匯入定義表Line] b on a.id=b.id
                        where a.匯入資料 = '{Str處理Table}' and b.IsDeleted= 0 
                        order by a.匯入資料,SeqNo"  );
                    break;

                default:
                    break;
            }
            DataTable dt = new DataTable();
            if (sb.Length > 0)
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sb.ToString(), Conn);
                    //myAdapter.Fill(Ds, "Str處理狀況");
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                }

            return dt;
        }
        private void F_資料確認( IRow row, int i, int 起始欄)
        {
            string StrError = "";
            DataRow D_dataRow = DTImportData.NewRow();
            DataRow D_erroraRow = DTError.NewRow();
            #region 基礎資料
            //D_dataRow[0] = str頁簽名稱;

            #endregion
            for (int j = 起始欄 - 1; j < DTDefine.Rows.Count; j++)
            {
                if (DTDefine.Rows[j]["IsUsing"].ToString() == "0")
                    continue;

                Boolean B是否為必要欄位;
                
                if (!Boolean.TryParse(DTDefine.Rows[j]["是否為必要欄位"].ToString(), out B是否為必要欄位))
                {
                    B是否為必要欄位 = false;
                }
                string Str資料格式 = "";
                Str資料格式 = DTDefine.Rows[j]["資料格式"].ToString();
                //必填沒有資料
                if (row.GetCell(j) == null)
                {
                    if (B是否為必要欄位)
                        StrError += FConvertError(DTDefine.Rows[j]["欄位名稱"].ToString(), i, StrError, j, "No Define");
                    else
                        D_dataRow[j] = "";
                }
                else
                {
                    switch (Str資料格式)
                    {
                        case "Varchar":
                        case "Nvarchar":
                            try
                            {
                                if (!string.IsNullOrEmpty(row.GetCell(j).ToString()))
                                    D_dataRow[j] = row.GetCell(j).ToString().Trim();
                                else
                                {
                                    if (B是否為必要欄位)
                                        StrError += FConvertError(DTDefine.Rows[j]["欄位名稱"].ToString(), i, StrError, j, "No Data");
                                    else
                                        D_dataRow[j] = "";
                                }
                                    
                            }
                            catch (Exception)
                            {
                                StrError += FConvertError(DTDefine.Rows[j]["欄位名稱"].ToString(), i, StrError, j, "ImportError");
                            }
                            break;
                        case "Int":
                        case "Float":
                            try
                            {
                                if (row.GetCell(j).CellType == CellType.Numeric)
                                    D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                                else if (row.GetCell(j).CellType == CellType.Formula)
                                {
                                    D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                                }

                            }
                            catch (Exception)
                            {
                                if (B是否為必要欄位)
                                {
                                    StrError += FConvertError(DTDefine.Rows[j]["欄位名稱"].ToString(), i, StrError, j, "int Error1");
                                }
                                else
                                    D_dataRow[j] = "0";
                            }
                            break;
                        case "Datetime":
                            try
                            {

                                D_dataRow[j] = row.GetCell(j).DateCellValue.ToString("yyyy-MM-dd");
                            }
                            catch (Exception)
                            {
                                if (B是否為必要欄位)
                                {
                                    StrError = FConvertError(DTDefine.Rows[j]["欄位名稱"].ToString(), i, StrError, j, "DateformatError");
                                }
                                else
                                    D_dataRow[j] = "";
                            }
                            break;
                        default:
                            StrError += FConvertError(DTDefine.Rows[j]["欄位名稱"].ToString(), i, StrError, j, "No Define");
                            break;
                    }
                }
            }

            if (StrError.Length>0)
            {
                D_erroraRow[0] = "Row " + i.ToString() + " " + StrError;
                DTError.Rows.Add(D_erroraRow);
            }
            else
                DTImportData.Rows.Add(D_dataRow);

        }
        
        
        public static string FConvertError(string Str欄位名稱, int i, string sError, int j, string strErrorDefine)
        {
            try
            {
                sError += string.Format(" {0}  {1}. ", lang.翻譯("Program", strErrorDefine, "TW"), Str欄位名稱);
            }
            catch (Exception)
            {


            }
            return sError;
        }
        public void 讀取多語資料(string StrPageName)
        {
            lang.gg.Clear();
            lang.讀取多語資料("Program", StrPageName);
        }


        //public UpDateStatus F_UpLoad()
        //{
        //    //有錯誤資料不給匯入
        //    //if (SearchTB.Text.Trim() != "" && F_CheckData() && Session["ExcelError"] == null)
        //    if (DTError == null)
        //    {
        //        int iIndex = GetExcelIdex(Str匯入Head);
        //        string StrInsertColumn = "", StrInsertValue = "";
        //        string StrErrorIDLog = "";
        //        //取得塞入資料流水號(TableName,程式)

        //        if (iIndex > 0)
        //            using (SqlConnection conn1 = new SqlConnection(strConnectString))
        //            {
        //                SqlCommand command1 = conn1.CreateCommand();
        //                SqlTransaction transaction1;
        //                conn1.Open();
        //                transaction1 = conn1.BeginTransaction("createExcelImport");

        //                command1.Connection = conn1;
        //                command1.Transaction = transaction1;
        //                try
        //                {
        //                    #region 匯入明細
        //                    for (int i = 0; i < DTImport.Rows.Count; i++)
        //                    {
        //                        StrErrorIDLog = "第" + i.ToString() + "筆資料";
        //                        //處理字串
        //                        for (int j = 0; j < DTImport.Columns.Count; j++)
        //                        {
        //                            StrErrorIDLog += "設定匯入表格第" + j.ToString() + "筆資料";
        //                            if (j > 0)
        //                            {
        //                                StrInsertColumn += ",";
        //                                StrInsertValue += ",";
        //                            }
        //                            else
        //                            {
        //                                StrInsertColumn = "id,";
        //                                StrInsertValue = "@id,";
        //                            }
        //                            StrInsertColumn += DTDefine.Rows[j]["資料名稱中文"].ToString();
        //                            StrInsertValue += "@" + DTDefine.Rows[j]["資料名稱中文"].ToString();
        //                        }
        //                        command1.CommandText = string.Format(@"INSERT INTO {0}
        //                                          ({1})
        //                                     VALUES
        //                                           ({2}
        //                                            )
        //                                           ", Str匯入Line, StrInsertColumn, StrInsertValue);

        //                        command1.Parameters.Add("@id", SqlDbType.Int).Value = iIndex;
        //                        //處理匯入資料
        //                        for (int j = 0; j < DTImport.Columns.Count; j++)
        //                        {
        //                            switch (DTDefine.Rows[j]["資料格式"])
        //                            {
        //                                case "Varchar":
        //                                    command1.Parameters.Add("@" + DTDefine.Rows[j]["資料名稱中文"], SqlDbType.VarChar).Value = DTImport.Rows[i][j].ToString();
        //                                    break;
        //                                case "Nvarchar":
        //                                    command1.Parameters.Add("@" + DTDefine.Rows[j]["資料名稱中文"], SqlDbType.NVarChar).Value = DTImport.Rows[i][j].ToString();
        //                                    break;
        //                                case "Int":
        //                                    command1.Parameters.Add("@" + DTDefine.Rows[j]["資料名稱中文"], SqlDbType.Int).Value = DTImport.Rows[i][j].ToString();
        //                                    break;
        //                                case "Float":
        //                                    command1.Parameters.Add("@" + DTDefine.Rows[j]["資料名稱中文"], SqlDbType.Float).Value = DTImport.Rows[i][j].ToString();
        //                                    break;
        //                                case "Datetime":

        //                                    if (string.IsNullOrEmpty(DTImport.Rows[i][j].ToString()))
        //                                    {
        //                                        SqlDateTime st = SqlDateTime.Null;
        //                                        command1.Parameters.Add("@" + DTDefine.Rows[j]["資料名稱中文"], SqlDbType.DateTime).Value = st;
        //                                    }
        //                                    else
        //                                        command1.Parameters.Add("@" + DTDefine.Rows[j]["資料名稱中文"], SqlDbType.DateTime).Value = DTImport.Rows[i][j].ToString();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }
        //                        }
        //                        command1.ExecuteNonQuery();
        //                        command1.Parameters.Clear();
        //                    }
        //                    //上傳成功更新Head狀態
        //                    command1.CommandText = string.Format(@"UPDATE {0} SET IsUpdate = 1  WHERE id = {1} ", Str匯入Head, iIndex);
        //                    //command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Session["Date"].ToString();
        //                    command1.ExecuteNonQuery();
        //                    command1.Parameters.Clear();
        //                    command1.CommandText = string.Format(@"UPDATE {0} SET IsDelete = 1  WHERE id <> {1} and IsDelete <> 1 ", Str匯入Head, iIndex);
        //                    command1.ExecuteNonQuery();
        //                    #endregion
        //                    transaction1.Commit();
        //                    GridView1.DataSource = null;
        //                    GridView1.DataBind();
        //                }
        //                #region 匯入ErrorLog
        //                catch (Exception ex1)
        //                {
        //                    try
        //                    {
        //                        Log.ErrorLog(ex1, "Import Excel Error :" + Session["FileName"].ToString(), StrProgram);
        //                    }
        //                    catch (Exception ex2)
        //                    {
        //                        Log.ErrorLog(ex2, "Insert Error Error:" + Session["FileName"].ToString(), StrProgram);
        //                    }
        //                    finally
        //                    {
        //                        transaction1.Rollback();
        //                        F_ErrorShow("Please Contact MIS : Import Error");
        //                        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('匯入失敗請連絡MIS');</script>");
        //                    }
        //                }
        //                #endregion
        //                finally
        //                {
        //                    //使用Using會自動釋放資源
        //                    //conn1.Close();
        //                    //conn1.Dispose();
        //                    //command1.Dispose();
        //                    //Label1.Text = "資料上傳成功";
        //                }
        //            }
        //        else
        //        {
        //            F_ErrorShow("Create Head Error");
        //        }
                    
        //    }
        //    else
        //    {
        //        F_ErrorShow(lang.翻譯("Program", "ImportDataError", "TW"));
        //    }
        //}

        public DataTable OledLoadExcel(System.Web.UI.HtmlControls.HtmlInputFile upload_file, string Str儲存路徑)
        {
            DataTable dt = new DataTable();

            string fileName = Path.GetFileName(upload_file.PostedFile.FileName);

            string LocationFiled = HttpContext.Current.Server.MapPath(Str儲存路徑);

            string Str副檔名 = Path.GetExtension(fileName).ToUpper();
            while (File.Exists(LocationFiled + fileName))
            {
                fileName = fileName.Substring(0, fileName.Length - Str副檔名.Length) + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Str副檔名;
            }
            upload_file.PostedFile.SaveAs(LocationFiled + fileName);

            //定義OleDb======================================================
            //1.檔案位置

            string FilePath = LocationFiled + fileName;

            //2.提供者名稱  Microsoft.Jet.OLEDB.4.0適用於2003以前版本，Microsoft.ACE.OLEDB.12.0 適用於2007以後的版本處理 xlsx 檔案
            string ProviderName = "Microsoft.ACE.OLEDB.12.0;";

            //3.Excel版本，Excel 8.0 針對Excel2000及以上版本，Excel5.0 針對Excel97。
            string ExtendedString = "'Excel 8.0;";

            //4.第一行是否為標題(;結尾區隔)
            //HDR=Yes，指示第一行是標題，不做為資料使用；HDR=NO，指示第一行不是標題，做為資料來使用。
            string HDR = "Yes;";

            //5.IMEX=1 通知驅動程序始終將「互混」數據列作為文本讀取(;結尾區隔,'文字結尾)
            //  0 表示Export mode，「匯出模式」，只能用來做「寫入」用途
            //  1 表示Import mode，「匯入模式」，只能用來做「讀取」用途。
            //  2 表示Linked mode(full update capabilities)，「連結模式」，可同時支援「讀取」與「寫入」用途
            string IMEX = "0';";

            //=============================================================
            //連線字串
            string connectString =
                    "Data Source=" + FilePath + ";" +
                    "Provider=" + ProviderName +
                    "Extended Properties=" + ExtendedString +
                    "HDR=" + HDR +
                    "IMEX=" + IMEX;
            //=============================================================

            using (OleDbConnection Connect = new OleDbConnection(connectString))
            {
                Connect.Open();
                //string queryString = "SELECT * FROM [" + SheetName + "$]";
                string queryString = "SELECT * FROM [Details$]";
                try
                {
                    using (OleDbDataAdapter dr = new OleDbDataAdapter(queryString, Connect))
                    {
                        dr.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    dt = null;
                }
            }

            return dt;
        }
    }
}