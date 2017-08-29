using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
using GGFPortal.DataSetSource;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;

namespace GGFPortal.MGT
{

    public partial class MGT001 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestGroupConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            快遞時間TB.Attributes["readonly"] = "readonly";
            快遞日期TB.Attributes["readonly"] = "readonly";
            if (Page.IsPostBack)
            {
                if (idHF.Value == null)
                { 
                    Show(false);
                    ClearPanel();
                }
            }

        }

        private void ClearPanel()
        {
            快遞日期TB.Text = "";
            提單號碼TB.Text = "";
            送件地點TB.Text = "";
        }

        protected string convertdate(DateTime dt)
        {
            return dt.ToString("yyyyMM");
        }
        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //YearDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(快遞時間TB.Text.Trim()))
            {
                DateTime 快遞時間 = Convert.ToDateTime(快遞時間TB.Text.Trim());
                string 快遞單號 = (string.IsNullOrEmpty(快遞單號TB.Text.Trim())) ? "%" : 快遞單號TB.Text.Trim();
                var c = db.快遞單.Where(p => p.修改日期 == 快遞時間 && p.提單號碼.Contains(快遞單號));
                if (c.Count()>0)
                {
                    Show(false);
                    foreach (var item in c)
                    {
                        快遞日期TB.Text = item.提單日期.ToString("yyyy-MM-dd");
                        快遞廠商DDL.SelectedValue = item.快遞廠商;
                        提單號碼TB.Text = item.提單號碼;
                        送件地點TB.Text = item.送件地點;
                        idHF.Value = item.id.ToString();
                    }
                    Session["提單日期"] = (string.IsNullOrEmpty(快遞時間TB.Text.Trim())) ? "%" : 快遞時間TB.Text.Trim();
                    Session["提單號碼"] = (string.IsNullOrEmpty(快遞單號TB.Text.Trim())) ? "%": 快遞單號TB.Text.Trim();
                }
                else
                {
                    快遞日期TB.Text = 快遞時間TB.Text;
                    提單號碼TB.Text = 快遞單號TB.Text;
                    Session["提單日期"] = "%";
                    Session["提單號碼"] = "%";
                    Show(true);

                }

            }

            //DbInit();
        }
        protected void DbInit()
        {
            ACRGV.DataBind();
        }

        private StringBuilder selectsql()
        {
            StringBuilder strsql = new StringBuilder(" select * from [ExportTaxRebate] where Flag =1 and RebateDate = @RebateDate");
            return strsql;
        }


        private int GetTaxIndex()
        {
            Int32 TAXId = 0;
            //string sql =
            //    @"INSERT INTO [dbo].[ExportTaxRebate]
            //               ([RebateDate])
            //         VALUES
            //               (@RebateDate); 
            //        SELECT CAST(scope_identity() AS int)";
            //using (SqlConnection conn = new SqlConnection(strConnectString))
            //{
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.Parameters.Add("@RebateDate", SqlDbType.NVarChar);
            //    cmd.Parameters["@RebateDate"].Value = YearDDL.SelectedValue;
            //    try
            //    {
            //        conn.Open();
            //        TAXId = (Int32)cmd.ExecuteScalar();
            //    }
            //    catch (Exception ex)
            //    {
            //        Log.ErrorLog(ex, "Get ExportTaxRebate uid Error:", "TAX008.aspx");
            //    }
            //}
            return (int)TAXId;
        }

        protected void DeleteBT_Click(object sender, EventArgs e)
        {
            var x = db.快遞單.Find(idHF.Value);
            x.IsDeleted = false;
            db.SaveChanges();
            idHF.Value = null;
            Show(false);

        }

        private void Show(bool bshow)
        {
            if (bshow)
            {
                ADDPanel.Visible = true;
                GridPanel.Visible = true;
                SaveBT.Visible = true;
                DeleteBT.Visible = true;
            }
            else
            {
                ADDPanel.Visible = false;
                GridPanel.Visible = true;
                SaveBT.Visible = false;
                DeleteBT.Visible = false;
            }
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {
            String savePath = Server.MapPath(@"~\MGT\MGT001\");
            String fileName = FileUpload1.FileName.Trim();
            if (FileUpload1.HasFile)
            {
                savePath = savePath + fileName;
                FileUpload1.SaveAs(savePath);
            }
            else
                fileName = "";
            

            using (var conn = new GGFEntitiesMGT())
            {
                using (var transaction = conn.Database.BeginTransaction())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(idHF.Value))
                        {
                            var 新增快遞單 = new 快遞單();
                            新增快遞單.提單日期 = Convert.ToDateTime(快遞日期TB.Text);
                            新增快遞單.快遞廠商 = 快遞廠商DDL.SelectedValue;
                            新增快遞單.提單號碼 = 提單號碼TB.Text;
                            新增快遞單.送件地點 = 送件地點TB.Text;
                            if (fileName.Length > 0)
                                新增快遞單.快遞單檔案 = fileName;
                            conn.快遞單.Add(新增快遞單);
                        }
                        else
                        {
                            var 修改快遞單 = conn.快遞單.Find(idHF.Value);
                            修改快遞單.提單日期 = Convert.ToDateTime(快遞日期TB.Text);
                            修改快遞單.快遞廠商 = 快遞廠商DDL.SelectedValue;
                            修改快遞單.提單號碼 = 提單號碼TB.Text;
                            修改快遞單.送件地點 = 送件地點TB.Text;
                            if (fileName.Length > 0)
                                修改快遞單.快遞單檔案 = fileName;
                        }
                        conn.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex1)
                    {

                        try
                        {
                            Log.ErrorLog(ex1, "Delete Error :", "MGT001.aspx");
                        }
                        catch (Exception ex2)
                        {
                            Log.ErrorLog(ex2, "Delete Error Error:", "MGT001.aspx");
                        }
                        finally
                        {
                            transaction.Rollback();
                            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('刪除失敗請連絡MIS');</script>");
                        }
                    }
                }
            }
        }

        protected void ClearBT_Click1(object sender, EventArgs e)
        {
            快遞時間TB.Text = "";
            快遞單號TB.Text = "";
        }

        protected void ACRGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (var conn = new GGFEntitiesMGT())
            {
                int iid = 0;
                if (e.CommandName == "編輯")
                {
                    
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    int.TryParse(strid, out iid);
                    if (iid>0)
                    {
                        var dset = db.快遞單.Where(p=>p.id==iid);
                        foreach (var item in dset)
                        {
                            快遞日期TB.Text = item.提單日期.ToString("yyyy-MM-dd");
                            快遞廠商DDL.SelectedValue = item.快遞廠商;
                            提單號碼TB.Text = item.提單號碼;
                            送件地點TB.Text = item.送件地點;
                            idHF.Value = item.id.ToString();
                        }
                        Session["提單日期"] = (string.IsNullOrEmpty(快遞時間TB.Text.Trim())) ? "%" : 快遞時間TB.Text.Trim();
                        Session["提單號碼"] = (string.IsNullOrEmpty(快遞單號TB.Text.Trim())) ? "%" : 快遞單號TB.Text.Trim();

                    }
                    if (idHF.Value!=null)
                    {
                        DbInit();
                    }

                }
                else if (e.CommandName == "刪除")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    using (var transaction = conn.Database.BeginTransaction())
                    {
                        try
                        {

                            int.TryParse(strid, out iid);
                            var 刪除快遞單 = conn.快遞單.Where(o => o.id == iid).FirstOrDefault();
                            刪除快遞單.IsDeleted = true;
                            conn.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Delete Error :", "MGT001.aspx");
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Delete Error Error:", "MGT001.aspx");
                            }
                            finally
                            {
                                transaction.Rollback();
                                //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('刪除失敗請連絡MIS');</script>");
                            }
                        }
                    }
                }
                else if (e.CommandName == "新增明細")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    //Session["uid"] = GridView1.Rows[row.RowIndex].Cells[1].Text;
                    Session["id"] = strid;
                    Response.Redirect("MGT002.aspx");
                }
            }
        }
    }
}