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

    public partial class MGT002 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["TestGroupConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        protected void Page_Load(object sender, EventArgs e)
        {
            快遞時間TB.Attributes["readonly"] = "readonly";
            //快遞日期TB.Attributes["readonly"] = "readonly";
            if (Page.IsPostBack)
            {
                if (idHF.Value == null)
                { 
                    Show(false);
                    ClearPanel();
                }
            }
            else
            {
                if(Session["id"]!=null)
                {
                    string sid = Session["id"].ToString();
                    int iid = 0;
                    int.TryParse(sid, out iid);
                    HeadDB(iid);
                }
            }
        }

        private void HeadDB(int iid)
        {
            var 快遞單資料 = db.快遞單.Where(p => p.id == iid);
            string s快遞單檔案 = "";
            if (快遞單資料.Count() > 0)
            {
                foreach (var item in 快遞單資料)
                {
                    快遞日期LB.Text = item.提單日期.ToString("yyyy-MM-dd");
                    快遞廠商LB.Text = item.快遞廠商;
                    提單號碼LB.Text = item.提單號碼;
                    送件地點LB.Text = item.送件地點;
                    if (item.快遞單檔案 != null)
                    {
                        s快遞單檔案 = Path.GetExtension(item.快遞單檔案).ToUpper();
                        if (s快遞單檔案 == ".JPG" || s快遞單檔案 == ".JPGE" || s快遞單檔案 == ".GIF" || s快遞單檔案 == ".PNG")
                            快遞單檔案Literal.Text = @"<img alt='提單' src='MGTFile\" + item.快遞單檔案 + @"' />";
                        else
                            快遞單檔案Literal.Text = @"<a class='btn btn-link' href='MGTFile\" + item.快遞單檔案 + @"' >下載</a>";
                    }
                    idHF.Value = iid.ToString();
                }
                Show(true);
            }
        }

        private void ClearPanel()
        {

            快遞時間TB.Text = "";
            快遞單號TB.Text = "";
            //送件地點TB.Text = "";
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
                string 快遞單號 = (string.IsNullOrEmpty(快遞單號TB.Text.Trim())) ? "" : 快遞單號TB.Text.Trim();
                //var c = db.快遞單.Where(p => p.提單日期.Month == 快遞時間.Month && p.提單日期.Year == 快遞時間.Year && p.提單日期.Day == 快遞時間.Day);
                var c = db.快遞單.Where(p => p.提單日期== 快遞時間);
                if (快遞單號.Length>0)
                {
                    c = c.Where(p => p.提單號碼.Contains(快遞單號));
                }
                if (c.Count()>1)
                {
                    Session["提單日期"] = 快遞時間TB.Text.Trim();
                    SelectPanel_ModalPopupExtender.Show();
                }
                else 
                {
                    if (c.Count() > 0)
                    {
                        foreach (var item in c)
                        {

                        }
                        Show(true);
                    }
                    else
                    {
                        MessageLB.Text = "日期沒有快遞單，請櫃台新增快遞單資料";
                        AlertPanel_ModalPopupExtender.Show();
                    }
                }

            }
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
        private void Show(bool bshow)
        {
            if (bshow)
            {
                ADDPanel.Visible = true;
            }
            else
            {
                ADDPanel.Visible = false;
            }
        }

        protected void SaveBT_Click(object sender, EventArgs e)
        {
            新增BT.Visible = true;
            更新BT.Visible = false;
            EditListPanel_ModalPopupExtender.Show();
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

                    //Show(true);
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    int.TryParse(strid, out iid);
                    if (iid>0)
                    {
                        var dset = db.快遞單明細.Where(p => p.uid == iid);
                        foreach (var item in dset)
                        {
                            寄件人TB.Text = item.寄件人;
                            分機TB.Text = item.寄件人分機;
                            客戶名稱TB.Text = item.客戶名稱;
                            收件人TB.Text = item.收件人;
                            重量TB.Text = item.重量.ToString();
                            責任歸屬TB.Text = item.責任歸屬;
                            到付CB.Text = item.付款方式;
                            備註TB.Text = item.備註;
                            明細TB.Text = item.明細;
                            uidHF.Value = item.uid.ToString();

                        }
                    }
                    新增BT.Visible = false;
                    更新BT.Visible = true;
                    EditListPanel_ModalPopupExtender.Show();
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
                            var 刪除快遞單 = conn.快遞單明細.Where(o => o.uid == iid).FirstOrDefault();
                            刪除快遞單.IsDeleted = true;
                            conn.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex1)
                        {
                            try
                            {
                                Log.ErrorLog(ex1, "Delete Error :", "MGT002.aspx");
                            }
                            catch (Exception ex2)
                            {
                                Log.ErrorLog(ex2, "Delete Error Error:", "MGT002.aspx");
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
        protected void 取消BT_Click(object sender, EventArgs e)
        {
            EditListPanel_ModalPopupExtender.Show();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iid = 0;
            if (e.CommandName=="Select")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                int.TryParse(strid, out iid);
                if (iid > 0)
                {
                    HeadDB(iid);

                }
                if (uidHF.Value != null)
                {
                    DbInit();
                }
            }
        }
        protected void 新增BT_Click(object sender, EventArgs e)
        {
            string s結果;
            s結果= 新增修改();
            if (s結果.Length>0)
            {
                //MessageLB.Text = s結果;
                AlertPanel_ModalPopupExtender.Show();

            }
        }
        protected void 更新BT_Click(object sender, EventArgs e)
        {
            新增修改();
        }

        private string 新增修改()
        {
            StringBuilder sbError = new StringBuilder();
            using (var conn = new GGFEntitiesMGT())
            {
                using (var transaction = conn.Database.BeginTransaction())
                {
                    try
                    {
                        int iuid = 0, iid = 0;
                        decimal d重量 = 0;
                        decimal.TryParse(重量TB.Text, out d重量);
                        int.TryParse(uidHF.Value, out iuid);
                        int.TryParse(idHF.Value, out iid);
                        
                        var 工號資料 = db.bas_employee.Where(p => p.site == "GGF" && p.employee_no == 寄件人TB.Text).FirstOrDefault();
                        if (iid == 0)
                            sbError.Append("請重選資料<br/>");
                        if (工號資料 == null)
                        { 
                            sbError.Append("無工號資料<br/>");
                        }
                        else
                        {
                            if (工號資料.employee_status == "IA")
                                sbError.Append("工號已停用<br/>");
                        }
                        
                        if (d重量 == 0)
                            sbError.Append("請輸入重量<br/>");
                        if (string.IsNullOrEmpty(收件人TB.Text.Trim()))
                            sbError.Append("請輸入收件人<br/>");
                        if (string.IsNullOrEmpty(客戶名稱TB.Text.Trim()))
                            sbError.Append("請輸入客戶名稱<br/>");

                        if (sbError.Length > 0)
                        {
                            //EditMessageLB.Text =  sbError.ToString();
                            EditListPanel_ModalPopupExtender.Show();
                        }
                        else
                        {
                            if (iuid == 0)
                            {
                                var 新增快遞單明細 = new 快遞單明細();
                                新增快遞單明細.id = int.Parse(idHF.Value);
                                新增快遞單明細.付款方式 = (到付CB.Checked) ? "到付" : "";
                                新增快遞單明細.寄件人 = 寄件人TB.Text.Trim();
                                新增快遞單明細.寄件人分機 = 分機TB.Text.Trim();
                                新增快遞單明細.客戶名稱 = 客戶名稱TB.Text.Trim();
                                新增快遞單明細.寄件人部門 = 工號資料.dept_no;
                                新增快遞單明細.收件人 = 收件人TB.Text.Trim();
                                新增快遞單明細.重量 = d重量;
                                新增快遞單明細.責任歸屬 = 責任歸屬TB.Text.Trim();
                                新增快遞單明細.備註 = 備註TB.Text.Trim();
                                新增快遞單明細.明細 = 明細TB.Text.Trim();
                                conn.快遞單明細.Add(新增快遞單明細);
                            }
                            else
                            {
                                var 新增快遞單明細 = conn.快遞單明細.Find(iuid);
                                //新增快遞單明細.id = int.Parse(idHF.Value);
                                新增快遞單明細.付款方式 = (到付CB.Checked) ? "到付" : "";
                                新增快遞單明細.寄件人 = 寄件人TB.Text.Trim();
                                新增快遞單明細.寄件人分機 = 分機TB.Text.Trim();
                                新增快遞單明細.寄件人部門 = 工號資料.dept_no;
                                新增快遞單明細.收件人 = 收件人TB.Text.Trim();
                                新增快遞單明細.重量 = d重量;
                                新增快遞單明細.責任歸屬 = 責任歸屬TB.Text.Trim();
                                新增快遞單明細.備註 = 備註TB.Text.Trim();
                                新增快遞單明細.明細 = 明細TB.Text.Trim();

                            }
                            conn.SaveChanges();
                            transaction.Commit();
                            DbInit();
                        }
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
            return (sbError.Length > 0) ? sbError.ToString() : "";
           
        }
    }
}