using System;
using System.Data;
using System.Web.UI;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Net;
using GGFPortal.ReferenceCode;
using System.Collections.Generic;

namespace GGFPortal.FactoryMG
{
    public partial class F002 : System.Web.UI.Page
    {
        SysLog Log = new SysLog();
        DataCheck 確認LOCK = new DataCheck();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        static string strConnectString1 = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        //static string strImportType = "Package";
        string strArea = "", strImportType = "", StrRedirect,StrTeam;
        string StrPageName = "TempCode", StrProgram = "F002.aspx";
        多語 lang = new 多語();
        List<Column1> xx=new List<Column1>();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //清空Error資料
            Session.Remove("Error");
            try
            {
                if (!string.IsNullOrEmpty(Session["Area"].ToString()) && !string.IsNullOrEmpty(Session["Team"].ToString()))
                {
                    strImportType = Session["Team"].ToString();
                    strArea = Session["Area"].ToString();
                    lang.讀取多語資料("Factory");
                    StrRedirect = "Findex.aspx";
                    switch (strArea)
                    {
                        case "VGG":

                            StrTeam = lang.gg.Find(p => p.資料代號 == strImportType).越文;
                            break;
                        case "GAMA":
                            StrTeam = lang.gg.Find(p => p.資料代號 == strImportType).英文;
                            break;
                        default:
                            Session["Error"] = "Session Timeout";
                            Response.Redirect(StrRedirect);
                            break;
                    }
                    TypeLB.Text = StrTeam;
                    AreaLB.Text = strArea;
                    Page.Title = strArea + StrTeam;
                }
                else
                {
                    Session["Error"] = "Session Timeout";
                    Response.Redirect(StrRedirect);
                }
                    
            }
            catch (Exception ex)
            {
                Session["Error"] = "Page_PreInit Error :" + ex.ToString();
                Response.Redirect(StrRedirect);
                throw;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    SearchTB.Attributes["readonly"] = "readonly";
            //    strArea = (Request.Params["AREA"] != null) ? Request.Params["AREA"] : "";
            //    strImportType = (Request.Params["TYPE"] != null) ? Request.Params["TYPE"] : "";
            //    if (strArea == "" || strImportType == "")
            //        Response.Redirect(StrRedirect);
            //    AreaLB.Text = strArea;
            //}
            //catch (Exception)
            //{
            //    Session.RemoveAll();
            //    Session["Error"] = "Session Timeout";
            //    Response.Redirect(StrRedirect);
            //    throw;
            //}


            //TypeLB.Text = strImportType;
            //switch (strImportType)
            //{
            //    case "Stitch":
            //        TypeLB.Text = "Stitch";
            //        break;
            //    case "Package":
            //        TypeLB.Text = "Đóng gói";
            //        break;
            //    case "Cut":
            //        TypeLB.Text = "Cắt";
            //        break;
            //    case "Iron":
            //        TypeLB.Text = "Là";
            //        break;
            //    case "QC":
            //        TypeLB.Text = "Kiểm tra chất lượng";
            //        break;
            //    default:
            //        Response.Redirect("VNindex.aspx");
            //        break;
            //}

        }

        protected void TeamCodeBT_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString1"].ConnectionString.ToString());
            SqlDataAdapter myAdapter = new SqlDataAdapter(@"SELECT [dept_no] ,[dept_name] ,remark as Old_dept_no FROM [dbo].[GGB_dept] 
                                                    where dept_no like 'A%' or  dept_no like 'C%' or  dept_no like 'D%' 
                                                    or dept_no like 'R%' or  dept_no like 'V%'", Conn);
            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "GGB_dept");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            GGFPortal.ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
            xx.ExcelWithNPOI(ds.Tables["GGB_dept"], @"xlsx");
        }
        protected void CheckBT_Click(object sender, EventArgs e)
        {
            if (確認LOCK.Check工時Lock(strArea, SearchTB.Text))
            {

                Column1 GetExcelDefine = new Column1();
                switch(strImportType)
                {
                    case "Stitch":
                        GetExcelDefine.VNStitchmain(strArea); //車縫
                        break;
                    case "Package":
                        GetExcelDefine.VNPackagemain(strArea);//包裝
                        break;
                    case "Cut":
                        GetExcelDefine.VNCutmain(strArea);//裁剪
                        break;
                    case "Iron":
                        GetExcelDefine.VNIronmain(strArea);//整燙
                        break;
                    case "QC":
                        GetExcelDefine.VNQCmain(strArea);//品檢
                        break;
                    default:
                        Response.Redirect(StrProgram);
                        break;
                }
                
                String savePath = Server.MapPath(@"~\ExcelUpLoad\"+ strArea + @"\");

                DataTable D_table = new DataTable("Excel");
                D_table = GetExcelDefine.ExcelTable.Copy();
                DataTable D_errortable = new DataTable("Error");
                //實際顯示欄位
                int Excel欄位數 = D_table.Columns.Count-2;
                if (SearchTB.Text.Length > 0 && F_CheckData())
                {
                    if (FileUpload1.HasFile)
                    {
                        String fileName = FileUpload1.FileName;
                        Session["FileName"] = fileName;
                        savePath = savePath + fileName;
                        FileUpload1.SaveAs(savePath);

                        //Label1.Text = "Kiểm tra tệp tin dữ liệu thành công, tên tệp tin---- " + fileName;
                        //--------------------------------------------------
                        //---- （以上是）上傳 FileUpload的部分，成功運作！
                        //--------------------------------------------------

                        
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
                                Session["Date"] = SearchTB.Text;

                                //-- for迴圈的「啟始值」要加一，表示不包含 Excel表頭列
                                // for (int i = (u_sheet.FirstRowNum + 1); i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                                for (int i = 3; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    DataRow D_dataRow = D_table.NewRow();
                                    DataRow D_erroraRow = D_errortable.NewRow();
                                    D_dataRow[0] = u_sheet.SheetName.ToString();
                                    D_dataRow[1] = SearchTB.Text;
                                    bool bcheck = true, berror = false;
                                    string sError = "";
                                    //for (int j = row.FirstCellNum; j < row.LastCellNum; j++)   //-- 每一個欄位做迴圈
                                    for (int j = row.FirstCellNum; j < Excel欄位數; j++)   //有些EXCEL會沒填資料
                                    {
                                        //沒有Style就不抓
                                        if (row.GetCell(2) == null)
                                        {
                                            bcheck = false;
                                            break;
                                        }

                                        switch (GetExcelDefine.VNExcel[j + 2].ColumnType)
                                        {
                                            // Type 1：數字 , Type 2：String , Type 3：日期  , Type 6：不需要資料 String, Type 7：不需要資料 int
                                            case 1:
                                                IntData(row, D_dataRow, ref berror, ref sError, i, j, 1, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 2:
                                                StringData(row, D_dataRow, ref berror, ref sError, i, j, 1, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 3:
                                                try
                                                {
                                                    D_dataRow[j + 2] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).DateCellValue.ToString("yyyyMMdd");
                                                    //轉換日期格式
                                                }
                                                catch 
                                                {
                                                    //D_dataRow[j] = row.GetCell(j).CellFormula.ToString();
                                                    berror = true;
                                                    sError += "第" + (i - 4).ToString() + "行、" + GetExcelDefine.VNExcel[j + 2].ChineseName + "日期格式錯誤。";
                                                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                                                                                                                                   //throw;
                                                }
                                                break;
                                            case 4:
                                                FloatData(row, D_dataRow, ref berror, ref sError, i, j, 1, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 6:
                                                StringData(row, D_dataRow, ref berror, ref sError, i, j, 0, GetExcelDefine.VNExcel[j + 2].ChineseName);
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
                                                IntData(row, D_dataRow, ref berror, ref sError, i, j, 0, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 8:
                                                FloatData(row, D_dataRow, ref berror, ref sError, i, j, 0, GetExcelDefine.VNExcel[j + 2].ChineseName);

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
                                        D_erroraRow[2] = "Hàng thứ " + i.ToString() + sError;
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
                            //GridView1.DataSource = D_View2;
                            //GridView1.DataBind();
                            for (int i = 0; i < Excel欄位數+2; i++)
                            {
                                ExcelGV.HeaderRow.Cells[i].Text = GetExcelDefine.VNExcel[i].VNName;
                            }
                            
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

                            HSSFWorkbook workbook = new HSSFWorkbook(FileUpload1.FileContent);  //==只能讀取 System.IO.Stream
                            for (int x = 0; x < workbook.NumberOfSheets; x++)
                            {
                                HSSFSheet u_sheet = (HSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                                HSSFRow headerRow = (HSSFRow)u_sheet.GetRow(3);  //-- Excel 表頭列
                                IRow DateRow = (IRow)u_sheet.GetRow(2);             //-- v.1.2.4版修改
                                Session["Date"] = SearchTB.Text;

                                for (int i = 3; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    DataRow D_dataRow = D_table.NewRow();
                                    DataRow D_erroraRow = D_errortable.NewRow();
                                    D_dataRow[0] = u_sheet.SheetName.ToString();
                                    D_dataRow[1] = SearchTB.Text;
                                    bool bcheck = true, berror = false;
                                    string sError = "";
                                    //for (int j = row.FirstCellNum; j < row.LastCellNum; j++)   //-- 每一個欄位做迴圈
                                    for (int j = row.FirstCellNum; j < Excel欄位數; j++)   //有些EXCEL會沒填資料
                                    {
                                        //沒有Style就不抓
                                        if (row.GetCell(2) == null)
                                        {
                                            bcheck = false;
                                            break;
                                        }
                                        switch (GetExcelDefine.VNExcel[j + 2].ColumnType)
                                        {
                                            // Type 1：數字 , Type 2：String , Type 3：日期  , Type 6：不需要資料 String, Type 7：不需要資料 int
                                            case 1:
                                                IntData(row, D_dataRow, ref berror, ref sError, i, j, 1, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 2:
                                                StringData(row, D_dataRow, ref berror, ref sError, i, j, 1, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 3:
                                                try
                                                {
                                                    D_dataRow[j + 2] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).DateCellValue.ToString("yyyyMMdd");
                                                    //轉換日期格式
                                                }
                                                catch 
                                                {
                                                    //D_dataRow[j] = row.GetCell(j).CellFormula.ToString();
                                                    berror = true;
                                                    sError += "Hàng thứ " + i.ToString() + "、" + GetExcelDefine.VNExcel[j + 2].ChineseName + "error5。";
                                                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                                                                                                                                   //throw;
                                                }
                                                break;
                                            case 4:
                                                FloatData(row, D_dataRow, ref berror, ref sError, i, j, 1, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 6:
                                                StringData(row, D_dataRow, ref berror, ref sError, i, j, 0, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 7:
                                                IntData(row, D_dataRow, ref berror, ref sError, i, j, 0, GetExcelDefine.VNExcel[j + 2].ChineseName);
                                                break;
                                            case 8:
                                                FloatData(row, D_dataRow, ref berror, ref sError, i, j, 0, GetExcelDefine.VNExcel[j + 2].ChineseName);
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
                                        D_erroraRow[2] = "Hàng thứ " + i.ToString()+ sError;
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
                else
                {
                    if (F_CheckData() == false)
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('當日已有匯入資料');</script>");
                    else
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇匯入日期');</script>");
                }

            }
            else
            {
                DataLock();
            }
        }
        private static void StringData(IRow row, DataRow D_dataRow, ref bool berror, ref string sError, int i, int j, int x, string ColumnName)
        {
            try
            {
                if (x == 1&& row.GetCell(j)==null)
                {
                    berror = true;
                    sError += "NoData" + ColumnName ;
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow

                }
                else
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
                                sError += "StyleCheck" + strString ;
                            }
                            reader.Close();
                        }
                    }
                }

            }
            catch 
            {
                //x==1代表需要檢查資料
                if (x == 1)
                {
                    berror = true;
                    sError += "ImportError" + ColumnName ;
                }
                //else
                //    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄匯入失敗(非必要資料不影響匯入)。";
                D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                //throw;
            }
        }

        private static void IntData(IRow row, DataRow D_dataRow, ref bool berror, ref string sError, int i, int j, int x,string ColumnName)
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
                catch 
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError += "int Error1。" + ColumnName ;
                    }
                    //else
                    //    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : "0";  //--每一個欄位，都加入同一列 DataRow
                }
            }
            else
            {
                try
                {
                    int iout = 0;
                    if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                    {
                        if (x == 1)
                        {
                            berror = true;
                            sError += "NoData" + ColumnName ;
                        }
                        D_dataRow[j + 2] = "0";  //--每一個欄位，都加入同一列 DataRow
                    }
                    else
                    {
                        if (int.TryParse(row.GetCell(j).ToString(), out iout) == false)
                        {
                            if (x == 1)
                            {
                                berror = true;
                                sError += "int Error2" + ColumnName + row.GetCell(j).ToString()+ "。";
                            }
                            //else
                            //    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字(非必要資料不影響匯入)。";
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow

                        }
                        else
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow 
                    }
                    //D_dataRow[j + 2] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "0" : (int.TryParse( row.GetCell(j).ToString(),out iout)==false)?"0": row.GetCell(j).ToString();   //--每一個欄位，都加入同一列 DataRow
                }
                catch 
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError += "Number Error2。" + ColumnName;
                    }
                    //else
                    //    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                    //throw;
                }
            }
        }

        private static void FloatData(IRow row, DataRow D_dataRow, ref bool berror, ref string sError, int i, int j, int x, string ColumnName)
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
                catch 
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError += "Float Error1" + ColumnName;
                    }
                    //else 
                    //    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "欄公式錯誤(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "" : "0";  //--每一個欄位，都加入同一列 DataRow
                }

            }
            else
            {

                try
                {

                    if (string.IsNullOrEmpty(row.GetCell(j).ToString()))
                    {
                        if (x == 1)
                        {
                            berror = true;
                            sError += "NoData" + ColumnName;
                        }
                        D_dataRow[j + 2] = "0" ;  //--每一個欄位，都加入同一列 DataRow
                    }
                    else
                    {
                        double dout = 0;
                        if (double.TryParse(row.GetCell(j).ToString(), out dout) == false)
                        {
                            if (x == 1)
                            {
                                berror = true;
                                sError +=  ColumnName + "Float Error2";
                            }
                            //else
                            //    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字(非必要資料不影響匯入)。";
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                        }
                        else
                            D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow 
                    }
                }
                catch 
                {
                    if (x == 1)
                    {
                        berror = true;
                        sError +=  ColumnName + "非數字。";
                    }
                    //else
                    //    sError += "第" + i.ToString() + "行、第" + (j).ToString() + "非數字(非必要資料不影響匯入)。";
                    D_dataRow[j + 2] = (row.GetCell(j) == null) ? "0" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
                    //throw;
                }
            }
        }
        //抓HeadID
        private int GetExcelIdex()
        {
            Int32 ProductivityHeadID = 0;
            string sql =
                @"INSERT INTO [dbo].[Productivity_Head]
                    (FileName,Area,Creator,Team,Date)
                    VALUES(@FileName,@Area,'Program',@Team,@Date); 
                    SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar);
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Area", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Team", SqlDbType.NVarChar);
                cmd.Parameters["@Date"].Value = SearchTB.Text;
                cmd.Parameters["@FileName"].Value = Session["FileName"].ToString();
                cmd.Parameters["@Area"].Value = strArea;
                cmd.Parameters["@Team"].Value = strImportType;
                try
                {
                    conn.Open();
                    ProductivityHeadID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Get Productivity_Head uid Error" + Session["FileName"].ToString() + ":", StrProgram);
                }
            }
            return (int)ProductivityHeadID;
        }

        protected void UpLoadBT_Click(object sender, EventArgs e)
        {
            if(SearchTB.Text.Trim()!=""&&F_CheckData())
            { 
                if (Session["ExcelError"] == null)
                    if (Session["Excel"] != null)
                    {
                        DataTable dt = (DataTable)Session["Excel"];
                        int iIndex = 0;
                        iIndex = GetExcelIdex();
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
                                        string strInsertColumn="", strInsertData="";
                                        if (strImportType=="Stitch")
                                        {
                                            strInsertColumn = ",[QCQty],[ErrorQty],[OnlineDay],[ErrorRate]";
                                            strInsertData = ",@QCQty ,@ErrorQty,@OnlineDay,@ErrorRate";
                                        }
                                        //TypeLB.Text = i.ToString();
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
                                                       ,[Creator] {0})
                                                 VALUES
                                                       ({1}
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
                                                       ,'Program' {2} )
                                                       ", strInsertColumn, iIndex, strInsertData);
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
                                        if (strImportType == "Stitch")
                                        {
                                            command1.Parameters.Add("@QCQty", SqlDbType.Int).Value = dt.Rows[i]["QCQty"].ToString();
                                            command1.Parameters.Add("@ErrorQty", SqlDbType.Int).Value = dt.Rows[i]["ErrorQty"].ToString();
                                            //command1.Parameters.Add("@ErrorUnreturnQty", SqlDbType.Int).Value = dt.Rows[i]["ErrorQty"].ToString();
                                            command1.Parameters.Add("@OnlineDay", SqlDbType.Int).Value = dt.Rows[i]["OnlineDay"].ToString();
                                            command1.Parameters.Add("@ErrorRate", SqlDbType.Int).Value = dt.Rows[i]["ErrorRate"].ToString();
                                        }
                                        command1.ExecuteNonQuery();
                                        command1.Parameters.Clear();
                                    }
                                    //上傳成功更新Head狀態
                                    command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 1 ,[Date] = @Date WHERE uid = {0} ", iIndex);
                                    command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = Session["Date"].ToString();
                                    command1.ExecuteNonQuery();
                                    transaction1.Commit();
                                    Label1.Text = "DataUpSuccess";
                                }
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
                                        Label1.Text = "DataUpfail";
                                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('匯入失敗請連絡MIS');</script>");
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
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('單頭匯入失敗請連絡MIS');</script>");
                    }
            }
            else
            {
                if(F_CheckData()==false)
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('HaveData');</script>");
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Import Date');</script>");
            }
        }

        protected void TempExcel_Click(object sender, EventArgs e)
        {
            //宣告並建立WebClient物件
            WebClient wc = new WebClient();
            byte[] b=null;
            
            switch (strImportType)
            {

                case "Stitch":
                    //GetExcelDefine.VNStitchmain(); //車縫
                    b = wc.DownloadData(Server.MapPath("~\\FactoryMG\\Temp\\Excel\\Sample車縫.xlsx"));
                    break;
                case "Package":
                    b = wc.DownloadData(Server.MapPath("~\\FactoryMG\\Temp\\Excel\\Sample包裝.xlsx"));
                    break;
                case "Cut":
                    b = wc.DownloadData(Server.MapPath("~\\FactoryMG\\Temp\\Excel\\Sample採剪.xlsx"));
                    break;
                case "Iron":
                    b = wc.DownloadData(Server.MapPath("~\\FactoryMG\\Temp\\Excel\\Sample包裝.xlsx"));
                    break;
                case "QC":
                    b = wc.DownloadData(Server.MapPath("~\\FactoryMG\\Temp\\Excel\\Sample品檢.xlsx"));
                    break;
                default:
                    Response.Redirect("Factoryindex.aspx");
                    break;
            }
            //載入要下載的檔案
            //byte[] b = wc.DownloadData(path);

            //清除Response內的HTML
            Response.Clear();

            //設定標頭檔資訊 attachment 是本文章的關鍵字
            Response.AddHeader("Content-Disposition", "attachment;filename="+ strImportType + ".xlsx");

            //開始輸出讀取到的檔案
            Response.BinaryWrite(b);

            //一定要加入這一行，否則會持續把Web內的HTML文字也輸出。
            Response.End();

        }

        protected void DeleteBT_Click(object sender, EventArgs e)
        {
            if (確認LOCK.Check工時Lock(strArea, SearchTB.Text))
            {
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
                        command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 2,[ModifyDate]=GETDATE()  WHERE Team = @Team and [Date] = @Date and [Flag] = 1 ");
                        command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SearchTB.Text;
                        command1.Parameters.Add("@Team", SqlDbType.NVarChar).Value = strImportType;
                        command1.ExecuteNonQuery();
                        transaction1.Commit();
                        Label1.Text = "刪除完畢，請再次夾檔";
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Delete Error :" , StrProgram);
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Delete Error Error:" , StrProgram);
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Delete Failed');</script>");
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
            }
            else
            {
                DataLock();
            }
        }

        private void DataLock()
        {
            Label1.Text = "資料已鎖定，請洽管理者";
        }

        public Boolean F_CheckData()
        {
            bool bcheck = true;
            if (確認LOCK.Check工時Lock(strArea, SearchTB.Text))
            { 
                using (SqlConnection conn = new SqlConnection(strConnectString1))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = @"SELECT [uid]
                                              ,[Team]
                                              ,[FileName]
                                              ,[Date]
                                              ,[Area]
                                              ,[Flag]
                                              ,[CreateDate]
                                              ,[Creator]
                                            FROM [dbo].[Productivity_Head]
                                            where Team = @Team and Date = @Date and Flag = 1";
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@Team", SqlDbType.NVarChar).Value =strImportType ;
                    command.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SearchTB.Text;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        bcheck = false;
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                    }
                    reader.Close();
                }
            }
            else
            {
                bcheck = false;
                DataLock();
            }
            return bcheck;
        }
        
    }
}