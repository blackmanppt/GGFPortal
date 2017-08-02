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
    }
}
