using System;
using System.Data;
using System.Data.SqlClient;

namespace GGFPortal.VN
{
    public partial class VNProductivityManagement : System.Web.UI.Page
    {
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    YearDDL.Items.Add(DateTime.Now.AddMonths(-i).ToString("yyyy"));
                }
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
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
            //        command1.Parameters.Add("@samc_fin_date", SqlDbType.DateTime).Value =;
            //        command1.Parameters.Add("@sam_nbr", SqlDbType.NVarChar).Value = Session["SampleNbr"].ToString();
            //        command1.Parameters.Add("@site", SqlDbType.NVarChar).Value = Session["Site"].ToString();
            //        command1.ExecuteNonQuery();
            //        command1.Parameters.Clear();
            //        transaction1.Commit();
            //        //ClearData();
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
        }
    }
}