using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.VN
{
    public partial class VNTest : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strid = GridView1.DataKeys[e.RowIndex].Value.ToString();
            using (SqlConnection conn = new SqlConnection(strConnectString))
            {
                conn.Open();
                SqlCommand command1 = conn.CreateCommand();
                SqlTransaction transaction1;
                transaction1 = conn.BeginTransaction("UpdateSamTest");

                command1.Connection = conn;
                command1.Transaction = transaction1;
                try
                {
                    //TypeLB.Text = i.ToString();
                    command1.CommandText = string.Format(@"UPDATE [dbo].[Productivity_Head] SET [Flag] = 2 ,[ModifyDate]=GETDATE()  WHERE uid = {0} ", strid);
                    command1.ExecuteNonQuery();
                    command1.Parameters.Clear();
                    transaction1.Commit();
                    //ClearData();
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
}