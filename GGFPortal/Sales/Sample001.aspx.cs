using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Sales
{
    public partial class Sample001 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchStyleNo(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = strConnectString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select DISTINCT  TOP 10 [cus_style_no] from [samc_reqm] where  status <>'CL' and ([cus_style_no] like '%'+  @SearchText + '%' or [sam_nbr] like '%'+  @SearchText + '%') ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText.Trim());
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> StyleNo = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(sdr["cus_style_no"].ToString());
                        }
                    }
                    conn.Close();
                    return StyleNo;
                }
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Session["SampleNbr"] = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
            Session["SamDay"] = GridView1.Rows[e.NewSelectedIndex].Cells[7].Text.Replace("&nbsp;", "");
            Session["site"] = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;

            Response.Redirect("Sample002.aspx");

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strimg="";
            try
            {
                if(e.Row.DataItemIndex>-1)
                    if (e.Row.Cells[4].Text.Replace("&nbsp;","").Length > 0 && e.Row.RowType != DataControlRowType.Header)
                    {
                        strimg = e.Row.Cells[4].Text;
                        ((Image)e.Row.FindControl("Image1")).ImageUrl = "http://192.168.0.114/W/" + strimg.Substring(3, strimg.Length - 3);
                    }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}