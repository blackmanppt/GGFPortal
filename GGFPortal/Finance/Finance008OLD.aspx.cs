using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance
{
    public partial class Finance008OLD : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {

            }
            else
            {
                Session["F001StartDay"] = DateTime.Now.ToString("yyyyMMdd");
                Session["F001EndDay"] = "29990101";
                Session["F001Site"] = "%";
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Session["F001StartDay"] = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "20000101";
            Session["F001EndDay"] = (EndDay.Text.Length > 0) ? EndDay.Text : "29990101";
            switch (SiteDDL.SelectedIndex)
            {
                case 1:
                    Session["F001Site"] = "GGF";
                    break;
                case 2:
                    Session["F001Site"] = "TCL";
                    break;
                default:
                    Session["F001Site"] = "%";
                    break;
            }
            Session["agents"] = (AgentSearchTB.Text.Length > 0) ? AgentSearchTB.Text.Trim() : "%";
            ReportViewer1.LocalReport.Refresh();
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        //AutoComplete
        public static List<string> AgentSearch(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"select distinct a.agents,b.cus_name_brief from ordc_bah1 a left join bas_cus_master b on a.agents =b.cus_id
                                        where bah_status<>'CA' and (a.agents like '%'+  @SearchText + '%' or b.cus_name_brief like '%'+@SearchText+'%')";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> VendorID = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(sdr["agents"].ToString(), sdr["cus_name_brief"].ToString());
                            VendorID.Add(item);
                        }
                    }
                    conn.Close();
                    return VendorID;
                }
            }
        }
    }
}