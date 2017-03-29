using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace GGFPortal.Sales
{
    public partial class Sample002 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Uid"]==null)
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
                

        }

        protected void AddBT_Click(object sender, EventArgs e)
        {
            if (Session["SampleNbr"] != null)
            {
                if(TypeDDL.SelectedValue!="")
                {
                    if(UserDDL.SelectedValue!="")
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
                                                   ([sam_nbr]
                                                   ,[SampleType]
                                                   ,[SampleUser]
                                                   ,[SampleNo]
                                                   ,[Qty]
                                                   )
                                                VALUES
                                                    (@sam_nbr
                                                   ,@SampleType
                                                   ,@SampleUser
                                                   ,@SampleNo
                                                   ,@Qty
                                                   )
                                                    ");
                                command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
                                command1.Parameters.Add("@SampleType", SqlDbType.NVarChar).Value = TypeDDL.SelectedValue;
                                command1.Parameters.Add("@SampleUser", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text;
                                command1.Parameters.Add("@SampleNo", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                                command1.Parameters.Add("@Qty", SqlDbType.Int).Value = QtyTB.Text.Trim();
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
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有選擇處理人員，請重新選取');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有選擇處理方式，請重新選取');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有樣品單號，請重新選取');</script>");
                Response.Redirect("Sample001.aspx");
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
        }

        protected void UpDateBT_Click1(object sender, EventArgs e)
        {
            if (Session["SampleNbr"] != null)
            {
                if (TypeDDL.SelectedValue != "")
                {
                    if (UserDDL.SelectedValue != "")
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
                                command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestSam] SET [SampleType] = @SampleType ,[SampleUser] = @SampleUser,[SampleNo] = @SampleNo,[Qty] = @Qty WHERE uid = {0} ", Session["Uid"].ToString());
                                command1.Parameters.Add("@SampleType", SqlDbType.NVarChar).Value = TypeDDL.SelectedValue;
                                command1.Parameters.Add("@SampleUser", SqlDbType.NVarChar).Value = UserDDL.SelectedItem.Text;
                                command1.Parameters.Add("@SampleNo", SqlDbType.NVarChar).Value = UserDDL.SelectedValue;
                                command1.Parameters.Add("@Qty", SqlDbType.Int).Value = QtyTB.Text.Trim();
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
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有選擇處理人員，請重新選取');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有選擇處理方式，請重新選取');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('沒有樣品單號，請重新選取');</script>");
                Response.Redirect("Sample001.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
        {
            Session["Uid"] = this.GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
            TypeDDL.SelectedValue = TypeDDL.Items.FindByText(this.GridView1.Rows[e.NewSelectedIndex].Cells[4].Text).Value;
            UserDDL.SelectedValue= UserDDL.Items.FindByText(this.GridView1.Rows[e.NewSelectedIndex].Cells[5].Text).Value;
            QtyTB.Text = this.GridView1.Rows[e.NewSelectedIndex].Cells[6].Text;
            UpDateBT.Visible = true;
            CancelBT.Visible = true;
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
                    command1.CommandText = string.Format(@"UPDATE [dbo].[GGFRequestSam] SET [Flag] = 1  WHERE uid = {0} ", strid);
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

        protected void CancelBT_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}