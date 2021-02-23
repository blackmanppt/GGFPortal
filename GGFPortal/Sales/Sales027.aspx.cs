using AjaxControlToolkit;
using ClosedXML.Excel;
using GGFPortal.ReferenceCode;
using Microsoft.Reporting.WebForms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sales027 : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "AMZ 拆單", StrProgram = "Sales027.aspx";
        static DataSet Ds = new DataSet();
        static 多語 lang = new 多語();
        static DataCheck datacheck = new DataCheck();
        //根錄下的資料夾
        static string Str上傳路徑 = @"~\ExcelUpLoad\";
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

        }
        /// <summary>
        /// file upload input需要的宣告
        /// </summary>
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
        //If this code does not exist in the file, add the code into the file after the following line:

        protected void CheckBT_Click(object sender, EventArgs e)
        {
            if ((upload_file.PostedFile != null) && (upload_file.PostedFile.ContentLength > 0))
            {
                string fileName = System.IO.Path.GetFileName(upload_file.PostedFile.FileName);
                string LocationFiled = Server.MapPath(Str上傳路徑);
                string str頁簽名稱 = "";

                try
                {
                    DataTable D_table = new DataTable("Excel");
                    DataTable D_errortable = new DataTable("Error");
                    string 副檔名 = System.IO.Path.GetExtension(fileName);

                    int  I資料起始列=1;

                    #region 基本資料欄位
                    D_table.Columns.Add("款號");
                    D_table.Columns.Add("地區");
                    D_table.Columns.Add("顏色");
                    D_table.Columns.Add("Size");
                    DataColumn Col數量 = new DataColumn("數量");
                    Col數量.DataType = System.Type.GetType("System.Int32");
                    D_table.Columns.Add(Col數量);
                    #endregion

                    #region ErrorTable

                    D_errortable.Columns.Add("Error");
                    #endregion
                    //
                    if (副檔名.ToUpper() == ".XLSX")
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(upload_file.PostedFile.InputStream);  //==只能讀取 System.IO.Stream
                        for (int x = 0; x < workbook.NumberOfSheets; x++)
                        {
                            //-- 0表示：第一個 worksheet工作表
                            XSSFSheet u_sheet = (XSSFSheet)workbook.GetSheetAt(x);
                            str頁簽名稱 = u_sheet.SheetName.ToString();
                            //-- Excel 表頭列
                            XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(I資料起始列);
                            IRow DateRow = (IRow)u_sheet.GetRow(0);
                            //-- for迴圈的「啟始值」要加一，表示不包含 Excel表頭列
                            // for (int i = (u_sheet.FirstRowNum + 1); i <= u_sheet.LastRowNum; i++)   
                            //-- 每一列做迴圈
                            //i=1第二列開始
                            for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);

                                #region 關鍵資料沒有不執行，避免USER亂填EXCEL
                                string Str款號 = "";
                                try
                                {
                                    Str款號 = row.GetCell(0).ToString();
                                }
                                catch (Exception)
                                {
                                }
                                if (string.IsNullOrEmpty(Str款號))
                                    continue;
                                #endregion
                                F_資料確認(ref D_table, ref D_errortable, str頁簽名稱, row,i, DateRow);
                            }
                            //-- 釋放 NPOI的資源
                            u_sheet = null;
                        }
                        //-- 釋放 NPOI的資源
                        workbook = null;
                    }
                    else
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(upload_file.PostedFile.InputStream);  //==只能讀取 System.IO.Stream
                        for (int x = 0; x < workbook.NumberOfSheets; x++)
                        {
                            HSSFSheet u_sheet = (HSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                            HSSFRow headerRow = (HSSFRow)u_sheet.GetRow(I資料起始列);  //-- Excel 表頭列
                            IRow DateRow = (IRow)u_sheet.GetRow(0);             //-- v.1.2.4版修改
                                                                                     //檢查是否有要對應資料
                            str頁簽名稱 = u_sheet.SheetName.ToString();
                            for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);

                                #region 關鍵資料沒有不執行，避免USER亂填EXCEL
                                string Str款號 = "";
                                try
                                {
                                    Str款號 = row.GetCell(0).ToString();
                                }
                                catch (Exception)
                                {
                                }
                                if (string.IsNullOrEmpty(Str款號))
                                    continue;
                                #endregion
                                F_資料確認(ref D_table, ref D_errortable, str頁簽名稱, row,i, DateRow);
                            }
                            //-- 釋放 NPOI的資源
                            u_sheet = null;
                        }
                        //-- 釋放 NPOI的資源
                        workbook = null;
                    }
                    //--錯誤資料顯示
                    if (D_errortable.Rows.Count > 0)
                    {
                        DataView D_View3 = new DataView(D_errortable);
                    }
                    if (D_table.Rows.Count > 0)
                    {
                        if (D_errortable.Rows.Count == 0)
                        {
                            ReportViewer1.Visible = true;
                            ReportViewer1.ProcessingMode = ProcessingMode.Local;

                            ReportDataSource source = new ReportDataSource("AMZ_Po", D_table);
                            ReportViewer1.LocalReport.DataSources.Clear();
                            if (SumCB.Checked)
                            {
                                ReportViewer1.LocalReport.ReportPath = @"ReportSource\Sales\ReportSales027.rdlc";
                            }
                            else
                            {
                                ReportViewer1.LocalReport.ReportPath = @"ReportSource\Sales\ReportSales027_V2.rdlc";
                            }
                            ReportViewer1.LocalReport.DisplayName = "AMZ_Po拆分";
                            ReportViewer1.LocalReport.DataSources.Add(source);

                            ReportViewer1.DataBind();
                            ReportViewer1.LocalReport.Refresh();
                            ErrorGV.Visible = false;
                        }
                        else
                        {
                            ErrorGV.DataSource = D_errortable;
                            ErrorGV.DataBind();
                            ErrorGV.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    F_ErrorShow($"Error: {ex.Message}"); 
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
       
        private void F_資料確認(ref DataTable D_table,ref DataTable D_errortable, string str頁簽名稱, IRow row, int i, IRow DateRow)
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
            DataRow D_erroraRow = D_errortable.NewRow();
            #region 基礎資料
            //D_dataRow[0] = str頁簽名稱;

            #endregion
            

            try
            {
                //款號
                #region 款號
                string Str款號 = "";
                bool bCheck = true;
                if (row.GetCell(0).CellType == CellType.String || row.GetCell(0).CellType == CellType.Numeric)
                {
                    Str款號 = row.GetCell(0).ToString();
                }
                else
                {
                    StrError += "沒有款號";
                }

                #region 顏色
                string StrColor = "";
                if (row.GetCell(1).CellType == CellType.String)
                {
                    StrColor = row.GetCell(1).ToString();
                }
                else
                {
                    StrError += $"{(StrError.Length > 0 ? "," : "")}沒有顏色";

                }
                #endregion

                #region Size
                string StrSize = "";
                if (row.GetCell(2).CellType == CellType.String)
                {
                    StrSize = row.GetCell(2).ToString();
                }
                else
                {
                    if ("#N/A" == row.GetCell(2).ToString())
                        bCheck = false;
                    StrError += $"{(StrError.Length > 0 ? "," : "")}沒有Size";
                }
                #endregion
                if(bCheck)
                    for (int x = 3; x < row.Count(); x++)
                    {
                        int i數量 = 0;
                        if (row.GetCell(x).CellType == CellType.Numeric)
                        {

                            i數量 = (int)row.GetCell(x).NumericCellValue;
                        }

                        string[] StrArr顏色 = Regex.Split(StrColor, "[/]");

                        if (StrArr顏色.Length > 0)
                        {
                            foreach (var item in StrArr顏色)
                            {
                                if (i數量 > 0 && string.IsNullOrEmpty(StrError))
                                {
                                    D_dataRow = D_table.NewRow();
                                    D_dataRow[0] = Str款號;
                                    D_dataRow[1] = DateRow.GetCell(x);
                                    D_dataRow[2] = item;
                                    D_dataRow[3] = StrSize;
                                    D_dataRow[4] = i數量;
                                    D_table.Rows.Add(D_dataRow);
                                }
                            
                            }
                        }
                    }
                //int I數量US = 0, I數量EU=0, I數量JP=0;
                //if (row.GetCell(3).CellType == CellType.Numeric)
                //{
                //    I數量US = (int)row.GetCell(3).NumericCellValue;
                //}
                //if(row.Cells.Count > 4)
                //    if (row.GetCell(4).CellType == CellType.Numeric)
                //    {
                //        I數量EU = (int)row.GetCell(4).NumericCellValue;
                //    }
                //if(row.Cells.Count>5)
                //    if (row.GetCell(5).CellType == CellType.Numeric)
                //    {
                //        I數量JP = (int)row.GetCell(5).NumericCellValue;
                //    }
                //if(I數量US==0&& I數量EU==0&& I數量JP==0)
                //{
                //    StrError += $"{(StrError.Length > 0 ? "," : "")}沒有數量";
                //}
                #endregion
                //NA資料不檢查
                if (StrError.Length>0&&bCheck)
                {
                    D_erroraRow[0] = "Row " + i.ToString() + " " + StrError;
                    D_errortable.Rows.Add(D_erroraRow);
                }
            }
            catch (Exception ex)
            {

                F_ErrorShow(ex.Message.ToString());
            }
            

        }

        protected void UpLoadBT_Click(object sender, EventArgs e)
        {
            F_UpLoad();
        }

        protected void ExportBT_Click(object sender, EventArgs e)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add((DataTable)Session["ImportExcelData"], "AMZ");
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", "AMZ_Po"));
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
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
        /// <summary>
        /// 將Session的資料上傳到資料庫
        /// </summary>
        public void F_UpLoad()
        {
           
        }
    }
}