﻿using AjaxControlToolkit;
using GGFPortal.ReferenceCode;
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
        static string StrPageName = "AMZ 拆單", StrProgram = "TempCode.aspx";
        //static string strArea = "", strImportType = "";
        static string Str匯入定義Table = "河內打樣單";
        static string Str匯入Head = "GGF河內打樣單Head", Str匯入Line = "GGF河內打樣單";
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
        /// <summary>
        /// file upload input需要的宣告
        /// </summary>
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
                string LocationFiled = Server.MapPath(Str上傳路徑);
                string str頁簽名稱 = "";

                try
                {
                    DataTable D_table = new DataTable("Excel");
                    DataTable D_errortable = new DataTable("Error");
                    string 副檔名 = System.IO.Path.GetExtension(fileName);
                    //DataTable DtColumnDefine = GetDBData("欄位定義");
                    //if(Session["DataDefine"]!=null)
                    //    Session.Remove("DataDeffine");
                    //Session["DataDeffine"] = DtColumnDefine;
                    //指定Import Sheet Name
                    //string StrSheetNameCheck = "";
                    //Boolean BCheck = false;
                    int  I資料起始列=3;

                    #region 基本資料欄位
                    D_table.Columns.Add("款號");
                    D_table.Columns.Add("顏色");
                    D_table.Columns.Add("數量");
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
                            //檢查是否有要對應資料
                            //if (BCheck && StrSheetNameCheck != str頁簽名稱)
                            //{
                            //    continue;
                            //}
                            //-- Excel 表頭列
                            XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(I資料起始列);
                            IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);
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
                                    Str款號 = row.GetCell(3).ToString();
                                }
                                catch (Exception)
                                {
                                }
                                if (string.IsNullOrEmpty(Str款號))
                                    continue;
                                #endregion
                                F_資料確認(ref D_table, ref D_errortable, str頁簽名稱, row,i);
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
                            IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);             //-- v.1.2.4版修改
                                                                                     //檢查是否有要對應資料
                            //if (BCheck && StrSheetNameCheck != str頁簽名稱)
                            //{
                            //    continue;
                            //}
                            str頁簽名稱 = u_sheet.SheetName.ToString();
                            for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);

                                #region 關鍵資料沒有不執行，避免USER亂填EXCEL
                                string Str款號 = "";
                                try
                                {
                                    Str款號 = row.GetCell(3).ToString();
                                }
                                catch (Exception)
                                {
                                }
                                if (string.IsNullOrEmpty(Str款號))
                                    continue;
                                #endregion
                                F_資料確認(ref D_table, ref D_errortable, str頁簽名稱, row,i);
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
                        ErrorGV.DataSource = D_View3;
                        ErrorGV.DataBind();
                    }
                    if (D_table.Rows.Count > 0)
                    {
                        GridView1.DataSource = D_table;
                        GridView1.DataBind();
                        if (D_errortable.Rows.Count == 0)
                        {
                            Session["ImportExcelData"] = D_table;
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
       
        private void F_資料確認(ref DataTable D_table,ref DataTable D_errortable, string str頁簽名稱, IRow row, int i)
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
            Boolean BError = false;
            #region 基礎資料
            //D_dataRow[0] = str頁簽名稱;

            #endregion
            

            try
            {
                //款號
                #region 款號
                string Str款號 = "";
                if (row.GetCell(3).CellType == CellType.String)
                {
                    Str款號 = row.GetCell(3).ToString();
                }
                else
                {
                    StrError += "沒有款號";
                }
                #endregion
                //數量
                #region 數量

                int I數量 = 0;
                if (row.GetCell(13).CellType == CellType.Numeric)
                {
                    I數量 = (int)row.GetCell(13).NumericCellValue;
                }
                else
                {
                    StrError += $"{(StrError.Length > 0 ? "," : "")}沒有數量";
                }
                #endregion
                #region 顏色
                string StrColor = "";
                if (row.GetCell(5).CellType == CellType.String)
                {
                    StrColor = row.GetCell(5).ToString();
                }
                else
                {
                    StrError += $"{(StrError.Length>0?",":"")}沒有顏色";
                    
                }
                    
                
                StringBuilder 多筆資料 = new StringBuilder("");
                string[] stringSeparators = new string[] { "/" };
                string[] StrArr顏色 = StrColor.Split(stringSeparators, StringSplitOptions.None);

                //string[] strtextarry = SplitEnter(strtext);
                if (StrArr顏色.Length > 0)
                {
                    foreach (var item in StrArr顏色)
                    {
                        D_dataRow[0] = Str款號;
                        D_dataRow[1] = item;
                        D_dataRow[2] = I數量;
                        D_table.Rows.Add(D_dataRow);
                    }
                  
                }
                #endregion


                if (StrError.Length>0)
                {
                    D_erroraRow[0] = "Row " + i.ToString() + " " + StrError;
                    D_errortable.Rows.Add(D_erroraRow);
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        protected void UpLoadBT_Click(object sender, EventArgs e)
        {
            F_UpLoad();
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