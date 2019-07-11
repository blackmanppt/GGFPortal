using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace GGFPortal.VN
{
    public partial class VN004 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();
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
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("QC"))
                    Ds.Tables.Remove("QC");
                string sqlstr = selectsql();
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.Fill(Ds, "QC");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            }
            if (Ds.Tables["QC"].Rows.Count > 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportDataSource source = new ReportDataSource("VN002", Ds.Tables["QC"]);
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
            //if(TeamCB.Items[0].Selected != true)
            //{
            //    string strchk = "";
            //    for (int i = 1; i < TeamCB.Items.Count; i++)
            //    {
            //        if(strchk.Length>0)
            //            strchk += (TeamCB.Items[i].Selected == true) ? string.Format(",'{0}'", TeamCB.Items[i].Value) : "";
            //        else
            //            strchk += (TeamCB.Items[i].Selected == true) ? string.Format("'{0}'", TeamCB.Items[i].Value) : "";
            //    }
            //    strwhere += (strchk.Length > 0) ? " and b.Team in ( " + strchk + " )" : "";
            //}

            
            string sqlstr = @"
                                select a.*,b.Date,c.MappingData from  Productivity_Line a left join Productivity_Head b on a.uid=b.uid left join Mapping c on b.Team=c.Data and c.UsingDefine='Productivity'    
                                where b.Team='QC' and b.Flag=1   and Area ='VGG'
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