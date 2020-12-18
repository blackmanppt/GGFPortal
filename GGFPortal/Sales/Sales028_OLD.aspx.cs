using AjaxControlToolkit;
using ClosedXML.Excel;
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
    public partial class Sales028_OLD : System.Web.UI.Page
    {
        字串處理 字串處理 = new 字串處理();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        static string StrPageName = "AMZ Po 調整", StrProgram = "Sales028.aspx";
        //static string strArea = "", strImportType = "";
        static string Str匯入定義Table = "河內打樣單";
        static DataSet Ds = new DataSet();
        static 多語 lang = new 多語();
        static DataCheck datacheck = new DataCheck();
        //根錄下的資料夾
        static string Str上傳路徑 = @"~\ExcelUpLoad\Salse\AMZ";
        static List<string> ListColor = new List<string>();
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
                    DataTable DtCula = new DataTable("CulTable");
                    string 副檔名 = System.IO.Path.GetExtension(fileName);
                    if (Session["DataDefine"] != null)
                        Session.Remove("DataDeffine");
                    int I資料起始列;

                    #region 基本資料欄位

                    #endregion

                    #region ErrorTable
                    //D_errortable.Columns.Add("SheetName");
                    //D_errortable.Columns.Add("Dept");
                    D_errortable.Columns.Add("Error");
                    #endregion
                    //
                    //foreach (DataRow Dr in DtColumnDefine.Rows)
                    //{
                    //    D_table.Columns.Add(Dr["資料名稱中文"].ToString());
                    //}

                    I資料起始列 = 0;

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
                            //-- Excel 表頭列
                            XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(I資料起始列);
                            IRow DateRow = (IRow)u_sheet.GetRow(I資料起始列);
                            //i=1第二列開始
                            for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);
                                F_資料確認(ref D_table, ref D_errortable, ref DtCula, row, i);

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
                            str頁簽名稱 = u_sheet.SheetName.ToString();
                            for (int i = I資料起始列; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                            {
                                //--不包含 Excel表頭列的 "其他資料列"
                                IRow row = (IRow)u_sheet.GetRow(i);

                                F_資料確認(ref D_table, ref D_errortable,ref DtCula, row, i);
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
                        var DistinctColor = ListColor.Distinct().ToList();
                        if (DistinctColor.Count() > 0)
                        {
                            using (DataTable dt= DtCula.Clone())
                            {
                                dt.Columns.RemoveAt(1);
                                dt.Columns[0].ColumnName = "單一顏色";
                                foreach (var item in DistinctColor)
                                {
                                    try
                                    {
                                        DataRow dr = dt.NewRow();
                                        dr[0] = item;
                                        DataView dv1 = new DataView(DtCula);
                                        DataView dv2 = new DataView(DtCula);
                                        dv1.RowFilter = " 計算color1 = '" + item + "'";
                                        dv2.RowFilter = " 計算color2 = '" + item + "'";
                                        for (int i = 2; i < dt.Columns.Count + 1; i++)
                                        {
                                            try
                                            {
                                                int x = 0;
                                                if (dv1.Count > 0)
                                                    foreach (DataRowView dv1Row in dv1)
                                                    {
                                                        x += int.Parse(dv1Row[i].ToString());
                                                    }
                                                if (dv2.Count > 0)
                                                    foreach (DataRowView dv2Row in dv2)
                                                    {
                                                        x += int.Parse(dv2Row[i].ToString());
                                                    }
                                                dr[i - 1] = x;
                                            }
                                            catch (Exception ex2)
                                            {

                                            }
                                            
                                        }
                                        dt.Rows.Add(dr);
                                    }
                                    catch (Exception ex1)
                                    {

                                        
                                    }
                                    
                                }
                                if(dt.Rows.Count>0)
                                {
                                    GridView3.DataSource = dt;
                                    GridView3.DataBind();


                                    using (XLWorkbook wb = new XLWorkbook())
                                    {
                                        wb.Worksheets.Add(DtCula, "AMZ_PO_Qty");
                                        wb.Worksheets.Add(dt, "AMZ_Color_Qty");
                                        Response.Clear();
                                        Response.Buffer = true;
                                        Response.Charset = "";
                                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                        Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", "AMZ_PO"));
                                        using (MemoryStream MyMemoryStream = new MemoryStream())
                                        {
                                            wb.SaveAs(MyMemoryStream);
                                            MyMemoryStream.WriteTo(Response.OutputStream);
                                            Response.Flush();
                                            Response.End();
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    F_ErrorShow($"Error: {ex.Message}");
                }
            }
        }

        public void F_ErrorShow(string strError)
        {
            ((Label)Master.FindControl("MessageLB")).Text = strError;
            ((ModalPopupExtender)Master.FindControl("AlertPanel_ModalPopupExtender")).Show();
        }

        private void F_資料確認(ref DataTable D_table,ref DataTable D_errortable,ref DataTable DtCula, IRow row, int i)
        {
            string StrError = "";
            int IRowCount = row.Count();
            
            if (i==0)
            {
                for (int x = 0; x < IRowCount*2; x++)
                {
                    if(x< IRowCount)
                    {
                        if(x<2)
                            D_table.Columns.Add(row.GetCell(x).ToString());
                        else
                        {
                            DataColumn column;
                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.Int32");
                            column.ColumnName =  row.GetCell(x).ToString();
                            D_table.Columns.Add(column);
                        }
                    }
                    else
                    {
                        if ( x<IRowCount * 2-1)
                            if(x<IRowCount+2)
                            {
                                DtCula.Columns.Add("計算" + row.GetCell(x - IRowCount).ToString());
                            }
                            else
                            {
                                DataColumn column;
                                column = new DataColumn();
                                column.DataType = System.Type.GetType("System.Int32");
                                column.ColumnName = "計算" + row.GetCell(x - IRowCount).ToString();
                                DtCula.Columns.Add(column);
                            }
                             

                    }
                }
            }
            else
            {
                DataRow D_dataRow = D_table.NewRow();
                DataRow D_erroraRow = D_errortable.NewRow();
                DataRow D_DtCulDataRow = DtCula.NewRow();
                Boolean BError = false;
                #region 基礎資料
                try
                {
                    int I公式件數總計 = (int)row.GetCell(IRowCount-2).NumericCellValue;
                    int I數量增減 = (int)row.GetCell(IRowCount - 1).NumericCellValue;
                    int I件數總計確認 = 0;
                    int I件異動後總件數 = 0;
                    for (int j = 0; j < IRowCount; j++)
                    {
                        if(j<2)
                        {
                            D_dataRow[j] = row.GetCell(j).ToString().Trim();
                            D_DtCulDataRow[j] = row.GetCell(j).ToString().Trim();
                            ListColor.Add(row.GetCell(j).ToString().Trim());
                        }
                        else
                        {
                            int icount = 0;
                            try
                            {
                                switch (row.GetCell(j).CellType)
                                {
                                    case CellType.Numeric:
                                    case CellType.Formula:
                                        if (j < IRowCount - 2)
                                        {
                                            I件數總計確認 += (int)row.GetCell(j).NumericCellValue;
                                            if (j == IRowCount - 2 && I件數總計確認 != I公式件數總計)
                                            {
                                                BError = true;
                                                StrError = "件數不同：件數加總" + I件數總計確認.ToString() + "，公式加總" + I公式件數總計.ToString();
                                            }
                                            icount = (I數量增減 != 0) ? (int)((float)row.GetCell(j).NumericCellValue + ((float)row.GetCell(j).NumericCellValue / I公式件數總計) * I數量增減) : (int)row.GetCell(j).NumericCellValue;
                                            //D_dataRow[j + IRowCount - 2] = icount;
                                            D_DtCulDataRow[j] = icount;
                                            I件異動後總件數 += icount;
                                        }
                                        if (j == IRowCount - 2)
                                            D_DtCulDataRow[IRowCount - 2] = I件異動後總件數;
                                        D_dataRow[j] = (int)row.GetCell(j).NumericCellValue;
                                        break;
                                    case CellType.Error:
                                    default:
                                        D_dataRow[j] = 0;
                                        break;
                                }
                            }
                            catch (Exception ex2)
                            {
                                F_ErrorShow(ex2.ToString());
                            }
                            

                        }
                    }
                    D_table.Rows.Add(D_dataRow);
                    DtCula.Rows.Add(D_DtCulDataRow);
                    if (BError)
                    {
                        D_erroraRow[0] = "Row " + i.ToString() + " " + StrError;
                        D_errortable.Rows.Add(D_erroraRow);
                    }
                }
                catch (Exception ex)
                {
                    F_ErrorShow(ex.ToString());
                }
                #endregion
            }
        }

        protected void UpLoadBT_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// booking import primary Key
        /// </summary>
        /// <returns>取得新增的 primary Key</returns>
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
    }
}