using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;

namespace GGFPortal.ReferenceCode
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class VendorAutoComplete
    {
        [ScriptMethod()]
        [WebMethod]
        public IList<string> GetItemList1(string keywordStartsWith)
        {
            IList<string> output = new List<string>();

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["serial"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string strSQL =
                @"SELECT TOP 10 ItemNo," +
                       " ItemDescription" +
                  " FROM COM_ORACLE..COM_ORACLE_ITEMS" +
                 " WHERE ItemNo like '" + keywordStartsWith.ToUpper() + "%'" +
                 " ORDER BY ItemNo ";

            da.SelectCommand = new SqlCommand(strSQL, conn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    output.Add(dt.Rows[i][0].ToString());
            }
            return output;
        }

        [WebMethod]
        public IList<string> GetItemList2(string keywordStartsWith, string domain)
        {
            IList<string> output = new List<string>();

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["serial"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string strSQL =
                @"SELECT TOP 10 ItemNo," +
                       " ItemDescription" +
                  " FROM COM_ORACLE..COM_ORACLE_ITEMS" +
                 " WHERE OrganizationId=" + domain +
                   " AND ItemNo like '" + keywordStartsWith.ToUpper() + "%'" +
                 " ORDER BY ItemNo ";

            da.SelectCommand = new SqlCommand(strSQL, conn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    output.Add(dt.Rows[i][0].ToString());
            }
            return output;
        }
    }
   
}