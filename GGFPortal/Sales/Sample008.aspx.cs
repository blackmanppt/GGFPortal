using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using GGFPortal.資料庫連線;
using GGFPortal.ReferenceCode;
using System.Web;

namespace GGFPortal.Sales
{
    public partial class Sample008 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        Get使用者資料 使用者資料 = new Get使用者資料();
        protected void Page_Load(object sender, EventArgs e)
        {
            //防止上一頁
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.MinValue);

            DateTB.Attributes["readonly"] = "readonly";

            if (Session["uid"]==null)
                Response.Redirect("Sample001.aspx");
            else
            {
                if (!Page.IsPostBack)
                {
                    SiteHF.Value = Session["Site"].ToString();
                    SampleNbrHF.Value = Session["SampleNbr"].ToString();
                    DeptHF.Value = Session["Dept"].ToString();
                    GGFDataContext db = new GGFDataContext();
                    var xx = from x in db.GGFRequestSam
                             where x.uid == Int32.Parse(Session["uid"].ToString())
                             select x;
                    foreach (var item in xx)
                    {
                        SampleNbrLB.Text = item.sam_nbr;
                        打樣人員LB.Text = item.SampleUser;
                    }
                }
            }
            //if (Session["SampleNbr"] ==null)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有樣品單號，請重新選取');</script>");
            //    Response.Redirect("Sample008.aspx");
            //}
            //else
            //{
            //    SampleNbrLB.Text = Session["SampleNbr"].ToString();
            //}
            //if(Session["SampleUser"] ==null)
            //    Response.Redirect("Sample008.aspx");
        }

        protected void AddBT_Click(object sender, EventArgs e)
        {
            string strCheck = CheckData();
            if (strCheck == "")
            {
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("InsertGGFRequestMark");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        //TypeLB.Text = i.ToString();
                        command1.CommandText = string.Format(@"INSERT INTO [dbo].[GGFRequestMark]
                                                               ([uid]
                                                               ,[修改人員]
                                                               ,[工號]
                                                               ,[處理類別]
                                                               ,[Creator]
                                                               ,[處理時間]
                                                               ,[件數]
                                                               ,[備註]
                                                               )
                                                            VALUES
                                                                (@uid
                                                                ,@修改人員
                                                                ,@工號
                                                                ,@處理類別
                                                                ,@Creator
                                                                ,@處理時間
                                                                ,@件數
                                                                ,@備註
                                                                )
                                                                ");
                        command1.Parameters.Add("@uid", SqlDbType.Int).Value = Session["uid"].ToString();
                        command1.Parameters.Add("@修改人員", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text; ;
                        command1.Parameters.Add("@工號", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                        command1.Parameters.Add("@處理類別", SqlDbType.Int).Value = TypeDDL.SelectedValue;
                        command1.Parameters.Add("@Creator", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                        command1.Parameters.Add("@處理時間", SqlDbType.NVarChar).Value = DateTB.Text;
                        command1.Parameters.Add("@件數", SqlDbType.NVarChar).Value = 件數TB.Text;
                        command1.Parameters.Add("@備註", SqlDbType.NVarChar).Value = 備註TB.Text;
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        ClearData();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Insert Error :" + Session["SampleNbr"].ToString(), "Sample008.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Insert Error Error:" + Session["SampleNbr"].ToString(), "Sample008.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('新增失敗請連絡MIS');</script>");
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('" + strCheck + "');</script>");
            }
        }

        protected void ClearData()
        {
            TypeDDL.SelectedValue = "1";
            UserDDL.SelectedValue = "";
            //QtyTB.Text = "";
            GridView1.DataBind();
            AddBT.Visible = true;
            UpDateBT.Visible = false;
            CancelBT.Visible = false;
            Session["id"] = null;
            GridView1.SelectedIndex = -1;
            //DateLB.Visible = false;
            DateTB.Text = "";
            //DateTB.Visible = false;
            件數TB.Text = "";
            備註TB.Text = "";
        }

        protected void UpDateBT_Click1(object sender, EventArgs e)
        {
            string strCheck = CheckData();
            if (strCheck == "")
            {
                using (SqlConnection conn1 = new SqlConnection(strConnectString))
                {
                    SqlCommand command1 = conn1.CreateCommand();
                    SqlTransaction transaction1;
                    conn1.Open();
                    transaction1 = conn1.BeginTransaction("UpdateGGFRequestSam");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        //TypeLB.Text = i.ToString();
                        command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestMark]
                                                               SET [uid] = @uid
                                                                  ,[修改人員] = @修改人員
                                                                  ,[工號] = @工號
                                                                  ,[處理類別] = @處理類別
                                                                  ,[修改日期] = GETDATE() 
                                                                  ,[Modifier] = @Modifier
                                                                  ,[處理時間] = @處理時間
                                                                  ,[件數]=@件數
                                                                  ,[備註]=@備註
                                                            WHERE id = {0} ", Session["id"].ToString());
                        command1.Parameters.Add("@uid", SqlDbType.Int).Value = Session["uid"].ToString();
                        command1.Parameters.Add("@修改人員", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text;
                        command1.Parameters.Add("@工號", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                        command1.Parameters.Add("@處理類別", SqlDbType.Int).Value = TypeDDL.SelectedValue;
                        command1.Parameters.Add("@Modifier", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                        command1.Parameters.Add("@處理時間", SqlDbType.NVarChar).Value = DateTB.Text;
                        command1.Parameters.Add("@件數", SqlDbType.NVarChar).Value = 件數TB.Text;
                        command1.Parameters.Add("@備註", SqlDbType.NVarChar).Value = 備註TB.Text;
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        ClearData();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample008.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample008.aspx");
                        }
                        finally
                        {
                            transaction1.Rollback();
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('新增失敗請連絡MIS');</script>");
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
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('"+ strCheck + "');</script>");
            }
                
        }

        protected void GridView1_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
        {
            Session["id"] = this.GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
            TypeDDL.SelectedValue = TypeDDL.Items.FindByText(this.GridView1.Rows[e.NewSelectedIndex].Cells[3].Text).Value;
            UserDDL.SelectedValue= UserDDL.Items.FindByText(this.GridView1.Rows[e.NewSelectedIndex].Cells[4].Text).Value;
            //QtyTB.Text = this.GridView1.Rows[e.NewSelectedIndex].Cells[6].Text;
            DateTB.Text = (this.GridView1.Rows[e.NewSelectedIndex].Cells[6].Text=="沒有資料")?"": this.GridView1.Rows[e.NewSelectedIndex].Cells[6].Text;
            件數TB.Text = (this.GridView1.Rows[e.NewSelectedIndex].Cells[7].Text == "沒有資料") ? "" : this.GridView1.Rows[e.NewSelectedIndex].Cells[7].Text;
            備註TB.Text = (this.GridView1.Rows[e.NewSelectedIndex].Cells[8].Text == "沒有資料") ? "" : this.GridView1.Rows[e.NewSelectedIndex].Cells[8].Text;
            //DateTB.Visible = true;
            UpDateBT.Visible = true;
            CancelBT.Visible = true;
            //DateLB.Visible = true;
            //DateTB.Visible = true;
            AddBT.Visible = false;

        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string strid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            using (SqlConnection conn =new SqlConnection(strConnectString))
            {
                conn.Open();
                SqlCommand command1 = conn.CreateCommand();
                SqlTransaction transaction1;
                transaction1 = conn.BeginTransaction("UpdateGGFRequestSam");

                command1.Connection = conn;
                command1.Transaction = transaction1;
                try
                {
                    //TypeLB.Text = i.ToString();
                    command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestMark] SET [狀態] = 1 ,[修改日期]=GETDATE() ,Modifier=@Modifier   WHERE id = {0} ", strid);
                    command1.Parameters.Add("@Modifier", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                    command1.ExecuteNonQuery();
                    command1.Parameters.Clear();
                    transaction1.Commit();
                    ClearData();
                }
                catch (Exception ex1)
                {
                    try
                    {
                        Log.ErrorLog(ex1, "Delete Error :" + Session["SampleNbr"].ToString(), "Sample008.aspx");
                    }
                    catch (Exception ex2)
                    {
                        Log.ErrorLog(ex2, "Delete Error Error:" + Session["SampleNbr"].ToString(), "Sample008.aspx");
                    }
                    finally
                    {
                        transaction1.Rollback();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('刪除失敗請連絡MIS');</script>");
                    }
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                    command1.Dispose();
                }

            }
        }

        protected void CancelBT_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        protected string CheckData()
        {
            string strerror = "";
            if (Session["SampleNbr"] == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有樣品單號，請重新選取');</script>");
                strerror = "沒有樣品單號";
            }
            if (TypeDDL.SelectedValue == "")
            {
                strerror += (strerror.Length > 0) ?  "、沒有選擇處理方式" : "沒有選擇處理方式";
            }
            if (UserDDL.SelectedValue == "")
            {
                strerror += (strerror.Length > 0) ?  "、沒有選擇處理人員" : "沒有選擇處理人員";
            }
            if(DateTB.Text==""&& UpDateBT.Visible==true)
            {
                strerror += (strerror.Length > 0) ?  "、沒有選擇處理日期" : "沒有選擇處理日期";
            }
            if (string.IsNullOrEmpty(件數TB.Text))
            {
                strerror += (strerror.Length > 0) ? "、沒有件數" : "沒有件數";
            }
            else
            {
                string RegularExpressions = null;
                RegularExpressions = @"^\+?[1-9][0-9]*$";
                Match m = Regex.Match(件數TB.Text, RegularExpressions);
                strerror += (m.Success) ? "" : (strerror.Length > 0) ? "、件數格式錯誤" : "件數格式錯誤";
            }
            //if(QtyTB.Text!="")
            //{ 
            //    string RegularExpressions = null;
            //    RegularExpressions = "^[0-9]+(.[0-9]{1})?$";
            //    Match m = Regex.Match(QtyTB.Text, RegularExpressions);
            //    strerror += (m.Success) ? "" : (strerror.Length > 0) ? "、數量格式錯誤" : "數量格式錯誤";
            //}




            return (strerror == "") ? "" : "資料錯誤："+strerror;
        }

        protected void IndexBT_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Sample001.aspx");
        }

        protected void DayUpdateBT_Click(object sender, EventArgs e)
        {
            //if(FinalDayTB.Text!="")
            //{
            //    using (SqlConnection conn1 = new SqlConnection(strConnectString))
            //    {
            //        SqlCommand command1 = conn1.CreateCommand();
            //        SqlTransaction transaction1;
            //        conn1.Open();
            //        transaction1 = conn1.BeginTransaction("UpdateGGFSam");

            //        command1.Connection = conn1;
            //        command1.Transaction = transaction1;
            //        try
            //        {
            //            //TypeLB.Text = i.ToString();
            //            command1.CommandText = @"UPDATE [dbo].[samc_reqm] SET [samc_fin_date] = @samc_fin_date WHERE sam_nbr = @sam_nbr and site =@site ";
            //            //command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = Convert.ToDateTime(FinalDayTB.Text);
            //            command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
            //            command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
            //            command1.ExecuteNonQuery();
            //            command1.Parameters.Clear();
            //            transaction1.Commit();
            //            ClearData();
            //        }
            //        catch (Exception ex1)
            //        {
            //            try
            //            {
            //                Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
            //            }
            //            catch (Exception ex2)
            //            {
            //                Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
            //            }
            //            finally
            //            {
            //                transaction1.Rollback();
            //                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('打版預計完成日上傳失敗');</script>");
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
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇打版預計完成日');</script>");
            //}
        }

        protected void SamBT_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session["Site"] = SiteHF.Value;
            Session["SampleNbr"] = SampleNbrHF.Value;
            Session["Dept"] = DeptHF.Value;
            Response.Redirect("Sample002.aspx");
            
        }
    }
}