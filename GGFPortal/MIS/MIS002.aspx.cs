using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GGFPortal.MIS
{
    public partial class MIS002 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StartDayTB.Attributes["readonly"] = "readonly";
            if (IsPostBack)
            {

            }
            else
            {
                Session["StartDay"] = DateTime.Now.AddDays(-1);
                Session["EndDay"] = DateTime.Now.AddDays(6);
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (StartDayTB.Text.Length > 0 )
            {
                DateTime parsed;
                if (DateTime.TryParseExact(StartDayTB.Text, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
                {
                    Session["StartDay"] = parsed;
                    Session["EndDay"] = parsed.AddDays(6);
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('日期切換失敗\\請重新選擇');</script>");


            }
            else
            {
                
                //ReportViewer1.Visible = false;
            }
        }
    }
}