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

namespace GGFPortal.ReferenceCode
{
    public class ExcelImport
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
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
        public void F_CheckDate(string Str匯入資料)
        {
            if(XSSworkbook != null|| HSSworkbook!=null)
            {
                string str頁簽名稱 = "";
                int ISheetCheck = 0;//確認Sheet 資料是否正確，每份Sheet只會有一個對應
                try
                {
                    DTImportData = GetDBData("GetDefine", Str匯入資料);

                   //指定Import Sheet Name
                    string StrSheetNameCheck = "";
                    Boolean BCheck = false;
                    int I資料起始欄, I資料起始列;

                    DTError.Columns.Add("Error");

                    foreach (DataRow Dr in DTImportData.Rows)
                    {
                        DTImportData.Columns.Add(Dr["資料名稱中文"].ToString());
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
                                else
                                {
                                    ISheetCheck = +1;
                                }
                                //-- Excel 表頭列
                                XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(I資料起始列);
                                IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);

                                for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    //F_資料格式確認( row, DTImportData, i, I資料起始欄);
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
                                else
                                {
                                    ISheetCheck = +1;
                                }
                                str頁簽名稱 = u_sheet.SheetName.ToString();
                                for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    //F_資料格式確認( str頁簽名稱, row, DTImportData, i, I資料起始欄);
                                }
                                //-- 釋放 NPOI的資源
                                u_sheet = null;
                            }
                        }
                        //--錯誤資料顯示
                        DataView D_View3 = new DataView(DTError);

                        if (DTError.Rows.Count > 0)
                        {

                            if (str頁簽名稱 == "AMZCapacity")
                            {
                                //CapacityErrorGV.DataSource = D_View3;
                                //CapacityErrorGV.DataBind();
                            }
                            else
                            {
                                //GuidanceErrorGV.DataSource = D_View3;
                                //GuidanceErrorGV.DataBind();
                            }
                            if (ISheetCheck != 1)
                            {
                                //F_ErrorShow(str頁簽名稱 + "Sheet 比對失敗");
                                StrErrorShow = str頁簽名稱 + "Sheet 比對失敗";
                            }
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
                        b.資料名稱中文,
                        b.資料名稱英文,
                        b.資料名稱越文,
                        b.資料格式,
                        b.是否為必要欄位 
                        from [GGF資料匯入定義表Head] a left join [GGF資料匯入定義表Line] b on a.id=b.id
                        where a.匯入資料 = '{Str處理Table}' and b.IsDeleted= 0 
                        order by a.匯入資料,SeqNo"  );
                    break;
                case "test":
                    sb.AppendFormat(@"o");
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
        private void F_資料確認(ref DataTable D_table, ref DataTable D_errortable, string str頁簽名稱, IRow row, int i, int 起始欄)
        {
            string StrError = "";

            DataRow D_dataRow = D_table.NewRow();
            DataRow D_erroraRow = D_errortable.NewRow();
            Boolean BError = false;
            #region 基礎資料
            //D_dataRow[0] = str頁簽名稱;

            #endregion
            for (int j = 起始欄 - 1; j < DTDefine.Rows.Count; j++)
            {
                Boolean B是否為必要欄位;
                string Str資料格式 = "";
                if (!Boolean.TryParse(DTDefine.Rows[j]["是否為必要欄位"].ToString(), out B是否為必要欄位))
                {
                    B是否為必要欄位 = false;
                }
                Str資料格式 = DTDefine.Rows[j]["資料格式"].ToString();
                switch (Str資料格式)
                {
                    case "Int":
                        datacheck.IntData(row, DTDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    case "Varchar":
                    case "Nvarchar":
                        datacheck.StringData(row, DTDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    case "Datetime":
                        datacheck.DatetimeData(row, DTDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    case "Float":
                        datacheck.FloatData(row, DTDefine, i, ref StrError, D_dataRow, j, B是否為必要欄位, ref BError);
                        break;
                    default:
                        break;
                }
            }
            DTImportData.Rows.Add(D_dataRow);
            if (BError)
            {
                D_erroraRow[0] = "Row " + i.ToString() + " " + StrError;
                D_errortable.Rows.Add(D_erroraRow);
            }

        }
    }
}