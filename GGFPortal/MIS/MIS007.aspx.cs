using GGFPortal.DataSetSource;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS
{

    public partial class MIS007 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Today"]==null)
            //{
            //    Session["Today"] = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void 確認GV_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            using (var conn = new GGFEntitiesMGT())
            {
                int iid = 0;
                if (e.CommandName == "檢貨")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = 確認GV.DataKeys[row.RowIndex].Values[0].ToString();
                    using (SqlConnection conn1 = new SqlConnection(strConnectString))
                    {
                        SqlCommand command1 = conn1.CreateCommand();
                        SqlTransaction transaction1;
                        conn1.Open();
                        transaction1 = conn1.BeginTransaction("UpdatePur");

                        command1.Connection = conn1;
                        command1.Transaction = transaction1;
                        try
                        {
                            command1.CommandText = string.Format(@"
update purc_purchase_master
set pur_head_status='OP',pur_approver='105020',pur_approve_date=getdate()
where pur_head_status in ('NA','O1') and
pur_nbr in
(
{0}
)
", "");
                            //command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SearchTB.Text;
                            command1.ExecuteNonQuery();
                            command1.Parameters.Clear();
                            command1.CommandText = string.Format(@"
update purc_purchase_detail
set pur_detail_status='OP'
where pur_detail_status in ('NA','O1') and
pur_nbr
in
(
{0}
)
");
                            //command1.Parameters.Add("@Date", SqlDbType.NVarChar).Value = SearchTB.Text;
                            command1.ExecuteNonQuery();

                            transaction1.Commit();
                            //Label1.Text = "刪除完畢，請再次夾檔";
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Delete Error :", "MIS007.aspx");
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Delete Error Error:", "MIS007.aspx");
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
                    //int.TryParse(strid, out iid);
                    //if (iid > 0)
                    //{
                    //    int.TryParse(strid, out iid);
                    //    using (var transaction = conn.Database.BeginTransaction())
                    //    {
                    //        try
                    //        {
                    //            int.TryParse(strid, out iid);
                    //            var 快遞單結案 = conn.快遞單.Where(o => o.id == iid).FirstOrDefault();
                    //            快遞單結案.檢貨狀態 = true;
                    //            快遞單結案.檢貨時間 = DateTime.Now;
                    //            conn.SaveChanges();
                    //            transaction.Commit();
                    //            //ACRGV.DataBind();
                    //        }
                    //        catch (Exception ex1)
                    //        {
                    //            try
                    //            {
                    //                Log.ErrorLog(ex1, "檢貨 Error :", "MGT008.aspx");
                    //            }
                    //            catch (Exception ex2)
                    //            {
                    //                Log.ErrorLog(ex2, "檢貨 Error Error:", "MGT008.aspx");
                    //            }
                    //            finally
                    //            {
                    //                transaction.Rollback();
                    //            }
                    //        }
                    //    }
                    //}
                }
                else if (e.CommandName == "結案")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = 確認GV.DataKeys[row.RowIndex].Values[0].ToString();
                    using (var transaction = conn.Database.BeginTransaction())
                    {
                        try
                        {
                            int.TryParse(strid, out iid);
                            var 快遞單結案 = conn.快遞單.Where(o => o.id == iid).FirstOrDefault();
                            快遞單結案.結案狀態 = true;
                            快遞單結案.結案時間 = DateTime.Now;
                            conn.SaveChanges();
                            transaction.Commit();
                            //ACRGV.DataBind();
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "結案 Error :", "MGT008.aspx");
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "結案 Error Error:", "MGT008.aspx");
                            }
                            finally
                            {
                                transaction.Rollback();
                            }
                        }
                    }
                }
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            Session["Today"] = StartDay.Text.Trim();
            Session["Nbr"] = (!string.IsNullOrEmpty(提單TB.Text.Trim()))?提單TB.Text.Trim():"%";
            Session["快遞商"] = (快遞廠商DDL.SelectedValue != "") ? 快遞廠商DDL.SelectedValue : "%";
            確認GV.DataBind();
        }

        protected void ClearBT_Click(object sender, EventArgs e)
        {
            Session["Today"] = DateTime.Now.ToString("yyyy-MM-dd");
            Session["使用日期"] = 0;
            Session["Nbr"] = "%";
            Session["快遞商"] = "%";
        }
    }
}