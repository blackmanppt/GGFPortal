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
    public partial class TAX003 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);
            SaveBT2.Attributes.Add("onclick ", "return confirm( '確定要儲存發票號碼?');");
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
                AcrTicketGV.DataSource = dt;
                AcrTicketGV.DataBind();
            }
        }

        private string selectsql()
        {
            string strwhere = "";
            string strStartDay, strEndDay;
            strwhere += (string.IsNullOrEmpty(StyleNoTB.Text.Trim())) ? "" : " and style_no = '" + StyleNoTB.Text.Trim() + "' ";
            strStartDay = (StartDayTB.Text.Length > 0) ? StartDayTB.Text : "2014-01-01";
            strEndDay = (EndDayTB.Text.Length > 0) ? EndDayTB.Text : "2999-01-01";
            strwhere += " and acr_date between '" + strStartDay + "' and '" + strEndDay + "' ";
            if (MonthDDL.SelectedIndex>0)
            {
                string date = MonthDDL.SelectedValue.Substring(4) + "/01/" + MonthDDL.SelectedValue.Substring(0, 4);
                string sStarDate, sEndDate;
                DateTime dt = Convert.ToDateTime(date);
                sStarDate = MonthDDL.SelectedValue + "01";
                sEndDate = dt.AddMonths(1).ToString("yyyyMMdd");
                strwhere += "and acr_date>= '" + sStarDate + "' and acr_date < '"+ sEndDate+ "'";
            }
            string sqlstr = @"
                                select uid,CheckFlag,CheckCreateDate,ticket,site,kind,acr_nbr,acr_seq,acr_date,style_no,acr_status,reference_no,reason
                                FROM [dbo].[acr_trn_check] where CheckFlag <>'CA' ";
            sqlstr += strwhere;
            return sqlstr;
        }

  

        protected void SaveBT_Click(object sender, EventArgs e)
        {

            //POPPanel_ModalPopupExtender.Hide();
            //if (string.IsNullOrEmpty(NameTB.Text) == false)
            //{
            //    using (SqlConnection conn1 = new SqlConnection(strConnectString))
            //    {
            //        SqlCommand command1 = conn1.CreateCommand();
            //        SqlTransaction transaction1;
            //        conn1.Open();
            //        transaction1 = conn1.BeginTransaction("createphone");

            //        command1.Connection = conn1;
            //        command1.Transaction = transaction1;

            //        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
            //        try
            //        {
            //            command1.CommandText = @"
            //                                    UPDATE [dbo].[GGFPhoneNumber]
            //                                       SET [name] = @name
            //                                          ,[empolyee_no] = @empolyee_no
            //                                          ,[eng_name] = @eng_name
            //                                          ,[email] = @email
            //                                          ,[skype_account] = @skype_account
            //                                          ,[location] = @location
            //                                          ,[modify_day] = getdate()
            //                                          ,[modifier] = 'Progrma'
            //                                     WHERE uid = @uid
            //                                                        ";
            //            command1.Parameters.Add("@uid", SqlDbType.Int).Value = UidLB.Text;
            //            command1.Parameters.Add("@name", SqlDbType.NVarChar).Value = NameTB.Text.Trim();
            //            command1.Parameters.Add("@empolyee_no", SqlDbType.NVarChar).Value = NumberBT.Text.Trim();
            //            command1.Parameters.Add("@eng_name", SqlDbType.NVarChar).Value = EngName.Text.Trim();
            //            command1.Parameters.Add("@email", SqlDbType.NVarChar).Value = EmailTB.Text.Trim();
            //            command1.Parameters.Add("@skype_account", SqlDbType.NVarChar).Value = SkypeBT.Text.Trim();
            //            command1.Parameters.Add("@location", SqlDbType.NVarChar).Value = LocationDDL.SelectedValue.ToString();

            //            command1.ExecuteNonQuery();
            //            command1.Parameters.Clear();
            //            transaction1.Commit();

            //        }
            //        catch (Exception ex1)
            //        {

            //            try
            //            {
            //                Log.ErrorLog(ex1, "Insert Error", "MIS004.aspx");
            //            }
            //            catch (Exception ex2)
            //            {
            //                Log.ErrorLog(ex2, "Insert Error2", "MIS004.aspx");
            //            }
            //            finally
            //            {
            //                transaction1.Rollback();
            //            }
            //        }
            //        finally
            //        {
            //            conn1.Close();
            //            conn1.Dispose();
            //            command1.Dispose();
            //        }
            //    }
            //}
            //else
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請輸入名稱');</script>");
            //}
        }

        protected void SearchBT_Click1(object sender, EventArgs e)
        {
            DbInit();
        }

        protected void SaveBT2_Click(object sender, EventArgs e)
        {
            int iGVCount = 0;
            string suid = "";
            iGVCount = AcrTicketGV.Rows.Count;
            for (int i = 0; i < iGVCount; i++)
            {
                CheckBox chk = (CheckBox)AcrTicketGV.Rows[i].Cells[0].FindControl("CheckBox1");
                if(chk.Checked)
                {
                    suid += string.Format( ",{0} ", AcrTicketGV.Rows[i].Cells[1].Text);
                }
            }
            
            if (suid.Length>0 && string.IsNullOrEmpty(TicketBT.Text.Trim())==false)
            {
                Boolean bSessuceCheck = false;
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("createphone");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;

                    ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
                    try
                    {
                        command1.CommandText =string.Format( @"UPDATE [dbo].[acr_trn_check] SET [ticket] = @ticket WHERE uid in ({0}) ", suid.Substring(1));
                        command1.Parameters.Add("@ticket", SqlDbType.NVarChar).Value = TicketBT.Text.Trim();
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        bSessuceCheck = true;
                        TicketBT.Text = "";

                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Insert Error", "TAX003.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Insert Error2", "TAX003.aspx");
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
                        if(bSessuceCheck)
                            DbInit(); 
                        else
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('資料更新失敗，請跟MIS確認');</script>");
                    }
                }
            }
            else
            {
                string sAlertMessage="";
                if (string.IsNullOrEmpty(TicketBT.Text.Trim()))
                {
                    sAlertMessage = "發票號碼未填";
                }
                if (suid.Length==0)
                {
                    sAlertMessage +=(sAlertMessage.Length>0) ? string.Format("\\n{0}", "未勾選應收單據"): string.Format("{0}", "未勾選應收單據");
                }
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + sAlertMessage + "');</script>");
            }
        }

        protected void SelectAllBT_Click(object sender, EventArgs e)
        {
            Button bt = (Button)AcrTicketGV.HeaderRow.Cells[0].FindControl("SelectAllBT");
            int icount = AcrTicketGV.Rows.Count;
            Boolean bCheck = false;

            if (icount>0)
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

        }
    }
}