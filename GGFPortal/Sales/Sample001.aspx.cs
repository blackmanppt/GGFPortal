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
            if(!Page.IsPostBack )
            {
                DbInit();
            }
            

            //if (Convert.ToInt32(GridView1.PageIndex) != 0)
            //{
            //    //==如果不加上這行IF判別式，假設當我們看第四頁時， 
            //    //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
            //    GridView1.PageIndex = 0;
            //}
            
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
            //Session["SampleNbr"] = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
            //Session["SamDay"] = GridView1.Rows[e.NewSelectedIndex].Cells[7].Text.Replace("&nbsp;", "");
            //Session["site"] = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
            //Session["TDDay"] = GridView1.Rows[e.NewSelectedIndex].Cells[9].Text.Replace("&nbsp;", "");
            //DbInit();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(GridView1.PageIndex) != 0)
            //{
            //    //==如果不加上這行IF判別式，假設當我們看第四頁時， 
            //    //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
            //    GridView1.PageIndex = 0;
            //}
            DbInit();
        }
        private void DbInit()
        {
            string sqlstr = selectsql();

            this.SqlDataSource1.SelectCommand = sqlstr;
            this.SqlDataSource1.DataBind();
            GridView1.DataBind();
        }

        private string selectsql()
        {
            //string strPur, strAcp, strStyleno;
            string strwhere = "";


            
            string sqlstr = @"
                            SELECT a.*, b.type_desc FROM samc_reqm AS a LEFT OUTER JOIN samc_type AS b 
                            ON a.site = b.site AND a.type_id = b.type_id WHERE  (a.status <>'CL') and a.progress_rate in ('2','3')
                            ";
            strwhere += (UnTDCB.Checked) ? "" : " and td_fin_date is not Null";
            strwhere += (未收單CB.Checked) ? "" : " and samc_fin_date is not Null";
            strwhere += (string.IsNullOrEmpty(StyleNoTB.Text)) ? "" : string.Format(" and (a.cus_style_no LIKE   LTRIM(RTRIM('%{0}%')) ) ", StyleNoTB.Text);
            sqlstr += strwhere + " ORDER BY a.modify_date DESC ";
            return sqlstr;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditeDetail_1")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                //string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();

                SetSession(row, "Sam1");

                Response.Redirect("Sample002.aspx");


                ////Session["uid"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                //Session["uid"] = strid;
                //Response.Redirect("Sample008.aspx");
            }
            else if (e.CommandName == "EditeDetail_2")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                //string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();

                //Session["SampleNbr"] = GridView1.Rows[row.RowIndex].Cells[2].Text;
                //Session["SamDay"] = GridView1.Rows[row.RowIndex].Cells[7].Text.Replace("&nbsp;", "");
                //Session["site"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                //Session["TDDay"] = GridView1.Rows[row.RowIndex].Cells[10].Text.Replace("&nbsp;", "");
                //Session["SamIn"] = GridView1.Rows[row.RowIndex].Cells[11].Text.Replace("&nbsp;", "");
                //Session["SamOut"] = GridView1.Rows[row.RowIndex].Cells[12].Text.Replace("&nbsp;", "");
                //Session["Dept"] = "Sam2";
                SetSession(row, "Sam2");
                Response.Redirect("Sample002.aspx");


                ////Session["uid"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                //Session["uid"] = strid;
                //Response.Redirect("Sample008.aspx");
            }
            else if (e.CommandName == "EditeDetail_3")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                //string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();

                //Session["SampleNbr"] = GridView1.Rows[row.RowIndex].Cells[2].Text;
                //Session["SamDay"] = GridView1.Rows[row.RowIndex].Cells[7].Text.Replace("&nbsp;", "");
                //Session["site"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                //Session["TDDay"] = GridView1.Rows[row.RowIndex].Cells[10].Text.Replace("&nbsp;", "");
                //Session["SamIn"] = GridView1.Rows[row.RowIndex].Cells[11].Text.Replace("&nbsp;", "");
                //Session["SamOut"] = GridView1.Rows[row.RowIndex].Cells[12].Text.Replace("&nbsp;", "");
                //Session["Dept"] = "TD";
                SetSession(row, "TD");
                Response.Redirect("Sample002.aspx");


                ////Session["uid"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                //Session["uid"] = strid;
                //Response.Redirect("Sample008.aspx");
            }
            else if(e.CommandName=="Page")
            {
                DbInit();
            }

        }

        private void SetSession(GridViewRow row,string strDept)
        {
            Session["SampleNbr"] = GridView1.Rows[row.RowIndex].Cells[2].Text;
            Session["SamDay"] = GridView1.Rows[row.RowIndex].Cells[7].Text.Replace("&nbsp;", "");
            Session["site"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
            Session["TDDay"] = GridView1.Rows[row.RowIndex].Cells[10].Text.Replace("&nbsp;", "");
            Session["SamIn"] = GridView1.Rows[row.RowIndex].Cells[11].Text.Replace("&nbsp;", "");
            Session["SamOut"] = GridView1.Rows[row.RowIndex].Cells[12].Text.Replace("&nbsp;", "");
            Session["Dept"] = strDept;
            Session["style"] = GridView1.Rows[row.RowIndex].Cells[3].Text.Replace("&nbsp;", "");
            Session["PlanDate"] = GridView1.Rows[row.RowIndex].Cells[13].Text.Replace("&nbsp;", "");
        }
    }
}