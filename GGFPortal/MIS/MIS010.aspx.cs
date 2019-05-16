using GGFPortal.DataSetSource;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS
{

    public partial class MIS010 : System.Web.UI.Page
    {
        static string strConnectString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GGFConnectionString"].ToString();
        GGFEntitiesMGT db = new GGFEntitiesMGT();
        ReferenceCode.SysLog Log = new ReferenceCode.SysLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Today"]==null)
            {
                Session["Today"] = DateTime.Now.ToString("yyyy-MM-dd");
            }
            //StartDay.Attributes["readonly"] = "readonly";
            //EndDay.Attributes["readonly"] = "readonly";
        }

        protected void 確認GV_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            using (var conn = new GGFEntitiesMGT())
            {
                
                if (e.CommandName == "檢貨")
                {
                    //GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    //string strid = 確認GV.DataKeys[row.RowIndex].Values[0].ToString();
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
                    //            確認GV.DataBind();
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
                    //GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    //string strid = 確認GV.DataKeys[row.RowIndex].Values[0].ToString();
                    //using (var transaction = conn.Database.BeginTransaction())
                    //{
                    //    try
                    //    {
                    //        int.TryParse(strid, out iid);
                    //        var 快遞單結案 = conn.快遞單.Where(o => o.id == iid).FirstOrDefault();
                    //        快遞單結案.結案狀態 = (快遞單結案.結案狀態 == true)?false:true;
                    //        快遞單結案.結案時間 = DateTime.Now;
                    //        conn.SaveChanges();
                    //        transaction.Commit();
                    //        確認GV.DataBind();
                    //        //ACRGV.DataBind();
                    //    }
                    //    catch (Exception ex1)
                    //    {
                    //        try
                    //        {
                    //            Log.ErrorLog(ex1, "結案 Error :", "MGT008.aspx");
                    //        }
                    //        catch (Exception ex2)
                    //        {
                    //            Log.ErrorLog(ex2, "結案 Error Error:", "MGT008.aspx");
                    //        }
                    //        finally
                    //        {
                    //            transaction.Rollback();
                    //        }
                    //    }
                    //}
                }
            }
        }

        protected void SearchBT_Click(object sender, EventArgs e)
        {
            //Session["Today"] = StartDay.Text.Trim();
            //Session["Nbr"] = (!string.IsNullOrEmpty(提單TB.Text.Trim()))?提單TB.Text.Trim():"%";
            //Session["快遞商"] = (快遞廠商DDL.SelectedValue != "") ? 快遞廠商DDL.SelectedValue : "%";
            //確認GV.DataBind();
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