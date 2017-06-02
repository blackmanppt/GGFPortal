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
                command.Parameters.Add("@Year", SqlDbType.NVarChar).Value = str月份.Substring(1,4);
                command.Parameters.Add("@Month", SqlDbType.NVarChar).Value = str月份.Substring(5,2);
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
    }
    
}