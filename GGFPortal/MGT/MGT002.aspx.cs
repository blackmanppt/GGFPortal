using System;
using System.Data;
using System.Text;
using System.Web.UI;
using GGFPortal.DataSetSource;
using System.Linq;
using System.Web.UI.WebControls;
using System.IO;

namespace GGFPortal.MGT
{

    public partial class MGT002 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        protected void Page_Load(object sender, EventArgs e)
        {

            快遞時間TB.Attributes["readonly"] = "readonly";
            //快遞日期TB.Attributes["readonly"] = "readonly";
            if (Session["提單日期"] != null)
                Session["提單日期"] = (Session["提單日期"].ToString() == "%") ? "2000/1/1" : Session["提單日期"];
            if (Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(idHF.Value))
                    if (F_確認檢貨(int.Parse(idHF.Value)))
                        MsgLB.Text = "快遞單櫃台已檢貨";
                //if (string.IsNullOrEmpty(idHF.Value) )
                //{ 
                //    Show(false);
                //    ClearPanel();
                //}
                //else //if(idHF.Value!="")
                //{ 
                //    if (F_確認檢貨(int.Parse(idHF.Value)))
                //        MsgLB.Text = "快遞單櫃台已檢貨";
                //}
            }
            else
            {
                if(Session["id"]!=null)
                {
                    string sid = Session["id"].ToString();
                    int iid = 0;
                    int.TryParse(sid, out iid);
                    if (F_確認檢貨(iid))
                        MsgLB.Text = "快遞單櫃台已檢貨";
                    HeadDB(iid);
                }
            }

        }

        private void HeadDB(int iid)
        {
            var 快遞單資料 = db.快遞單.Where(p => p.id == iid&&p.IsDeleted==false);
            string s快遞單檔案 = "";
            if (快遞單資料.Count() > 0)
            {
                foreach (var item in 快遞單資料)
                {
                    快遞日期LB.Text = item.提單日期.ToString("yyyy-MM-dd");
                    快遞廠商LB.Text = item.快遞廠商;
                    提單號碼LB.Text = item.提單號碼;
                    送件地點LB.Text = item.送件地點+"-"+item.地點備註;
                    部門LB.Text = (item.送件部門!=null)? item.送件部門 + ":":"";
                    if (item.快遞單檔案 != null)
                    {
                        s快遞單檔案 = Path.GetExtension(item.快遞單檔案).ToUpper();
                        if (s快遞單檔案 == ".JPG" || s快遞單檔案 == ".JPGE" || s快遞單檔案 == ".GIF" || s快遞單檔案 == ".PNG")
                        {
                            快遞單檔案Literal.Text = @"<img alt='提單' src='MGTFile\" + item.快遞單檔案 + @"' />";
                            //Literal1.Text = @"<button class='print-link' onclick='jQuery('#picture').print()'>列印圖片</button>";
                           // Button1.Visible = true;
                            Session["pic"] = @"MGTFile\" + item.快遞單檔案;
                        }
                        else
                        {
                            //Button1.Attributes["Style"] = "display:none";
                            //Button1.Visible = false; 
                            快遞單檔案Literal.Text = @"<a class='btn btn-link' href='MGTFile\" + item.快遞單檔案 + @"' >下載</a>";
                        }
                    }
                    else
                        快遞單檔案Literal.Text = "";
                    idHF.Value = iid.ToString();
                }
                Session["id"] = iid.ToString();
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
            MsgLB.Text = "";
            if (!string.IsNullOrEmpty(快遞時間TB.Text.Trim()))
            {
                DateTime 快遞時間 = Convert.ToDateTime(快遞時間TB.Text.Trim());
                string 快遞單號 = (string.IsNullOrEmpty(快遞單號TB.Text.Trim())) ? "" : 快遞單號TB.Text.Trim();
                //var c = db.快遞單.Where(p => p.提單日期.Month == 快遞時間.Month && p.提單日期.Year == 快遞時間.Year && p.提單日期.Day == 快遞時間.Day);
                var c = db.快遞單.Where(p => p.提單日期== 快遞時間 && p.IsDeleted==false);
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
                            if (F_確認檢貨(item.id))
                                MsgLB.Text = "快遞單櫃台已檢貨";
                            HeadDB(item.id);
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
            int iid = 0;
            int.TryParse(idHF.Value, out iid);
            if (F_確認結案(iid))
            {
                結案顯示();
            }
            else
            { 
                新增BT.Visible = true;
                更新BT.Visible = false;
                EditListPanel_ModalPopupExtender.Show();
            }
        }

        protected void ClearBT_Click1(object sender, EventArgs e)
        {
            快遞時間TB.Text = "";
            快遞單號TB.Text = "";
            MsgLB.Text = "";
        }

        protected void ACRGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (var conn = new GGFEntitiesMGT())
            {
                int iuid = 0,iid=0;
                int.TryParse(idHF.Value, out iid);
                if (e.CommandName == "編輯")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    int.TryParse(strid, out iuid);
                    if (!F_確認結案(iid))
                    { 
                        if (iuid > 0)
                        {
                        
                            var dset = db.快遞單明細.Where(p => p.uid == iuid);
                            foreach (var item in dset)
                            {
                                寄件人工號TB.Text = item.寄件人工號;
                                分機TB.Text = item.寄件人分機;
                                客戶名稱TB.Text = item.客戶名稱;
                                收件人TB.Text = item.收件人;
                                重量TB.Text = item.重量.ToString();
                                責任歸屬TB.Text = item.責任歸屬;
                                到付CB.Checked = (item.付款方式.Length > 0) ? true : false;
                                備註TB.Text = item.備註二;
                                明細TB.Text = item.明細;
                                uidHF.Value = item.uid.ToString();
                                原因歸屬DDL.SelectedValue = item.原因歸屬 ?? "";

                            }
                            新增BT.Visible = false;
                            更新BT.Visible = true;
                            EditListPanel_ModalPopupExtender.Show();
                        }
                    }
                    else
                        結案顯示();

                }
                else if (e.CommandName == "刪除")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string strid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    using (var transaction = conn.Database.BeginTransaction())
                    {
                        try
                        {

                            int.TryParse(strid, out iuid);
                            var 刪除快遞單 = conn.快遞單明細.Where(o => o.uid == iuid).FirstOrDefault();
                            刪除快遞單.IsDeleted = true;
                            刪除快遞單.修改日期 = DateTime.Now;
                            conn.SaveChanges();
                            transaction.Commit();
                            ACRGV.DataBind();
                            ClearEdit();
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
                else if (e.CommandName == "列印")
                {
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    string struid = ACRGV.DataKeys[row.RowIndex].Values[0].ToString();
                    Session.RemoveAll();
                    Session["uid"] = struid;
                    Session["id"] = ACRGV.Rows[row.RowIndex].Cells[1].Text;
                    //Session["提單日期"] = ACRGV.Rows[row.RowIndex].Cells[3].Text;
                    //Response.Redirect("MGT003.aspx");
                    Response.Redirect("MGT005.aspx");

                }
            }
        }
        
        protected void 取消BT_Click(object sender, EventArgs e)
        {
            ClearEdit();
            EditListPanel_ModalPopupExtender.Hide();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MsgLB.Text = "";
            int iid = 0;
            if (e.CommandName=="Select")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string strid = GridView1.DataKeys[row.RowIndex].Values[0].ToString();
                int.TryParse(strid, out iid);
                if (iid > 0)
                {
                    if (F_確認檢貨(iid))
                        MsgLB.Text = "快遞單櫃台已檢貨";
                    HeadDB(iid);

                }
                DbInit();
            }
        }
        protected void 新增BT_Click(object sender, EventArgs e)
        {
            新增修改();
        }
        protected void 更新BT_Click(object sender, EventArgs e)
        {
            新增修改();
        }

        private void 結案顯示()
        {
            MsgLB.Text = "快遞單已結案或超過收件時間，請明日寄送";
        }

        private void 新增修改()
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
                        
                        var 工號資料 = db.bas_employee.Where(p => p.site == "GGF" && p.employee_no == 寄件人工號TB.Text).FirstOrDefault();
                        if (iid == 0)
                            sbError.Append("請重選資料");
                        if (工號資料 == null)
                        {
                            sbErrorstring(sbError, "無工號資料");
                        }
                        else
                        {
                            if (工號資料.employee_status == "IA")
                                sbErrorstring(sbError, "工號已停用");
                        }
                        
                        //if (d重量 == 0)
                        //    sbErrorstring(sbError, "請輸入重量");
                        if (string.IsNullOrEmpty(收件人TB.Text.Trim()))
                            sbErrorstring(sbError, "請輸入收件人");
                        if (string.IsNullOrEmpty(客戶名稱TB.Text.Trim()))
                            sbErrorstring(sbError, "請輸入客戶名稱");
                        if (string.IsNullOrEmpty(責任歸屬TB.Text))
                            sbErrorstring(sbError, "請輸入責任歸屬：振大付費塡GG，廠商付費塡廠商名稱");
                        if (string.IsNullOrEmpty(明細TB.Text))
                            sbErrorstring(sbError, "請輸明細");
                        if (string.IsNullOrEmpty(原因歸屬DDL.SelectedValue))
                            sbErrorstring(sbError, "請輸原因歸屬");
                        if(F_確認結案(iid))
                            sbErrorstring(sbError, "快遞單已結案，請明天再送");
                        if (sbError.Length > 0)
                        {
                            EditMessageLB.Text =  sbError.ToString();
                            EditListPanel_ModalPopupExtender.Show();
                        }
                        else
                        {
                            if (iuid == 0)
                            {
                                var 新增快遞單明細 = new 快遞單明細();
                                新增快遞單明細.id = int.Parse(idHF.Value);
                                新增快遞單明細.付款方式 = (到付CB.Checked) ? "到付" : "";
                                新增快遞單明細.寄件人工號 = 寄件人工號TB.Text.Trim();
                                新增快遞單明細.寄件人 = 工號資料.employee_name;
                                新增快遞單明細.寄件人分機 = 分機TB.Text.Trim();
                                新增快遞單明細.客戶名稱 = 客戶名稱TB.Text.Trim();
                                新增快遞單明細.寄件人部門 = 工號資料.dept_no;
                                新增快遞單明細.收件人 = 收件人TB.Text.Trim();
                                新增快遞單明細.IsDeleted = false;
                                新增快遞單明細.重量 = d重量;
                                新增快遞單明細.責任歸屬 = 責任歸屬TB.Text.Trim();
                                新增快遞單明細.備註二 = 備註TB.Text.Trim();
                                新增快遞單明細.明細 = 明細TB.Text.Trim();
                                新增快遞單明細.email = 工號資料.email_address;
                                新增快遞單明細.原因歸屬 = 原因歸屬DDL.SelectedValue;
                                conn.快遞單明細.Add(新增快遞單明細);
                            }
                            else
                            {
                                var 新增快遞單明細 = conn.快遞單明細.Find(iuid);
                                //新增快遞單明細.id = int.Parse(idHF.Value);
                                新增快遞單明細.付款方式 = (到付CB.Checked) ? "到付" : "";
                                新增快遞單明細.寄件人工號 = 寄件人工號TB.Text.Trim();
                                新增快遞單明細.寄件人 = 工號資料.employee_name;
                                新增快遞單明細.寄件人分機 = 分機TB.Text.Trim();
                                新增快遞單明細.寄件人部門 = 工號資料.dept_no;
                                新增快遞單明細.收件人 = 收件人TB.Text.Trim();
                                新增快遞單明細.重量 = d重量;
                                新增快遞單明細.責任歸屬 = 責任歸屬TB.Text.Trim();
                                新增快遞單明細.備註二 = 備註TB.Text.Trim();
                                新增快遞單明細.明細 = 明細TB.Text.Trim();
                                新增快遞單明細.修改日期 = DateTime.Now;
                                新增快遞單明細.email = 工號資料.email_address;
                                新增快遞單明細.原因歸屬 = 原因歸屬DDL.SelectedValue;
                            }
                            conn.SaveChanges();
                            transaction.Commit();
                            DbInit();
                            ClearEdit();
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
        }

        private static void sbErrorstring(StringBuilder sbError,string strerror)
        {
            if (sbError.Length>0)
                sbError.Append("<br/>");
            sbError.Append(strerror);
        }

        public void ClearEdit()
        {
            寄件人工號TB.Text = "";
            分機TB.Text = "";
            客戶名稱TB.Text = "";
            收件人TB.Text = "";
            重量TB.Text = "";
            責任歸屬TB.Text = "";
            到付CB.Checked = false;
            備註TB.Text = "";
            明細TB.Text = "";
            原因歸屬DDL.SelectedValue = "";
            uidHF.Value = null;
        }

        public Boolean F_確認結案(int iid)
        {
            bool b是否結案 = false;
            if (iid > 0)
            {
                var 快遞單 = db.快遞單.Where(p => p.id == iid).FirstOrDefault();
                if (快遞單.結案狀態 != null)
                {
                    if(快遞單.結案狀態 == true)
                        b是否結案 = true;
                }
            }
            if(DateTime.Now.Hour>19)
                b是否結案 = true;
            return b是否結案;
        }
        public Boolean F_確認檢貨(int iid)
        {
            bool b是否檢貨 = false;
            if (iid>0)
            {
                var 快遞單 = db.快遞單.Where(p => p.id == iid).FirstOrDefault();
                if (快遞單.檢貨狀態!=null)
                {
                    if(快遞單.檢貨狀態 == true)
                        b是否檢貨 = true;
                }
            }
            return b是否檢貨;
        }
    }
}