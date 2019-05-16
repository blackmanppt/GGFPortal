using GGFPortal.DataSetSource;
using NPOI.SS.UserModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using GGFPortal.ReferenceCode;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace GGFPortal.Finance
{

    public partial class Finance016 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        SysLog Log = new SysLog();
        資料庫搜尋條件 addid = new 資料庫搜尋條件();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Today"]==null)
            //{
            //    Session["Today"] = DateTime.Now.ToString("yyyy-MM-dd");
            //}
        }


        /// <summary>
        /// 確認資料正確性
        /// </summary>
        /// <param name="D_table">正常資料</param>
        /// <param name="D_errortable">回傳Error</param>
        /// <param name="str頁簽名稱">Sheetname</param>
        /// <param name="row">列資料</param>
        private void F_資料確認(DataTable D_table, DataTable D_errortable, string str頁簽名稱, IRow row)
        {
            StringBuilder sbError = new StringBuilder();
            bool berror = false;
            //Regex資料驗證規則
            //string strRegex工號 = "V[0-9]{4}", strRegex工段 = "[0-9]{3}", strRegex數量 = "[0-9]{4}";
            //string strRegex日期 = "\\b(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})\\b";
            #region old code驗證區

            string str幣別 = "";
            float f賣出 = 0,f買進=0;
            try
            {
                //幣別
                if (!string.IsNullOrEmpty(row.GetCell(0).ToString()))
                {
                    if (row.GetCell(0).ToString().ToUpper() == "NULL")
                    {
                        berror = 錯誤訊息(sbError, "幣別資料為NULL");
                    }
                    else
                    {
                        str幣別 = row.GetCell(0).ToString().ToUpper();
                        sbError.AppendFormat("幣別：{0}", str幣別);
                    }
                }
                //賣出單價
                if (!string.IsNullOrEmpty(row.GetCell(2).ToString()))
                {
                    if (row.GetCell(2).ToString().ToUpper() == "NULL")
                    {
                        berror = 錯誤訊息(sbError, "賣出資料資料為NULL");
                    }
                    else
                    {
                        float.TryParse(row.GetCell(2).NumericCellValue.ToString(),out f賣出);
                    }
                }
                //買進單價
                if (!string.IsNullOrEmpty(row.GetCell(3).ToString()))
                {
                    if (row.GetCell(3).ToString().ToUpper() == "NULL")
                    {
                        berror = 錯誤訊息(sbError, "買進資料資料為NULL");
                    }
                    else
                    {
                        float.TryParse(row.GetCell(3).NumericCellValue.ToString(), out f買進);
                    }
                }
            }
            catch (Exception ex)
            {
                berror = 錯誤訊息(sbError,"資料轉換錯誤" + ex.ToString());
                throw;
            }
            
            if (!berror)
            {
                DataRow D_dataRow = D_table.NewRow();
                D_dataRow[0] = str幣別;
                D_dataRow[1] = f賣出;
                D_dataRow[2] = f買進;
                D_table.Rows.Add(D_dataRow);
            }
            else
            {
                DataRow D_erroraRow = D_errortable.NewRow();
                D_erroraRow[0] = sbError;
                D_errortable.Rows.Add(D_erroraRow);
            }
            #endregion

        }

        /// <summary>
        /// 將Session的資料上傳到資料庫
        /// </summary>
        public void F_UpLoad()
        {
            //有錯誤資料不給匯入
            //if (SearchTB.Text.Trim() != "" && F_CheckData() && Session["ExcelError"] == null)
            if(Session["ExcelError"] == null)
            {
                if (Session["Excel"] != null)
                {
                    DataTable dt = (DataTable)Session["Excel"];
                    using (SqlConnection conn1 = new SqlConnection(strConnectString))
                    {
                        SqlCommand command1 = conn1.CreateCommand();
                        SqlTransaction transaction1;
                        conn1.Open();
                        transaction1 = conn1.BeginTransaction("CreateBas_customs_rateImport");

                        command1.Connection = conn1;
                        command1.Transaction = transaction1;
                        try
                        {
                            DateTime dtTime = Convert.ToDateTime(Session["三巡時間年"].ToString() + "-" + Session["三巡時間月"].ToString() + "-01");

                            string str三巡時間巡 = Session["str三巡時間巡"].ToString();
                            string str三巡時間年 = Session["三巡時間年"].ToString();
                            string str三巡時間月 = Session["三巡時間月"].ToString();
                            DateTime dt三巡起, dt三巡迄;
                            switch (str三巡時間巡)
                            {
                                case "1":
                                    dt三巡起 = Convert.ToDateTime(str三巡時間年 + "-" + str三巡時間月 + "-01");
                                    dt三巡迄 = Convert.ToDateTime(str三巡時間年 + "-" + str三巡時間月 + "-10");
                                    break;
                                case "2":
                                    dt三巡起 = Convert.ToDateTime(str三巡時間年 + "-" + str三巡時間月 + "-11");
                                    dt三巡迄 = Convert.ToDateTime(str三巡時間年 + "-" + str三巡時間月 + "-20");
                                    break;
                                default:
                                    dt三巡起 = Convert.ToDateTime(str三巡時間年 + "-" + str三巡時間月 + "-21");
                                    dt三巡迄 = dtTime.AddMonths(1).AddDays(-1);
                                    break;
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {


                                command1.CommandText = string.Format(@"INSERT INTO [dbo].[bas_customs_rate]
                                                    ([site]
                                                    ,[year_month]
                                                    ,[period_type]
                                                    ,[base_currency]
                                                    ,[work_currency]
                                                    ,[start_date]
                                                    ,[end_date]
                                                    ,[import_rate]
                                                    ,[export_rate]
                                                    ,[creator]
                                                    ,[create_date]
                                                    ,[modifier]
                                                    ,[modify_date])
                                                VALUES
                                                    ('GGF'
                                                    ,@year_month
                                                    ,@period_type
                                                    ,'NTD'
                                                    ,@work_currency
                                                    ,@start_date
                                                    ,@end_date
                                                    ,@import_rate
                                                    ,@export_rate
                                                    ,@creator
                                                    ,getdate()
                                                    ,@creator
                                                    ,getdate()
                                                    )
                                                    ");
                                command1.Parameters.Add("@year_month", SqlDbType.NVarChar).Value = str三巡時間年+ str三巡時間月;
                                command1.Parameters.Add("@period_type", SqlDbType.NVarChar).Value = str三巡時間巡;
                                command1.Parameters.Add("@work_currency", SqlDbType.NVarChar).Value = dt.Rows[i]["外匯幣別"].ToString();
                                command1.Parameters.Add("@start_date", SqlDbType.DateTime).Value = dt三巡起;
                                command1.Parameters.Add("@end_date", SqlDbType.DateTime).Value = dt三巡迄;
                                command1.Parameters.Add("@import_rate", SqlDbType.Decimal).Value = dt.Rows[i]["買進匯率"].ToString();
                                command1.Parameters.Add("@export_rate", SqlDbType.Decimal).Value = dt.Rows[i]["賣出匯率"].ToString();
                                command1.Parameters.Add("@creator", SqlDbType.NVarChar).Value = "104056";

                                command1.ExecuteNonQuery();
                                command1.Parameters.Clear();
                            }
                            
                            
                            
                            transaction1.Commit();
                        }
                        #region 匯入ErrorLog
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Import Excel Error :" + Session["FileName"].ToString(), "Finance016.aspx");
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Insert Error Error:" + Session["FileName"].ToString(), "Finance016.aspx");
                            }
                            finally
                            {
                                transaction1.Rollback();
                                F_ErrorShow("匯入失敗請連絡MIS");
                            }
                        }
                        #endregion
                        finally
                        {
                            conn1.Close();
                            conn1.Dispose();
                            command1.Dispose();
                            Session.RemoveAll();
                            DataGV.DataSource = null;
                            DataGV.DataBind();
                            F_Show(false);
                            
                        }
                    }
                }
            }
            else
            {
                if (Session["ExcelError"] != null)
                    F_ErrorShow("請修正錯誤資料");
                //else if (SearchTB.Text.Trim() != "")
                //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('當日已有匯入資料');</script>");
                //else
                //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇匯入日期');</script>");
            }
        }

        /// <summary>
        /// 錯誤訊息紀錄
        /// </summary>
        /// <param name="sbError">錯誤字串</param>
        /// <param name="strerror">欲添加錯誤字串</param>
        /// <returns></returns>
        private static bool 錯誤訊息(StringBuilder sbError, string strerror)
        {
            bool berror = true;
            sbError.Append(strerror);
            return berror;
        }

        /// <summary>
        /// 顯示匯入異常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void show3_Click(object sender, EventArgs e)
        {
            F_ErrorShow("Show Error");
        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        protected void DataCheckBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(文件上傳FU.FileName))
                F_LoadExcel();
            else
                F_ErrorShow("未夾檔案");
        }
        public void F_LoadExcel()
        {
            //引用//ReferenceCode/ExcelColumn.cs的類別
            CustomerRate GetExcelDefine = new CustomerRate();
            //導入匯入table
            GetExcelDefine.RateDT();
            //上傳路徑
            String savePath = Server.MapPath(@"~\ExcelUpLoad\Finance\CustomerRate");
            string str頁簽名稱 = "", str三巡時間年 = "", str三巡時間月 = "", str三巡時間巡 = "";
            DataTable D_table = new DataTable("Excel");
            //建立Excel欄位
            D_table = GetExcelDefine.CustomerRateDataTable.Copy();
            DataTable D_errortable = new DataTable("Error");
            //實際顯示欄位
            int Excel欄位數 = D_table.Columns.Count - 2;
            int iyear = 0;
            if (文件上傳FU.HasFile)
            {
                string fileName = 文件上傳FU.FileName;
                Session["FileName"] = fileName;
                savePath = savePath + fileName;
                文件上傳FU.SaveAs(savePath);
                
                bool bCheckTime = true,bCheckDB = true;

                #region ErrorTable
                //                    D_errortable.Columns.Add("SheetName");
                D_errortable.Columns.Add("Error");
                //D_errortable.Columns.Add("Error");
                #endregion


                if (fileName.Substring(fileName.Length - 4, 4).ToUpper() == "XLSX")
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(文件上傳FU.FileContent);  //==只能讀取 System.IO.Stream

                    for (int x = 0; x < workbook.NumberOfSheets; x++)
                    {
                        XSSFSheet u_sheet = (XSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                        XSSFRow headerRow = (XSSFRow)u_sheet.GetRow(3);  //-- Excel 表頭列
                        //抓第一行資料
                        IRow DateRow = (IRow)u_sheet.GetRow(0);             //-- v.1.2.4版修改
                        //Session["Date"] = SearchTB.Text;
                        str頁簽名稱 = u_sheet.SheetName.ToString();
                        //str三巡時間 = DateRow.GetCell(3).ToString();
                        if ("三巡外匯表" == str頁簽名稱 )
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(DateRow.Cells[5].ToString()))
                                    bCheckTime = false;
                                str三巡時間年 = DateRow.Cells[5].ToString();
                                if (string.IsNullOrEmpty(DateRow.Cells[7].ToString()))
                                    bCheckTime = false;
                                str三巡時間月 = DateRow.Cells[7].ToString();
                                if (string.IsNullOrEmpty(DateRow.Cells[9].ToString()))
                                    bCheckTime = false;
                                str三巡時間巡 = DateRow.Cells[9].ToString();
                                int.TryParse(str三巡時間年, out iyear);
                                if (iyear > 0)
                                {
                                    iyear = iyear + 1911;
                                    str三巡時間年 = iyear.ToString();
                                }
                                else
                                    bCheckTime = false;
                                if (bCheckTime)
                                {
                                    bCheckDB = F_CheckData(str三巡時間巡, str三巡時間年 + str三巡時間月);
                                }

                            }
                            catch (Exception)
                            {
                                //日期確認失敗
                                bCheckTime = false;
                            }
                            //執行程式
                            if (bCheckTime && bCheckDB)
                            {

                                //i=1第二列開始
                                for (int i = 1; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    F_資料確認(D_table, D_errortable, str頁簽名稱, row);
                                }
                            }
                            else if(!bCheckTime)
                            {
                                F_ErrorShow("三巡日期錯誤");
                            }

                        }
                        //-- 釋放 NPOI的資源
                        u_sheet = null;
                    }
                    //-- 釋放 NPOI的資源
                    workbook = null;
                }
                else
                {

                    HSSFWorkbook workbook = new HSSFWorkbook(文件上傳FU.FileContent);  //==只能讀取 System.IO.Stream
                    for (int x = 0; x < workbook.NumberOfSheets; x++)
                    {
                        HSSFSheet u_sheet = (HSSFSheet)workbook.GetSheetAt(x);  //-- 0表示：第一個 worksheet工作表
                        HSSFRow headerRow = (HSSFRow)u_sheet.GetRow(3);  //-- Excel 表頭列
                        IRow DateRow = (IRow)u_sheet.GetRow(2);             //-- v.1.2.4版修改
                        str頁簽名稱 = u_sheet.SheetName.ToString();

                        if ("三巡外匯表" == str頁簽名稱)
                        {
                            try
                            {
                                if (string.IsNullOrEmpty(DateRow.Cells[5].ToString()))
                                    bCheckTime = false;
                                //str三巡時間年 = DateRow.Cells[5].ToString();
                                if (string.IsNullOrEmpty(DateRow.Cells[7].ToString()))
                                    bCheckTime = false;
                                str三巡時間月 = DateRow.Cells[7].ToString();
                                if (string.IsNullOrEmpty(DateRow.Cells[9].ToString()))
                                    bCheckTime = false;
                                str三巡時間巡 = DateRow.Cells[9].ToString();
                                int.TryParse(str三巡時間年, out iyear);
                                if (iyear > 0)
                                {
                                    iyear = iyear + 1911;
                                    str三巡時間年 = iyear.ToString();
                                }
                                else
                                    bCheckTime = false;
                                if (bCheckTime)
                                {
                                    bCheckTime = F_CheckData(str三巡時間巡, str三巡時間年 + str三巡時間月);
                                }

                            }
                            catch (Exception)
                            {
                                //日期確認失敗
                                bCheckTime = false;
                            }
                            //執行程式
                            if (bCheckTime)
                            {
                                //i=1第二列開始
                                for (int i = 1; i <= u_sheet.LastRowNum; i++)   //-- 每一列做迴圈
                                {
                                    //--不包含 Excel表頭列的 "其他資料列"
                                    IRow row = (IRow)u_sheet.GetRow(i);
                                    F_資料確認(D_table, D_errortable, str頁簽名稱, row);
                                }
                            }
                            else
                            {
                                F_ErrorShow("三巡日期錯誤");
                            }

                        }
                        //-- 釋放 NPOI的資源
                        u_sheet = null;
                    }
                    //-- 釋放 NPOI的資源
                    workbook = null;
                }
            }
            else
            {
                F_Show(false);
                F_ErrorShow("????  ...... 請先挑選檔案之後，再來上傳");
            }   // FileUpload使用的第一個 if判別式

            if (D_table.Rows.Count > 0)
            {
                Session["Excel"] = D_table;
                Session["三巡時間年"] = iyear.ToString();
                Session["三巡時間月"] = str三巡時間月;
                Session["str三巡時間巡"] = str三巡時間巡;
                YearLB.Text= iyear.ToString();
                MonthLB.Text = str三巡時間月;
                switch (str三巡時間巡)
                {
                    case "1":
                        三巡LB.Text = "上巡";
                        break;
                    case "2":
                        三巡LB.Text = "中巡";
                        break;
                    default:
                        三巡LB.Text = "下巡";
                        break;
                }
                F_Show(true);
                DataGV.DataSource = D_table;
                DataGV.DataBind();
            }
            else
            {
                Session["Excel"] = null;
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
        /// <summary>
        /// 資料鎖定驗證
        /// </summary>
        /// <returns></returns>
        private bool F_CheckData(string strPType,string strDate)
        {
            bool bcheck = true;

            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                // 海關三巡沒有越盾，User可能會手動輸入
                command.CommandText = @"SELECT top 1 *
                                            FROM [dbo].[bas_customs_rate]
                                            where [period_type] = @PType and [year_month] = @Date and work_currency <>'VND'";
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@Date", SqlDbType.NVarChar).Value = strDate;
                command.Parameters.Add("@PType", SqlDbType.NVarChar).Value = strPType;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    bcheck = false;
                }
                reader.Close();
                if (!bcheck)
                {
                    F_ErrorShow("資料庫已有資料 年：" + strDate +"、巡：" + strPType );
                }
            }
            return bcheck;
        }
        public void F_Show(bool bshow)
        {
            if (bshow)
            {
                YearLB.Visible = true;
                MonthLB.Visible = true;
                三巡LB.Visible = true;
                TitleLB1.Visible = true;
                TitleLB2.Visible = true;
                TitleLB3.Visible = true;
            }
            else
            {
                YearLB.Visible = false;
                MonthLB.Visible = false;
                三巡LB.Visible = false;
                TitleLB1.Visible = false;
                TitleLB2.Visible = false;
                TitleLB3.Visible = false;
            }
            
        }

        protected void UpLoadBT_Click(object sender, EventArgs e)
        {
            F_UpLoad();
        }
    }
}