using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sales024 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        //static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "Capacities", StrProgram = "Sales024.aspx";
        //static string strImportType = "";
        static string Str匯入定義Table = "AMZCapacity";
        static string StrAMZCapacity = "AMZCapacity", StrAMZGuidance = "AMZGuidance";
        private static string Str匯入Head = "AMZCapacityHead";
        static DataSet Ds = new DataSet();
        static 多語 lang = new 多語();
        static DataCheck datacheck = new DataCheck();
        static XSSFWorkbook XSSworkbook;
        static HSSFWorkbook HSSworkbook;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            #region 網頁Layout基本參數
            //網頁標題

            ((Label)Master.FindControl("BrandLB")).Text = StrPageName;
            Page.Title = StrPageName;
            datacheck.讀取多語資料(StrPageName);
            lang.讀取多語資料("Program", StrProgram);
            //StrError名稱 = "";
            //StrProgram = "TempCode2.aspx";

            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTB.Attributes["readonly"] = "readonly";
        }
        protected DataTable GetDBData(string Str處理狀況)
        {
            StringBuilder sb = new StringBuilder();

            switch (Str處理狀況)
            {
                //匯入資料
                case "AMZGuidance":
                    sb.AppendFormat(@"select 
                        a.指定頁籤名稱,
                        a.是否指定頁籤,
                        a.資料起始欄,
                        a.資料起始列,
                        b.SeqNo,
                        b.資料名稱中文,
                        b.資料名稱英文,
                        b.資料名稱越文,
                        b.資料格式,
                        b.是否為必要欄位 
                        from [GGF資料匯入定義表Head] a left join [GGF資料匯入定義表Line] b on a.id=b.id
                        where a.匯入資料 = 'AMZGuidance' and b.IsDeleted= 0 
                        order by a.匯入資料,SeqNo");
                    break;
                case "AMZCapacity":
                    sb.AppendFormat(@"select 
                        a.指定頁籤名稱,
                        a.是否指定頁籤,
                        a.資料起始欄,
                        a.資料起始列,
                        b.SeqNo,
                        b.資料名稱中文,
                        b.資料名稱英文,
                        b.資料名稱越文,
                        b.資料格式,
                        b.是否為必要欄位 
                        from [GGF資料匯入定義表Head] a left join [GGF資料匯入定義表Line] b on a.id=b.id
                        where a.匯入資料 = 'AMZCapacity' and b.IsDeleted= 0 
                        order by a.匯入資料,SeqNo");
                    break;
                default:
                    break;
            }
            DataTable dt = new DataTable();
            if(sb.Length>0)
                using (SqlConnection Conn = new SqlConnection(strConnectString))
                {
                    SqlDataAdapter myAdapter = new SqlDataAdapter(sb.ToString(), Conn);
                    //myAdapter.Fill(Ds, "Str處理狀況");
                    myAdapter.Fill(dt);    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

                }

            return dt;
        }

        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
        //If this code does not exist in the file, add the code into the file after the following line:

        protected void CheckBT_Click(object sender, EventArgs e)
        {
            if ((upload_file.PostedFile != null) && (upload_file.PostedFile.ContentLength > 0))
            {
                string fileName = System.IO.Path.GetFileName(upload_file.PostedFile.FileName);
                string LocationFiled = Server.MapPath(@"~\ExcelUpLoad\");

                string 副檔名 = System.IO.Path.GetExtension(fileName).ToUpper();
                while (File.Exists(LocationFiled + fileName))
                {
                    fileName = fileName.Substring(0, fileName.Length - 副檔名.Length) + DateTime.Now.ToString("yyyyMMddhhmmssfff") + 副檔名;
                }
                upload_file.PostedFile.SaveAs(LocationFiled + fileName);
                if (副檔名 == ".XLSX")
                {
                    XSSworkbook = new XSSFWorkbook(upload_file.PostedFile.InputStream);
                    F_CheckDate(StrAMZGuidance, 副檔名);
                    F_CheckDate(StrAMZCapacity, 副檔名);
                    XSSworkbook = null;
                }
                    
                else
                {
                    HSSworkbook = new HSSFWorkbook(upload_file.PostedFile.InputStream);
                    F_CheckDate(StrAMZGuidance, 副檔名);
                    F_CheckDate(StrAMZCapacity, 副檔名);
                    HSSworkbook = null;
                }
                    

            }
            else
            {
                F_ErrorShow("Please select a file to upload.");
            }
        }
        public void F_CheckDate(string StrExcelSheet ,string 副檔名)
        {
            string str頁簽名稱 = "";
            int ISheetCheck = 0;//確認Sheet 資料是否正確，每份Sheet只會有一個對應
            try
            {
                DataTable D_table = new DataTable("Excel");
                DataTable D_errortable = new DataTable("Error");
                DataTable DtColumnDefine = GetDBData(StrExcelSheet);
                //EnumerableRowCollection<DataRow> query1 = from dt in DtColumnDefine.AsEnumerable()
                //                                         where dt.Field<string>("匯入資料") == "AMZCapacity"
                //                                         select dt;
                //EnumerableRowCollection<DataRow> query2 = from dt in DtColumnDefine.AsEnumerable()
                //                                         where dt.Field<string>("匯入資料") == "AMZGuidance"
                //                                          select dt;
                //DataTable dt1 = new DataTable(), dt2 = new DataTable();
                //foreach (DataRow dr in query1)
                //    dt1.ImportRow(dr); 
                //foreach (DataRow dr in query2)
                //    dt2.ImportRow(dr);

                //if (Session["DataDefine"]!=null)
                //    Session.Remove("DataDeffine");
                Session[StrExcelSheet + "Define"] = DtColumnDefine;

                //指定Import Sheet Name
                string StrSheetNameCheck = "";
                Boolean BCheck = false;
                int I資料起始欄, I資料起始列;

                D_errortable.Columns.Add("Error");

                foreach (DataRow Dr in DtColumnDefine.Rows)
                {
                    D_table.Columns.Add(Dr["資料名稱中文"].ToString());
                }

                if (DtColumnDefine.Rows.Count > 0)
                {
                    StrSheetNameCheck = (string.IsNullOrEmpty(DtColumnDefine.Rows[0]["指定頁籤名稱"].ToString())) ? "" : DtColumnDefine.Rows[0]["指定頁籤名稱"].ToString();

                    if (!Boolean.TryParse(DtColumnDefine.Rows[0]["是否指定頁籤"].ToString(), out BCheck))
                    {
                        BCheck = false;
                    }

                    if (!int.TryParse(DtColumnDefine.Rows[0]["資料起始列"].ToString(), out I資料起始列))
                    {
                        I資料起始列 = 1;
                    }

                    if (!int.TryParse(DtColumnDefine.Rows[0]["資料起始欄"].ToString(), out I資料起始欄))
                    {
                        I資料起始欄 = 0;
                    }



                    if (副檔名.ToUpper() == ".XLSX")
                    {
                        //XSSFWorkbook workbook = new XSSFWorkbook(upload_file.PostedFile.InputStream);  //==只能讀取 System.IO.Stream
                        for (int x = 0; x < XSSworkbook.NumberOfSheets; x++)
                        {
                            //-- 0表示：第一個 worksheet工作表
                            XSSFSheet u_sheet = (XSSFSheet)XSSworkbook.GetSheetAt(x);
                            str頁簽名稱 = u_sheet.SheetName.ToString();
                            
                            //檢查是否有要對應資料
                            if (BCheck && StrSheetNameCheck != str頁簽名稱)
                            {
                                continue;
                            }
                            else
                            {
                                ISheetCheck =+ 1;
                            }
                            //-- Excel 表頭列
                            XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(I資料起始列);
                            IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);

                            for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);
                                F_資料格式確認(ref D_table, ref D_errortable, str頁簽名稱, row, DtColumnDefine, i, I資料起始欄);
                            }
                            //-- 釋放 NPOI的資源
                            u_sheet = null;
                        }
                        //-- 釋放 NPOI的資源
                        //workbook = null;
                    }
                    else
                    {
                        //HSSFWorkbook workbook = new HSSFWorkbook(upload_file.PostedFile.InputStream);  //==只能讀取 System.IO.Stream
                        for (int x = 0; x < HSSworkbook.NumberOfSheets; x++)
                        {
                            HSSFSheet u_sheet = (HSSFSheet)HSSworkbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                            HSSFRow headerRow = (HSSFRow)u_sheet.GetRow(I資料起始列);  //-- Excel 表頭列
                            IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);             //-- v.1.2.4版修改
                                                                                     //檢查是否有要對應資料
                            if (BCheck && StrSheetNameCheck != str頁簽名稱)
                            {
                                continue;
                            }
                            else
                            {
                                ISheetCheck = +1;
                            }
                            str頁簽名稱 = u_sheet.SheetName.ToString();
                            for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);
                                F_資料格式確認(ref D_table, ref D_errortable, str頁簽名稱, row, DtColumnDefine, i, I資料起始欄);
                            }
                            //-- 釋放 NPOI的資源
                            u_sheet = null;
                        }
                        //-- 釋放 NPOI的資源
                        //workbook = null;
                    }
                    //--錯誤資料顯示
                    DataView D_View3 = new DataView(D_errortable);

                    if (D_errortable.Rows.Count > 0)
                    {
                        
                        if(str頁簽名稱== "AMZCapacity")
                        {
                            CapacityErrorGV.DataSource = D_View3;
                            CapacityErrorGV.DataBind();
                        }
                        else
                        {
                            GuidanceErrorGV.DataSource = D_View3;
                            GuidanceErrorGV.DataBind();
                        }
                        if(ISheetCheck != 1)
                        {
                            F_ErrorShow(str頁簽名稱 + "Sheet 比對失敗");
                        }
                    }
                    if (D_table.Rows.Count > 0)
                    {

                        if (D_errortable.Rows.Count == 0)
                        {
                            Session[StrExcelSheet] = D_table;
                        }
                    }
                }
                else
                {
                    F_ErrorShow("Please contact Mis : Import format is not defined");
                }
            }
            catch (Exception ex)
            {
                F_ErrorShow($"Error: {ex.Message}");
            }
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="D_table"></param>
        /// <param name="D_errortable"></param>
        /// <param name="str頁簽名稱"></param>
        /// <param name="row"></param>
        /// <param name="DtColumnDefine"></param>
        private void F_資料格式確認(ref DataTable D_table,ref DataTable D_errortable, string str頁簽名稱, IRow row, DataTable DtColumnDefine, int i, int 起始欄)
        {
            string StrError = "";

            DataRow D_dataRow = D_table.NewRow();
            DataRow D_erroraRow = D_errortable.NewRow();
            Boolean BError = false;
            for (int j = 起始欄-1; j < DtColumnDefine.Rows.Count; j++)
            {
                Boolean B是否為必要欄位;
                string Str資料格式 = "";
                if (!Boolean.TryParse(DtColumnDefine.Rows[j]["是否為必要欄位"].ToString(), out B是否為必要欄位))
                {
                    B是否為必要欄位 = false;
                }
                Str資料格式 = DtColumnDefine.Rows[j]["資料格式"].ToString();
                switch (Str資料格式)
                {
                    case "Int":
                        datacheck.IntData(row, DtColumnDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    case "Varchar":
                    case "Nvarchar":
                        datacheck.StringData(row, DtColumnDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    case "Datetime":
                        datacheck.DatetimeData(row, DtColumnDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    case "Float":
                        datacheck.FloatData(row, DtColumnDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    default:
                        break;
                }
            }
            D_table.Rows.Add(D_dataRow);
            if (BError)
            {
                D_erroraRow[0] = "Row " + i.ToString() + " " + StrError;
                D_errortable.Rows.Add(D_erroraRow);
            }

        }



        protected void UpLoadBT_Click(object sender, EventArgs e)
        {
            F_UpLoad();
        }

        /// <summary>
        /// booking import primary Key
        /// </summary>
        /// <returns>取得新增的 primary Key</returns>
        private int GetExcelIdex(string StrHeadTableName)
        {
            Int32 HeadID = 0;
            string sql =
                string.Format(@"INSERT INTO {0}
                    (匯入年月)
                    VALUES(@匯入年月); 
                    SELECT CAST(scope_identity() AS int)", StrHeadTableName);
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@匯入年月", SqlDbType.NVarChar).Value = DateTB.Text;
                try
                {
                    conn.Open();
                    HeadID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "GetHead id Error" + Str匯入定義Table + ":" + Session["FileName"].ToString() + ":", StrProgram);
                }
            }
            return (int)HeadID;
        }

        protected void DeleteBT_Click(object sender, EventArgs e)
        {
            if(DeleteData())
            {
                F_ErrorShow("刪除成功");
            }
            else
            {
                F_ErrorShow("刪除失敗");
            }
        }

        private bool DeleteData()
        {
            bool BCheck = true;
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand command = conn.CreateCommand();
                SqlTransaction transaction;
                conn.Open();
                transaction = conn.BeginTransaction("createExcelImport");

                command.Connection = conn;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = string.Format(@"Update AMZCapacityHead Set IsDeleted = 1 where 匯入年月 = @匯入年月");
                    command.Parameters.Add("@匯入年月", SqlDbType.NVarChar).Value = DateTB.Text;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    DeleteBT.Visible = false;
                }
                catch
                {
                    transaction.Rollback();
                    BCheck = false;
                }
            }
            return BCheck;
        }

        private static string FConvertError(string Str欄位名稱, int i, string sError, int j, string strErrorDefine)
        {
            sError += string.Format(" {0} column name:{1}. ", lang.翻譯("Program", strErrorDefine, "TW"), Str欄位名稱);
            return sError;
        }
        /// <summary>
        /// 將Session的資料上傳到資料庫
        /// </summary>
        public void F_UpLoad()
        {
            //有錯誤資料不給匯入
            if(!F_CheckDateData())
            {
                F_ErrorShow("已有匯入資料");
                DeleteBT.Visible = true;
            }
            else if (Session[StrAMZCapacity] != null && Session[StrAMZGuidance]!= null)
            {
                DataTable dt = (DataTable)Session[StrAMZCapacity];
                DataTable dtDataDefine = (DataTable)Session[StrAMZCapacity + "Define"];
                DataTable dt1 = (DataTable)Session[StrAMZGuidance];
                DataTable dtDataDefine1 = (DataTable)Session[StrAMZGuidance + "Define"];
                int iIndex = GetExcelIdex(Str匯入Head);
                string StrErrorIDLog = "";
                if (iIndex > 0)
                    using (SqlConnection conn1 = new SqlConnection(strConnectString))
                    {
                        SqlCommand sqlcommand = conn1.CreateCommand();
                        SqlTransaction transaction1;
                        conn1.Open();
                        transaction1 = conn1.BeginTransaction("createExcelImport");

                        sqlcommand.Connection = conn1;
                        sqlcommand.Transaction = transaction1;
                        try
                        {
                            #region 匯入明細
                            F_UpdateCommand(dt, dtDataDefine, iIndex, ref StrErrorIDLog, sqlcommand,StrAMZCapacity);
                            F_UpdateCommand(dt1, dtDataDefine1, iIndex, ref StrErrorIDLog, sqlcommand,StrAMZGuidance);
                            //上傳成功更新Head狀態
                            sqlcommand.CommandText = string.Format(@"UPDATE {0} SET IsUpDate = 1  WHERE id = {1} ", Str匯入Head, iIndex);
                            sqlcommand.ExecuteNonQuery();
                            #endregion
                            transaction1.Commit();
                            F_ErrorShow("上傳成功");
                            CapacityErrorGV.DataSource = null;
                            GuidanceErrorGV.DataSource = null;
                            CapacityErrorGV.DataBind();
                            GuidanceErrorGV.DataBind();
                        }
                    // 匯入ErrorLog
                    catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Import Excel Error :" + Session["FileName"].ToString(), StrProgram);
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Insert Error Error:" + Session["FileName"].ToString(), StrProgram);
                            }
                            finally
                            {
                                transaction1.Rollback();
                                F_ErrorShow("Please Contact MIS : Import Error");
                                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('匯入失敗請連絡MIS');</script>");
                            }
                        }
                        finally
                        {
                            Session.RemoveAll();
                            //Label1.Text = "資料上傳成功";
                        }
                    }
                    else
                        F_ErrorShow("Create Head Error");
            }
            else
            {
                F_ErrorShow(lang.翻譯("Program", "ImportDataError", "TW"));
            }
        }

        public void F_UpdateCommand(DataTable dt, DataTable dtDataDefine, int iIndex, ref string StrErrorIDLog, SqlCommand sqlcommand ,string StrTable)
        {
            try
            {

                string StrInsertColumn = "", StrInsertValue = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StrErrorIDLog = "第" + i.ToString() + "筆資料";
                    //處理字串
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        StrErrorIDLog += "設定匯入表格第" + j.ToString() + "筆資料";
                        if (j > 0)
                        {
                            StrInsertColumn += ",";
                            StrInsertValue += ",";
                        }
                        else
                        {
                            StrInsertColumn = "id,";
                            StrInsertValue = "@id,";
                        }
                        StrInsertColumn += dtDataDefine.Rows[j]["資料名稱中文"].ToString();
                        StrInsertValue += "@" + dtDataDefine.Rows[j]["資料名稱中文"].ToString();
                    }
                    sqlcommand.CommandText = string.Format(@"INSERT INTO {0}
                                                      ({1})
                                                 VALUES
                                                       ({2}
                                                        )
                                                       ", (StrTable==StrAMZGuidance)? "AMZGuidanceLine" : "AMZCapacityLine", StrInsertColumn, StrInsertValue);

                    sqlcommand.Parameters.Add("@id", SqlDbType.Int).Value = iIndex;
                    //處理匯入資料
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        switch (dtDataDefine.Rows[j]["資料格式"])
                        {
                            case "Varchar":
                                sqlcommand.Parameters.Add("@" + dtDataDefine.Rows[j]["資料名稱中文"], SqlDbType.VarChar).Value = dt.Rows[i][j].ToString();
                                break;
                            case "Nvarchar":
                                sqlcommand.Parameters.Add("@" + dtDataDefine.Rows[j]["資料名稱中文"], SqlDbType.NVarChar).Value = dt.Rows[i][j].ToString();
                                break;
                            case "Int":
                                sqlcommand.Parameters.Add("@" + dtDataDefine.Rows[j]["資料名稱中文"], SqlDbType.Int).Value = dt.Rows[i][j].ToString();
                                break;
                            case "Float":
                                sqlcommand.Parameters.Add("@" + dtDataDefine.Rows[j]["資料名稱中文"], SqlDbType.Float).Value = dt.Rows[i][j].ToString();
                                break;
                            case "Datetime":
                                if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                {
                                    SqlDateTime st = SqlDateTime.Null;
                                    sqlcommand.Parameters.Add("@" + dtDataDefine.Rows[j]["資料名稱中文"], SqlDbType.DateTime).Value = st;
                                }
                                else
                                    sqlcommand.Parameters.Add("@" + dtDataDefine.Rows[j]["資料名稱中文"], SqlDbType.DateTime).Value = dt.Rows[i][j].ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                F_ErrorShow(ex.ToString());
            }
            
        }

        private bool F_CheckDateData()
        {
            bool bcheck = true;

            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = string.Format(@"SELECT top 1 *
                                            FROM AMZCapacityHead
                                            where 匯入年月 = @Date and [IsDeleted] = 0 and [IsUpDate] = 1");
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@Date", SqlDbType.NVarChar).Value = DateTB.Text;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    bcheck = false;
                }
                reader.Close();
            }
            return bcheck;
        }
    }
}