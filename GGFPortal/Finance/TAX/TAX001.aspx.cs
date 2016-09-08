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
    public partial class TAX001 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.AppSettings["GGFConnectionString"];
        protected void Page_Load(object sender, EventArgs e)
        {
            //防止上一頁
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);
            DeleteBT.Attributes.Add("onclick ", "return confirm( '確定要刪除嗎');");
            if (DateDDL.Items.Count == 0)
            {
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (DateTime.Now.Year - 2015) * 12 + (DateTime.Now.Month - 12);


                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        DateDDL.Items.Add("");
                    }
                    DateDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyyMM"));
                }
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {

            if (checkData())
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('Please Select Search Data');</script>");
            else
            {
                DBInit2();//Search Data
                DBInit();

            }
        }

        private void DBInit2()
        {
            int iMonth, iYear;
            iYear = int.Parse(DateDDL.SelectedItem.Text.Substring(0, 4));
            iMonth = int.Parse(DateDDL.SelectedItem.Text.Substring(4, 2));
            string strsql = string.Format(@"select  
                                    a.*,
                                    a.foreign_amt*a.exchange_rate as 'NTDPrice',
                                    b.CheckFlag ,b.uid
                                    from acr_trn a left join acr_trn_check b on a.create_timestamp = b.create_timestamp and b.CheckFlag <>'CA'
                                    where a.site='GGF' and a.kind='AR05' and a.transaction_class='09' and a.acr_status ='OP' 
                                    AND DATEPART(MONTH, a.acr_date) ={0} and DATEPART(YEAR, a.acr_date) ={1} 
                                    Order by a.acr_date
                                    ", iMonth, iYear);
            if (Ds.Tables.Contains("acr_trn"))
                Ds.Tables.Remove("acr_trn");
            SearchReportData("acr_trn", strsql);

            if (Ds.Tables["acr_trn"].Rows.Count > 0)
            {
                // Create a DataView
                //已挑選ACR
                DataView dv = new DataView(Ds.Tables["acr_trn"]);
                dv.RowFilter = " CheckFlag = 'NA'";
                if (Ds.Tables.Contains("SelectedAcr"))
                    Ds.Tables.Remove("SelectedAcr");
                if (dv.Count > 0)
                    Ds.Tables.Add(dv.ToTable("SelectedAcr"));

                //未挑選ACR
                DataView dv2 = new DataView(Ds.Tables["acr_trn"]);
                dv2.RowFilter = " CheckFlag <> 'NA' or CheckFlag is null";
                if (Ds.Tables.Contains("Acr"))
                    Ds.Tables.Remove("Acr");
                if (dv2.Count > 0)
                    Ds.Tables.Add(dv2.ToTable("Acr"));
                if (Ds.Tables.Contains("SelectedAcr"))
                    if (Ds.Tables["SelectedAcr"].Rows.Count > 0)
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('已有挑選紀錄');</script>");

            }
            else
            {
                if (Ds.Tables.Contains("SelectedAcr"))
                    Ds.Tables.Remove("SelectedAcr");
                if (Ds.Tables.Contains("Acr"))
                    Ds.Tables.Remove("Acr");
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('No Data');</script>");
            }
        }

        private void DBInit()
        {
            if (Ds.Tables.Contains("SelectedAcr"))
                if (Ds.Tables["SelectedAcr"].Rows.Count > 0)
                {
                    ShowGV("ConvertGV", true);
                    ConvertGV.DataSource = Ds.Tables["SelectedAcr"];
                    ConvertGV.DataBind();
                }
                else
                    ShowGV("ConvertGV", false);
            else
                ShowGV("ConvertGV", false);
            if (Ds.Tables.Contains("Acr"))
                if (Ds.Tables["Acr"].Rows.Count > 0)
                {
                    ShowGV("AcrGV", true);
                    AcrGV.DataSource = Ds.Tables["Acr"];
                    AcrGV.DataBind();
                }
                else
                    ShowGV("AcrGV", false);
            else
                ShowGV("AcrGV", false);
        }

        private void ShowGV(string strGV, Boolean bshow)
        {
            switch (strGV)
            {
                case "ConvertGV":
                    DeleteBT.Visible = (bshow) ? true : false;
                    ConvertGV.Visible = (bshow) ? true : false;
                    ConvertLB.Visible = (bshow) ? true : false;
                    break;
                case "AcrGV":
                    AcrGV.Visible = (bshow) ? true : false;
                    AcrLB.Visible = (bshow) ? true : false;
                    break;
                default:
                    break;
            }

        }

        private void SearchReportData(string strType, string strsql)
        {
            //if(Ds.Tables[strType].Rows.Count>0)
            //    Ds.Tables[strType].Clear();
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                conn.Open();
                //Create a SqlConnection to the Northwind database.
                SqlCommand command = new SqlCommand(strsql, conn);
                command.CommandType = CommandType.Text;
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.SelectCommand = command;
                    adapter.Fill(Ds, strType);
                }
                catch (Exception ex)
                {
                    ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
                    Log.ErrorLog(ex, strType + " Search Data", "TAX001.aspx");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('資料搜尋錯誤:\\n" + ex.Message + "\\n請洽MIS Stone');</script>");
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        private Boolean checkData()
        {
            Boolean bCheck = false;
            if (string.IsNullOrEmpty(DateDDL.SelectedItem.Text))
                bCheck = true;
            return bCheck;
        }
        

        protected void AcrGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            AcrGV.PageIndex = e.NewSelectedIndex;
            DBInit();
        }

        protected void AcrGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AcrGV.PageIndex = e.NewPageIndex;
            DBInit();
        }

        protected void ConvertBT_Click(object sender, EventArgs e)
        {
            //測試
            if (Ds.Tables.Contains("SelectedAcr"))
            {
                if (Ds.Tables["SelectedAcr"].Rows.Count > 0)
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('已有結轉資料:\\n請洽MIS Stone');</script>");
            }
            else
            {
                if (Ds.Tables.Contains("Acr"))
                    if (Ds.Tables["Acr"].Rows.Count > 0)
                        using (SqlConnection conn1 = new SqlConnection(strConnectString))
                        {
                            SqlCommand command1 = conn1.CreateCommand();
                            SqlTransaction transaction1;
                            conn1.Open();
                            transaction1 = conn1.BeginTransaction("createOrder");

                            command1.Connection = conn1;
                            command1.Transaction = transaction1;
                            ReferenceCode.SysLog Log = new ReferenceCode.SysLog();

                            try
                            {
                                for (int i = 0; i < Ds.Tables["Acr"].Rows.Count; i++)
                                {
                                    command1.CommandText = @"INSERT INTO [dbo].[acr_trn_check]
                                                    ([create_timestamp],[site],[kind],[acr_nbr],[acr_date],[transaction_code],[transaction_class],[reverse_code]
                                                    ,[offset_method],[cus_id],[invoice_nbr],[employee_no],[dept_no],[area_no],[pay_term],[carrier_id],[transatn_term],[currency_id],[exchange_rate]
                                                    ,[offset_exchange],[offset_currency],[local_invoice_no],[tax_code],[tax_amt],[affect_column],[discount_rate],[discount_amt],[cash_flag],[data_source]
                                                    ,[acr_seq],[order_nbr],[order_seq],[adjust_code],[reference_no],[foreign_amt],[base_amt],[remark40],[reason],[rs_type],[item_no],[stockroom],[unit]
                                                    ,[unit_price],[acr_qty],[detail_amt],[iss_main_bank],[iss_branch_bank],[iss_bank_account],[cash_main_bank],[cash_branch_bank],[cash_bank_account]
                                                    ,[note_nbr],[note_type],[note_owner],[note_city],[note_issuer],[acr_counter_date],[acr_due_date],[note_due_date],[note_rec_date],[posted_bal]
                                                    ,[posted_nms],[posted_ais],[acr_status],[create_date],[modifier],[modify_date],[project_id],[adv_tax_code],[account_date],[team_dept],[keyin_user]
                                                    ,[issuer],[ord_nbr],[ord_seq],[cust_po_nbr],[prod_nbr],[ord_class],[item_statistic],[style_no])
                                                    VALUES
                                                    ( @create_timestamp,@site,@kind,@acr_nbr,@acr_date,@transaction_code,@transaction_class,@reverse_code
                                                    ,@offset_method,@cus_id,@invoice_nbr,@employee_no,@dept_no,@area_no,@pay_term,@carrier_id,@transatn_term,@currency_id,@exchange_rate
                                                    ,@offset_exchange,@offset_currency,@local_invoice_no,@tax_code,@tax_amt,@affect_column,@discount_rate,@discount_amt,@cash_flag,@data_source
                                                    ,@acr_seq,@order_nbr,@order_seq,@adjust_code,@reference_no,@foreign_amt,@base_amt,@remark40,@reason,@rs_type,@item_no,@stockroom,@unit
                                                    ,@unit_price,@acr_qty,@detail_amt,@iss_main_bank,@iss_branch_bank,@iss_bank_account,@cash_main_bank,@cash_branch_bank,@cash_bank_account
                                                    ,@note_nbr,@note_type,@note_owner,@note_city,@note_issuer,@acr_counter_date,@acr_due_date,@note_due_date,@note_rec_date,@posted_bal
                                                    ,@posted_nms,@posted_ais,@acr_status,@create_date,@modifier,@modify_date,@project_id,@adv_tax_code,@account_date,@team_dept,@keyin_user
                                                    ,@issuer,@ord_nbr,@ord_seq,@cust_po_nbr,@prod_nbr,@ord_class,@item_statistic,@style_no)
                                                    ";
                                    #region SQLData


                                    command1.Parameters.Add("@create_timestamp", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["create_timestamp"];
                                    //command1.Parameters.Add("@CheckFlag", SqlDbType.NVarChar).Value = "NA";//NA新增狀態
                                    command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["site"];
                                    command1.Parameters.Add("@kind", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["kind"];
                                    command1.Parameters.Add("@acr_nbr", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["acr_nbr"];
                                    command1.Parameters.Add("@acr_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["acr_date"];
                                    command1.Parameters.Add("@transaction_code", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["transaction_code"];
                                    command1.Parameters.Add("@transaction_class", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["transaction_class"];
                                    command1.Parameters.Add("@reverse_code", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["reverse_code"];
                                    command1.Parameters.Add("@offset_method", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["offset_method"];
                                    command1.Parameters.Add("@cus_id", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["cus_id"];
                                    command1.Parameters.Add("@invoice_nbr", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["invoice_nbr"];
                                    command1.Parameters.Add("@employee_no", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["employee_no"];
                                    command1.Parameters.Add("@dept_no", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["dept_no"];
                                    command1.Parameters.Add("@area_no", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["area_no"];
                                    command1.Parameters.Add("@pay_term", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["pay_term"];
                                    command1.Parameters.Add("@carrier_id", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["carrier_id"];
                                    command1.Parameters.Add("@transatn_term", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["transatn_term"];
                                    command1.Parameters.Add("@currency_id", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["currency_id"];
                                    command1.Parameters.Add("@exchange_rate", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["exchange_rate"];
                                    command1.Parameters.Add("@offset_exchange", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["offset_exchange"];
                                    command1.Parameters.Add("@offset_currency", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["offset_currency"];
                                    command1.Parameters.Add("@local_invoice_no", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["local_invoice_no"];
                                    command1.Parameters.Add("@tax_code", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["tax_code"];
                                    command1.Parameters.Add("@tax_amt", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["tax_amt"];
                                    command1.Parameters.Add("@affect_column", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["affect_column"];
                                    command1.Parameters.Add("@discount_rate", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["discount_rate"];
                                    command1.Parameters.Add("@discount_amt", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["discount_amt"];
                                    command1.Parameters.Add("@cash_flag", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["cash_flag"];
                                    command1.Parameters.Add("@data_source", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["data_source"];
                                    command1.Parameters.Add("@acr_seq", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["acr_seq"];
                                    command1.Parameters.Add("@order_nbr", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["order_nbr"];
                                    command1.Parameters.Add("@order_seq", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["order_seq"];
                                    command1.Parameters.Add("@adjust_code", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["adjust_code"];
                                    command1.Parameters.Add("@reference_no", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["reference_no"];
                                    command1.Parameters.Add("@foreign_amt", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["foreign_amt"];
                                    command1.Parameters.Add("@base_amt", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["base_amt"];
                                    command1.Parameters.Add("@remark40", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["remark40"];
                                    command1.Parameters.Add("@reason", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["reason"];
                                    command1.Parameters.Add("@rs_type", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["rs_type"];
                                    command1.Parameters.Add("@item_no", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["item_no"];
                                    command1.Parameters.Add("@stockroom", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["stockroom"];
                                    command1.Parameters.Add("@unit", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["unit"];
                                    command1.Parameters.Add("@unit_price", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["unit_price"];
                                    command1.Parameters.Add("@acr_qty", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["acr_qty"];
                                    command1.Parameters.Add("@detail_amt", SqlDbType.Int).Value = Ds.Tables["Acr"].Rows[i]["detail_amt"];
                                    command1.Parameters.Add("@iss_main_bank", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["iss_main_bank"];
                                    command1.Parameters.Add("@iss_branch_bank", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["iss_branch_bank"];
                                    command1.Parameters.Add("@iss_bank_account", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["iss_bank_account"];
                                    command1.Parameters.Add("@cash_main_bank", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["cash_main_bank"];
                                    command1.Parameters.Add("@cash_branch_bank", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["cash_branch_bank"];
                                    command1.Parameters.Add("@cash_bank_account", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["cash_bank_account"];
                                    command1.Parameters.Add("@note_nbr", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["note_nbr"];
                                    command1.Parameters.Add("@note_type", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["note_type"];
                                    command1.Parameters.Add("@note_owner", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["note_owner"];
                                    command1.Parameters.Add("@note_city", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["note_city"];
                                    command1.Parameters.Add("@note_issuer", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["note_issuer"];
                                    command1.Parameters.Add("@acr_counter_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["acr_counter_date"];
                                    command1.Parameters.Add("@acr_due_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["acr_due_date"];
                                    command1.Parameters.Add("@note_due_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["note_due_date"];
                                    command1.Parameters.Add("@note_rec_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["note_rec_date"];
                                    command1.Parameters.Add("@posted_bal", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["posted_bal"];
                                    command1.Parameters.Add("@posted_nms", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["posted_nms"];
                                    command1.Parameters.Add("@posted_ais", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["posted_ais"];
                                    command1.Parameters.Add("@acr_status", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["acr_status"];
                                    command1.Parameters.Add("@create_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["create_date"];
                                    command1.Parameters.Add("@modifier", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["modifier"];
                                    command1.Parameters.Add("@modify_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["modify_date"];
                                    command1.Parameters.Add("@project_id", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["project_id"];
                                    command1.Parameters.Add("@adv_tax_code", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["adv_tax_code"];
                                    command1.Parameters.Add("@account_date", SqlDbType.DateTime).Value = Ds.Tables["Acr"].Rows[i]["account_date"];
                                    command1.Parameters.Add("@team_dept", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["team_dept"];
                                    command1.Parameters.Add("@keyin_user", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["keyin_user"];
                                    command1.Parameters.Add("@issuer", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["issuer"];
                                    command1.Parameters.Add("@ord_nbr", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["ord_nbr"];
                                    command1.Parameters.Add("@ord_seq", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["ord_seq"];
                                    command1.Parameters.Add("@cust_po_nbr", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["cust_po_nbr"];
                                    command1.Parameters.Add("@prod_nbr", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["prod_nbr"];
                                    command1.Parameters.Add("@ord_class", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["ord_class"];
                                    command1.Parameters.Add("@item_statistic", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["item_statistic"];
                                    command1.Parameters.Add("@style_no", SqlDbType.NVarChar).Value = Ds.Tables["Acr"].Rows[i]["style_no"];
                                    #endregion
                                    command1.ExecuteNonQuery();
                                    command1.Parameters.Clear();
                                }
                                transaction1.Commit();
                                DBInit2();//Search Data
                                DBInit();

                            }
                            catch (Exception ex1)
                            {
                                try
                                {
                                    Log.ErrorLog(ex1, "Insert Error", "TAX001.aspx");
                                }
                                catch (Exception ex2)
                                {
                                    Log.ErrorLog(ex2, "Insert Error2", "TAX001.aspx");
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

        }

        protected void ConvertGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ConvertGV.PageIndex = e.NewPageIndex;
            DBInit();
        }


        protected void DeleteBT_Click(object sender, EventArgs e)
        {
            if(Ds.Tables["SelectedAcr"].Rows.Count>0)
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("createOrder");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    ReferenceCode.SysLog Log = new ReferenceCode.SysLog();

                    try
                    {
                        string strwhere = "";
                        for (int i = 0; i < Ds.Tables["SelectedAcr"].Rows.Count; i++)
                        {
                            if (i > 0)
                                strwhere += " , ";
                            strwhere += " '" + Ds.Tables["SelectedAcr"].Rows[i]["uid"] + "' ";

                        }
                        command1.CommandText = @"UPDATE [dbo].[acr_trn_check]
                                                   SET 
                                                      [CheckFlag] = 'CA'
                                                      ,[CheckModifyDate] =getdate()
      
                                                 WHERE uid in (" + strwhere + ") ";

                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        DBInit2();//Search Data
                        DBInit();

                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Delete Error", "TAX001.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Delete Error2", "TAX001.aspx");
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
    }
}