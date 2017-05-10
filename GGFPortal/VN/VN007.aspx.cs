using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

namespace GGFPortal.VN
{
    public partial class VN007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
                DbInit();
        }
        protected void Search_Click(object sender, EventArgs e)
        {


            DbInit();
        }


        private void DbInit()
        {
            //string sqlstr = selectsql();

            //this.SqlDataSource1.SelectCommand = sqlstr;
            //this.SqlDataSource1.DataBind();
            Session["Date1"] = (StartDayTB.Text == "") ? "19000101" : StartDayTB.Text;
            Session["Date2"] = (EndDayTB.Text == "") ? "29991231" : EndDayTB.Text;
            Session["StyleNo"] = (StyleNoSeachTB.Text == "") ? "%" : StyleNoSeachTB.Text;

            GridView2.DataBind();
            ReportViewer1.LocalReport.Refresh();
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
                    cmd.CommandText = "select distinct b.StyleNo from Productivity_Head a left join Productivity_Line b on a.uid=b.uid where a.Flag=1 and (b.StyleNo like '%'+  @SearchText + '%' ) ";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> StyleNo = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(sdr["StyleNo"].ToString());
                        }
                    }
                    conn.Close();
                    return StyleNo;
                }
            }
        }

    }
}