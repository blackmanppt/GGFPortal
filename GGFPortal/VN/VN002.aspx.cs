using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GGFPortal.VN
{
    public partial class VN002 : System.Web.UI.Page
    {
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        static string strConnectString1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TeamCodeBT_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString1"].ConnectionString.ToString());
            SqlDataAdapter myAdapter = new SqlDataAdapter("SELECT [dept_no] ,[dept_name]  FROM[GGF].[dbo].[GGB_dept]", Conn);
            DataSet ds = new DataSet();

            myAdapter.Fill(ds, "GGB_dept");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。


            GGFPortal.ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
            xx.ExcelWithNPOI(ds.Tables["GGB_dept"], @"xlsx");
        }
        public class Column
        {
            public int ColumnID { get; set; }
            public string ColumnName { get; set; }

            public int ColumnType { get; set; }
        }

        protected void CheckBT_Click(object sender, EventArgs e)
        {
            List<Column> InsertColumn = new List<Column>();
            // Type 1：int , Type 2：String , Type 3：日期 , Type 4：float, Type 6：不需要資料 String, Type 7：不需要資料 int , Type 8：float 不需要資料
            InsertColumn.Add(new Column() { ColumnID = 1, ColumnName = "SheetName", ColumnType = 2 });
            InsertColumn.Add(new Column() { ColumnID = 2, ColumnName = "Date", ColumnType = 3 });
            InsertColumn.Add(new Column() { ColumnID = 3, ColumnName = "Dept", ColumnType = 2 });
            InsertColumn.Add(new Column() { ColumnID = 4, ColumnName = "Customer", ColumnType = 2 });
            InsertColumn.Add(new Column() { ColumnID = 5, ColumnName = "StyleNo", ColumnType = 2 });
            InsertColumn.Add(new Column() { ColumnID = 6, ColumnName = "OrderQty", ColumnType = 1 });
            InsertColumn.Add(new Column() { ColumnID = 7, ColumnName = "TeamProductivity", ColumnType = 1 });
            InsertColumn.Add(new Column() { ColumnID = 8, ColumnName = "OrderShipDate", ColumnType = 3 });
            InsertColumn.Add(new Column() { ColumnID = 9, ColumnName = "OnlineDate", ColumnType = 3 });
            InsertColumn.Add(new Column() { ColumnID = 10, ColumnName = "StandardProductivity", ColumnType = 4 });
            InsertColumn.Add(new Column() { ColumnID = 11, ColumnName = "Person", ColumnType = 4 });
            InsertColumn.Add(new Column() { ColumnID = 12, ColumnName = "TotalTime", ColumnType = 4 });
            InsertColumn.Add(new Column() { ColumnID = 13, ColumnName = "Time", ColumnType = 4 });
            InsertColumn.Add(new Column() { ColumnID = 14, ColumnName = "Percent", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 15, ColumnName = "GoalProductivity", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 16, ColumnName = "DayProductivity", ColumnType = 1 });
            InsertColumn.Add(new Column() { ColumnID = 17, ColumnName = "PreProductivity", ColumnType = 7 });
            InsertColumn.Add(new Column() { ColumnID = 18, ColumnName = "TotalProductivity", ColumnType = 7 });
            InsertColumn.Add(new Column() { ColumnID = 19, ColumnName = "Difference", ColumnType = 7 });
            InsertColumn.Add(new Column() { ColumnID = 20, ColumnName = "Efficiency", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 21, ColumnName = "TotalEfficiency", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 22, ColumnName = "ReturnPercent", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 23, ColumnName = "Rmark1", ColumnType = 6 });
            InsertColumn.Add(new Column() { ColumnID = 24, ColumnName = "Rmark2", ColumnType = 6 });
            InsertColumn.Add(new Column() { ColumnID = 25, ColumnName = "DayCost1", ColumnType = 4 });
            InsertColumn.Add(new Column() { ColumnID = 26, ColumnName = "DayCost2", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 27, ColumnName = "DayCost3", ColumnType = 4 });
            InsertColumn.Add(new Column() { ColumnID = 28, ColumnName = "DayCost4", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 29, ColumnName = "DayCost5", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 30, ColumnName = "DayCost6", ColumnType = 8 });
            InsertColumn.Add(new Column() { ColumnID = 30, ColumnName = "DayCost7", ColumnType = 4 });


            String savePath = Server.MapPath(@"~\ExcelUpLoad\Salse\");

            DataTable D_table = new DataTable("Excel");
            DataTable D_errortable = new DataTable("Error");
            if (FileUpload1.HasFile)
            {
                String fileName = FileUpload1.FileName;
                Session["FileName"] = fileName;
                savePath = savePath + fileName;
                FileUpload1.SaveAs(savePath);

                Label1.Text = "上傳成功，檔名---- " + fileName;
                //--------------------------------------------------
                //---- （以上是）上傳 FileUpload的部分，成功運作！
                //--------------------------------------------------

                #region TableTitle excel排序
                D_table.Columns.Add("SheetName");
                D_table.Columns.Add("Date");
                D_table.Columns.Add("Dept");
                D_table.Columns.Add("Customer");
                D_table.Columns.Add("StyleNo");
                D_table.Columns.Add("OrderQty");
                D_table.Columns.Add("TeamProductivity");
                D_table.Columns.Add("OrderShipDate");
                D_table.Columns.Add("OnlineDate");
                D_table.Columns.Add("StandardProductivity");
                D_table.Columns.Add("Person");
                D_table.Columns.Add("TotalTime");
                D_table.Columns.Add("Time");
                D_table.Columns.Add("Percent");
                D_table.Columns.Add("GoalProductivity");
                D_table.Columns.Add("DayProductivity");
                D_table.Columns.Add("PreProductivity");
                D_table.Columns.Add("TotalProductivity");
                D_table.Columns.Add("Difference");
                D_table.Columns.Add("Efficiency");
                D_table.Columns.Add("TotalEfficiency");
                D_table.Columns.Add("ReturnPercent");
                D_table.Columns.Add("Rmark1");
                D_table.Columns.Add("Rmark2");
                D_table.Columns.Add("DayCost1");
                D_table.Columns.Add("DayCost2");
                D_table.Columns.Add("DayCost3");
                D_table.Columns.Add("DayCost4");
                D_table.Columns.Add("DayCost5");
                D_table.Columns.Add("DayCost6");
                D_table.Columns.Add("DayCost7");
                #endregion
                #region ErrorTable
                D_errortable.Columns.Add("SheetName");
                D_errortable.Columns.Add("Dept");
                D_errortable.Columns.Add("Error");
                #endregion


                if (fileName.Substring(fileName.Length - 4, 4).ToUpper() == "XLSX")
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(FileUpload1.FileContent);  //==只能讀取 System.IO.Stream

                    for (int x = 0; x < workbook.NumberOfSheets; x++)
                    {
                        XSSFSheet u_sheet = (XSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                        XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(3);  //-- Excel 表頭列
                        IRow DateRow = (IRow)u_sheet.GetRow(2);             //-- v.1.2.4版修改
                        Session["Date"] = DateRow.GetCell(19).DateCellValue.ToString("yyyyMMdd");

                        //-- for迴圈的「啟始值」要加一，表示不包含 Excel表頭列
                        // for (int i = (u_sheet.FirstRowNum + 1); i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                        for (int i = 5; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                        {
                            //--不包含 Excel表頭列的 "其他資料列"
                            IRow row = (IRow)u_sheet.GetRow(i);
                            DataRow D_dataRow = D_table.NewRow();
                            DataRow D_erroraRow = D_errortable.NewRow();
                            D_dataRow[0] = u_sheet.SheetName.ToString();
                            D_dataRow[1] = DateRow.GetCell(19).DateCellValue.ToString("yyyyMMdd");
                            bool bcheck = true, berror = false;
                            string sError = "";
                            for (int j = row.FirstCellNum; j < row.LastCellNum; j++)   //-- 每一個欄位做迴圈
                            {
                                //沒有Style就不抓
                                if (string.IsNullOrEmpty(row.GetCell(2).ToString()))
                                {
                                    bcheck = false;
                                    break;
                                }
                                switch (InsertColumn[j+2].ColumnType)
                                {
                                    // Type 1：數字 , Type 2：String , Type 3：日期  , Type 6：不需要資料 String, Type 7：不需要資料 int
                                    case 1:
                                        IntData(row, D_dataRow, ref berror, ref sError, i, j, 1);
                                        break;
                                    case 2:
                                        StringData(row, D_dataRow, ref berror, ref sError, i, j, 1);
                                        break;
                                    case 3:
                                        try
                                        {
                                            D_dataRow[j + 2] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).DateCellValue.ToString("yyyyMMdd");
                                            //轉換日期格式
                                        }
                                        catch (Exception ex)
                                        {
                                            //D_dataRow[j] = row.GetCell(j).CellFormula.ToString();
                                            berror = true;
                                            sError += "第" + i.ToString() + "行、第" + (j + 2).ToString() + "欄公式錯誤4：";
                                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                                                                                                                           //throw;
                                        }
                                        break;
                                    case 4:
                                        FloatData(row, D_dataRow, ref berror, ref sError, i, j, 1);
                                        break;
                                    case 6:
                                        StringData(row, D_dataRow, ref berror, ref sError, i, j, 0);
                                        #region string old
                                        ////-- 檢查這一格，是否包含公式（Formula）？ 
                                        //if ((row.GetCell(j) != null) && (row.GetCell(j).CellType == CellType.Formula))  //== v.1.2.4版修改。2.x版只是修正英文大小寫。
                                        //{
                                        //    try
                                        //    {
                                        //        D_dataRow[j + 2] = row.GetCell(j).NumericCellValue.ToString();
                                        //    }
                                        //    catch (Exception ex)
                                        //    {

                                        //        D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : "0";  //--每一個欄位，都加入同一列 DataRow
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    try
                                        //    {
                                        //        D_dataRow[j + 2] = row.GetCell(j).NumericCellValue.ToString();
                                        //    }
                                        //    catch (Exception ex)
                                        //    {

                                        //        D_dataRow[j + 2] = "";  //--每一個欄位，都加入同一列 DataRow
                                        //    }
                                        //}
                                        #endregion
                                        break;
                                    case 7:
                                        IntData(row, D_dataRow, ref berror, ref sError, i, j, 0);
                                        break;
                                    case 8:
                                        FloatData(row, D_dataRow, ref berror, ref sError, i, j, 0);

                                        break;

                                    default:
                                        break;

                                        //-- CellType需要搭配「NPOI.SS.UserModel命名空間」

                                }
                            }
                            if (bcheck)
                                D_table.Rows.Add(D_dataRow);
                            if (berror)
                            {
                                D_erroraRow[0] = u_sheet.SheetName.ToString();
                                D_erroraRow[1] = row.GetCell(0).ToString();
                                D_erroraRow[2] = sError;
                                D_errortable.Rows.Add(D_erroraRow);
                            }
                        }
                        //-- 釋放 NPOI的資源
                        u_sheet = null;
                    }
                    //-- 釋放 NPOI的資源
                    workbook = null;
                    //--Excel資料顯示             
                    DataView D_View2 = new DataView(D_table);
                    //GridView1.DataSource = D_View2;
                    //GridView1.DataBind();
                    ExcelGV.DataSource = D_View2;
                    ExcelGV.DataBind();
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

                    XSSFWorkbook workbook = new XSSFWorkbook(FileUpload1.FileContent);  //==只能讀取 System.IO.Stream
                    for (int x = 0; x < workbook.NumberOfSheets; x++)
                    {
                        HSSFSheet u_sheet = (HSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                        HSSFRow headerRow = (HSSFRow)u_sheet.GetRow(3);  //-- Excel 表頭列
                        IRow DateRow = (IRow)u_sheet.GetRow(2);             //-- v.1.2.4版修改
                        Session["Date"] = DateRow.GetCell(19).DateCellValue.ToString("yyyyMMdd");

                        for (int i = 5; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                        {
                            //--不包含 Excel表頭列的 "其他資料列"
                            IRow row = (IRow)u_sheet.GetRow(i);
                            DataRow D_dataRow = D_table.NewRow();
                            DataRow D_erroraRow = D_errortable.NewRow();
                            D_dataRow[0] = u_sheet.SheetName.ToString();
                            D_dataRow[1] = DateRow.GetCell(19).DateCellValue.ToString("yyyyMMdd");
                            bool bcheck = true, berror = false;
                            string sError = "";
                            for (int j = row.FirstCellNum; j < row.LastCellNum; j++)   //-- 每一個欄位做迴圈
                            {
                                //沒有Style就不抓
                                if (string.IsNullOrEmpty(row.GetCell(2).ToString()))
                                {
                                    bcheck = false;
                                    break;
                                }
                                switch (InsertColumn[j+2].ColumnType)
                                {
                                    // Type 1：數字 , Type 2：String , Type 3：日期  , Type 6：不需要資料 String, Type 7：不需要資料 int
                                    case 1:
                                        IntData(row, D_dataRow, ref berror, ref sError, i, j, 1);
                                        break;
                                    case 2:
                                        StringData(row, D_dataRow, ref berror, ref sError, i, j, 1);
                                        break;
                                    case 3:
                                        try
                                        {
                                            D_dataRow[j + 2] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).DateCellValue.ToString("yyyyMMdd");
                                            //轉換日期格式
                                        }
                                        catch (Exception ex)
                                        {
                                            //D_dataRow[j] = row.GetCell(j).CellFormula.ToString();
                                            berror = true;
                                            sError += "第" + i.ToString() + "行、第" + (j + 2).ToString() + "欄公式錯誤5。";
                                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                                                                                                                           //throw;
                                        }
                                        break;
                                    case 4:
                                        FloatData(row, D_dataRow, ref berror, ref sError, i, j, 1);
                                        break;
                                    case 6:
                                        StringData(row, D_dataRow, ref berror, ref sError, i, j, 0);
                                        break;
                                    case 7:
                                        IntData(row, D_dataRow, ref berror, ref sError, i, j, 0);
                                        break;
                                    case 8:
                                        FloatData(row, D_dataRow, ref berror, ref sError, i, j, 0);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (bcheck)
                                D_table.Rows.Add(D_dataRow);
                            if (berror)
                            {
                                D_erroraRow[0] = u_sheet.SheetName.ToString();
                                D_erroraRow[1] = row.GetCell(0).ToString();
                                D_erroraRow[2] = sError;
                                D_errortable.Rows.Add(D_erroraRow);
                            }
                        }
                        //-- 釋放 NPOI的資源
                        u_sheet = null;
                    }
                    //-- 釋放 NPOI的資源
                    workbook = null;
                    //--Excel資料顯示             
                    DataView D_View2 = new DataView(D_table);
                    //GridView1.DataSource = D_View2;
                    //GridView1.DataBind();
                    ExcelGV.DataSource = D_View2;
                    ExcelGV.DataBind();
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
                Label1.Text = "????  ...... 請先挑選檔案之後，再來上傳";
            }   // FileUpload使用的第一個 if判別式

            if (D_table.Rows.Count > 0)
                Session["Excel"] = D_table;
            else
            {
                Session["Excel"] = null;
                ExcelGV.DataSource = null;
                ExcelGV.DataBind();

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
        private static void StringData(IRow row, DataRow D_dataRow, ref bool berror, ref string sError, int i, int j, int x)
        {
            try
            {
                string strString = "";
                strString = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).ToString().Trim();   //--每一個欄位，都加入同一列 DataRow
                D_dataRow[j + 2] = strString;
                if (j==2)
                {
                    using (SqlConnection conn = new SqlConnection(strConnectString1))
                    {
                        // Create the command and set its properties.
                        SqlCommand command = new SqlCommand();
                        command.Connection = conn;
                        command.CommandText = "select * from ordc_bah1 where bah_status<> 'CA' and cus_item_no = @cus_item_no";
                        command.CommandType = CommandType.Text;

                        // Add the input parameter and set its properties.
                        SqlParameter parameter = new SqlParameter();
                        parameter.ParameterName = "@cus_item_no";
                        parameter.SqlDbType = SqlDbType.NVarChar;
                        parameter.Direction = ParameterDirection.Input;
                        parameter.Value = strString;

                        // Add the parameter to the Parameters collection. 
                        command.Parameters.Add(parameter);

                        // Open the connection and execute the reader.
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows==false)
                        {
                            berror = true;
                            sError += "Style_no("+ strString + ")：沒有資料";
                        }
                        reader.Close();
                    }
                }
                
            }
            catch (Exception ex)
            {
                //x==1代表需要檢查資料
                if (x == 1)
                {
                    berror = true;
                    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄匯入失敗。";
                }
                else
                    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄匯入失敗(非必要資料不影響匯入)。";
                D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                //throw;
            }
        }

        private static void IntData(IRow row, DataRow D_dataRow, ref bool berror, ref string sError, int i, int j, int x)
        {
            //x==1代表需要檢查資料
            if ((row.GetCell(j) != null) && (row.GetCell(j).CellType == CellType.Formula))  //== v.1.2.4版修改。2.x版只是修正英文大小寫。
            {
                //D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                ////-- 表示格子裡面，公式運算後的「值」，是數字（Numeric）。
                try
                {
                    D_dataRow[j + 2] = row.GetCell(j).NumericCellValue.ToString();
                }
                catch (Exception ex)
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤1。";
                    }
                    else
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : "0";  //--每一個欄位，都加入同一列 DataRow
                }

            }
            else
            {

                try
                {
                    int iout = 0;
                    if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                        D_dataRow[j + 2] = "0";
                    else
                    {
                        if (int.TryParse(row.GetCell(j).ToString(), out iout) == false)
                        {
                            if (x == 1)
                            {
                                berror = true;
                                sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字：" + row.GetCell(j).ToString();
                            }
                            else
                                sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字(非必要資料不影響匯入)。";
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow

                        }
                        else
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow 
                    }
                    //D_dataRow[j + 2] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "0" : (int.TryParse( row.GetCell(j).ToString(),out iout)==false)?"0": row.GetCell(j).ToString();   //--每一個欄位，都加入同一列 DataRow
                }
                catch (Exception ex)
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤2。";
                    }
                    else
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                    //throw;
                }
            }
        }

        private static void FloatData(IRow row, DataRow D_dataRow, ref bool berror, ref string sError, int i, int j, int x)
        {
            //x==1代表需要檢查資料
            if ((row.GetCell(j) != null) && (row.GetCell(j).CellType == CellType.Formula))  //== v.1.2.4版修改。2.x版只是修正英文大小寫。
            {
                //D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                ////-- 表示格子裡面，公式運算後的「值」，是數字（Numeric）。
                try
                {
                    D_dataRow[j + 2] = row.GetCell(j).NumericCellValue.ToString();
                }
                catch (Exception ex)
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤3。";
                    }
                    else
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : "0";  //--每一個欄位，都加入同一列 DataRow
                }

            }
            else
            {

                try
                {

                    if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                        D_dataRow[j + 2] = "0";
                    else
                    {
                        double dout = 0;
                        if (double.TryParse(row.GetCell(j).ToString(), out dout) == false)
                        {
                            if (x == 1)
                            {
                                berror = true;
                                sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字。";
                            }
                            else
                                sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字(非必要資料不影響匯入)。";
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                        }
                        else
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow 
                    }
                }
                catch (Exception ex)
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字。";
                    }
                    else
                        sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                    //throw;
                }
            }
        }
        //抓HeadID
        private int GetExcelIdex(string strArea)
        {
            Int32 ProductivityHeadID = 0;
            string sql =
                @"INSERT INTO [dbo].[Productivity_Head]
                    (FileName,Area,Creator)
                    VALUES(@FileName,@Area,'Program'); 
                    SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.Add("@Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Area", SqlDbType.NVarChar);
                //cmd.Parameters["@Date"].Value = strDate;
                cmd.Parameters["@FileName"].Value = Session["FileName"].ToString();
                cmd.Parameters["@Area"].Value = strArea;
                try
                {
                    conn.Open();
                    ProductivityHeadID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Get Productivity_Head uid Error" + Session["FileName"].ToString() + ":", "VN002.aspx");
                }
            }
            return (int)ProductivityHeadID;
        }

        protected void UpLoadBT_Click(object sender, EventArgs e)
        {
            if(SearchTB.Text.Trim()!="")
            { 
                if (Session["ExcelError"] == null)
                    if (Session["Excel"] != null)
                    {
                        DataTable dt = (DataTable)Session["Excel"];
                        Label2.Text = dt.Rows[2][2].ToString();
                        int iIndex = 0;
                        iIndex = GetExcelIdex("VGG");
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
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        Label2.Text = i.ToString();
                                        command1.CommandText = string.Format(@"INSERT INTO [dbo].[Productivity_Line]
                                                       ([uid]
                                                       ,[SheetName]
                                                       ,[Dept]
                                                       ,[Customer]
                                                       ,[StyleNo]
                                                       ,[OrderQty]
                                                       ,[OrderShipDate]
                                                       ,[OnlineDate]
                                                       ,[StandardProductivity]
                                                       ,[TeamProductivity]
                                                       ,[GoalProductivity]
                                                       ,[DayProductivity]
                                                       ,[PreProductivity]
                                                       ,[TotalProductivity]
                                                       ,[Person]
                                                       ,[TotalTime]
                                                       ,[Time]
                                                       ,[Percent]
                                                       ,[Difference]
                                                       ,[Efficiency]
                                                       ,[TotalEfficiency]
                                                       ,[ReturnPercent]
                                                       ,[Rmark1]
                                                       ,[Rmark2]
                                                       ,[DayCost1]
                                                       ,[DayCost2]
                                                       ,[DayCost3]
                                                       ,[DayCost4]
                                                       ,[DayCost5]
                                                       ,[DayCost6]
                                                       ,[DayCost7]
                                                       ,[Creator])
                                                 VALUES
                                                       ({0}
                                                       ,@SheetName
                                                       ,@Dept
                                                       ,@Customer
                                                       ,@StyleNo
                                                       ,@OrderQty
                                                       ,@OrderShipDate
                                                       ,@OnlineDate
                                                       ,@StandardProductivity
                                                       ,@TeamProductivity
                                                       ,@GoalProductivity
                                                       ,@DayProductivity
                                                       ,@PreProductivity
                                                       ,@TotalProductivity
                                                       ,@Person
                                                       ,@TotalTime
                                                       ,@Time
                                                       ,@Percent
                                                       ,@Difference
                                                       ,@Efficiency
                                                       ,@TotalEfficiency
                                                       ,@ReturnPercent
                                                       ,@Rmark1
                                                       ,@Rmark2
                                                       ,@DayCost1
                                                       ,@DayCost2
                                                       ,@DayCost3
                                                       ,@DayCost4
                                                       ,@DayCost5
                                                       ,@DayCost6
                                                       ,@DayCost7
                                                       ,'Program')
                                                       ", iIndex);
                                        command1.Parameters.Add("@SheetName", SqlDbType.NVarChar).Value = dt.Rows[i]["SheetName"].ToString();
                                        command1.Parameters.Add("@Dept", SqlDbType.NVarChar).Value = dt.Rows[i]["Dept"].ToString();
                                        command1.Parameters.Add("@Customer", SqlDbType.NVarChar).Value = dt.Rows[i]["Customer"].ToString();
                                        command1.Parameters.Add("@StyleNo", SqlDbType.NVarChar).Value = dt.Rows[i]["StyleNo"].ToString();
                                        command1.Parameters.Add("@OrderQty", SqlDbType.Int).Value = dt.Rows[i]["OrderQty"].ToString();
                                        command1.Parameters.Add("@OrderShipDate", SqlDbType.NVarChar).Value = dt.Rows[i]["OrderShipDate"].ToString();
                                        command1.Parameters.Add("@OnlineDate", SqlDbType.NVarChar).Value = dt.Rows[i]["OnlineDate"].ToString();
                                        command1.Parameters.Add("@StandardProductivity", SqlDbType.Float).Value = dt.Rows[i]["StandardProductivity"].ToString();
                                        command1.Parameters.Add("@TeamProductivity", SqlDbType.Int).Value = dt.Rows[i]["TeamProductivity"].ToString();
                                        command1.Parameters.Add("@GoalProductivity", SqlDbType.Float).Value = dt.Rows[i]["GoalProductivity"].ToString();
                                        command1.Parameters.Add("@DayProductivity", SqlDbType.Int).Value = dt.Rows[i]["DayProductivity"].ToString();
                                        command1.Parameters.Add("@PreProductivity", SqlDbType.Int).Value = dt.Rows[i]["PreProductivity"].ToString();
                                        command1.Parameters.Add("@TotalProductivity", SqlDbType.Int).Value = dt.Rows[i]["TotalProductivity"].ToString();
                                        command1.Parameters.Add("@Person", SqlDbType.Float).Value = dt.Rows[i]["Person"].ToString();
                                        command1.Parameters.Add("@TotalTime", SqlDbType.Float).Value = dt.Rows[i]["TotalTime"].ToString();
                                        command1.Parameters.Add("@Time", SqlDbType.Float).Value = dt.Rows[i]["Time"].ToString();
                                        command1.Parameters.Add("@Percent", SqlDbType.Float).Value = dt.Rows[i]["Percent"].ToString();
                                        command1.Parameters.Add("@Difference", SqlDbType.Int).Value = dt.Rows[i]["Difference"].ToString();
                                        command1.Parameters.Add("@Efficiency", SqlDbType.Float).Value = dt.Rows[i]["Efficiency"].ToString();
                                        command1.Parameters.Add("@TotalEfficiency", SqlDbType.Float).Value = dt.Rows[i]["TotalEfficiency"].ToString();
                                        command1.Parameters.Add("@ReturnPercent", SqlDbType.Float).Value = dt.Rows[i]["ReturnPercent"].ToString();
                                        command1.Parameters.Add("@Rmark1", SqlDbType.NVarChar).Value = dt.Rows[i]["Rmark1"].ToString();
                                        command1.Parameters.Add("@Rmark2", SqlDbType.NVarChar).Value = dt.Rows[i]["Rmark2"].ToString();
                                        command1.Parameters.Add("@DayCost1", SqlDbType.Float).Value = dt.Rows[i]["DayCost1"].ToString();
                                        command1.Parameters.Add("@DayCost2", SqlDbType.Float).Value = dt.Rows[i]["DayCost2"].ToString();
                                        command1.Parameters.Add("@DayCost3", SqlDbType.Float).Value = dt.Rows[i]["DayCost3"].ToString();
                                        command1.Parameters.Add("@DayCost4", SqlDbType.Float).Value = dt.Rows[i]["DayCost4"].ToString();
                                        command1.Parameters.Add("@DayCost5", SqlDbType.Float).Value = dt.Rows[i]["DayCost5"].ToString();
                                        command1.Parameters.Add("@DayCost6", SqlDbType.Float).Value = dt.Rows[i]["DayCost6"].ToString();
                                        command1.Parameters.Add("@DayCost7", SqlDbType.Float).Value = dt.Rows[i]["DayCost7"].ToString();

                                        command1.ExecuteNonQuery();
                                        command1.Parameters.Clear();
                                    }
                                    //上傳成功更新Head狀態
                                    command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 1 ,[Date] = @Date WHERE uid = {0} ", iIndex);
                                    command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Session["Date"].ToString();
                                    command1.ExecuteNonQuery();
                                    transaction1.Commit();
                                }
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
                                    }
                                }
                                finally
                                {
                                    conn1.Close();
                                    conn1.Dispose();
                                    command1.Dispose();
                                    Session.RemoveAll();
                                }
                            }
                        else
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('匯入失敗請連絡MIS');</script>");
                    }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇匯入日期');</script>");
            }
        }
    }
}