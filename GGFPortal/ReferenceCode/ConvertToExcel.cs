using ClosedXML.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class ConvertToExcel
    {
        public class Excute
        {
            public bool BError { get; set; }
            public string Str { get; set; }
        }
        /// <summary>
        /// NPOI轉excel
        /// </summary>
        /// <param name="dt">轉出資料</param>
        /// <param name="extension">轉出文件格式,xlsx or xls</param>
        public void ExcelWithNPOI(DataTable dt, string extension)
        {

            IWorkbook workbook;
            if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (extension == "xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }

            ISheet sheet1;
            if (dt.TableName != string.Empty)
            {
                sheet1 = workbook.CreateSheet(dt.TableName);
            }
            else
            {
                sheet1 = workbook.CreateSheet("Sheet1");
            }

            //ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            for (int j = 0; j < dt.Columns.Count; j++)
            {

                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }

            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }

            using (var exportData = new MemoryStream())
            {
                HttpContext.Current.Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", DateTime.Now.ToString("yyyymmdd") + ".xlsx"));
                    HttpContext.Current.Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", DateTime.Now.ToString("yyyymmdd") + ".xls"));
                    HttpContext.Current.Response.BinaryWrite(exportData.GetBuffer());
                }
                HttpContext.Current.Response.End();
            }
        }
        /// <summary>
        /// CloseExcel資料匯出
        /// </summary>
        /// <param name="DT匯出資料"></param>
        /// <param name="Str檔案名稱"></param>
        /// <returns>Error 結果</returns>
        public string ExportExcelByCloseExcel(DataTable DT匯出資料, string Str檔案名稱)
        {
            string StrError = "";
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(DT匯出資料, Str檔案名稱);
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xlsx", Str檔案名稱));
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(HttpContext.Current.Response.OutputStream);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.End();
                    }
                }
            }
            catch (Exception ex)
            {

                StrError = ex.ToString();
            }
            return StrError;
        }
    }
}