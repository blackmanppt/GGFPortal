using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using GGFPortal.ReferenceCode;

namespace GGFPortal.Sales
{
    public partial class Sample002 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        SysLog Log = new SysLog();
        Get使用者資料 使用者資料 = new Get使用者資料();
        protected void Page_Load(object sender, EventArgs e)
        {
            FinalDayTB.Attributes["readonly"] = "readonly";
            DateTB.Attributes["readonly"] = "readonly";
            TDFinTB.Attributes["readonly"] = "readonly";
            SamOutTB.Attributes["readonly"] = "readonly";
            SamInTB.Attributes["readonly"] = "readonly";
            //MarkDateTB.Attributes["readonly"] = "readonly";
            if (Session["Uid"]==null)
                UpDateBT.Visible = false;
            if (Session["SampleNbr"] ==null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有樣品單號，請重新選取');</script>");
                Response.Redirect("Sample001.aspx");
            }
            else
            {
                SampleNbrLB.Text = Session["SampleNbr"].ToString();
            }
            if (Session["Site"] == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有公司別，請重新選取');</script>");
                Response.Redirect("Sample001.aspx");
            }
            else
            {
                SiteLB.Text = Session["Site"].ToString();
            }
            if(!Page.IsPostBack )
            { 
                if (Session["SamDay"]!=null )
                {
                    FinalDayTB.Text = Session["SamDay"].ToString();
                }
                if (Session["TDDay"] != null )
                {
                    TDFinTB.Text = Session["TDDay"].ToString();
                }
                if (Session["SamIn"] != null )
                {
                    SamInTB.Text = Session["SamIn"].ToString();
                }
                if (Session["SamOut"] != null )
                {
                    SamOutTB.Text = Session["SamOut"].ToString();
                }
            }
            string xxx = "";
            xxx=使用者資料.取得電腦名稱();
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
                    transaction1 = conn1.BeginTransaction("InsertGGFRequestSam");

                    command1.Connection = conn1;
                    command1.Transaction = transaction1;
                    try
                    {
                        //TypeLB.Text = i.ToString();
                        command1.CommandText = string.Format(@"INSERT INTO [dbo].[GGFRequestSam]
                                            ([site]
                                            ,[sam_nbr]
                                            ,[SampleType]
                                            ,[SampleUser]
                                            ,[SampleNo]
                                            ,[Qty]
                                            ,[SampleCreatDate]
                                            ,[Creator]
                                            ,[Remark]
                                            )
                                        VALUES
                                            (@site
                                            ,@sam_nbr
                                            ,@SampleType
                                            ,@SampleUser
                                            ,@SampleNo
                                            ,@Qty
                                            ,@SampleCreatDate
                                            ,@Creator
                                            ,@Remark
                                            )
                                            ");
                        command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
                        command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
                        command1.Parameters.Add("@SampleType", SqlDbType.NVarChar).Value = TypeDDL.SelectedValue;
                        command1.Parameters.Add("@SampleUser", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text;
                        command1.Parameters.Add("@SampleNo", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                        command1.Parameters.Add("@Qty", SqlDbType.Decimal).Value = QtyTB.Text.Trim();
                        command1.Parameters.Add("@SampleCreatDate", SqlDbType.NVarChar).Value = DateTime.Now.ToString("yyyyMMdd");
                        command1.Parameters.Add("@Creator", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                        command1.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = RemarkTB.Text.Trim();
                        //command1.Parameters.Add("@馬克", SqlDbType.NVarChar).Value = MarkDDL.SelectedItem.Text;
                        //command1.Parameters.Add("@修改馬克", SqlDbType.NVarChar).Value = ReMarkDDL.SelectedItem.Text;
                        //command1.Parameters.Add("@馬克完成日", SqlDbType.NVarChar).Value = MarkDateTB.Text;
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();

                        transaction1.Commit();
                        ClearData();
                    }
                    catch (Exception ex1)
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
            TypeDDL.SelectedValue = "";
            UserDDL.SelectedValue = "";
            QtyTB.Text = "";
            GridView1.DataBind();
            AddBT.Visible = true;
            UpDateBT.Visible = false;
            CancelBT.Visible = false;
            Session["Uid"] = null;
            GridView1.SelectedIndex = -1;
            DateLB.Visible = false;
            DateTB.Text = "";
            DateTB.Visible = false;
            UserLB.Text = "";
            RemarkTB.Text = "";
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
                        command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestSam] SET [SampleType] = @SampleType 
                                                            ,[SampleUser] = @SampleUser,[SampleNo] = @SampleNo
                                                            ,[Qty] = @Qty,[SampleCreatDate] = @SampleCreatDate
                                                            ,[Modifier] = @Modifier
                                                            ,[ModifyDate]=GETDATE() 
                                                            ,[Remark]=@Remark
                                                            WHERE uid = {0} ", Session["Uid"].ToString());
                        command1.Parameters.Add("@SampleType", SqlDbType.NVarChar).Value = TypeDDL.SelectedValue;
                        command1.Parameters.Add("@SampleUser", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text;
                        command1.Parameters.Add("@SampleNo", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                        command1.Parameters.Add("@Qty", SqlDbType.Decimal).Value = QtyTB.Text.Trim();
                        command1.Parameters.Add("@SampleCreatDate", SqlDbType.NVarChar).Value = DateTB.Text;
                        command1.Parameters.Add("@Modifier", SqlDbType.NVarChar).Value = 使用者資料.取得使用者名稱();
                        command1.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = RemarkTB.Text.Trim();
                        //command1.Parameters.Add("@馬克", SqlDbType.NVarChar).Value = MarkDDL.SelectedItem.Text;
                        //command1.Parameters.Add("@修改馬克", SqlDbType.NVarChar).Value = ReMarkDDL.SelectedItem.Text;
                        //command1.Parameters.Add("@馬克完成日", SqlDbType.NVarChar).Value = MarkDateTB.Text;
                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();
                        ClearData();
                    }
                    catch (Exception ex1)
                    {
                        try
                        {
                            Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
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
            //Session["Uid"] = this.GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
            //if (UserDDL.Items.Contains(UserDDL.Items.FindByText(GridView1.Rows[e.NewSelectedIndex].Cells[6].Text))==true)
            //{
            //    UserDDL.SelectedValue = UserDDL.Items.FindByText(GridView1.Rows[e.NewSelectedIndex].Cells[6].Text).Value;
            //    UserLB.Text = "";
            //}
            //else
            //{
            //    UserDDL.SelectedValue = "";
            //    UserLB.Text = "離職人員";
            //}
            //TypeDDL.SelectedValue = TypeDDL.Items.FindByText(GridView1.Rows[e.NewSelectedIndex].Cells[5].Text).Value;
            //QtyTB.Text = GridView1.Rows[e.NewSelectedIndex].Cells[7].Text;
            //DateTB.Text = (this.GridView1.Rows[e.NewSelectedIndex].Cells[8].Text=="沒有資料")?"": this.GridView1.Rows[e.NewSelectedIndex].Cells[8].Text;
            //RemarkTB.Text = (this.GridView1.Rows[e.NewSelectedIndex].Cells[11].Text == "沒有資料") ? "" : this.GridView1.Rows[e.NewSelectedIndex].Cells[11].Text;
            //DateTB.Visible = true;
            //UpDateBT.Visible = true;
            //CancelBT.Visible = true;
            //DateLB.Visible = true;
            //DateTB.Visible = true;
            //AddBT.Visible = false;
            
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            
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
            if(QtyTB.Text!="")
            { 
                string RegularExpressions = null;
                RegularExpressions = "^[0-9]+(.[0-9]{1})?$";
                Match m = Regex.Match(QtyTB.Text, RegularExpressions);
                strerror += (m.Success) ? "" : (strerror.Length > 0) ? "、數量格式錯誤" : "數量格式錯誤";
            }
            

      

            return (strerror == "") ? "" : "資料錯誤："+strerror;
        }

        protected void IndexBT_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Sample001.aspx");
        }

        protected void DayUpdateBT_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(FinalDayTB.Text))
            {
                #region old code
                //using (SqlConnection conn1 = new SqlConnection(strConnectString))
                //{
                //    SqlCommand command1 = conn1.CreateCommand();
                //    SqlTransaction transaction1;
                //    conn1.Open();
                //    transaction1 = conn1.BeginTransaction("UpdateGGFSam");

                //    command1.Connection = conn1;
                //    command1.Transaction = transaction1;
                //    try
                //    {
                //        //TypeLB.Text = i.ToString();
                //        command1.CommandText = @"UPDATE [dbo].[samc_reqm] SET [samc_fin_date] = @samc_fin_date WHERE sam_nbr = @sam_nbr and site =@site ";
                //        command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = Convert.ToDateTime(FinalDayTB.Text);
                //        command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
                //        command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
                //        command1.ExecuteNonQuery();
                //        command1.Parameters.Clear();
                //        transaction1.Commit();
                //        ClearData();
                //    }
                //    catch (Exception ex1)
                //    {
                //        try
                //        {
                //            Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                //        }
                //        catch (Exception ex2)
                //        {
                //            Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                //        }
                //        finally
                //        {
                //            transaction1.Rollback();
                //            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('打版預計完成日上傳失敗');</script>");
                //        }
                //    }
                //    finally
                //    {
                //        conn1.Close();
                //        conn1.Dispose();
                //        command1.Dispose();
                //    }
                //}
                #endregion
                F_UpdataWorkDate("打版完成");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇打版完成日');</script>");
            }
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            //int x = 0;
            //if (e.CommandName=="Select")
            //{
            //    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            //    string strid = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex.ToString();
            //}
            if (e.CommandName == "EditeDetail")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                //Session["uid"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                Session["uid"] = strid;
                Response.Redirect("Sample008.aspx");
            }
            else if (e.CommandName == "EditData")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Session["Uid"] = this.GridView1.Rows[row.RowIndex].Cells[3].Text;
                if (UserDDL.Items.Contains(UserDDL.Items.FindByText(GridView1.Rows[row.RowIndex].Cells[6].Text)) == true)
                {
                    UserDDL.SelectedValue = UserDDL.Items.FindByText(GridView1.Rows[row.RowIndex].Cells[6].Text).Value;
                    UserLB.Text = "";
                }
                else
                {
                    UserDDL.SelectedValue = "";
                    UserLB.Text = "離職人員";
                }
                TypeDDL.SelectedValue = TypeDDL.Items.FindByText(GridView1.Rows[row.RowIndex].Cells[5].Text).Value;
                QtyTB.Text = GridView1.Rows[row.RowIndex].Cells[7].Text;
                DateTB.Text = (this.GridView1.Rows[row.RowIndex].Cells[8].Text == "沒有資料") ? "" : this.GridView1.Rows[row.RowIndex].Cells[8].Text;
                RemarkTB.Text = (this.GridView1.Rows[row.RowIndex].Cells[11].Text == "沒有資料") ? "" : this.GridView1.Rows[row.RowIndex].Cells[11].Text;
                DateTB.Visible = true;
                UpDateBT.Visible = true;
                CancelBT.Visible = true;
                DateLB.Visible = true;
                DateTB.Visible = true;
                AddBT.Visible = false;
            }
            else if (e.CommandName == "Delete")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                //string strid = GridView1.DataKeys[e.RowIndex].Value.ToString();

                using (SqlConnection conn = new SqlConnection(strConnectString))
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
                        command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestSam] SET [Flag] = 1 ,[ModifyDate]=GETDATE() ,Modifier=@Modifier  WHERE uid = {0} ", strid);
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
                            Log.ErrorLog(ex1, "Delete Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Delete Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
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
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button BT = (Button)e.Row.FindControl("修改馬克");
                if (e.Row.Cells[5].Text != "打版")
                    BT.Visible = false;

            }
        }
        Boolean F_UpdataWorkDate(string updataString)
        {
            bool UpDateCheck=true;
            using (SqlConnection conn1 = new SqlConnection(strConnectString))
            {
                string strDate="";
                SqlCommand command1 = conn1.CreateCommand();
                SqlTransaction transaction1;
                conn1.Open();
                transaction1 = conn1.BeginTransaction("UpdateGGFSam");

                command1.Connection = conn1;
                command1.Transaction = transaction1;
                try
                {
                    if (updataString == "打版完成")
                        strDate = @"[samc_fin_date] = @samc_fin_date";
                    else if(updataString == "樣衣收單")
                        strDate = @"[Sam_In_Date] = @Sam_In_Date";
                    else if (updataString == "樣衣完成")
                        strDate = @"[Sam_Out_Date] = @Sam_Out_Date";
                    else
                        strDate = @"[TD_Fin_Date] = @TD_Fin_Date";

                    command1.CommandText = string.Format(@"UPDATE [dbo].[samc_reqm] SET  WHERE sam_nbr = @sam_nbr and site =@site ", strDate);

                    if (updataString == "打版完成")
                        command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value = Convert.ToDateTime(FinalDayTB.Text);
                    else if (updataString == "樣衣收單")
                        command1.Parameters.Add("@Sam_In_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(SamInTB.Text);
                    else if (updataString == "樣衣完成")
                        command1.Parameters.Add("@Sam_Out_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(SamOutTB.Text);
                    else
                        command1.Parameters.Add("@TD_Fin_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(TDFinTB.Text);

                    command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
                    command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
                    command1.ExecuteNonQuery();
                    command1.Parameters.Clear();
                    transaction1.Commit();
                    ClearData();
                }
                catch (Exception ex1)
                {
                    UpDateCheck = false;
                    try
                    {
                        Log.ErrorLog(ex1, "Update Error :" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                    }
                    catch (Exception ex2)
                    {
                        Log.ErrorLog(ex2, "Update Error Error:" + Session["SampleNbr"].ToString(), "Sample002.aspx");
                    }
                    finally
                    {
                        transaction1.Rollback();
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('"+ updataString + "日上傳失敗');</script>");
                    }
                }
                finally
                {
                    conn1.Close();
                    conn1.Dispose();
                    command1.Dispose();
                }
            }
            return UpDateCheck;
        }

        protected void SamInBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SamInTB.Text))
            {
                F_UpdataWorkDate("樣衣收單");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇樣衣收單日');</script>");
            }
        }

        protected void SamOutBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SamOutTB.Text))
            {
                F_UpdataWorkDate("樣衣完成");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇樣衣完成日');</script>");
            }
        }

        protected void TDFinBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TDFinTB.Text))
            {
                F_UpdataWorkDate("TD完成");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請選擇TD完成日');</script>");
            }
        }
    }
}