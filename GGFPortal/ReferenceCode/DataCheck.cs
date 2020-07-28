using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class DataCheck
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        static 多語 lang = new 多語();
        
        public void 讀取多語資料(string StrPageName)
        {
            lang.gg.Clear();
            lang.讀取多語資料("Program", StrPageName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="代工廠"></param>
        /// <param name="月份"></param>
        /// <returns></returns>
        public Boolean Check工時Lock(string str代工廠, string str月份)
        {
            bool bcheck = true;
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = @"SELECT *
                                        FROM [dbo].[ProductivityCost]
                                        where VendorId = @VendorId and Year = @Year and Month = @Month and Flag = 1";
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@VendorId", SqlDbType.NVarChar).Value = str代工廠;
                command.Parameters.Add("@Year", SqlDbType.NVarChar).Value = str月份.Substring(0,4);
                command.Parameters.Add("@Month", SqlDbType.NVarChar).Value = str月份.Substring(4,2);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    bcheck = false;
                    //DataTable dt = new DataTable();
                    //dt.Load(reader);
                }
                reader.Close();
            }
            return bcheck;
        }
        /// <summary>
        /// excel 匯入 String檢查
        /// </summary>
        /// <param name="row">excel</param>
        /// <param name="DtColumnDefine"></param>
        /// <param name="i"></param>
        /// <param name="StrError"></param>
        /// <param name="D_dataRow"></param>
        /// <param name="j"></param>
        /// <param name="B是否為必要欄位"></param>
        /// <param name="BError"></param>
        public void StringData(IRow row, DataTable DtColumnDefine, int i, ref string StrError, DataRow D_dataRow, int j, bool B是否為必要欄位, ref bool BError)
        {
            try
            {
                if (B是否為必要欄位 && row.GetCell(j) == null)
                {
                    BError = true;
                    StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "NoData");
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
                    StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "ImportError");
                }
                D_dataRow[j] = (row.GetCell(j) == null) ? "" : row.GetCell(j).ToString();  //--每一個欄位，都加入同一列 DataRow
            }
        }

        public void IntData(IRow row, DataTable DtColumnDefine, int i, ref string StrError, DataRow D_dataRow, int j, bool B是否為必要欄位, ref bool BError)
        {
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
                        StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "int Error1");
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
                            StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "NoData");
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
                                StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "int Error2");
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
                        StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "int Error2");
                    }
                    D_dataRow[j] = "0";  //--每一個欄位，都加入同一列 DataRow
                }
            }
        }

        public void FloatData(IRow row, DataTable DtColumnDefine, int i, ref string StrError, DataRow D_dataRow, int j, bool B是否為必要欄位, ref bool BError)
        {
            if ((row.GetCell(j) != null) && (row.GetCell(j).CellType == CellType.Formula))  //== v.1.2.4版修改。2.x版只是修正英文大小寫。
            {
                try
                {
                    D_dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                }
                catch
                {
                    if (B是否為必要欄位 == true)
                    {
                        BError = true;
                        StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "Float Error1");
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
                            StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "NoData");
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
                                StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "Float Error2");
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
                        StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "NumFormatError");
                    }
                    D_dataRow[j] = "0";  //--每一個欄位，都加入同一列 DataRow
                }
            }
        }

        public void DatetimeData(IRow row, DataTable DtColumnDefine, int i, ref string StrError, DataRow D_dataRow, int j, bool B是否為必要欄位, ref bool BError)
        {
            try
            {
                if (B是否為必要欄位 == true && (string.IsNullOrEmpty(row.GetCell(j).ToString())))
                {
                    BError = true;
                    StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "DateformatError");
                }
                D_dataRow[j] = (string.IsNullOrEmpty(row.GetCell(j).ToString())) ? "" : row.GetCell(j).DateCellValue.ToString("yyyy-MM-dd");
            }
            catch
            {
                BError = true;
                StrError = FConvertError(DtColumnDefine.Rows[j]["資料名稱中文"].ToString(), i, StrError, j, "DateformatError");
            }
        }
        public static string FConvertError(string Str欄位名稱, int i, string sError, int j, string strErrorDefine)
        {
            try
            {
                sError += string.Format(" {0}  {1}. ", lang.翻譯("Program", strErrorDefine, "TW"), Str欄位名稱);
            }
            catch (Exception ex)
            {
                 

            }
            return sError;
        }
    }
    
}