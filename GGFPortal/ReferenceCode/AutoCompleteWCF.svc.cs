using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;

namespace GGFPortal.ReferenceCode
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AutoCompleteWCF
    {
        // 若要使用 HTTP GET，請加入 [WebGet] 屬性 (預設的 ResponseFormat 為 WebMessageFormat.Json)。
        // 若要建立可傳回 XML 的作業，
        //     請加入 [WebGet(ResponseFormat=WebMessageFormat.Xml)]，
        //     並在作業主體中包含下列這行程式:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // 在此新增您的作業實作
            return;
        }
        // 在此新增其他作業，並以 [OperationContract] 來標示它們
        [OperationContract]
        public List<string> SearchShipCus(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select distinct a.cus_id as Search,b.vendor_name from shpc_bah a left join bas_vendor_master b on a.site=b.site and a.cus_id=b.vendor_id
                                        where upper(a.cus_id) like '%' +  @SearchText + '%' or upper(b.vendor_name) like '%'+  @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        // 在此新增其他作業，並以 [OperationContract] 來標示它們
        [OperationContract]
        public List<string> SearchShipAgent(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select distinct a.客戶 as Search from View出口大表 a 
                                        where upper(a.客戶) like '%' +  @SearchText + '%' ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> SearchOrdStyle(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  cus_item_no as Search from ordc_bah1 where bah_status<>'CA'
                                        and upper(cus_item_no) like '%' +  @SearchText + '%' ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> SearchVNExcelStyle(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select distinct StyleNo  as Search  from Productivity_Line where  upper(StyleNo) like '%' +  @SearchText + '%' ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> SearchSampleNbr(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [sam_nbr] as Search from [samc_reqm] where [status]<>'CA'
                                        and upper(cus_style_no) like '%' +  @SearchText + '%' or upper(sam_nbr) like '%' +  @SearchText + '%'   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> SearchSampleStyleNo(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [cus_style_no] as Search from [samc_reqm] where [status]<>'CA'
                                        and upper(cus_style_no) like '%' +  @SearchText + '%' or upper(sam_nbr) like '%' +  @SearchText + '%'   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> 快遞單號(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [提單號碼] as Search from [快遞單] where upper([提單號碼]) like '%' +  @SearchText + '%' and [IsDeleted] = 0   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> Search訂單客戶(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [cus_id] as Search from [ordc_bah1] where upper([cus_id]) like '%' +  @SearchText + '%'   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> Search訂單品牌(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [brand] as Search from [ordc_bah1] where upper([brand]) like '%' +  @SearchText + '%'   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        /// <summary>
        /// 實際搜尋客戶品牌
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [OperationContract]
        public List<string> Search訂單客戶品牌(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [agents] as Search from [ordc_bah1] where upper([agents]) like '%' +  @SearchText + '%'   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }
        [OperationContract]
        public List<string> Search廠商名稱(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [廠商簡稱] as Search from [View廠商付款條件] where upper([廠商簡稱]) like '%' +  @SearchText + '%' or  upper([廠商名稱]) like '%' +  @SearchText + '%'   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchCusId = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            SearchCusId.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return SearchCusId;
                }
            }
        }

        [OperationContract]
        public List<string> Search供應商代號(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select  distinct top 10  [廠商代號] as Search ,[廠商簡稱] as SearchName from [View廠商付款條件] where upper([廠商簡稱]) like '%' +  @SearchText + '%' or  upper([廠商代號]) like '%' +  @SearchText + '%'   ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.ToUpper());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> SearchList = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            //SearchCusId.Add(sdr["Search"].ToString());
                            //string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["Search"].ToString(), sdr["SearchName"].ToString());
                            //SearchList.Add(item);
                            SearchList.Add(AjaxControlToolkit.AutoCompleteExtender
                        .CreateAutoCompleteItem(string.Format("{0},{1}",sdr["Search"].ToString(), sdr["SearchName"]),
                        sdr["Search"].ToString()));
                        }
                    }
                    conn.Close();
                    return SearchList;
                }
            }
        }
    }
}
