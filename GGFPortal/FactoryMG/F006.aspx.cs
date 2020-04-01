using GGFPortal.ReferenceCode;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace GGFPortal.FactoryMG
{
    public partial class F006 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        ReferenceCode.DataCheck 確認LOCK = new ReferenceCode.DataCheck();
        static string StrArea = "";
        static string StrPageName = "F006";
        static 多語 lang = new 多語();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                lang.gg.Clear();
                if (Session["Area"].ToString() == "")
                {
                    Response.Redirect("Findex.aspx");
                }
                StrArea = Session["Area"].ToString();
                //網頁標題
                if (StrArea == "TW")
                {
                    AreaDDL.Visible = true;
                    AreaLB.Visible = true;
                }
                else
                {
                    AreaDDL.Visible = false;
                    AreaLB.Visible = false;
                }
                lang.讀取多語資料("Program", StrPageName);
                StrArea = Session["Area"].ToString();
                #region 網頁Layout基本參數
                //網頁標題
                //BrandLB.Text = lang.翻譯("Program", StrPageName, StrArea);
                Page.Title = lang.翻譯("Program", StrPageName, StrArea);
                //MonthLB.Text = lang.翻譯("Program", "SelectMonth", StrArea);
                #endregion
            }
            catch (Exception)
            {
                Response.Redirect("Findex.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            EndDayTB.Attributes["readonly"] = "readonly";
            if(!IsPostBack)
                DbInit();
        }
        protected void Search_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(GridView1.PageIndex) != 0)
            {
                //==如果不加上這行IF判別式，假設當我們看第四頁時， 
                //==又輸入新的條件，重新作搜尋。「新的」搜尋結果將會直接看見 "第四頁"！這個問題發生在這裡，請看！=== 
                GridView1.PageIndex = 0;
            }
            DbInit();
        }

        private string[] SplitEnter(string strPur)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = strPur.Split(stringSeparators, StringSplitOptions.None);
            return lines;
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
            string strwhere = "";
            strwhere = string.Format(@" and a.Date between '{0}' and '{1}' {2}"
                                        , (String.IsNullOrEmpty(StartDayTB.Text)) ? "19000101" : StartDayTB.Text
                                        , (String.IsNullOrEmpty(EndDayTB.Text)) ? "29991231" : EndDayTB.Text
                                        , (FlagDDL.SelectedValue=="%")?"":" and a.Flag = '"+FlagDDL.SelectedValue+"' "
                                        );
            
            string sqlstr = string.Format(@"
                                SELECT a.uid, a.Date, b.MappingData, CASE WHEN a.Flag = 1 THEN N'新增' WHEN a.Flag = 2 THEN N'刪除' ELSE '' END AS 狀態, a.CreateDate, a.ModifyDate 
                                FROM Productivity_Head AS a LEFT OUTER JOIN Mapping AS b ON a.Team = b.Data AND b.UsingDefine = 'Productivity'
                                where a.Flag>0 and Area ='{1}' {0}
                                order by Date desc
                            ", strwhere, (StrArea == "TW") ? AreaDDL.SelectedValue : StrArea);


            return sqlstr;
        }

        private string SplitArray(string strtext, string strwhere, string strType)
        {
            string[] strtextarry = SplitEnter(strtext);
            if (strtextarry.Length > 1)
            {
                string strIn = " and " + strType + " in ( ";
                for (int i = 0; i < strtextarry.Length; i++)
                {
                    if (strtextarry[i].Trim().Length > 0)
                        if (i == 0)
                            strIn += " '" + strtextarry[i].Trim() + "' ";
                        else
                            strIn += " ,'" + strtextarry[i].Trim() + "' ";
                }
                strIn += " ) ";
                strwhere += strIn;
            }
            else
                strwhere += " and " + strType + " = '" + strtext + "' ";
            return strwhere;
        }

        private string GetDateString(string strtext)
        {
            string[] words = strtext.Split('/');
            string rstr = "";
            foreach (string s in words)
            {
                rstr = (s.Length < 2) ? rstr + "0" + s : rstr + s;
            }
            return rstr;
        }

        protected void Export_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ConnectionString.ToString());
            SqlDataAdapter myAdapter = new SqlDataAdapter(selectsql(), Conn);
            DataSet ds = new DataSet();
            myAdapter.Fill(ds, "ACP");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。
            //匯出Excel
            GGFPortal.ReferenceCode.ConvertToExcel xx = new ReferenceCode.ConvertToExcel();
            xx.ExcelWithNPOI(ds.Tables["ACP"], @"xlsx");
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string strid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string strDate = "", strTeam = "";
            strDate = (GridView1.Rows[e.RowIndex].Cells[1].Text =="") ? "" : GridView1.Rows[e.RowIndex].Cells[1].Text;
            strTeam = (GridView1.Rows[e.RowIndex].Cells[2].Text =="") ? "" : GridView1.Rows[e.RowIndex].Cells[2].Text;
            if (確認LOCK.Check工時Lock(StrArea, strDate))
            {
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("DeleteVNLog");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 2,[ModifyDate]=GETDATE()   WHERE uid = {0} and Area ='{1}'", strid,StrArea);
                        //command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = strDate;
                        //command1.Parameters.Add("@Team", SqlDbType.NVarChar).Value = strTeam;
                        command1.ExecuteNonQuery();
                        transaction1.Commit();
                        //Label1.Text = "刪除完畢，請再次夾檔";
                        DbInit();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Delete Error :", "VN006.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Delete Error Error:", "VN006.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('刪除失敗請連絡MIS');</script>");
                        }
                    }
                    finally
                    {
                        conn1.Close();
                        conn1.Dispose();
                        command1.Dispose();
                        Session.RemoveAll();
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('資料已鎖定，請洽管理者');</script>");
            }
            
        }
    }
}