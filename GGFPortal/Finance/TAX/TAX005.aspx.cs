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
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString2"].ToString();
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
                        SqlDataAdapter myAdapter1 = new SqlDataAdapter(" select * from  acr_trn_check where style_no =@strStyleNo  order by base_amt", Conn);
                        myAdapter1.SelectCommand.Parameters.AddWithValue("strStyleNo", strStyleNo);
                        myAdapter1.Fill(AcrDT);
                        
                        SqlDataAdapter myAdapter2 = new SqlDataAdapter(" select * from  purc_pkd_for_acr where cus_item_no =@strStyleNo order by customs_decleartion_amt", Conn);
                        myAdapter2.SelectCommand.Parameters.AddWithValue("strStyleNo", strStyleNo);
                        myAdapter2.Fill(PkmDT);
                    }
                    if (AcrDT.Rows.Count > 0 && PkmDT.Rows.Count > 0 && ikey>0)
                    {
                        #region 計算包裝底稿
                        //object sumObjectAcr, sumObjectPkm;
                        double dAcr = 0, dPkd = 0 ,dCompare=0;
                        dAcr = Convert.ToDouble( AcrDT.Compute("Sum(base_amt)", "style_no = '"+strStyleNo+"'"));
                        dPkd = Convert.ToDouble(PkmDT.Compute("Sum(customs_decleartion_amt)", "cus_item_no = '" + strStyleNo + "'"));
                        dCompare = dAcr * 0.8;
                        string strAcrUid = "", strPkmUid = "";
                        if (dCompare < dPkd)
                        {
                            for (int k = 0; k < PkmDT.Rows.Count; k++)
                            {
                                //double dCount = 0;
                                if (dCompare >= dPkd)
                                {
                                    strPkmUid += " , " + PkmDT.Rows[k]["uid"];
                                }
                                else
                                {
                                    dPkd -= Convert.ToDouble(PkmDT.Rows[k]["customs_decleartion_amt"]);
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < PkmDT.Rows.Count; k++)
                            {
                                strPkmUid += " , " + PkmDT.Rows[k]["uid"];
                            }
                        }
                        #endregion

                        for (int j = 0; j < AcrDT.Rows.Count; j++)
                        {
                            strAcrUid += " , " + AcrDT.Rows[j]["uid"];
                        }
                        
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
                                command1.CommandText = string.Format(@"UPDATE [dbo].[acr_trn_check] SET [AcrTaxID] = @AcrTaxID , CheckFlag ='CL' WHERE uid in ({0}) ", strAcrUid.Substring(2));
                                command1.Parameters.Add("@AcrTaxID", SqlDbType.Int).Value = ikey;
                                command1.ExecuteNonQuery();
                                command1.Parameters.Clear();
                                
                                command1.CommandText = string.Format(@"UPDATE [dbo].[purc_pkd_for_acr] SET [AcrTaxID] = @AcrTaxID , CheckFlag ='CL' WHERE uid in ({0}) ", strPkmUid.Substring(2));
                                command1.Parameters.Add("@AcrTaxID", SqlDbType.Int).Value = ikey;
                                command1.ExecuteNonQuery();
                                command1.Parameters.Clear();

                                command1.CommandText = string.Format(@"UPDATE [dbo].[AcrTax] SET [Flag] = 1 , AcrAmt =@AcrAmt ,PkdAmt =@PkdAmt WHERE uid = {0} ", ikey);
                                command1.Parameters.Add("@AcrAmt", SqlDbType.Float).Value = dAcr;
                                command1.Parameters.Add("@PkdAmt", SqlDbType.Float).Value = dPkd;
                                command1.ExecuteNonQuery();
                                transaction1.Commit();
                            }
                            catch (Exception ex1)
                            {
                                try
                                {
                                    Log.ErrorLog(ex1, "Insert Error style no:" + strStyleNo, "TAX005.aspx");
                                }
                                catch (Exception ex2)
                                {
                                    Log.ErrorLog(ex2, "Insert Error2 style no:" + strStyleNo, "TAX005.aspx");
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
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("SelectStyleNo"))
                    Ds.Tables.Remove("SelectStyleNo");
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
            DB();
        }

        private void DB()
        {
            using (SqlConnection Conn = new SqlConnection(strConnectString))
            {
                if (Ds.Tables.Contains("SelectStyleNo"))
                    Ds.Tables.Remove("SelectStyleNo");
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('應收與包裝底稿都無資料');</script>");
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
                cmd.Parameters["@StyleNo"].Value = strStyleNo;
                cmd.Parameters["@AcrMonthDate"].Value = strAcrMonthDate;
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