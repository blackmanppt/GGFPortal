using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GGFPortal.ReferenceCode
{
    public class 資料庫搜尋條件
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        public string 出單廠商 { get; set; }
        /// <summary>
        /// 取的GGFID內的最新流水號
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strProgram"></param>
        /// <returns>回傳流水號</returns>
        public int GetExcelIdex(string strTableName,string strProgram)
        {
            Int32 Uid = 0;
            string sql =
                @"exec [dbo].[SP_識別值增量] @AddID";
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@AddID", SqlDbType.NVarChar);
                cmd.Parameters["@AddID"].Value = strTableName;
                try
                {
                    conn.Open();
                    Uid = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    
                    Log.ErrorLog(ex, string.Format("Table:{0} add uid Error GetExcelIdex", strTableName), strProgram);
                }
            }
            return (int)Uid;
        }
        //public IEnumerable<string> 搜尋資料(string strsql,string strProgram)
        //{
        //    IEnumerable<string> strdata;

        //    return strdata;
        //}
    }
}