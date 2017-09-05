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
using System.IO;


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
        protected void ClearBT_Click(object sender, EventArgs e)
        {
            //YearDDL.SelectedValue = "";
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(快遞時間TB.Text.Trim()))
            {
                DateTime 快遞時間 = Convert.ToDateTime(快遞時間TB.Text.Trim());
                string 快遞單號 = (string.IsNullOrEmpty(快遞單號TB.Text.Trim())) ? "" : 快遞單號TB.Text.Trim();
                var c = db.快遞單.Where(p => p.提單日期 == 快遞時間);
                if (快遞單號!="")
                {
                    c = c.Where(p => p.提單號碼.Contains(快遞單號));
                }
                if (c.Count()>0)
                {
                    if (c.Count()>1)
                    {
                        Show(false);
                    }
                    else
                    {
                        foreach (var item in c)
                        {
                            快遞日期TB.Text = item.提單日期.ToString("yyyy-MM-dd");
                            快遞廠商DDL.SelectedValue = item.快遞廠商;
                            提單號碼TB.Text = item.提單號碼;
                            送件地點TB.Text = item.送件地點;
                            idHF.Value = item.id.ToString();
                        }
                        Show(true);
                    }
                    Session["提單日期"] = (string.IsNullOrEmpty(快遞時間TB.Text.Trim())) ? "%" : 快遞時間TB.Text.Trim();
                    Session["提單號碼"] = (string.IsNullOrEmpty(快遞單號TB.Text.Trim())) ? "%" : 快遞單號TB.Text.Trim();
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
            int iid = 0;
            int.TryParse(idHF.Value, out iid);

            var x = db.快遞單.Find(iid);
            if (x !=null)
            {
                try
                {
                    x.IsDeleted = true;
                    x.修改日期 = DateTime.Now;
                    db.SaveChanges();
                    idHF.Value = null;
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            else
            {
                MessageLB.Text = "沒有快遞單資料";
                AlertPanel_ModalPopupExtender.Show();
            }
            Show(false);
        }

        private void Show(bool bshow)
        {
            if (bshow)
            {
                ADDPanel.Visible = true;
                SaveBT.Visible = true;
                DeleteBT.Visible = true;
            }
            else
            {
                ADDPanel.Visible = false;
                SaveBT.Visible = false;
                DeleteBT.Visible = false;
            }
            DbInit();
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {
            String savePath = Server.MapPath(@"~\MGT\MGTFile\");
            String fileName = FileUpload1.FileName.Trim();

            if (FileUpload1.HasFile)
            {
                string 副檔名 = System.IO.Path.GetExtension(fileName);
                if (File.Exists(savePath + fileName))
                {
                    fileName = fileName.Substring(0,fileName.Length-副檔名.Length) + DateTime.Now.ToString("yyyyMMddhhmmssfff") + 副檔名;
                }
                savePath = savePath + fileName;
                FileUpload1.SaveAs(savePath);
            }
            else
                fileName = "";
            int iid = 0;
            using (var conn = new GGFEntitiesMGT())
            {
                using (var transaction = conn.Database.BeginTransaction())
                {
                    try
                    {
                        int.TryParse(idHF.Value.ToString(), out iid);

                        if (iid==0)
                        {
                            var 新增快遞單 = new 快遞單();
                            新增快遞單.提單日期 = Convert.ToDateTime(快遞日期TB.Text);
                            新增快遞單.快遞廠商 = 快遞廠商DDL.SelectedValue;
                            新增快遞單.提單號碼 = 提單號碼TB.Text;
                            新增快遞單.IsDeleted = false;
                            新增快遞單.送件地點 = 送件地點TB.Text;
                            if (fileName.Length > 0)
                                新增快遞單.快遞單檔案 = fileName;
                            conn.快遞單.Add(新增快遞單);
                        }
                        else
                        {
                            var 修改快遞單 = conn.快遞單.Find(iid);
                            修改快遞單.提單日期 = Convert.ToDateTime(快遞日期TB.Text);
                            修改快遞單.快遞廠商 = 快遞廠商DDL.SelectedValue;
                            修改快遞單.提單號碼 = 提單號碼TB.Text;
                            修改快遞單.送件地點 = 送件地點TB.Text;
                            if (fileName.Length > 0)
                                修改快遞單.快遞單檔案 = fileName;
                            修改快遞單.修改日期 = DateTime.Now;
                        }
                        conn.SaveChanges();
                        transaction.Commit();
                        DbInit();
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
                    Show(true);
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
                            刪除快遞單.修改日期 = DateTime.Now;
                            conn.SaveChanges();
                            transaction.Commit();
                            ACRGV.DataBind();
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
                else if (e.CommandName == "列印")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    Session.RemoveAll();
                    Session["id"] = strid;
                    Session["提單號碼"] = ACRGV.Rows[row.RowIndex].Cells[2].Text;
                    Session["提單日期"] = ACRGV.Rows[row.RowIndex].Cells[3].Text;
                    Response.Redirect("MGT002.aspx");
                    
                }
            }
        }
    }
}