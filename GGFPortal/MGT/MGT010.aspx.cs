using System;
using System.Data;
using System.Data.SqlClient;

namespace GGFPortal.MGT
{

    public partial class MGT010 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void F_Clear()
        {
            原因歸屬TB.Text = "";
        }

        
        public void F_ErrorShow(string strError)
        {
            MessageLB.Text = strError;
            AlertPanel_ModalPopupExtender.Show();
        }

        protected void 新增BT_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn1 = new SqlConnection(strConnectString))
            {
                SqlCommand command1 = conn1.CreateCommand();
                SqlTransaction transaction1;
                conn1.Open();
                transaction1 = conn1.BeginTransaction("InsertCode");

                try
                {
                    command1.Connection = conn1;
                    command1.Transaction = transaction1;

                    command1.CommandText = @"INSERT INTO [dbo].[Mapping]
                                                   ([UsingDefine]
                                                   ,[Data]
                                                   ,[MappingData]
                                                   ,[CreateDate]
                                                   ,[CreateUser])
                                             VALUES
                                                   (@UsingDefine
                                                   ,@Data
                                                   ,@MappingData
                                                   ,@CreateDate
                                                   ,@CreateUser)
                                        ";
                    command1.Parameters.Add("@UsingDefine", SqlDbType.Text).Value = "原因歸屬";
                    command1.Parameters.Add("@Data", SqlDbType.NVarChar).Value = 原因歸屬TB.Text;
                    command1.Parameters.Add("@MappingData", SqlDbType.NVarChar).Value = 原因歸屬TB.Text;
                    command1.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value =DateTime.Now;
                    command1.Parameters.Add("@CreateUser", SqlDbType.NVarChar).Value = "Program";

                    command1.ExecuteNonQuery();
                    command1.Parameters.Clear();

                    transaction1.Commit();
                    原因GV.DataBind();
                    F_Clear();
                }
                catch (Exception ex1)
                {
                    try
                    {
                        Log.ErrorLog(ex1, "Insert Error :", "MGT010.aspx");
                        F_ErrorShow(ex1.ToString());
                    }
                    catch (Exception ex2)
                    {
                        Log.ErrorLog(ex2, "Insert Error Error:", "MGT010.aspx");
                        F_ErrorShow(ex2.ToString());
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