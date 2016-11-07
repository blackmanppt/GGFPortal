using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.Finance.TAX
{
    public partial class TAX005 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        static DataSet Ds = new DataSet();
        ReferenceCode.SearchDataToDataSet GetData = new ReferenceCode.SearchDataToDataSet();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
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
        }

        protected void SettlementBT_Click(object sender, EventArgs e)
        {
            int iGVCount = 0;
            string strStyleNo = "";
            iGVCount = SearchGV.Rows.Count;
            int iError = 0,ikey=0;
            for (int i = 0; i < iGVCount; i++)
            {
                CheckBox chk = (CheckBox)SearchGV.Rows[i].Cells[0].FindControl("CheckBox1");
                if (chk.Checked)
                {
                    DataTable AcrDT = new DataTable(), PkmDT = new DataTable();
                    strStyleNo = SearchGV.Rows[i].Cells[1].Text;
                    ikey = AddStyleNo(strStyleNo, MonthDDL.SelectedValue);
                    using (SqlConnection Conn = new SqlConnection(strConnectString))
                    {
                        SqlDataAdapter myAdapter1 = new SqlDataAdapter(" select * from  acr_trn_check where style_no =@strStyleNo", Conn);
                        myAdapter1.SelectCommand.Parameters.AddWithValue("strStyleNo", strStyleNo);
                        myAdapter1.Fill(AcrDT);
                        
                        SqlDataAdapter myAdapter2 = new SqlDataAdapter(" select * from  purc_pkd_for_acr where cus_item_no =@strStyleNo", Conn);
                        myAdapter1.SelectCommand.Parameters.AddWithValue("strStyleNo", strStyleNo);
                        myAdapter2.Fill(PkmDT);
                    }
                    if (AcrDT.Rows.Count > 0 && PkmDT.Rows.Count > 0 && ikey>0)
                    {
                        using (SqlConnection conn1 = new SqlConnection(strConnectString))
                        {
                            
                            SqlCommand command1 = conn1.CreateCommand();
                            SqlTransaction transaction1;
                            conn1.Open();
                            transaction1 = conn1.BeginTransaction("createStyle");

                            command1.Connection = conn1;
                            command1.Transaction = transaction1;
                            try
                            {
                                for (int j = 0; j < AcrDT.Rows.Count; j++)
                                {
                                    command1.CommandText = string.Format(@"UPDATE [dbo].[acr_trn_check] SET [ticket] = @ticket WHERE uid in ({0}) ", strStyleNo.Substring(1));
                                    //command1.Parameters.Add("@ticket", SqlDbType.NVarChar).Value = TicketBT.Text.Trim();
                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();
                                }
                                for (int k = 0; k < PkmDT.Rows.Count; k++)
                                {
                                    command1.CommandText = string.Format(@"UPDATE [dbo].[acr_trn_check] SET [ticket] = @ticket WHERE uid in ({0}) ", strStyleNo.Substring(1));
                                    //command1.Parameters.Add("@ticket", SqlDbType.NVarChar).Value = TicketBT.Text.Trim();
                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();
                                }
                                transaction1.Commit();
                            }
                            catch (Exception ex1)
                            {
                                try
                                {
                                    Log.ErrorLog(ex1, "Insert Error style no:" + strStyleNo, "TAX003.aspx");
                                }
                                catch (Exception ex2)
                                {
                                    Log.ErrorLog(ex2, "Insert Error2 style no:" + strStyleNo, "TAX003.aspx");
                                }
                                finally
                                {
                                    iError++;
                                    transaction1.Rollback();
                                }
                            }
                            finally
                            {
                                conn1.Close();
                                conn1.Dispose();
                                command1.Dispose();
                            }
                        }
                    }
                    else
                    {
                        iError++;
                        Log.ErrorLog("應收或包裝底稿無資料", "Insert Error2 style no:" + strStyleNo, "TAX005.aspx");
                    }
                }
            }

            
        }

        private string selectsql()
        {
            string strwhere = "";
            if (MonthDDL.SelectedIndex > 0)
            {
                string date = MonthDDL.SelectedValue.Substring(4) + "/01/" + MonthDDL.SelectedValue.Substring(0, 4);
                string sStarDate, sEndDate;
                DateTime dt = Convert.ToDateTime(date);
                sStarDate = MonthDDL.SelectedValue + "01";
                sEndDate = dt.AddMonths(1).ToString("yyyyMMdd");
                strwhere += string.Format("and acr_date>= '{0}' and acr_date < '{1}'", sStarDate, sEndDate);
            }

            string sqlstr = @"
                                select distinct style_no
                                FROM [dbo].[acr_trn_check] a left join purc_pkd_for_acr b on a.site=b.site and a.style_no=b.cus_item_no 
								where a.CheckFlag ='NA'  and b.CheckFlag ='NA' ";
            sqlstr += strwhere;
            return sqlstr;
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                //DataTable dt = new DataTable();
                string sqlstr = selectsql();
                SqlDataAdapter myAdapter = new SqlDataAdapter(sqlstr, Conn);
                myAdapter.Fill(Ds, "SelectStyleNo");
            }
            if (Ds.Tables["SelectStyleNo"].Rows.Count > 0)
            {
                SearchGV.DataSource = Ds.Tables["SelectStyleNo"];
                SearchGV.DataBind();
                SettlementBT.Enabled = true;
            }
            else
            {
                SettlementBT.Enabled = false;
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請聯絡資訊部：應收與包裝底稿都無資料');</script>");
            }
        }
        protected void SelectAllBT_Click(object sender, EventArgs e)
        {
            Button bt = (Button)SearchGV.HeaderRow.Cells[0].FindControl("SelectAllBT");
            int icount = SearchGV.Rows.Count;
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
                    CheckBox chk = (CheckBox)SearchGV.Rows[i].Cells[0].FindControl("CheckBox1");
                    chk.Checked = bCheck;
                }
            }

        }
        private int AddStyleNo(string strStyleNo, string strAcrMonthDate)
        {
            Int32 newProdID = 0;
            string sql =
                @"INSERT INTO [dbo].[AcrTax]
                    (StyleNo,AcrMonthDate)
                    VALUES(@StyleNo,@AcrMonthDate); 
                    SELECT CAST(scope_identity() AS int)";
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@StyleNo", SqlDbType.NVarChar);
                cmd.Parameters.Add("@AcrMonthDate", SqlDbType.VarChar);
                cmd.Parameters["@name"].Value = strStyleNo;
                cmd.Parameters["@name"].Value = strAcrMonthDate;
                try
                {
                    conn.Open();
                    newProdID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Log.ErrorLog(ex, "Get AcrTax uid Error:" + strStyleNo, "TAX005.aspx");
                }
            }
            return (int)newProdID;
        }
    }
}