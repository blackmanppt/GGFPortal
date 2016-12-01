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
    public partial class TAX006 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        static DataSet Ds=new DataSet();
        ReferenceCode.SearchDataToDataSet GetData = new ReferenceCode.SearchDataToDataSet();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDayTB.Attributes["readonly"] = "readonly";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);
            if (MonthDDL.Items.Count == 0)
            {
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
                    cmd.CommandText = @"select top 10 uid,StyleNo,AcrMonthDate,AcrAmt,PkdAmt from AcrTax
                                where Flag=1   and StyleNo like '%'+  @SearchText + '%'";
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
            strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "201601";
            strEndDay = (EndDayTB.Text.Length > 0) ? EndDayTB.Text : "299901";
            strwhere += string.Format(" and AcrMonthDate between '{0}' and '{1}' ", strStartDay, strEndDay);
            string sqlstr = @"select uid,StyleNo,AcrMonthDate,AcrAmt,PkdAmt from AcrTax
                                where Flag=1 ";
            sqlstr += strwhere;
            return sqlstr;
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {
            int icount = AcrTicketGV.Rows.Count;
            //Boolean bCheck = false;
            if (icount > 0)
            {
                int iCbcount = 0;
                string strAcrAdd = "", strAcrDelete = "", strPkdAdd = "", strPkdDelete = "";
                double dAcr = 0, dPkd = 0;
                for (int i = 0; i < icount; i++)
                {
                    CheckBox chk = (CheckBox)AcrTicketGV.Rows[i].Cells[0].FindControl("CheckBox1");
                    //chk.Checked = bCheck;
                    //Add
                    if (chk.Checked)
                    {
                        if (AcrTicketGV.Rows[i].Cells[4].Text == "應收")
                        {
                            strAcrAdd += " ," + AcrTicketGV.Rows[i].Cells[1].Text;
                            dAcr += Convert.ToDouble(AcrTicketGV.Rows[i].Cells[6].Text);
                        }
                        else
                        {
                            strPkdAdd += " ," + AcrTicketGV.Rows[i].Cells[1].Text;
                            dPkd += Convert.ToDouble(AcrTicketGV.Rows[i].Cells[7].Text);
                        }
                        iCbcount++;
                    }
                    //Delete
                    else
                    {
                        if (AcrTicketGV.Rows[i].Cells[4].Text == "應收")
                        {
                            strAcrDelete += " ," + AcrTicketGV.Rows[i].Cells[1].Text;
                        }
                        else
                        {
                            strPkdDelete += " ," + AcrTicketGV.Rows[i].Cells[1].Text;
                        }
                    }
                }

                if (strAcrAdd.Length>0 || strPkdAdd.Length>0)
                {

                    if (dAcr *0.8>dPkd)
                    {
                        string strAcrTaxID = "";
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
                                command1.CommandText = string.Format(@"UPDATE [dbo].[acr_trn_check] SET [AcrTaxID] = {0} , CheckFlag ='NA' WHERE uid in ({1}) ", Session["AcrId"], strAcrAdd.Substring(2));
                                command1.ExecuteNonQuery();
                                //command1.Parameters.Clear();

                                if (strAcrDelete.Length>0)
                                {
                                    command1.CommandText = string.Format(@"UPDATE [dbo].[acr_trn_check] SET [AcrTaxID] = Null , CheckFlag ='NA' WHERE uid in ({0}) ", strAcrDelete.Substring(2));
                                    command1.ExecuteNonQuery();
                                }

                                command1.CommandText = string.Format(@"UPDATE [dbo].[purc_pkd_for_acr] SET [AcrTaxID] = {0} , CheckFlag ='NA' WHERE uid in ({1}) ", Session["AcrId"], strPkdAdd.Substring(2));
                                command1.ExecuteNonQuery();

                                if (strPkdDelete.Length>0)
                                {
                                    command1.CommandText = string.Format(@"UPDATE [dbo].[purc_pkd_for_acr] SET [AcrTaxID] = Null , CheckFlag ='NA' WHERE uid in ({0}) ", strPkdDelete.Substring(2));
                                    command1.ExecuteNonQuery();
                                }
                                
                                //command1.CommandText = string.Format(@"UPDATE [dbo].[AcrTax] SET [Flag] = 2  WHERE uid = {0} ", strAcrTaxID);
                                //command1.ExecuteNonQuery();
                                transaction1.Commit();
                            }
                            catch (Exception ex1)
                            {
                                try
                                {
                                    Log.ErrorLog(ex1, "Updata Error AcrTaxID:" + strAcrTaxID, "TAX006.aspx");
                                }
                                catch (Exception ex2)
                                {
                                    Log.ErrorLog(ex2, "Updata Error2 AcrTaxID:" + strAcrTaxID, "TAX006.aspx");
                                }
                                finally
                                {
                                    MessageLB.Text = "更新失敗請與資訊部聯絡";
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
                        MessageLB.Text = string.Format("包裝金額 {0} * 0.8 = {1} 大於應收金額 {2} '", dAcr, dAcr * 0.8, dPkd);
                        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", string.Format("<script>alert('包裝金額 {0} * 0.8 = {1} 大於應收金額 {2} ');</script>", dAcr, dAcr * 0.8 , dPkd));
                        POPPanel_ModalPopupExtender.Show();
                    }
                    
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇應收與包裝資料');</script>");
                    MessageLB.Text = "請選擇應收與包裝資料";
                    POPPanel_ModalPopupExtender.Show();
                    
                }

            }

        }


        protected void ACRGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            MessageLB.Text = "";
            string strAcrId= ACRGV.Rows[e.NewSelectedIndex].Cells[1].Text.ToString().Replace("&nbsp;", "");
            string strStyleNo = ACRGV.Rows[e.NewSelectedIndex].Cells[2].Text.ToString().Replace("&nbsp;", "");
            Session["AcrId"] = strAcrId;
            //string strWhere = ;
            if (string.IsNullOrEmpty(strAcrId) ==false)
            {
                if (Ds.Tables.Contains("acr_trn_check"))
                    Ds.Tables.Remove("acr_trn_check");

                Ds.Tables.Add(GetData.SQLToDataSet(strConnectString, "select * from  acr_trn_check where (AcrTaxID = '" + strAcrId + "' or AcrTaxID is null ) and style_no = '" + strStyleNo+"'", "acr_trn_check", "TAX004.aspx"));

                if (Ds.Tables.Contains("purc_pkd_check"))
                    Ds.Tables.Remove("purc_pkd_check");
                Ds.Tables.Add(GetData.SQLToDataSet(strConnectString, "select * from purc_pkd_for_acr  where (AcrTaxID ='" + strAcrId + "' or AcrTaxID is null ) and cus_item_no ='" + strStyleNo + "'", "purc_pkd_check", "TAX004.aspx"));
                int icheck1 = 0,icheck2=0;
                icheck1 = (Ds.Tables["acr_trn_check"].Rows.Count > 0) ? 0 : 1;
                icheck2 = (Ds.Tables["purc_pkd_check"].Rows.Count > 0) ? 0 : 1;
                if (icheck1==0 && icheck2 == 0)
                {
                    if (Ds.Tables.Contains("AcrTable"))
                        Ds.Tables.Remove("AcrTable");
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

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "AcrTaxID";
                    dt.Columns.Add(column);

                    for (int i = 0; i < Ds.Tables["acr_trn_check"].Rows.Count; i++)
                    {
                        row = dt.NewRow();
                        row["id"] = Ds.Tables["acr_trn_check"].Rows[i]["uid"].ToString();
                        row["style_no"] = Ds.Tables["acr_trn_check"].Rows[i]["style_no"].ToString();
                        row["DATE"] = Ds.Tables["acr_trn_check"].Rows[i]["acr_date"].ToString();
                        row["TYPE"] = "應收";
                        row["MONEY"] = Ds.Tables["acr_trn_check"].Rows[i]["base_amt"].ToString();
                        //row["AMT"] = Ds.Tables["acr_trn_check"].Rows[i]["uid"].ToString();
                        row["nbr"] = Ds.Tables["acr_trn_check"].Rows[i]["acr_nbr"].ToString();
                        row["AcrTaxID"] = Ds.Tables["acr_trn_check"].Rows[i]["AcrTaxID"].ToString().Replace("&nbsp;", "");
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
                        row["nbr"] = Ds.Tables["purc_pkd_check"].Rows[i]["pak_nbr"].ToString()+ Ds.Tables["purc_pkd_check"].Rows[i]["pak_seq"].ToString();
                        row["AcrTaxID"] = Ds.Tables["purc_pkd_check"].Rows[i]["AcrTaxID"].ToString().Replace("&nbsp;", "");
                        dt.Rows.Add(row);

                    }
                    POPPanel_ModalPopupExtender.Show();
                    AcrTicketGV.DataSource = dt;
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

        protected void ACRGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('"+ ACRGV.Rows[e.RowIndex].Cells[1].Text.ToString().Replace("&nbsp;", "") + "');</script>");
            string strAcrTaxID = ACRGV.Rows[e.RowIndex].Cells[1].Text.ToString().Replace("&nbsp;", "");
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
                    command1.CommandText = string.Format(@"UPDATE [dbo].[acr_trn_check] SET [AcrTaxID] = Null , CheckFlag ='NA' WHERE AcrTaxID = ({0}) ", strAcrTaxID);
                    command1.ExecuteNonQuery();
                    command1.Parameters.Clear();

                    command1.CommandText = string.Format(@"UPDATE [dbo].[purc_pkd_for_acr] SET [AcrTaxID] = Null , CheckFlag ='NA' WHERE AcrTaxID = ({0}) ", strAcrTaxID);
                    command1.ExecuteNonQuery();
                    command1.Parameters.Clear();

                    command1.CommandText = string.Format(@"UPDATE [dbo].[AcrTax] SET [Flag] = 2  WHERE uid = {0} ", strAcrTaxID);
                    command1.ExecuteNonQuery();
                    transaction1.Commit();
                }
                catch (Exception ex1)
                {
                    try
                    {
                        Log.ErrorLog(ex1, "Delete Error AcrTaxID:" + strAcrTaxID, "TAX006.aspx");
                    }
                    catch (Exception ex2)
                    {
                        Log.ErrorLog(ex2, "Delete Error2 AcrTaxID:" + strAcrTaxID, "TAX006.aspx");
                    }
                    finally
                    {
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

        protected void AcrTicketGV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cb1;
                cb1 = (CheckBox)e.Row.FindControl("CheckBox1");
                if (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[7] != null)
                    cb1.Checked = (((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[7].ToString() == "") ? false : true;
            }
        }
        //private int[,] F_GetProcent()
        //{
        //    int[,] iCount;


        //    return iCount;
        //}


    }
}