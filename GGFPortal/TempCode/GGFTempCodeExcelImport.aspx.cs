using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.TempCode
{
    public partial class GGFTempCodeExcelImport : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "Search For Grid", StrProgram = "TempCode.aspx";
        static DataSet Ds = new DataSet();
        static 多語 lang = new 多語();
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

        //public class Columndefined
        //{
        //    public int ColumnID { get; set; }
        //    public string ColumnName { get; set; }
        //    public string VNName { get; set; }
        //    public int ColumnType { get; set; }
        //    public string ChineseName { get; set; }
        //}
        protected DataTable GetDBData(string Str處理狀況)
        {
            StringBuilder sb = new StringBuilder();

            switch (Str處理狀況)
            {
                //匯入資料
                case "欄位定義":
                    sb.Append(@"select 
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
                        from [dbo].[GGF資料匯入定義表Head] a left join [dbo].[GGF資料匯入定義表Line] b on a.id=b.id
                        where a.匯入資料='河內打樣單1' and b.IsDeleted= 0 
                        order by SeqNo");
                    break;
                case "確認上傳資料2":

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
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
        //If this code does not exist in the file, add the code into the file after the following line:

        protected void CheckBT_Click(object sender, EventArgs e)
        {
            ////引用//ReferenceCode/ExcelColumn.cs的類別
            //ExcelImportTemplate GetExcelDefine = new ExcelImportTemplate();
            ////建立匯入table
            //GetExcelDefine.F_ImportTable();
            ////上傳路徑
            //// 根目錄/路徑(~/路徑)
            //String savePath = Server.MapPath(@"~\ExcelUpLoad\Sales\AMZForcast");

            //DataTable D_table = new DataTable("Excel");
            ////建立Excel欄位
            //D_table = GetExcelDefine.Dt1.Copy();
            //DataTable D_errortable = new DataTable("Error");
            ////實際顯示欄位
            //int Excel欄位數 = D_table.Columns.Count - 2;
            if ((upload_file.PostedFile != null) && (upload_file.PostedFile.ContentLength > 0))
            {
                string fileName = System.IO.Path.GetFileName(upload_file.PostedFile.FileName);
                string LocationFiled = Server.MapPath(@"~\ExcelUpLoad\");
                string str頁簽名稱 = "";

                

                try
                {
                    //upload_file.PostedFile.SaveAs(SaveLocation);
                    //Response.Write("The file has been uploaded.");
                    DataTable D_table = new DataTable("Excel");
                    DataTable D_errortable = new DataTable("Error");
                    string 副檔名 = System.IO.Path.GetExtension(fileName);
                    DataTable DtColumnDefine = GetDBData("欄位定義");
                    //指定Import Sheet Name
                    string StrSheetNameCheck = "";
                    Boolean BCheck = false;
                    int I資料起始欄 = 0, I資料起始列 = 0;

                    #region 基本資料欄位
                    //D_table.Columns.Add("預設資料");

                    #endregion

                    foreach (DataRow Dr in DtColumnDefine.Rows)
                    {
                        D_table.Columns.Add(Dr["資料名稱中文"].ToString());
                    }

                    if (DtColumnDefine.Rows.Count>0)
                    {
                        StrSheetNameCheck = (string.IsNullOrEmpty(DtColumnDefine.Rows[0]["指定頁籤名稱"].ToString()))?"": DtColumnDefine.Rows[0]["指定頁籤名稱"].ToString();
                        Boolean.TryParse( DtColumnDefine.Rows[0]["指定頁籤名稱"].ToString(),out BCheck);
                        int.TryParse(DtColumnDefine.Rows[0]["資料起始列"].ToString(), out I資料起始列);
                        int.TryParse(DtColumnDefine.Rows[0]["資料起始欄"].ToString(), out I資料起始欄);

                        while (File.Exists(LocationFiled + fileName))
                        {
                            fileName = fileName.Substring(0, fileName.Length - 副檔名.Length) + DateTime.Now.ToString("yyyyMMddhhmmssfff") + 副檔名;
                        }
                        upload_file.PostedFile.SaveAs(LocationFiled + fileName);

                        if (副檔名.ToUpper() == ".XLSX")
                        {
                            XSSFWorkbook workbook = new XSSFWorkbook(upload_file.PostedFile.InputStream);  //==只能讀取 System.IO.Stream
                            for (int x = 0; x < workbook.NumberOfSheets; x++)
                            {
                                //-- 0表示：第一個 worksheet工作表
                                XSSFSheet u_sheet = (XSSFSheet)workbook.GetSheetAt(x);
                                str頁簽名稱 = u_sheet.SheetName.ToString();
                                //檢查是否有要對應資料
                                if (BCheck && StrSheetNameCheck!= str頁簽名稱)
                                {
                                    continue;
                                }
                                //-- Excel 表頭列
                                XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(I資料起始列+1);
                                IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);
                                //-- for迴圈的「啟始值」要加一，表示不包含 Excel表頭列
                                // for (int i = (u_sheet.FirstRowNum + 1); i <= u_sheet.LastRowNum; i++)   
                                //-- 每一列做迴圈
                                //i=1第二列開始
                                for (int i = 1; i <= u_sheet.LastRowNum; i++)
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    F_資料確認(ref D_table,ref D_errortable, str頁簽名稱, row, DtColumnDefine, i);
                                }
                                //-- 釋放 NPOI的資源
                                u_sheet = null;
                            }
                            //-- 釋放 NPOI的資源
                            workbook = null;

                            //--錯誤資料顯示
                            if (D_errortable.Rows.Count > 0)
                            {
                                DataView D_View3 = new DataView(D_errortable);
                                ErrorGV.DataSource = D_View3;
                                ErrorGV.DataBind();
                            }
                            if(D_table.Rows.Count>0)
                            {
                                GridView1.DataSource = D_table;
                                GridView1.DataBind();
                            }
                            //--------------------------------------------------
                            //---- （以下是）上傳 FileUpload的部分！
                            //--------------------------------------------------
                        }
                        else
                        {

                            HSSFWorkbook workbook = new HSSFWorkbook(upload_file.PostedFile.InputStream);  //==只能讀取 System.IO.Stream
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
                                    F_資料確認(ref D_table, ref D_errortable, str頁簽名稱, row, DtColumnDefine, i);
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
                                //ErrorGV.DataSource = D_View3;
                                //ErrorGV.DataBind();
                            }

                            //--------------------------------------------------
                            //---- （以下是）上傳 FileUpload的部分！
                            //--------------------------------------------------

                        }
                    }
                    else
                    {
                        F_ErrorShow("Please contact Mis : Import format is not defined");
                    }

                }
                catch (Exception ex)
                {
                    F_ErrorShow("Error: " + ex.Message); 
                }
            }
            else
            {
                F_ErrorShow("Please select a file to upload.");
            }

        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }
        /// <summary>
        /// 確認每列匯入的資料
        /// </summary>
        /// <param name="D_table"></param>
        /// <param name="D_errortable"></param>
        /// <param name="str頁簽名稱"></param>
        /// <param name="row"></param>
        private void F_資料確認(DataTable D_table, DataTable D_errortable, string str頁簽名稱, IRow row)
        {
            StringBuilder sbError = new StringBuilder();

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

            //Regex資料驗證規則
            //string strRegex工號 = "V[0-9]{4}", strRegex工段 = "[0-9]{3}", strRegex數量 = "[0-9]{4}";
            //string strRegex日期 = "\\b(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})\\b";
            #endregion

            //List<Columndefined> VNExcel = new List<Columndefined>();

            //z為每行第幾個資料
            //
            //使用迴圈坐資料驗證，適合用於固定欄位
            //for (int z = 3; z < 24; z = z + 7)
            //{
            //}

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="D_table"></param>
        /// <param name="D_errortable"></param>
        /// <param name="str頁簽名稱"></param>
        /// <param name="row"></param>
        /// <param name="DtColumnDefine"></param>
        private void F_資料確認(ref DataTable D_table,ref DataTable D_errortable, string str頁簽名稱, IRow row, DataTable DtColumnDefine, int i)
        {
            string StrError = "";

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

            //Regex資料驗證規則
            //string strRegex工號 = "V[0-9]{4}", strRegex工段 = "[0-9]{3}", strRegex數量 = "[0-9]{4}";
            //string strRegex日期 = "\\b(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})\\b";
            #endregion
            DataRow D_dataRow = D_table.NewRow();
            #region 基礎資料
            //D_dataRow[0] = str頁簽名稱;

            #endregion
            for (int j = 0; j < DtColumnDefine.Rows.Count; j++)
            {
                Boolean B是否為必要欄位 = false, BError=false;
                string Str資料格式 = "";
                Boolean.TryParse(DtColumnDefine.Rows[j]["是否為必要欄位"].ToString(), out B是否為必要欄位);
                Str資料格式 = DtColumnDefine.Rows[j]["資料格式"].ToString();
                DataRow D_erroraRow = D_errortable.NewRow();
                switch (Str資料格式)
                {
                    case "Int":
                        if ((row.GetCell(j) != null) && (row.GetCell(j).CellType == CellType.Formula))  //== v.1.2.4版修改。2.x版只是修正英文大小寫。
                        {
                            ////-- 表示格子裡面，公式運算後的「值」，是數字（Numeric）。
                            try
                            {
                                D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                            }
                            catch
                            {
                                if (B是否為必要欄位 == true)
                                {
                                    BError = true;
                                    StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "int Error1");
                                }
                                D_dataRow[j] = (row.GetCell(j) == null) ? "" : "0";  //--每一個欄位，都加入同一列 DataRow
                            }
                        }
                        else
                        {
                            try
                            {
                                int iout = 0;
                                if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                                {
                                    if (B是否為必要欄位 == true)
                                    {
                                        BError = true;
                                        StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "NoData");
                                    }
                                    D_dataRow[j + 2] = "0";  //--每一個欄位，都加入同一列 DataRow
                                }
                                else
                                {
                                    if (int.TryParse(row.GetCell(j).ToString(), out iout) == false)
                                    {
                                        if (B是否為必要欄位 == true)
                                        {
                                            BError = true;
                                            StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "int Error2");
                                        }
                                        D_dataRow[j] = (row.GetCell(j) == null) ? "0" : iout.ToString();  //--每一個欄位，都加入同一列 DataRow

                                    }
                                    else
                                        D_dataRow[j] = (row.GetCell(j) == null) ? "0" : iout.ToString();  //--每一個欄位，都加入同一列 DataRow 
                                }
                            }
                            catch
                            {
                                if (B是否為必要欄位 == true)
                                {
                                    BError = true;
                                    StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "int Error2");
                                }
                                D_dataRow[j] = "0";  //--每一個欄位，都加入同一列 DataRow
                            }
                        }
                        break;
                    case "String":
                        try
                        {
                            if (B是否為必要欄位 && row.GetCell(j) == null)
                            {
                                BError = true;
                                StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "NoData");
                                D_dataRow[j] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                            }
                            else
                            {
                                string strString = "";
                                strString = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).ToString().Trim();   //--每一個欄位，都加入同一列 DataRow
                                D_dataRow[j] = strString;
                            }

                        }
                        catch
                        {
                            if (B是否為必要欄位 == true)
                            {
                                BError = true;
                                StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "ImportError");
                            }
                            D_dataRow[j] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                        }
                        break;
                    case "Datetime":
                        try
                        {
                            if (B是否為必要欄位 == true && (string.IsNullOrEmpty(row.GetCell(j).ToString())))
                            {
                                BError = true;
                                StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "DateformatError");
                            }
                            D_dataRow[j] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).DateCellValue.ToString("yyyyMMdd");
                        }
                        catch
                        {
                            BError = true;
                            StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "DateformatError");
                            //D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                        }
                        break;
                    case "Float":
                        if ((row.GetCell(j) != null) && (row.GetCell(j).CellType == CellType.Formula))  //== v.1.2.4版修改。2.x版只是修正英文大小寫。
                        {
                            //D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                            ////-- 表示格子裡面，公式運算後的「值」，是數字（Numeric）。
                            try
                            {
                                D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                            }
                            catch
                            {
                                if (B是否為必要欄位 == true)
                                {
                                    BError = true;
                                    StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "Float Error1");
                                }
                                D_dataRow[j] = (row.GetCell(j) == null) ? "" : "0";  //--每一個欄位，都加入同一列 DataRow
                            }
                        }
                        else
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                                {
                                    if (B是否為必要欄位 == true)
                                    {
                                        BError = true;
                                        StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "NoData");
                                    }
                                    D_dataRow[j] = "0";  //--每一個欄位，都加入同一列 DataRow
                                }
                                else
                                {
                                    double dout = 0;
                                    if (double.TryParse(row.GetCell(j).ToString(), out dout) == false)
                                    {
                                        if (B是否為必要欄位 == true)
                                        {
                                            BError = true;
                                            StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "Float Error2");
                                        }
                                        D_dataRow[j] = dout.ToString();  //--每一個欄位，都加入同一列 DataRow
                                    }
                                    else
                                    {
                                        D_dataRow[j] = (row.GetCell(j) == null) ? "0" : dout.ToString();  //--每一個欄位，都加入同一列 DataRow 
                                    }
                                }
                            }
                            catch
                            {
                                if (B是否為必要欄位 == true)
                                {
                                    BError = true;
                                    StrError = FConvertError(DtColumnDefine.Rows[i]["資料名稱中文"].ToString(), i, StrError, j, "NumFormatError");
                                }
                                D_dataRow[j] = "0";  //--每一個欄位，都加入同一列 DataRow
                            }
                        }
                        break;
                    default:

                        break;
                }
                if(BError)
                {
                    D_erroraRow[0] = StrError;
                    //D_erroraRow[1] = row.GetCell(0).ToString();
                    //D_erroraRow[2] = "Hàng thứ " + i.ToString() + sError;
                    D_errortable.Rows.Add(D_erroraRow);
                }

            }
            D_table.Rows.Add(D_dataRow);

        }
        /// <summary>
        /// booking import primary Key
        /// </summary>
        /// <returns>取得新增的 primary Key</returns>
        private int GetExcelIdex()
        {
            Int32 ProductivityHeadID = 0;
            string sql =
                @"INSERT INTO [dbo].[GGF資料匯入定義表Head]
                    (建立日期)
                    VALUES(@建立日期); 
                    SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add("@建立日期", SqlDbType.NVarChar);
                cmd.Parameters["@建立日期"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                try
                {
                    conn.Open();
                    ProductivityHeadID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Get GGF資料匯入定義表Head id Error" + Session["FileName"].ToString() + ":", StrProgram);
                }
            }
            return (int)ProductivityHeadID;
        }
        private static string FConvertError(string Str欄位名稱, int i, string sError, int j, string strErrorDefine)
        {
            try
            {
                sError += string.Format(" {0} column name:{1}. ", lang.翻譯("Program", strErrorDefine, "TW"), Str欄位名稱);
            }
            catch (Exception)
            {


            }
            return sError;
        }
    }
}