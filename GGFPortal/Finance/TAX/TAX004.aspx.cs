using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//範本
namespace GGFPortal.Finance.TAX
{
    public partial class TAX004 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString2"].ToString();
        static DataSet Ds = new DataSet();
        ReferenceCode.SearchDataToDataSet GetData = new ReferenceCode.SearchDataToDataSet();
        //ReferenceCode.StringConvert GetSQL = new ReferenceCode.StringConvert();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);
            //SaveBT2.Attributes.Add("onclick ", "return confirm( '確定要儲存發票號碼?');");
            if (MonthDDL.Items.Count == 0)
            {
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (dtNow.Year - 2015) * 12 + (dtNow.Month - 12);
                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        MonthDDL.Items.Add("");
                    }
                    MonthDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                }
            }
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
                    cmd.CommandText = @"SELECT distinct top 10 [style_no]
                                        FROM [dbo].[acr_trn_check] where CheckFlag <>'CA'  and style_no like '%'+  @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> StyleNo = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            StyleNo.Add(sdr["style_no"].ToString());
                        }
                    }
                    conn.Close();
                    return StyleNo;
                }
            }
        }
        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DbInit();
        }
        private void DbInit()
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                DataTable dt = new DataTable();
                string sqlstr = selectsql();
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.Fill(dt);
                ACRGV.DataSource = dt;
                ACRGV.DataBind();
            }
        }

        private string selectsql()
        {
            string strwhere = "";
            string strStartDay, strEndDay;
            strwhere += (string.IsNullOrEmpty(StyleNoTB.Text.Trim())) ? "" : " and style_no = '" + StyleNoTB.Text.Trim() + "' ";
            strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "2014-01-01";
            strEndDay = (EndDayTB.Text.Length > 0) ? EndDayTB.Text : "2999-01-01";
            strwhere += string.Format(" and acr_date between '{0}' and '{1}' ", strStartDay, strEndDay);
            if (MonthDDL.SelectedIndex > 0)
            {
                string date = MonthDDL.SelectedValue.Substring(4) + "/01/" + MonthDDL.SelectedValue.Substring(0, 4);
                string sStarDate, sEndDate;
                DateTime dt = Convert.ToDateTime(date);
                sStarDate = MonthDDL.SelectedValue + "01";
                sEndDate = dt.AddMonths(1).ToString("yyyyMMdd");
                strwhere += string.Format("and acr_date>= '{0}' and acr_date < '{1}'", sStarDate, sEndDate);
            }
            //string sqlstr = @"
            //                    select uid,CheckFlag,CheckCreateDate,ticket,site,kind,acr_nbr,acr_seq,acr_date,style_no,acr_status,reference_no,reason
            //                    FROM [dbo].[acr_trn_check] where CheckFlag ='NA' ";
            string sqlstr = @"
                                select distinct style_no
                                FROM [dbo].[acr_trn_check] where CheckFlag <>'CA' ";
            sqlstr += strwhere;
            return sqlstr;
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {

            if (F_SaveCheck())
            {
                //Ds.Tables["AcrTable"].Rows.Count
            }
            else
            {

            }
        }
        private Boolean F_SaveCheck()
        {
            int icount = AcrTicketGV.Rows.Count;
            Boolean bCheck = false;
            if (icount > 0)
            {
                int iMainCheck = 0, iSubCheck = 0;
                Boolean bStyleNoCheck = true;
                string strStyleNo = "";
                for (int i = 0; i < icount; i++)
                {
                    CheckBox chk = (CheckBox)AcrTicketGV.Rows[i].Cells[0].FindControl("CheckBox1");
                    chk.Checked = bCheck;
                    if (chk.Checked)
                    {
                        if (i > 0)
                        {
                            //確認是否有多筆Style
                            bStyleNoCheck = (strStyleNo == AcrTicketGV.Rows[i].Cells[4].Text) ? true : false;
                        }

                        if (AcrTicketGV.Rows[i].Cells[4].Text == "應收")
                        {
                            if (bStyleNoCheck)
                            {
                                iMainCheck++;
                                if (iSubCheck > 0)
                                    iSubCheck = 0;
                            }
                            else
                            {

                            }

                        }
                        else
                        {
                            if (iMainCheck > 0)
                            {
                                iSubCheck++;
                                if (iMainCheck > 0)
                                    iMainCheck = 0;
                            }
                            else
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請聯絡資訊部：請選擇應收資料');</script>");

                        }
                        strStyleNo = AcrTicketGV.Rows[i].Cells[4].Text;
                    }
                }
            }

            return bCheck;
        }

        protected void ACRGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string strStyleNo = ACRGV.Rows[e.NewSelectedIndex].Cells[1].Text.ToString().Replace("&nbsp;", "");

            //string strWhere = ;
            if (string.IsNullOrEmpty(strStyleNo) == false)
            {
                if (Ds.Tables.Contains("acr_trn_check"))
                    Ds.Tables.Remove("acr_trn_check");

                Ds.Tables.Add(GetData.SQLToDataSet(strConnectString, "select * from  acr_trn_check where style_no = '" + strStyleNo + "'", "acr_trn_check", "TAX004.aspx"));

                if (Ds.Tables.Contains("purc_pkd_check"))
                    Ds.Tables.Remove("purc_pkd_check");
                Ds.Tables.Add(GetData.SQLToDataSet(strConnectString, "select * from purc_pkd_for_acr  where cus_item_no ='" + strStyleNo + "'", "purc_pkd_check", "TAX004.aspx"));
                int icheck1 = 0, icheck2 = 0;
                icheck1 = (Ds.Tables["acr_trn_check"].Rows.Count > 0) ? 0 : 1;
                icheck2 = (Ds.Tables["purc_pkd_check"].Rows.Count > 0) ? 0 : 1;
                if (icheck1 == 0 && icheck2 == 0)
                {
                    DataTable dt = new DataTable("AcrTable");
                    DataColumn column;
                    DataRow row;

                    // Create new DataColumn, set DataType, 
                    // ColumnName and add to DataTable.    
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Int32");
                    column.ColumnName = "id";
                    //column.ReadOnly = true;
                    //column.Unique = true;
                    // Add the Column to the DataColumnCollection.
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "style_no";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.DateTime");
                    column.ColumnName = "DATE";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "TYPE";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Double");
                    column.ColumnName = "MONEY";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.Double");
                    column.ColumnName = "AMT";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "nbr";
                    dt.Columns.Add(column);

                    for (int i = 0; i < Ds.Tables["acr_trn_check"].Rows.Count; i++)
                    {
                        row = dt.NewRow();
                        row["id"] = Ds.Tables["acr_trn_check"].Rows[i]["uid"].ToString();
                        row["style_no"] = Ds.Tables["acr_trn_check"].Rows[i]["style_no"].ToString();
                        row["DATE"] = Ds.Tables["acr_trn_check"].Rows[i]["acr_date"].ToString();
                        row["TYPE"] = "應收";
                        row["MONEY"] = Ds.Tables["acr_trn_check"].Rows[i]["foreign_amt"].ToString();
                        //row["AMT"] = Ds.Tables["acr_trn_check"].Rows[i]["uid"].ToString();
                        row["nbr"] = Ds.Tables["acr_trn_check"].Rows[i]["acr_nbr"].ToString();
                        dt.Rows.Add(row);
                    }
                    for (int i = 0; i < Ds.Tables["purc_pkd_check"].Rows.Count; i++)
                    {
                        row = dt.NewRow();
                        row["id"] = Ds.Tables["purc_pkd_check"].Rows[i]["uid"].ToString();
                        row["style_no"] = Ds.Tables["purc_pkd_check"].Rows[i]["cus_item_no"].ToString();
                        row["DATE"] = Ds.Tables["purc_pkd_check"].Rows[i]["create_date"].ToString();
                        row["TYPE"] = "包裝";
                        //row["MONEY"] = Ds.Tables["purc_pkd_check"].Rows[i]["uid"].ToString();
                        row["AMT"] = Ds.Tables["purc_pkd_check"].Rows[i]["customs_decleartion_amt"].ToString();
                        row["nbr"] = Ds.Tables["purc_pkd_check"].Rows[i]["pak_nbr"].ToString() + Ds.Tables["purc_pkd_check"].Rows[i]["pak_seq"].ToString();
                        dt.Rows.Add(row);

                    }
                    POPPanel_ModalPopupExtender.Show();
                    AcrTicketGV.DataSource = dt;
                    if (Ds.Tables.Contains("AcrTable"))
                        Ds.Tables.Remove("AcrTable");
                    Ds.Tables.Add(dt);
                    AcrTicketGV.DataBind();

                }
                else if (icheck1 == 1 && icheck2 == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請聯絡資訊部：應收無資料');</script>");
                }
                else if (icheck2 == 1 && icheck1 == 0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請聯絡資訊部：包裝底稿無資料');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請聯絡資訊部：應收與包裝底稿都無資料');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請聯絡資訊部：沒有Style_No');</script>");
            }

        }

        protected void SelectAllBT_Click(object sender, EventArgs e)
        {
            Button bt = (Button)AcrTicketGV.HeaderRow.Cells[0].FindControl("SelectAllBT");
            int icount = AcrTicketGV.Rows.Count;
            Boolean bCheck = false;

            if (icount > 0)
            {
                if (bt.Text == "全選")
                {
                    bCheck = true;
                    bt.Text = "全取消";
                }
                else
                {
                    bt.Text = "全選";
                }
                for (int i = 0; i < icount; i++)
                {
                    CheckBox chk = (CheckBox)AcrTicketGV.Rows[i].Cells[0].FindControl("CheckBox1");
                    chk.Checked = bCheck;
                }
            }
            POPPanel_ModalPopupExtender.Show();

        }
        //private int[,] F_GetProcent()
        //{
        //    int[,] iCount;


        //    return iCount;
        //}


    }
}