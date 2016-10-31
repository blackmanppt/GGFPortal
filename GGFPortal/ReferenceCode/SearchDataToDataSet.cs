using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GGFPortal.ReferenceCode
{
    public class SearchDataToDataSet
    {
        public DataTable SQLToDataSet( string strConnectString, string strSql,string strTableName,string strFunctionName)
        {
            DataTable Dt=new DataTable();
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                Dt.TableName = strTableName;
                conn.Open();
                //Create a SqlConnection to the Northwind database.
                SqlCommand command = new SqlCommand(strSql, conn);
                command.CommandType = CommandType.Text;
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.SelectCommand = command;
                    adapter.Fill(Dt);
                }
                catch (Exception ex)
                {
                    ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
                    Log.ErrorLog(ex, strTableName + " Search Data", strFunctionName);
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('資料搜尋錯誤:\\n" + ex.Message + "\\n請洽MIS Stone');</script>");
                }
                finally
                {
                    conn.Close();
                }
            }
            return Dt;
        }
    }
}