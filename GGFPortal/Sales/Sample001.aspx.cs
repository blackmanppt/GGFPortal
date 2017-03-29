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
                    cmd.CommandText = "select DISTINCT  TOP 10 [sam_nbr] from [samc_reqm] where progress_rate = N'2' and status <>'CL' and ([cus_style_no] like '%'+  @SearchText + '%' or [sam_nbr] like '%'+  @SearchText + '%') ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> StyleNo = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(sdr["sam_nbr"].ToString());
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
            Response.Redirect("Sample002.aspx");

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string strimg="";
            if( e.Row.RowIndex>0)
            {
                if(e.Row.Cells[4].Text.Length > 0 )
                { 
                strimg = e.Row.Cells[4].Text;
                ((Image)e.Row.FindControl("Image1")).ImageUrl = "http://192.168.0.114/W/" +strimg.Substring(3,strimg.Length-3);
                }
            }
            
        }
    }
}