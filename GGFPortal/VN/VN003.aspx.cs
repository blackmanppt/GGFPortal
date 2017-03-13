using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.VN
{
    public partial class VN003 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDay.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {
            }
            else
            {
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("Stitch"))
                    Ds.Tables.Remove("Stitch");
                string sqlstr = selectsql();
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.Fill(Ds, "Stitch");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (Ds.Tables["Stitch"].Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("VN001", Ds.Tables["Stitch"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('搜尋不到資料');</script>");
        }
        private void DbInit()
        {
            string sqlstr = selectsql();
        }
        private string selectsql()
        {
            string strwhere = "";
            string strStartDay, strEndDay;
            strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "20140101";
            strEndDay = (EndDay.Text.Length > 0) ? EndDay.Text : "29990101";
            strwhere += " and b.Date between '" + strStartDay + "' and '" + strEndDay + "' ";
            strwhere += (StyleNoTB.Text.Trim().Length > 0) ? " and a.StyleNo ='" + StyleNoTB.Text.Trim() + "'" : "";
            string sqlstr = @"
                                select a.* from  Productivity_Line a left join Productivity_Head b on a.uid=b.uid and b.Flag=1
                                where 1=1 
                            ";

            sqlstr += strwhere;
            return sqlstr;
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
                    cmd.CommandText = "select distinct top 10  a.StyleNo from  Productivity_Line a left join Productivity_Head b on a.uid=b.uid and b.Flag=1  where a.StyleNo like '%'+  @SearchText + '%'";
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