using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GGFPortal.ReferenceCode
{
    /// <summary>
    ///Finance002Auto 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    
     [System.Web.Script.Services.ScriptService]
    public class Finance002Auto : System.Web.Services.WebService
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        //[System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        //AutoComplete
        public static List<string> SearchVendorID(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  vendor_id,vendor_name from bas_vendor_master where (vendor_id like '%'+  @SearchText + '%' or vendor_name like '%'+@SearchText+'%') and  vendor_status<>'CA'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> VendorID = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["vendor_id"].ToString(), sdr["vendor_name"].ToString());
                            VendorID.Add(item);
                        }
                    }
                    conn.Close();
                    return VendorID;
                }
            }
        }
        [System.Web.Services.WebMethod]
        public static List<string> SearchPurID(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  pur_nbr from purc_receive_detail where rec_detail_status <>'CA' and pur_nbr like '%'+  @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> PurID = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            //string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["pur_nbr"].ToString());
                            PurID.Add(sdr["pur_nbr"].ToString());
                        }
                    }
                    conn.Close();
                    return PurID;
                }
            }
        }
    }
}
