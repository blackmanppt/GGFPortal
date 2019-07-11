using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;

namespace GGFPortal.FactoryMG
{
    public partial class FProductivityManagement : System.Web.UI.Page
    {
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //# 設定此頁面不留Cache，讓上一頁無法回來。
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //## 初始化畫面。
            }
            //Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.WebForms;
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (YearDDL.Items.Count == 0)
            {
                //int iCountYear = DateTime.Now.Year - 2015;
                DateTime dtNow = DateTime.Now;
                //dtNow = DateTime.Parse("2020-12-01"); //測試用
                int iCountMonth = (DateTime.Now.Year - 2015);


                for (int i = 1; i < iCountMonth; i++)
                {
                    if (i == 1)
                    {
                        YearDDL.Items.Add("");
                    }
                    YearDDL.Items.Add(DateTime.Now.AddYears(-i).ToString("yyyy"));
                }
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            DBinit();
        }

        private void DBinit()
        {
            Session["SearchFlag"] = (String.IsNullOrEmpty(YearDDL.SelectedValue)) ? "1" : "2";
            Session["SearchFlag2"] = (String.IsNullOrEmpty(MonthDDL.SelectedValue)) ? "1" : "2";
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            YearDDL.SelectedValue = "";
            MonthDDL.SelectedValue = "";
            Session["SearchFlag"] = "1";
        }

        protected void GridView1_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
        {
            ModalPopupExtender1.Show();
            string struid, strFlag;
            //int iWTUid = 0;
            struid = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
            strFlag = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
            CostTB.Text = GridView1.Rows[e.NewSelectedIndex].Cells[7].Text;
            UidHF.Value = struid;
            //FlagHF.Value = strFlag;
            if (strFlag=="0")
            {
                BlockCB.Checked = false;
            }
            else
            {
                BlockCB.Checked = true;
            }
            
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {
            string strvalue;
            strvalue = (String.IsNullOrEmpty( UidHF.Value))?"": UidHF.Value;
            StringBuilder sbsql = new StringBuilder();
            if (!String.IsNullOrEmpty( strvalue))
            {
                using (SqlConnection conn = new SqlConnection(strConnectString))
                {
                    conn.Open();
                    SqlCommand Command = conn.CreateCommand();
                    SqlTransaction transaction;
                    transaction = conn.BeginTransaction("ProductivityCost");
                    Command.Connection = conn;
                    Command.Transaction = transaction;
                    try
                    {
                        //update status
                        sbsql.AppendFormat(@"
                                UPDATE [dbo].[ProductivityCost]
                                   SET [Cost] = @Cost
                                      ,[Flag] = @Flag
                                      ,[ModifyUser]=@ModifyUser
                                      ,[ModifyDate]=@ModifyDate
                                 WHERE uid =@uid");
                        Command.CommandText = sbsql.ToString();
                        Command.Parameters.Add("@Flag", SqlDbType.Bit).Value = BlockCB.Checked;
                        Command.Parameters.Add("@Cost", SqlDbType.Decimal).Value = CostTB.Text;
                        Command.Parameters.Add("@ModifyUser", SqlDbType.NVarChar).Value = "Program";
                        Command.Parameters.Add("@ModifyDate", SqlDbType.DateTime).Value = DateTime.Now;
                        Command.Parameters.Add("@uid", SqlDbType.Int).Value = UidHF.Value;
                        Command.ExecuteNonQuery();

                        transaction.Commit();
                        GridView1.DataBind();
                        UidHF.Value = "";
                    }
                    catch (SqlException ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Insert Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Insert Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        finally
                        {
                            transaction.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('新增失敗請連絡MIS');</script>");
                        }
                    }
                    finally
                    {
                        conn.Close();  // close connection
                                       //ModalPopupExtender1.Show();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請重新點選資料');</script>");
            }
            
                
        }
    }
}