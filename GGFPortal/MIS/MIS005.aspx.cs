using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS
{
    public partial class MIS005 : System.Web.UI.Page
    {
        static DataSet Ds = new DataSet();

        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                //DbInit();
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
                PhoneGV.DataSource = dt;
                PhoneGV.DataBind();
            }
        }

        private string selectsql()
        {
            string strSearch;
            string strwhere = "";
            strSearch = (SearchTB.Text.Trim().Length > 0) ? SearchTB.Text.Trim() : "";

            //string sqlstr = @"SELECT * FROM [ViewACP] ";
            string sqlstr = @"
                                SELECT [phone] as '分機'
                                      ,[name] as '員工姓名'
                                      ,[empolyee_no] as '員工編號'
                                      ,[eng_name] as '英文姓名'
                                      ,[email] as 'Email'
                                      ,[skype_account] as 'Skype'
                                      ,[location] as '位置'
                                  FROM [dbo].[GGFPhoneNumber]
                            ";

            strwhere = " where [phone] like '%"+strSearch+ "%' or [name] like '%" + strSearch + "%' or [empolyee_no] like '%" + strSearch + "%' or [eng_name] like '%" + strSearch + "%' or [email] like '%" + strSearch + "%' or [skype_account] like '%" + strSearch + "%' or [location] like '%" + strSearch + "%'";
            sqlstr += strwhere ;
            return sqlstr;
        }

        protected void PhoneGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //SELECT uid,[phone] as '分機'
            //                          ,[name] as '員工姓名'
            //                          ,[empolyee_no] as '員工編號'
            //                          ,[eng_name] as '英文姓名'
            //                          ,[email] as 'Email'
            //                          ,[skype_account] as 'Skype'
            //                          ,[location] as '位置'
            //                      FROM[dbo].[GGFPhoneNumber]
            UidLB.Text= PhoneGV.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
            PhoneLB.Text = PhoneGV.Rows[e.NewSelectedIndex].Cells[2].Text.ToString();
            NameTB.Text = PhoneGV.Rows[e.NewSelectedIndex].Cells[3].Text.ToString().Replace("&nbsp;", "");
            NumberBT.Text = PhoneGV.Rows[e.NewSelectedIndex].Cells[4].Text.ToString().Replace("&nbsp;", "");
            EngName.Text = PhoneGV.Rows[e.NewSelectedIndex].Cells[5].Text.ToString().Replace("&nbsp;", "");
            EmailTB.Text= PhoneGV.Rows[e.NewSelectedIndex].Cells[6].Text.ToString().Replace("&nbsp;", "");
            SkypeBT.Text = PhoneGV.Rows[e.NewSelectedIndex].Cells[7].Text.ToString().Replace("&nbsp;", "");
            LocationDDL.SelectedValue = PhoneGV.Rows[e.NewSelectedIndex].Cells[8].Text.ToString();
            POPPanel_ModalPopupExtender.Show();
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {

            POPPanel_ModalPopupExtender.Hide();
            if (string.IsNullOrEmpty(NameTB.Text)==false)
            { 
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
                        command1.CommandText = @"
                                                UPDATE [dbo].[GGFPhoneNumber]
                                                   SET [name] = @name
                                                      ,[empolyee_no] = @empolyee_no
                                                      ,[eng_name] = @eng_name
                                                      ,[email] = @email
                                                      ,[skype_account] = @skype_account
                                                      ,[location] = @location
                                                      ,[modify_day] = getdate()
                                                      ,[modifier] = 'Progrma'
                                                 WHERE uid = @uid
                                                                    ";
                        command1.Parameters.Add("@uid", SqlDbType.Int).Value = UidLB.Text;
                        command1.Parameters.Add("@name", SqlDbType.NVarChar).Value = NameTB.Text.Trim();
                        command1.Parameters.Add("@empolyee_no", SqlDbType.NVarChar).Value = NumberBT.Text.Trim();
                        command1.Parameters.Add("@eng_name", SqlDbType.NVarChar).Value = EngName.Text.Trim();
                        command1.Parameters.Add("@email", SqlDbType.NVarChar).Value = EmailTB.Text.Trim();
                        command1.Parameters.Add("@skype_account", SqlDbType.NVarChar).Value = SkypeBT.Text.Trim();
                        command1.Parameters.Add("@location", SqlDbType.NVarChar).Value = LocationDDL.SelectedValue.ToString();

                        command1.ExecuteNonQuery();
                        command1.Parameters.Clear();
                        transaction1.Commit();

                    }
                    catch (Exception ex1)
                    {

                        try
                        {
                            Log.ErrorLog(ex1, "Insert Error", "TAX002.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Insert Error2", "TAX002.aspx");
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
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('請輸入名稱');</script>");
            }
        }
    }
}