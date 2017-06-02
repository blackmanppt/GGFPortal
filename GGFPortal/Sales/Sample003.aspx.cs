using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sample003 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartTB.Attributes["readonly"] = "readonly";
            EndTB.Attributes["readonly"] = "readonly";
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCus(string prefixText, int count)
        {
            string strsql = "select DISTINCT  TOP 10 [cus_id] as Search from [samc_reqm] where  status <>'CL' and ([cus_id] like '%'+  @SearchText + '%' ) ";
            return AutoComplete(prefixText, strsql);
        }

        private static List<string> AutoComplete(string prefixText, string strsql)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = strsql;
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> Search = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Search.Add(sdr["Search"].ToString());
                        }
                    }
                    conn.Close();
                    return Search;
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static List<string> SearchStyleNo(string prefixText, int count)
        {
            string strsql = " select DISTINCT  TOP 10 [cus_style_no] as Search from [samc_reqm] where  status <>'CL' and ([cus_style_no] like '%'+  @SearchText + '%' or [sam_nbr] like '%'+  @SearchText + '%') ";
            return AutoComplete(prefixText, strsql);
            //using (SqlConnection conn = new SqlConnection())
            //{
            //    conn.ConnectionString = strConnectString;
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.CommandText = "select DISTINCT  TOP 10 [cus_style_no] from [samc_reqm] where  status <>'CL' and ([cus_style_no] like '%'+  @SearchText + '%' or [sam_nbr] like '%'+  @SearchText + '%') ";
            //        cmd.Parameters.AddWithValue("@SearchText", prefixText);
            //        cmd.Connection = conn;
            //        conn.Open();
            //        List<string> StyleNo = new List<string>();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            while (sdr.Read())
            //            {
            //                StyleNo.Add(sdr["cus_style_no"].ToString());
            //            }
            //        }
            //        conn.Close();
            //        return StyleNo;
            //    }
            //}
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            Session["StarDay"] = (string.IsNullOrEmpty(StartTB.Text)) ? "2000-01-01" : StartTB.Text;
            Session["EndDay"] = (string.IsNullOrEmpty(EndTB.Text)) ? "2999-01-01" : EndTB.Text;
            Session["cus_id"] = (string.IsNullOrEmpty(CusText.Text)) ? "%" : CusText.Text;
            Session["styleno"] = (string.IsNullOrEmpty(StyleTB.Text)) ? "%" : StyleTB.Text;
            ReportViewer1.LocalReport.Refresh();
        }
    }
}