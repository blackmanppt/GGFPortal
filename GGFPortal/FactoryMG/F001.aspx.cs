using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace GGFPortal.FactoryMG
{
    public partial class F001 : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Title = "test1234";
            Button xx = (Button)Master.FindControl("Button5");
            xx.Text = "test5";
        }
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDayTB.Attributes["readonly"] = "readonly";
            //if (Convert.ToInt32(ACPGV.PageIndex) != 0)
            //{
            //    //==如果不加上這行IF判別式，假設當我們看第四頁時， 
            //    //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
            //    //ACPGV.PageIndex = 0;
            //}
            if (IsPostBack)
            {
                if (StartDayTB.Text.Length > 0)
                {
                    EndDayTB_CalendarExtender.StartDate = Convert.ToDateTime(StartDayTB.Text);
                }
                if (EndDayTB.Text.Length > 0)
                {
                    StartDayTB_CalendarExtender.EndDate = Convert.ToDateTime(EndDayTB.Text);
                }
                DbInit();
            }
            
        }

        private void DbInit()
        {
            string sqlstr = selectsql();

            //this.SqlDataSource1.SelectCommand = sqlstr;
            //this.SqlDataSource1.DataBind();
            GridView1.DataBind();
        }

        private string selectsql()
        {
            //string strLastDate, strAcp, strStyleno;
            string strwhere = "", strStartDay, strEndDay;
            
            if (StartDayTB.Text.Length>0 || EndDayTB.Text.Length>0)
            {
                strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : DateTime.Now.AddDays(-8).ToString("yyyy-MM-dd");
                strEndDay = (EndDayTB.Text.Length > 0) ? EndDayTB.Text : DateTime.Now.AddMonths(3).ToString("yyyy-MM") + "-01";
                strwhere = "and x.last_date between '"+ strStartDay + "' and '" + strEndDay+"' ";
            }
            else
            {
                strwhere = " and x.last_date between '"+DateTime.Now.AddDays(-8).ToString("yyyy-MM-dd")+"' and '"+DateTime.Now.AddMonths(3).ToString("yyyy-MM")+"-01'";
            }
            if (StyleNoTB.Text.Trim().Length > 0)
                strwhere += " and  cus_item_no LIKE '%" + StyleNoTB.Text.Trim() + "%' ";
            string sqlstr = @"
                                select distinct a.agents,b.cus_name,brand,cus_item_no from
                                ordc_bat x left join 
                                 ordc_bah1 a on x.site=a.site and x.ord_nbr=a.ord_nbr
                                left join bas_cus_master b on a.agents=b.cus_id
                                where bah_status<>'CA'
                            ";

            //if (strPur.Length > 0 || strAcp.Length > 0 || strStyleno.Length > 0)
            //{
            //    ReferenceCode.StringConvert SplitString = new ReferenceCode.StringConvert();
            //    if (strPur.Length > 0)
            //        strwhere = SplitString.SplitArray(strPur, strwhere, "pur_nbr");
            //    if (strAcp.Length > 0)
            //        strwhere = SplitString.SplitArray(strAcp, strwhere, "acp_nbr");
            //    if (strStyleno.Length > 0)
            //        strwhere = SplitString.SplitArray(strStyleno, strwhere, "style_no");
            //}
            sqlstr = sqlstr + strwhere;
            return sqlstr;
        }



        protected void Export_Click(object sender, EventArgs e)
        {
            //check資料
            if (String.IsNullOrEmpty(StartDayTB.Text) && String.IsNullOrEmpty(EndDayTB.Text) )
            {

                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Please enter Search Data');</script>");
                F_ErrorShow("Please enter Search Data");
            }
            else
            {
                
                SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString1"].ConnectionString.ToString());
                //----(2). 執行SQL指令（Select陳述句）----
                SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql(), Conn);
                DataSet ds = new DataSet();

                myAdapter.Fill(ds, "ACP");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
                //匯出Excel
                GGFPortal.ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
                xx.ExcelWithNPOI(ds.Tables["ACP"], @"xlsx");
            }

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
                    cmd.CommandText = "select DISTINCT  TOP 10 cus_item_no from ordc_bah1 where bah_status <>'CA'  and cus_item_no like '%'+  @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> StyleNo = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(sdr["cus_item_no"].ToString());
                        }
                    }
                    conn.Close();
                    return StyleNo;
                }
            }
        }
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

    }
}