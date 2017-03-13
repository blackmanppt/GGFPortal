using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class SALE_V2 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {
                if (StartDayTB.Text.Length > 0)
                {
                    //EndDayTB_CalendarExtender.StartDate = Convert.ToDateTime(StartDayTB.Text.Substring(0, 4) + "/" + StartDayTB.Text.Substring(4, 2) + "/" + StartDayTB.Text.Substring(6, 2));
                    EndDay_CalendarExtender.StartDate = Convert.ToDateTime(StartDayTB.Text);
                }
                if (EndDay.Text.Length > 0)
                {
                    StartDayTB_CalendarExtender.EndDate = Convert.ToDateTime(EndDay.Text);
                    //StartDayTB_CalendarExtender.EndDate = Convert.ToDateTime(EndDayTB.Text.Substring(0, 4) + "/" + EndDayTB.Text.Substring(4, 2) + "/" + EndDayTB.Text.Substring(6, 2));
                }
            }
            else
            {
                //DateTime dtTo = default(DateTime);
                //if (Session["dtToSelect"] == null)
                //{
                //    dtTo = Convert.ToDateTime(Session["dtToSelect"]);
                //}
                //else
                //{
                //    dtTo = DateTime.MinValue; // or maxvalue or today if you want
                //}
                //Session["StartDay"] = DateTime.Now;
                //Session["EndDay"] = DateTime.Now.AddYears(3);
                //////Session["F001Site"] = "%";
                //ReportViewer1.LocalReport.Refresh();
            }
            
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Session["StartDay"] = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "1900/01/01";
            Session["EndDay"] = (EndDay.Text.Length > 0) ? EndDay.Text : "2999/12/31";
            Session["Brand"] = (BrandTB.Text.Length > 0) ? BrandTB.Text : "%";
            Session["SamcType"] = (SamcTypeDDL.Text.Length > 0) ? SamcTypeDDL.Text : "%";
            Session["CaiCai"] = (NewOldDDL.Text=="新增") ? "2" : "1";
            ReportViewer1.LocalReport.Refresh();
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        //AutoComplete
        public static List<string> SearchBrand(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT distinct brand_name  FROM samc_reqm 
                                        where progress_rate = N'2'  
                                        and brand_name like '%'+  @SearchText + '%' ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> Brand = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Brand.Add(sdr["brand_name"].ToString());
                        }
                    }
                    conn.Close();
                    return Brand;
                }
            }
        }

        protected void CearBT_Click(object sender, EventArgs e)
        {
            StartDayTB.Text = "";
            EndDay.Text = "";
            SamcTypeDDL.Text = "";
            BrandTB.Text = "";
        }
    }
}